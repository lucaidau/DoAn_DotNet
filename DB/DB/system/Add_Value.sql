USE QUAN_LY_THU_VIEN
GO


DBCC CHECKIDENT ('CHI_TIET_PHIEU_MUON', RESEED, 0);
DBCC CHECKIDENT ('PHIEU_MUON', RESEED, 0);
DBCC CHECKIDENT ('BAN_SAO_SACH', RESEED, 0);
DBCC CHECKIDENT ('CHI_TIET_TAC_GIA', RESEED, 0);
DBCC CHECKIDENT ('SACH', RESEED, 0);
DBCC CHECKIDENT ('THE_MUON', RESEED, 0);
DBCC CHECKIDENT ('BAN_SAO_SACH', RESEED, 0);
DBCC CHECKIDENT ('THU_THU', RESEED, 0);
DBCC CHECKIDENT ('DOC_GIA', RESEED, 0);
DBCC CHECKIDENT ('TAC_GIA', RESEED, 0);
DBCC CHECKIDENT ('NHA_PHAT_HANH', RESEED, 0);
DBCC CHECKIDENT ('TAI_KHOAN', RESEED, 0);



DELETE FROM CHI_TIET_PHIEU_MUON;
DELETE FROM PHIEU_MUON;
DELETE FROM BAN_SAO_SACH;
DELETE FROM CHI_TIET_TAC_GIA;
DELETE FROM SACH;
DELETE FROM THE_MUON;
DELETE FROM THU_THU;
DELETE FROM DOC_GIA;
DELETE FROM TAC_GIA;
DELETE FROM NHA_PHAT_HANH;
DELETE FROM TAI_KHOAN;

SELECT * FROM TAI_KHOAN
SELECT * FROM THU_THU
SELECT * FROM DOC_GIA
SELECT * FROM THE_MUON
SELECT * FROM SACH
SELECT * FROM BAN_SAO_SACH
SELECT * FROM TAC_GIA
SELECT * FROM CHI_TIET_TAC_GIA
SELECT * FROM NHA_PHAT_HANH
SELECT * FROM PHIEU_MUON
SELECT * FROM CHI_TIET_PHIEU_MUON


-- Tài khoản --
INSERT INTO TAI_KHOAN (TenTK, HashMK, SDT, HoTen, GioiTinh, Email) VALUES 
('admin', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', '0901234567', N'Nguyễn Quản Trị', 1, 'admin@huit.edu.vn'),
('staff01', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', '0907654321', N'Trần Thị Thủ Thư', 0, 'thuthu@huit.edu.vn'),
('user01', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', '0988888888', N'Lê Văn Độc Giả', 1, 'user01@gmail.com');

INSERT INTO THU_THU (IDTaiKhoan) VALUES (2); 
INSERT INTO DOC_GIA (IDTaiKhoan, SoTienDatCoc) VALUES (3, 50000);

-- Danh mục --
INSERT INTO NHA_PHAT_HANH (TenNhaPhatHanh) VALUES 
(N'NXB Trẻ'), (N'NXB Giáo Dục'), (N'Kim Đồng');

INSERT INTO TAC_GIA (TenTG) VALUES 
(N'Ngô Tất Tố'), (N'Tô Hoài'), (N'J.K. Rowling');

-- Sách --
INSERT INTO SACH (TenSach, IDNhaPhatHanh, IDNguoiThem) VALUES 
(N'Dế Mèn Phiêu Lưu Ký', 1, 1),
(N'Tắt Đèn', 2, 1),
(N'Harry Potter', 3, 1);

-- Chi tiết sách --
INSERT INTO CHI_TIET_TAC_GIA (IDSach, IDTacGia) VALUES 
(1, 2), -- Dế Mèn - Tô Hoài
(2, 1), -- Tắt Đèn - Ngô Tất Tố
(3, 3); -- Harry Potter - J.K. Rowling

INSERT INTO BAN_SAO_SACH (IDSach, IDNguoiNhap, GiaNhap, TrangThai) VALUES 
(1, 1, 45000, 1), -- Dế Mèn cuốn 1 (Sẵn sàng)
(1, 1, 45000, 1), -- Dế Mèn cuốn 2 (Sẵn sàng)
(2, 1, 35000, 1), -- Tắt Đèn (Sẵn sàng)
(3, 1, 120000, 0); -- Harry Potter (Cuốn này giả định đang mượn - TrangThai = 0)

-- Thẻ mượn
INSERT INTO THE_MUON (IDDocGia, NgayCap, NgayHetHan, MaKichHoat, TrangThai) VALUES 
(1, GETDATE(), DATEADD(year, 1, GETDATE()), 123456, 1); -- Thẻ của đọc giả 1 được kích hoạt

INSERT INTO PHIEU_MUON (IDDocGia, NgayDangKi, HanTra, TrangThai, TienCoc)
VALUES 
(1, '2026-04-20 08:30:00', '2026-05-20', 1, 50000.00), -- Độc giả 1 mượn đợt 1
(1, '2026-04-25 14:00:00', '2026-05-25', 1, 100000.00) -- Độc giả 1 mượn thêm đợt 2

INSERT INTO CHI_TIET_PHIEU_MUON (IDPhieuMuon, IDBanSao, TrangThai, NgayMuon, NgayTra, TienPhat, LiDo)
VALUES 
-- Các sách thuộc Phiếu mượn số 1
(1, 1, 1, '2026-04-20', NULL, 0, NULL), 
(1, 2, 1, '2026-04-20', NULL, 0, NULL),

-- Sách thuộc Phiếu mượn số 2
(2, 3, 1, '2026-04-25', NULL, 0, NULL)

