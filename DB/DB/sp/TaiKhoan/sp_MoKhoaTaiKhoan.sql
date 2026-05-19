USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- SP   : sp_MoKhoaTaiKhoan
-- Mô tả: Mở khóa tài khoản đọc giả (TrangThai = 1).
-- Tham số:
--   @idDocGia INT
-- Trả về: 1 = thành công, -1 = lỗi
-- =============================================
CREATE OR ALTER PROCEDURE sp_MoKhoaTaiKhoan
    @idDocGia INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE DOC_GIA SET TrangThai = 1 WHERE IDDocGia = @idDocGia;
        SELECT 1 AS Result;
    END TRY
    BEGIN CATCH
        SELECT -1 AS Result;
    END CATCH
END
GO
