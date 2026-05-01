using System;
using System.Windows;
using System.Windows.Controls;

namespace DA_QuanLiThuVien.Views.UserControls.DocGia
{
    public partial class UcMenuDocGia : UserControl
    {
        // Sự kiện để báo MainWindow xử lý đăng xuất
        public Action OnLogout;

        public UcMenuDocGia()
        {
            InitializeComponent();
        }

        private void ResetButtonBackground()
        {
            var defaultBg = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Transparent);
            var defaultFg = new System.Windows.Media.SolidColorBrush(
                (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#0B2545"));

            BtnTimKiemSach.Background    = defaultBg;   BtnTimKiemSach.Foreground    = defaultFg;
            BtnSachDangMuon.Background   = defaultBg;   BtnSachDangMuon.Foreground   = defaultFg;
            BtnThongTinCaNhan.Background = defaultBg;   BtnThongTinCaNhan.Foreground = defaultFg;
        }

        private void SetActiveButton(Button btn)
        {
            ResetButtonBackground();
            btn.Background = new System.Windows.Media.SolidColorBrush(
                (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#1E4D8C"));
            btn.Foreground = System.Windows.Media.Brushes.White;
        }

        private void BtnTimKiemSach_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((Button)sender);
            SubContent.Content = new UcTimKiemSach();
        }

        private void BtnSachDangMuon_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((Button)sender);
            SubContent.Content = new UcSachDangMuon();
        }

        private void BtnThongTinCaNhan_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((Button)sender);
            SubContent.Content = new UcThongTinCaNhan();
        }

        private void BtnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Bạn có muốn đăng xuất?", "Xác nhận",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                OnLogout?.Invoke();
            }
        }
    }
}
