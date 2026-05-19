USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- SP   : sp_LayThongTinDocGia
-- Mô tả: Lấy thông tin cá nhân + thẻ mượn của đọc giả.
--        Dùng cho màn hình "Thông tin cá nhân" (Đọc Giả).
-- Tham số:
--   @idTaiKhoan INT  -- IDTaiKhoan từ UserSession
-- =============================================
CREATE OR ALTER PROCEDURE sp_LayThongTinDocGia
    @idTaiKhoan INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        tk.IDTaiKhoan,
        dg.IDDocGia,
        tk.TenTK,
        tk.HoTen,
        tk.SDT,
        tk.Email,
        tk.GioiTinh,
        dg.SoTienDatCoc,
        dg.TrangThai            AS TrangThaiTK,
        tm.IDTheMuon,
        tm.NgayCap,
        tm.NgayHetHan,
        tm.TrangThai            AS TrangThaiThe
    FROM TAI_KHOAN tk
    INNER JOIN DOC_GIA dg ON dg.IDTaiKhoan = tk.IDTaiKhoan
    LEFT  JOIN THE_MUON tm ON tm.IDDocGia  = dg.IDDocGia
    WHERE tk.IDTaiKhoan = @idTaiKhoan;
END
GO
