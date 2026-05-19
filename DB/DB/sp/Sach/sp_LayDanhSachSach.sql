USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- SP   : sp_LayDanhSachSach
-- Mô tả: Lấy danh sách sách kèm tác giả,
--        nhà phát hành, số bản sao còn lại.
-- Tham số:
--   @keyword  VARCHAR(100)  -- tìm theo tên sách / tác giả (NULL = lấy tất cả)
--   @theLoai  NVARCHAR(100) -- lọc theo thể loại (NULL = tất cả)
-- =============================================
CREATE OR ALTER PROCEDURE sp_LayDanhSachSach
    @keyword  VARCHAR(100) = NULL,
    @theLoai  NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        s.IDSach,
        s.TenSach,
        s.TheLoai,
        s.ISBN,
        s.NamXuatBan,
        nph.TenNhaPhatHanh,
        -- Ghép tên tất cả tác giả thành 1 chuỗi
        STUFF((
            SELECT ', ' + tg.TenTG
            FROM CHI_TIET_TAC_GIA ctg
            INNER JOIN TAC_GIA tg ON tg.IDTacGia = ctg.IDTacGia
            WHERE ctg.IDSach = s.IDSach
            FOR XML PATH(''), TYPE
        ).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS TenTacGia,
        -- Tổng số bản sao
        COUNT(bs.IDBanSao) AS TongBanSao,
        -- Số bản sao còn sẵn (TrangThai = 1)
        SUM(CASE WHEN bs.TrangThai = 1 THEN 1 ELSE 0 END) AS SoBanSaoConLai,
        -- Có sẵn để mượn không
        CASE WHEN SUM(CASE WHEN bs.TrangThai = 1 THEN 1 ELSE 0 END) > 0
             THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS ConSach
    FROM SACH s
    LEFT JOIN NHA_PHAT_HANH nph ON nph.IDNhaPhatHanh = s.IDNhaPhatHanh
    LEFT JOIN BAN_SAO_SACH bs   ON bs.IDSach = s.IDSach
    WHERE
        (@keyword IS NULL OR s.TenSach LIKE '%' + @keyword + '%'
            OR EXISTS (
                SELECT 1 FROM CHI_TIET_TAC_GIA ctg2
                INNER JOIN TAC_GIA tg2 ON tg2.IDTacGia = ctg2.IDTacGia
                WHERE ctg2.IDSach = s.IDSach AND tg2.TenTG LIKE '%' + @keyword + '%'
            )
        )
        AND (@theLoai IS NULL OR s.TheLoai = @theLoai)
    GROUP BY
        s.IDSach, s.TenSach, s.TheLoai, s.ISBN, s.NamXuatBan,
        nph.TenNhaPhatHanh
    ORDER BY s.TenSach;
END
GO
