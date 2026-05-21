using System.Collections.Generic;
using System.Windows.Controls;

namespace DA_QuanLiThuVien.Views.UserControls.ThuThu
{
    public partial class UcQuanLyNhapSach : UserControl
    {
        public UcQuanLyNhapSach()
        {
            InitializeComponent();
            LoadMockData();
        }

        private void LoadMockData()
        {
            if (Helper.UserSession.UserFullName != "Quản Trị Demo") return;

            DgPhieuNhap.ItemsSource = new List<object>
            {
                new { MaPhieu = "PN231001", NhaCungCap = "Công ty phát hành sách Fahasa", NgayNhap = "12/10/2023", TongTien = "15,500,000 VNĐ", NguoiLap = "admin123" },
                new { MaPhieu = "PN231002", NhaCungCap = "Nhà Xuất Bản Trẻ", NgayNhap = "15/10/2023", TongTien = "8,200,000 VNĐ", NguoiLap = "admin123" },
                new { MaPhieu = "PN231105", NhaCungCap = "Tiki Trading", NgayNhap = "05/11/2023", TongTien = "2,350,000 VNĐ", NguoiLap = "admin123" },
                new { MaPhieu = "PN231112", NhaCungCap = "Nhà Xuất Bản Kim Đồng", NgayNhap = "12/11/2023", TongTien = "5,400,000 VNĐ", NguoiLap = "admin123" }
            };
        }
    }
}
