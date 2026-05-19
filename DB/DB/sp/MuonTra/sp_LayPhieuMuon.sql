USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- SP   : sp_LayPhieuMuon
-- Mô tả: Lấy danh sách phiếu mượn (Thủ Thư xem tất cả).
--        JOIN đủ thông tin độc giả + tên sách.
-- Tham số:
--   @idDocGia   INT  -- NULL = lấy tất cả, có giá trị = lọc theo đọc giả
--   @trangThai  INT  -- NULL = tất cả | 1=đang mượn | 2=đã trả | 3=quá hạn
-- =============================================
CREATE OR ALTER PROCEDURE sp_LayPhieuMuon
    @idDocGia  INT = NULL,
    @trangThai INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ctpm.IDChiTiet    AS LoanDetailId,
        pm.IDPhieuMuon    AS LoanId,
        tk.HoTen          AS ReaderName,
        dg.IDDocGia,
        s.TenSach         AS BookTitle,
        bs.IDBanSao,
        ctpm.NgayMuon     AS LoanDate,
        pm.HanTra         AS DueDate,
        ctpm.NgayTra      AS ReturnDate,
        ctpm.TienPhat     AS FineAmount,
        CASE
            WHEN ctpm.NgayTra IS NOT NULL       THEN N'Đã trả'
            WHEN GETDATE() > pm.HanTra          THEN N'Quá hạn'
            ELSE                                     N'Đang mượn'
        END AS Status
    FROM CHI_TIET_PHIEU_MUON ctpm
    INNER JOIN PHIEU_MUON   pm  ON pm.IDPhieuMuon  = ctpm.IDPhieuMuon
    INNER JOIN DOC_GIA      dg  ON dg.IDDocGia      = pm.IDDocGia
    INNER JOIN TAI_KHOAN    tk  ON tk.IDTaiKhoan    = dg.IDTaiKhoan
    INNER JOIN BAN_SAO_SACH bs  ON bs.IDBanSao      = ctpm.IDBanSao
    INNER JOIN SACH         s   ON s.IDSach         = bs.IDSach
    WHERE
        (@idDocGia IS NULL OR pm.IDDocGia = @idDocGia)
        AND (
            @trangThai IS NULL
            OR (@trangThai = 2 AND ctpm.NgayTra IS NOT NULL)
            OR (@trangThai = 3 AND ctpm.NgayTra IS NULL AND GETDATE() > pm.HanTra)
            OR (@trangThai = 1 AND ctpm.NgayTra IS NULL AND GETDATE() <= pm.HanTra)
        )
    ORDER BY ctpm.NgayMuon DESC;
END
GO
