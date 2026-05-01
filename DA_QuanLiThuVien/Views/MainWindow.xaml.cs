using System.Windows;
using DA_QuanLiThuVien.Views.UserControls.ThuThu;
using DA_QuanLiThuVien.Views.UserControls.DocGia;
using DA_QuanLiThuVien.ViewModels.Main;

namespace DA_QuanLiThuVien.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();
            this.Loaded += Window_Loaded;
        }

        // Tự động mở màn hình đầu tiên theo role khi window load xong
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as MainWindowViewModel;
            if (vm?.Role == "Thủ Thư")
            {
                SetActiveButton(BtnQuanLySach);
                MainContent.Content = new UcQuanLySach();
            }
            else
            {
                SetActiveButton(BtnTimKiemSach);
                MainContent.Content = new UcTimKiemSach();
            }
        }

        private void ResetButtonBackground()
        {
            var defaultBg = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Transparent);
            var defaultFg = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#0B2545"));
            
            BtnQuanLySach.Background = defaultBg;
            BtnDocGia.Background = defaultBg;
            BtnQuanLyTKDocGia.Background = defaultBg;
            BtnMuonTra.Background = defaultBg;
            BtnBaoCao.Background = defaultBg;
            BtnCaiDat.Background = defaultBg;

            BtnQuanLySach.Foreground = defaultFg;
            BtnDocGia.Foreground = defaultFg;
            BtnQuanLyTKDocGia.Foreground = defaultFg;
            BtnMuonTra.Foreground = defaultFg;
            BtnBaoCao.Foreground = defaultFg;
            BtnCaiDat.Foreground = defaultFg;

            if (BtnTimKiemSach != null)
            {
                BtnTimKiemSach.Background = defaultBg;
                BtnTimKiemSach.Foreground = defaultFg;
                BtnSachDangMuon.Background = defaultBg;
                BtnSachDangMuon.Foreground = defaultFg;
                BtnThongTinCaNhan.Background = defaultBg;
                BtnThongTinCaNhan.Foreground = defaultFg;
            }
        }

        private void SetActiveButton(System.Windows.Controls.Button btn)
        {
            ResetButtonBackground();
            btn.Background = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#1E4D8C"));
            btn.Foreground = System.Windows.Media.Brushes.White;
        }

        private void BtnQuanLySach_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((System.Windows.Controls.Button)sender);
            MainContent.Content = new UcQuanLySach();
        }

        private void BtnDocGia_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((System.Windows.Controls.Button)sender);
            MainContent.Content = new UcDocGia();
        }

        private void BtnQuanLyTKDocGia_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((System.Windows.Controls.Button)sender);
            MainContent.Content = new UcQuanLyTKDocGia();
        }

        private void BtnMuonTra_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((System.Windows.Controls.Button)sender);
            MainContent.Content = new UcMuonTra();
        }

        private void BtnBaoCao_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((System.Windows.Controls.Button)sender);
            MainContent.Content = new UcBaoCao();
        }

        private void BtnCaiDat_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((System.Windows.Controls.Button)sender);
            MainContent.Content = new UcCaiDat();
        }

        private void BtnTimKiemSach_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((System.Windows.Controls.Button)sender);
            MainContent.Content = new UcTimKiemSach();
        }

        private void BtnSachDangMuon_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((System.Windows.Controls.Button)sender);
            MainContent.Content = new UcSachDangMuon();
        }

        private void BtnThongTinCaNhan_Click(object sender, RoutedEventArgs e)
        {
            SetActiveButton((System.Windows.Controls.Button)sender);
            MainContent.Content = new UcThongTinCaNhan();
        }

        private void BtnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                this.Closing -= Window_Closing;
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Closing -= Window_Closing;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
