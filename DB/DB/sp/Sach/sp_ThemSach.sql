USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- SP   : sp_ThemSach
-- Mô tả: Thêm sách mới + tác giả + 1 bản sao đầu tiên.
-- Tham số:
--   @tenSach        NVARCHAR(100)
--   @theLoai        NVARCHAR(100)
--   @isbn           VARCHAR(20)
--   @namXuatBan     INT
--   @idNhaPhatHanh  INT
--   @tenTacGia      NVARCHAR(50)  -- tên tác giả (tự tạo nếu chưa có)
--   @giaNhap        DECIMAL(18,2)
--   @idNguoiThem    INT           -- IDThuThu đang đăng nhập
-- Trả về:
--   1  = thành công  (kèm IDSach mới)
--   0  = tên sách đã tồn tại
--  -1  = lỗi
-- =============================================
CREATE OR ALTER PROCEDURE sp_ThemSach
    @tenSach        NVARCHAR(100),
    @theLoai        NVARCHAR(100)  = NULL,
    @isbn           VARCHAR(20)    = NULL,
    @namXuatBan     INT            = NULL,
    @idNhaPhatHanh  INT            = NULL,
    @tenTacGia      NVARCHAR(50)   = NULL,
    @giaNhap        DECIMAL(18,2)  = 0,
    @idNguoiThem    INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

            -- Kiểm tra trùng tên + ISBN
            IF EXISTS (SELECT 1 FROM SACH WHERE TenSach = @tenSach AND (ISBN = @isbn OR @isbn IS NULL))
            BEGIN
                ROLLBACK TRANSACTION;
                SELECT 0 AS Result, NULL AS IDSach;
                RETURN;
            END

            -- Thêm sách
            INSERT INTO SACH (TenSach, TheLoai, ISBN, NamXuatBan, IDNhaPhatHanh, IDNguoiThem)
            VALUES (@tenSach, @theLoai, @isbn, @namXuatBan, @idNhaPhatHanh, @idNguoiThem);

            DECLARE @NewSachID INT = SCOPE_IDENTITY();

            -- Xử lý tác giả
            IF @tenTacGia IS NOT NULL
            BEGIN
                DECLARE @IDTacGia INT;
                SELECT @IDTacGia = IDTacGia FROM TAC_GIA WHERE TenTG = @tenTacGia;

                IF @IDTacGia IS NULL
                BEGIN
                    INSERT INTO TAC_GIA (TenTG) VALUES (@tenTacGia);
                    SET @IDTacGia = SCOPE_IDENTITY();
                END

                INSERT INTO CHI_TIET_TAC_GIA (IDSach, IDTacGia)
                VALUES (@NewSachID, @IDTacGia);
            END

            -- Thêm 1 bản sao đầu tiên
            INSERT INTO BAN_SAO_SACH (IDSach, IDNguoiNhap, NgayNhap, GiaNhap, TrangThai)
            VALUES (@NewSachID, @idNguoiThem, GETDATE(), @giaNhap, 1);

        COMMIT TRANSACTION;
        SELECT 1 AS Result, @NewSachID AS IDSach;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SELECT -1 AS Result, NULL AS IDSach;
    END CATCH
END
GO
