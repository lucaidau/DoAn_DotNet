using System.Windows;
using System.Windows.Controls;

namespace DA_QuanLiThuVien.Views.UserControls.ThuThu
{
    /// <summary>
    /// Interaction logic for UcQuanLyTKDocGia.xaml
    /// </summary>
    public partial class UcQuanLyTKDocGia : UserControl
    {
        public UcQuanLyTKDocGia()
        {
            InitializeComponent();
        }

        // Khi chọn dòng trên DataGrid -> tự điền thông tin xuống form bên dưới
        private void dgTaiKhoan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Lấy item đang chọn và điền vào các TextBox
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Lọc danh sách theo txtTimKiem, cboTrangThai, cboGioiTinh
            MessageBox.Show("Chức năng tìm kiếm đang được cập nhật!", "Thông báo",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            txtTimKiem.Clear();
            cboTrangThai.SelectedIndex = 0;
            cboGioiTinh.SelectedIndex = 0;
            XoaForm();
            // TODO: Reload danh sách từ DB
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Validate form và thêm tài khoản mới vào DB
            MessageBox.Show("Chức năng thêm tài khoản đang được cập nhật!", "Thông báo",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Lấy tài khoản đang chọn và cập nhật thông tin vào DB
            MessageBox.Show("Chức năng cập nhật thông tin đang được cập nhật!", "Thông báo",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnKhoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgTaiKhoan.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần khóa!", "Cảnh báo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn KHÓA tài khoản này?", "Xác nhận",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirm == MessageBoxResult.Yes)
            {
                // TODO: Cập nhật TrangThai = false (khóa) vào DB
                MessageBox.Show("Chức năng khóa tài khoản đang được cập nhật!", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnMoKhoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgTaiKhoan.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần mở khóa!", "Cảnh báo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn MỞ KHÓA tài khoản này?", "Xác nhận",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirm == MessageBoxResult.Yes)
            {
                // TODO: Cập nhật TrangThai = true (mở khóa) vào DB
                MessageBox.Show("Chức năng mở khóa tài khoản đang được cập nhật!", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgTaiKhoan.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Cảnh báo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn XÓA tài khoản này? Hành động không thể hoàn tác!",
                "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (confirm == MessageBoxResult.Yes)
            {
                // TODO: Xóa tài khoản khỏi DB
                MessageBox.Show("Chức năng xóa tài khoản đang được cập nhật!", "Thông báo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>Xóa trắng toàn bộ form nhập liệu</summary>
        private void XoaForm()
        {
            txtTenTK.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtMatKhau.Clear();
            cboGioiTinhForm.SelectedIndex = 0;
            dgTaiKhoan.SelectedItem = null;
        }
    }
}
