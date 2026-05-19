USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- SP   : sp_XoaTaiKhoan
-- Mô tả: Xóa tài khoản đọc giả.
--        Từ chối nếu còn phiếu mượn chưa trả.
-- Tham số:
--   @idTaiKhoan INT
-- Trả về:
--   1  = xóa thành công
--   0  = còn phiếu mượn chưa trả
--  -1  = lỗi
-- =============================================
CREATE OR ALTER PROCEDURE sp_XoaTaiKhoan
    @idTaiKhoan INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

            DECLARE @idDocGia INT;
            SELECT @idDocGia = IDDocGia FROM DOC_GIA WHERE IDTaiKhoan = @idTaiKhoan;

            -- Kiểm tra phiếu mượn đang mở (chưa trả hết)
            IF EXISTS (
                SELECT 1
                FROM CHI_TIET_PHIEU_MUON ctpm
                INNER JOIN PHIEU_MUON pm ON pm.IDPhieuMuon = ctpm.IDPhieuMuon
                WHERE pm.IDDocGia = @idDocGia AND ctpm.NgayTra IS NULL
            )
            BEGIN
                ROLLBACK TRANSACTION;
                SELECT 0 AS Result;
                RETURN;
            END

            -- Xóa theo thứ tự FK
            DELETE FROM CHI_TIET_PHIEU_MUON
            WHERE IDPhieuMuon IN (SELECT IDPhieuMuon FROM PHIEU_MUON WHERE IDDocGia = @idDocGia);

            DELETE FROM PHIEU_MUON WHERE IDDocGia = @idDocGia;
            DELETE FROM THE_MUON   WHERE IDDocGia = @idDocGia;
            DELETE FROM DOC_GIA    WHERE IDDocGia = @idDocGia;
            DELETE FROM TAI_KHOAN  WHERE IDTaiKhoan = @idTaiKhoan;

        COMMIT TRANSACTION;
        SELECT 1 AS Result;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SELECT -1 AS Result;
    END CATCH
END
GO
