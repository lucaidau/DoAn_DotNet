using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DA_QuanLiThuVien.Views.UserControls.ThuThu
{
    /// <summary>
    /// Interaction logic for UcDocGia.xaml
    /// </summary>
    public partial class UcDocGia : UserControl
    {
        public UcDocGia()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Viết logic lấy dữ liệu từ các TextBox (txtMaPhieu, txtHoTen...) và thêm vào DB
            MessageBox.Show("Chức năng thêm độc giả đang được cập nhật!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Viết logic lấy độc giả đang chọn từ DataGrid và cập nhật
            MessageBox.Show("Chức năng sửa thông tin đang được cập nhật!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnKhoaThe_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Đổi trạng thái thẻ thư viện thành 'Bị Khóa'
            MessageBox.Show("Chức năng khóa thẻ đang được cập nhật!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Xác nhận và xóa độc giả
            MessageBox.Show("Chức năng xóa độc giả đang được cập nhật!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
