using System.Windows;
using DA_QuanLiThuVien.Views.UserControls.ThuThu;


namespace Qltv.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ResetButtonBackground()
        {
            var defaultBg = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Transparent);
            var defaultFg = new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#0B2545"));
            
            BtnQuanLySach.Background = defaultBg;
            BtnDocGia.Background = defaultBg;
            BtnMuonTra.Background = defaultBg;
            BtnBaoCao.Background = defaultBg;
            BtnCaiDat.Background = defaultBg;

            BtnQuanLySach.Foreground = defaultFg;
            BtnDocGia.Foreground = defaultFg;
            BtnMuonTra.Foreground = defaultFg;
            BtnBaoCao.Foreground = defaultFg;
            BtnCaiDat.Foreground = defaultFg;
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
    }
}
