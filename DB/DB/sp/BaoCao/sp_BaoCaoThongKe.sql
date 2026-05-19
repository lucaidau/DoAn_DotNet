USE QUAN_LY_THU_VIEN
GO

-- =============================================
-- SP   : sp_BaoCaoThongKe
-- Mô tả: Thống kê tổng hợp + lượt mượn theo tháng
--        cho màn hình Báo Cáo (Thủ Thư).
-- Tham số:
--   @tuNgay  DATE  -- NULL = không giới hạn
--   @denNgay DATE  -- NULL = không giới hạn
-- Trả về 3 result set:
--   1. Tổng hợp nhanh (TongSach, TongDocGia, TongPhieu, SoQuaHan, TongPhat)
--   2. Lượt mượn theo tháng (trong khoảng @tuNgay..@denNgay)
--   3. Top 5 sách được mượn nhiều nhất
-- =============================================
CREATE OR ALTER PROCEDURE sp_BaoCaoThongKe
    @tuNgay  DATE = NULL,
    @denNgay DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- ── Result set 1: Tổng hợp nhanh ─────────────────────────────────────────
    SELECT
        (SELECT COUNT(*) FROM SACH)                                             AS TongSach,
        (SELECT COUNT(*) FROM BAN_SAO_SACH WHERE TrangThai = 1)                AS SoBanSaoCon,
        (SELECT COUNT(*) FROM DOC_GIA WHERE TrangThai = 1)                     AS TongDocGia,
        (SELECT COUNT(*) FROM PHIEU_MUON)                                       AS TongPhieu,
        (SELECT COUNT(*)
         FROM CHI_TIET_PHIEU_MUON ctpm
         INNER JOIN PHIEU_MUON pm ON pm.IDPhieuMuon = ctpm.IDPhieuMuon
         WHERE ctpm.NgayTra IS NULL AND GETDATE() > pm.HanTra)                 AS SoQuaHan,
        ISNULL((SELECT SUM(TienPhat) FROM CHI_TIET_PHIEU_MUON), 0)            AS TongTienPhat;

    -- ── Result set 2: Lượt mượn theo tháng ───────────────────────────────────
    SELECT
        FORMAT(ctpm.NgayMuon, 'MM/yyyy') AS Thang,
        COUNT(*)                          AS SoLuot
    FROM CHI_TIET_PHIEU_MUON ctpm
    WHERE
        (@tuNgay  IS NULL OR CAST(ctpm.NgayMuon AS DATE) >= @tuNgay)
        AND (@denNgay IS NULL OR CAST(ctpm.NgayMuon AS DATE) <= @denNgay)
    GROUP BY FORMAT(ctpm.NgayMuon, 'MM/yyyy'), YEAR(ctpm.NgayMuon), MONTH(ctpm.NgayMuon)
    ORDER BY YEAR(ctpm.NgayMuon), MONTH(ctpm.NgayMuon);

    -- ── Result set 3: Top 5 sách mượn nhiều nhất ─────────────────────────────
    SELECT TOP 5
        s.TenSach,
        COUNT(ctpm.IDChiTiet) AS SoLuotMuon
    FROM CHI_TIET_PHIEU_MUON ctpm
    INNER JOIN BAN_SAO_SACH bs ON bs.IDBanSao = ctpm.IDBanSao
    INNER JOIN SACH         s  ON s.IDSach    = bs.IDSach
    WHERE
        (@tuNgay  IS NULL OR CAST(ctpm.NgayMuon AS DATE) >= @tuNgay)
        AND (@denNgay IS NULL OR CAST(ctpm.NgayMuon AS DATE) <= @denNgay)
    GROUP BY s.IDSach, s.TenSach
    ORDER BY SoLuotMuon DESC;
END
GO
