USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- SP   : sp_LaySachDocGia
-- Mô tả: Lấy sách đang mượn + thống kê của 1 đọc giả.
--        Dùng cho màn hình "Sách đang mượn" (Đọc Giả).
-- Tham số:
--   @idTaiKhoan INT  -- IDTaiKhoan từ UserSession
-- =============================================
CREATE OR ALTER PROCEDURE sp_LaySachDocGia
    @idTaiKhoan INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @idDocGia INT;
    SELECT @idDocGia = IDDocGia FROM DOC_GIA WHERE IDTaiKhoan = @idTaiKhoan;

    -- Danh sách chi tiết mượn
    SELECT
        ctpm.IDChiTiet,
        pm.IDPhieuMuon,
        s.TenSach,
        ctpm.NgayMuon,
        pm.HanTra,
        ctpm.NgayTra,
        ISNULL(ctpm.TienPhat, 0) AS TienPhat,
        CASE
            WHEN ctpm.NgayTra IS NOT NULL       THEN N'Đã trả'
            WHEN GETDATE() > pm.HanTra          THEN N'Quá hạn'
            ELSE                                     N'Đang mượn'
        END AS TrangThai
    FROM CHI_TIET_PHIEU_MUON ctpm
    INNER JOIN PHIEU_MUON   pm ON pm.IDPhieuMuon = ctpm.IDPhieuMuon
    INNER JOIN BAN_SAO_SACH bs ON bs.IDBanSao    = ctpm.IDBanSao
    INNER JOIN SACH         s  ON s.IDSach        = bs.IDSach
    WHERE pm.IDDocGia = @idDocGia
    ORDER BY ctpm.NgayMuon DESC;

    -- Thống kê tổng hợp (trả về result set thứ 2)
    SELECT
        SUM(CASE WHEN ctpm.NgayTra IS NULL AND GETDATE() <= pm.HanTra THEN 1 ELSE 0 END) AS SoDangMuon,
        SUM(CASE WHEN ctpm.NgayTra IS NULL AND GETDATE()  > pm.HanTra THEN 1 ELSE 0 END) AS SoQuaHan,
        SUM(CASE WHEN ctpm.NgayTra IS NOT NULL                        THEN 1 ELSE 0 END) AS SoDaTra,
        ISNULL(SUM(CASE WHEN ctpm.NgayTra IS NULL AND GETDATE() > pm.HanTra
                        THEN DATEDIFF(DAY, pm.HanTra, GETDATE()) * 5000
                        ELSE 0 END), 0) AS TongTienPhat
    FROM CHI_TIET_PHIEU_MUON ctpm
    INNER JOIN PHIEU_MUON pm ON pm.IDPhieuMuon = ctpm.IDPhieuMuon
    WHERE pm.IDDocGia = @idDocGia;
END
GO
