USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- SP   : sp_DoiMatKhau
-- Mô tả: Đổi mật khẩu sau khi xác minh mật khẩu cũ.
-- Tham số:
--   @idTaiKhoan  INT
--   @hashMKCu    VARCHAR(100)  -- hash mật khẩu hiện tại
--   @hashMKMoi   VARCHAR(100)  -- hash mật khẩu mới
-- Trả về:
--   1  = đổi thành công
--   0  = mật khẩu cũ không đúng
--  -1  = lỗi
-- =============================================
CREATE OR ALTER PROCEDURE sp_DoiMatKhau
    @idTaiKhoan INT,
    @hashMKCu   VARCHAR(100),
    @hashMKMoi  VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY

        IF NOT EXISTS (SELECT 1 FROM TAI_KHOAN WHERE IDTaiKhoan = @idTaiKhoan AND HashMK = @hashMKCu)
        BEGIN
            SELECT 0 AS Result;
            RETURN;
        END

        UPDATE TAI_KHOAN SET HashMK = @hashMKMoi WHERE IDTaiKhoan = @idTaiKhoan;
        SELECT 1 AS Result;

    END TRY
    BEGIN CATCH
        SELECT -1 AS Result;
    END CATCH
END
GO
