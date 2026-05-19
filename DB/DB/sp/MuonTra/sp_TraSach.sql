USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- SP   : sp_TraSach
-- Mô tả: Ghi nhận trả sách, tính tiền phạt quá hạn.
--        Trigger trg_TraSach sẽ tự cập nhật BAN_SAO_SACH.TrangThai = 1.
-- Tham số:
--   @idChiTiet    INT           -- IDChiTiet của CHI_TIET_PHIEU_MUON
--   @mucPhatNgay  DECIMAL(18,2) -- tiền phạt / ngày (vd: 5000)
-- Trả về:
--   1  = thành công (kèm TienPhat tính được)
--   0  = không tìm thấy hoặc đã trả rồi
--  -1  = lỗi
-- =============================================
CREATE OR ALTER PROCEDURE sp_TraSach
    @idChiTiet   INT,
    @mucPhatNgay DECIMAL(18,2) = 5000
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

            -- Kiểm tra tồn tại và chưa trả
            IF NOT EXISTS (
                SELECT 1 FROM CHI_TIET_PHIEU_MUON
                WHERE IDChiTiet = @idChiTiet AND NgayTra IS NULL
            )
            BEGIN
                ROLLBACK TRANSACTION;
                SELECT 0 AS Result, 0 AS TienPhat;
                RETURN;
            END

            -- Tính tiền phạt dựa theo HanTra của phiếu mượn
            DECLARE @tienPhat DECIMAL(18,2) = 0;
            DECLARE @hanTra   DATETIME;

            SELECT @hanTra = pm.HanTra
            FROM CHI_TIET_PHIEU_MUON ctpm
            INNER JOIN PHIEU_MUON pm ON pm.IDPhieuMuon = ctpm.IDPhieuMuon
            WHERE ctpm.IDChiTiet = @idChiTiet;

            IF GETDATE() > @hanTra
                SET @tienPhat = DATEDIFF(DAY, @hanTra, GETDATE()) * @mucPhatNgay;

            -- Cập nhật ngày trả + tiền phạt (trigger sẽ tự xử lý BAN_SAO)
            UPDATE CHI_TIET_PHIEU_MUON
            SET NgayTra  = GETDATE(),
                TienPhat = @tienPhat,
                TrangThai = 2         -- 2 = đã trả
            WHERE IDChiTiet = @idChiTiet;

        COMMIT TRANSACTION;
        SELECT 1 AS Result, @tienPhat AS TienPhat;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SELECT -1 AS Result, 0 AS TienPhat;
    END CATCH
END
GO
