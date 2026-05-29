using System;
using System.Windows;
using System.Windows.Controls;

namespace DA_QuanLiThuVien.Views.UserControls.ThuThu
{
    public partial class UcMenuThuThu : UserControl
    {
        // Sự kiện để báo MainWindow xử lý đăng xuất
        public Action OnLogout;

        public UcMenuThuThu()
        {
            InitializeComponent();
        }

        private void ResetButtonBackground()
        {
            var defaultBg = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Transparent);
            var defaultFg = new System.Windows.Media.SolidColorBrush(
                (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#0B2545"));

            BtnQuanLySach.Background = defaultBg;   BtnQuanLySach.Foreground = defaultFg;
            BtnDocGia.Background    = defaultBg;    BtnDocGia.Foreground    = defaultFg;
            BtnMuonTra.Background   = defaultBg;    BtnMuonTra.Foreground   = defaultFg;
            BtnBaoCao.Background    = defaultBg;    BtnBaoCao.Foreground    = defaultFg;
            BtnCaiDat.Background    = defaultBg;    BtnCaiDat.Foreground    = defaultFg;
        }

        private void SetActiveButton(Button btn)
        {
            ResetButtonBackground();
            btn.Background = new System.Windows.Media.SolidColorBrush(
                (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#1E4D8C"));
            btn.Foreground = System.Windows.Media.Brushes.White;
        }

        private void BtnQuanLySach_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((Button)sender);
            SubContent.Content = new UcQuanLySach();
        }

        private void BtnDocGia_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((Button)sender);
            SubContent.Content = new UcDocGia();
        }

        private void BtnMuonTra_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((Button)sender);
            SubContent.Content = new UcMuonTra();
        }

        private void BtnBaoCao_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((Button)sender);
            SubContent.Content = new UcBaoCao();
        }

        private void BtnCaiDat_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((Button)sender);
            SubContent.Content = new UcCaiDat();
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
