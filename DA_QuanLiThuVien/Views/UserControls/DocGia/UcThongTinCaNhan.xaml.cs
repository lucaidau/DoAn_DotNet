using System.Windows;
using System.Windows.Controls;

namespace DA_QuanLiThuVien.Views.UserControls.DocGia
{
    public partial class UcThongTinCaNhan : UserControl
    {
        public UcThongTinCaNhan()
        {
            InitializeComponent();
        }

        private void btnShowDoiMatKhau_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chuyển sang màn hình Đổi mật khẩu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            pnlThongTin.Visibility = Visibility.Collapsed;//hide thông tin cá nhân
            pnlDoiMatKhau.Visibility = Visibility.Visible;//show đổi mật khẩu
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            pnlDoiMatKhau.Visibility = Visibility.Collapsed;
            pnlThongTin.Visibility = Visibility.Visible;
        }
    }
}
