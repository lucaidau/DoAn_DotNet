USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- SP   : sp_XoaSach
-- Mô tả: Xóa sách. Từ chối nếu còn bản sao đang được mượn.
-- Tham số:
--   @idSach INT
-- Trả về:
--   1  = xóa thành công
--   0  = vẫn còn bản sao đang mượn (TrangThai = 0)
--  -1  = lỗi
-- =============================================
CREATE OR ALTER PROCEDURE sp_XoaSach
    @idSach INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

            -- Kiểm tra còn bản sao đang mượn không
            IF EXISTS (
                SELECT 1 FROM BAN_SAO_SACH
                WHERE IDSach = @idSach AND TrangThai = 0
            )
            BEGIN
                ROLLBACK TRANSACTION;
                SELECT 0 AS Result;
                RETURN;
            END

            -- Xóa theo thứ tự FK
            DELETE FROM CHI_TIET_TAC_GIA WHERE IDSach = @idSach;
            DELETE FROM BAN_SAO_SACH     WHERE IDSach = @idSach;
            DELETE FROM SACH             WHERE IDSach = @idSach;

        COMMIT TRANSACTION;
        SELECT 1 AS Result;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SELECT -1 AS Result;
    END CATCH
END
GO
