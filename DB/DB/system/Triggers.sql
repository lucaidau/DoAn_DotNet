USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- Trigger: trg_MuonSach
-- Mô tả : Khi thêm chi tiết phiếu mượn,
--         tự động đánh dấu bản sao = 0 (đang mượn)
-- =============================================
CREATE OR ALTER TRIGGER trg_MuonSach
ON CHI_TIET_PHIEU_MUON
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE BAN_SAO_SACH
    SET TrangThai = 0
    WHERE IDBanSao IN (SELECT IDBanSao FROM inserted);
END
GO

-- =============================================
-- Trigger: trg_TraSach
-- Mô tả : Khi cập nhật NgayTra trong chi tiết phiếu mượn,
--         tự động đánh dấu bản sao = 1 (còn sách)
-- =============================================
CREATE OR ALTER TRIGGER trg_TraSach
ON CHI_TIET_PHIEU_MUON
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF UPDATE(NgayTra)
    BEGIN
        UPDATE BAN_SAO_SACH
        SET TrangThai = 1
        WHERE IDBanSao IN (
            SELECT i.IDBanSao FROM inserted i
            INNER JOIN deleted d ON i.IDChiTiet = d.IDChiTiet
            WHERE i.NgayTra IS NOT NULL AND d.NgayTra IS NULL
        );
    END
END

