USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- SP   : sp_TaoPhieuMuon
-- Mô tả: Tạo phiếu mượn + chi tiết cho 1 bản sao sách.
--        Trigger trg_MuonSach sẽ tự cập nhật BAN_SAO_SACH.TrangThai = 0.
-- Tham số:
--   @idDocGia   INT
--   @idBanSao   INT
--   @hanTra     DATETIME
--   @tienCoc    DECIMAL(18,2)
--   @idThuThu   INT           -- IDThuThu lập phiếu (ghi log nếu cần)
-- Trả về:
--   1  = thành công (kèm IDPhieuMuon)
--   0  = bản sao không tồn tại hoặc đang được mượn
--  -1  = lỗi
-- =============================================
CREATE OR ALTER PROCEDURE sp_TaoPhieuMuon
    @idDocGia INT,
    @idBanSao INT,
    @hanTra   DATETIME,
    @tienCoc  DECIMAL(18,2) = 0,
    @idThuThu INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

            -- Kiểm tra bản sao còn trống không
            IF NOT EXISTS (SELECT 1 FROM BAN_SAO_SACH WHERE IDBanSao = @idBanSao AND TrangThai = 1)
            BEGIN
                ROLLBACK TRANSACTION;
                SELECT 0 AS Result, NULL AS IDPhieuMuon;
                RETURN;
            END

            -- Kiểm tra đọc giả hợp lệ / không bị khóa
            IF NOT EXISTS (SELECT 1 FROM DOC_GIA WHERE IDDocGia = @idDocGia AND TrangThai = 1)
            BEGIN
                ROLLBACK TRANSACTION;
                SELECT 0 AS Result, NULL AS IDPhieuMuon;
                RETURN;
            END

            -- Tạo phiếu mượn
            INSERT INTO PHIEU_MUON (IDDocGia, NgayDangKi, HanTra, TrangThai, TienCoc)
            VALUES (@idDocGia, GETDATE(), @hanTra, 1, @tienCoc);

            DECLARE @IDPhieuMuon INT = SCOPE_IDENTITY();

            -- Thêm chi tiết (trigger sẽ cập nhật TrangThai bản sao → 0)
            INSERT INTO CHI_TIET_PHIEU_MUON (IDPhieuMuon, IDBanSao, TrangThai, NgayMuon, TienPhat)
            VALUES (@IDPhieuMuon, @idBanSao, 1, GETDATE(), 0);

        COMMIT TRANSACTION;
        SELECT 1 AS Result, @IDPhieuMuon AS IDPhieuMuon;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SELECT -1 AS Result, NULL AS IDPhieuMuon;
    END CATCH
END
GO
