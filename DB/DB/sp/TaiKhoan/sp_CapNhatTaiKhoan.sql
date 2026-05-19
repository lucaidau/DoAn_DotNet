USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- SP   : sp_CapNhatTaiKhoan
-- Mô tả: Cập nhật thông tin tài khoản đọc giả.
--        Mật khẩu chỉ cập nhật nếu @hashMKMoi khác NULL.
-- Tham số:
--   @idTaiKhoan INT
--   @hoTen      NVARCHAR(100)
--   @sdt        VARCHAR(10)
--   @email      VARCHAR(100)
--   @gioiTinh   BIT
--   @hashMKMoi  VARCHAR(100) = NULL (NULL = không đổi mật khẩu)
-- Trả về:
--   1  = thành công
--   0  = SĐT hoặc Email đã tồn tại ở tài khoản khác
--  -1  = lỗi
-- =============================================
CREATE OR ALTER PROCEDURE sp_CapNhatTaiKhoan
    @idTaiKhoan INT,
    @hoTen      NVARCHAR(100),
    @sdt        VARCHAR(10),
    @email      VARCHAR(100),
    @gioiTinh   BIT,
    @hashMKMoi  VARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

            -- Kiểm tra SĐT trùng (tài khoản khác)
            IF EXISTS (SELECT 1 FROM TAI_KHOAN WHERE SDT = @sdt AND IDTaiKhoan <> @idTaiKhoan)
            BEGIN
                ROLLBACK TRANSACTION;
                SELECT 0 AS Result, N'Số điện thoại đã được sử dụng.' AS Message;
                RETURN;
            END

            -- Kiểm tra Email trùng
            IF EXISTS (SELECT 1 FROM TAI_KHOAN WHERE Email = @email AND IDTaiKhoan <> @idTaiKhoan)
            BEGIN
                ROLLBACK TRANSACTION;
                SELECT 0 AS Result, N'Email đã được sử dụng.' AS Message;
                RETURN;
            END

            UPDATE TAI_KHOAN SET
                HoTen    = @hoTen,
                SDT      = @sdt,
                Email    = @email,
                GioiTinh = @gioiTinh,
                HashMK   = ISNULL(@hashMKMoi, HashMK)
            WHERE IDTaiKhoan = @idTaiKhoan;

        COMMIT TRANSACTION;
        SELECT 1 AS Result, N'Cập nhật thành công.' AS Message;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SELECT -1 AS Result, ERROR_MESSAGE() AS Message;
    END CATCH
END
GO
