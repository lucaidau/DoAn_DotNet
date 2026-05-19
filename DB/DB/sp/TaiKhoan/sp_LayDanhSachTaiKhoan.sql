USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- SP   : sp_LayDanhSachTaiKhoan
-- Mô tả: Lấy danh sách tài khoản Đọc Giả kèm
--        trạng thái, tiền đặt cọc. Hỗ trợ lọc.
-- Tham số:
--   @keyword    VARCHAR(100) -- tìm theo TenTK / HoTen / SDT / Email (NULL = tất cả)
--   @trangThai  BIT          -- 1=hoạt động, 0=bị khóa, NULL=tất cả
--   @gioiTinh   BIT          -- 1=Nam, 0=Nữ, NULL=tất cả
-- =============================================
CREATE OR ALTER PROCEDURE sp_LayDanhSachTaiKhoan
    @keyword   VARCHAR(100) = NULL,
    @trangThai BIT          = NULL,
    @gioiTinh  BIT          = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ROW_NUMBER() OVER (ORDER BY tk.IDTaiKhoan) AS STT,
        tk.IDTaiKhoan,
        dg.IDDocGia,
        tk.TenTK,
        tk.HoTen,
        tk.SDT,
        tk.Email,
        tk.GioiTinh,
        ISNULL(dg.TrangThai, 1)   AS TrangThai,
        ISNULL(dg.SoTienDatCoc,0) AS SoTienDatCoc
    FROM TAI_KHOAN tk
    INNER JOIN DOC_GIA dg ON dg.IDTaiKhoan = tk.IDTaiKhoan
    WHERE
        (@keyword IS NULL OR
            tk.TenTK LIKE '%' + @keyword + '%' OR
            tk.HoTen LIKE '%' + @keyword + '%' OR
            tk.SDT   LIKE '%' + @keyword + '%' OR
            tk.Email LIKE '%' + @keyword + '%'
        )
        AND (@trangThai IS NULL OR dg.TrangThai = @trangThai)
        AND (@gioiTinh  IS NULL OR tk.GioiTinh  = @gioiTinh)
    ORDER BY tk.IDTaiKhoan;
END
GO
