CREATE OR ALTER PROCEDURE sp_DangNhap
    @userName VARCHAR(50),
    @hashPass VARCHAR(100)
AS
    BEGIN
        SET NOCOUNT ON;
        IF EXISTS(SELECT 1 FROM TAI_KHOAN WHERE @userName = TenTK AND HashMK = @hashPass)
            BEGIN
                SELECT
                     tk.IDTaiKhoan,
                     tk.HoTen,
                     CASE
                        WHEN tt.IDTaiKhoan IS NOT NULL THEN 1
                        WHEN dg.IDTaiKhoan IS NOT NULL THEN 0
                        ELSE -1
                    END AS Role,
                1 AS Result
                FROM TAI_KHOAN tk
                LEFT JOIN THU_THU tt ON tt.IDTaiKhoan = tk.IDTaiKhoan
                LEFT JOIN DOC_GIA dg ON dg.IDTaiKhoan = tk.IDTaiKhoan
                WHERE @userName = TenTK AND HashMK = @hashPass
            END
        ELSE
            BEGIN
                SELECT 
                0 AS IDTaiKhoan,
                NULL AS HoTen,
                -1 AS Role,
                0 AS Result;
            END
    END

