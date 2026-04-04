CREATE PROCEDURE sp_DangKi
	@fullName NVARCHAR(50),
	@userName VarChar(50),
	@phoneNumber VarChar(10),
	@email Char(100),
	@gender BIT,
	@hashPass Char(255),
	@role BIT
AS
	BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				IF EXISTS (SELECT 1 FROM TAI_KHOAN WHERE @userName = TenTK AND @hashPass = HashMK)
					BEGIN
						ROLLBACK TRANSACTION
						SELECT 0 AS Result;
						RETURN;
					END

				INSERT INTO TAI_KHOAN(TenTK, HashMK, SDT, HoTen, GioiTinh, Email) VALUES 
				(@userName, @hashPass, @phoneNumber, @fullName, @gender, @email)

				DECLARE @NewID INT = SCOPE_IDENTITY();

				IF(@role = 1)
					INSERT INTO THU_THU(IDTaiKhoan) VALUES(@NewID)
				ELSE
					INSERT INTO DOC_GIA (IDTaiKhoan) VALUES (@NewID)
				COMMIT TRANSACTION
				SELECT 1 AS Result;
		END TRY

		BEGIN CATCH
			IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
			SELECT -1 AS Result;
		END CATCH
	END