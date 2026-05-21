using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DA_QuanLiThuVien.Views.UserControls.ThuThu
{
    public partial class UcQuanLyTKDocGia : UserControl
    {
        public UcQuanLyTKDocGia()
        {
            InitializeComponent();
            LoadMockData();
        }

        private void LoadMockData()
        {
            if (Helper.UserSession.UserFullName != "Quản Trị Demo") return;

            dgTaiKhoan.ItemsSource = new List<object>
            {
                new { STT = 1, TenTK = "nguyenvana", HoTen = "Nguyễn Văn A", SDT = "0901234567", Email = "nva@gmail.com", GioiTinhText = "Nam", TrangThaiBg = "#E5F7ED", TrangThaiText = "Đang hoạt động", TrangThaiFg = "#0B6E4F", SoTienDatCoc = 100000 },
                new { STT = 2, TenTK = "tranthib", HoTen = "Trần Thị B", SDT = "0987654321", Email = "ttb@gmail.com", GioiTinhText = "Nữ", TrangThaiBg = "#FDE8E8", TrangThaiText = "Bị khóa", TrangThaiFg = "#C81E1E", SoTienDatCoc = 50000 },
                new { STT = 3, TenTK = "lehoangc", HoTen = "Lê Hoàng C", SDT = "0912345678", Email = "lhc@gmail.com", GioiTinhText = "Nam", TrangThaiBg = "#E5F7ED", TrangThaiText = "Đang hoạt động", TrangThaiFg = "#0B6E4F", SoTienDatCoc = 150000 },
            };
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e) { }
        private void btnLamMoi_Click(object sender, RoutedEventArgs e) { }
        private void dgTaiKhoan_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void btnThem_Click(object sender, RoutedEventArgs e) { }
        private void btnSua_Click(object sender, RoutedEventArgs e) { }
        private void btnKhoa_Click(object sender, RoutedEventArgs e) { }
        private void btnMoKhoa_Click(object sender, RoutedEventArgs e) { }
        private void btnXoa_Click(object sender, RoutedEventArgs e) { }
    }
}
