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
            pnlThongTin.Visibility = Visibility.Collapsed;
            pnlDoiMatKhau.Visibility = Visibility.Visible;
        }

        private void btnQuayLai_Click(object sender, RoutedEventArgs e)
        {
            pnlDoiMatKhau.Visibility = Visibility.Collapsed;
            pnlThongTin.Visibility = Visibility.Visible;
        }
    }
}
