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
		IF EXISTS (SELECT 1 FROM TAI_KHOAN WHERE TenTK = @userName AND SDT = @phoneNumber)
			BEGIN
				SELECT 0 AS Result;
				RETURN;
			END
		
		INSERT INTO TAI_KHOAN(TenTK, HashMK, SDT, HoTen, GioiTinh, Email)
		VALUES(@userName, @hashPass, @phoneNumber, @fullName, @gender, @email)

		DECLARE @NewID INT = SCOPE_IDENTITY();

		IF (@role = 1)
			BEGIN
				INSERT INTO THU_THU(IDTaiKhoan) VALUES(@NewID)
			END	

		ELSE
			BEGIN
				INSERT INTO DOC_GIA(IDTaiKhoan) VALUES(@NewID)
			END
		SELECT 1 AS Result;
	END
