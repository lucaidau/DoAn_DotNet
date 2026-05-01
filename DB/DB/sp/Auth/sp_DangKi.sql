CREATE OR ALTER PROCEDURE sp_DangKi
    @fullName   NVARCHAR(100),
    @userName   VARCHAR(50),
    @phoneNumber VARCHAR(10),
    @email      VARCHAR(100),
    @gender     BIT,
    @hashPass   VARCHAR(100),
    @role       BIT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION

            IF EXISTS (SELECT 1 FROM TAI_KHOAN WHERE TenTK = @userName)
            BEGIN
                ROLLBACK TRANSACTION;
                SELECT 0 AS Result;
                RETURN;
            END

            INSERT INTO TAI_KHOAN (TenTK, HashMK, SDT, HoTen, GioiTinh, Email)
            VALUES (@userName, @hashPass, @phoneNumber, @fullName, @gender, @email);

            DECLARE @NewID INT = SCOPE_IDENTITY();

            IF (@role = 1)
            BEGIN
                INSERT INTO THU_THU (IDTaiKhoan) VALUES (@NewID);
            END
            ELSE
            BEGIN
                INSERT INTO DOC_GIA (IDTaiKhoan) VALUES (@NewID);

                DECLARE @NewDocGiaID INT = SCOPE_IDENTITY();

                INSERT INTO THE_MUON (IDDocGia, NgayCap, NgayHetHan, TrangThai)
                VALUES (@NewDocGiaID, GETDATE(), DATEADD(YEAR, 1, GETDATE()), 1);
            END

        COMMIT TRANSACTION;
        SELECT 1 AS Result;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SELECT -1 AS Result;
    END CATCH
END
GO