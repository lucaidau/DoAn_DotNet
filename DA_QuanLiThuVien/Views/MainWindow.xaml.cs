using System.Windows;
using DA_QuanLiThuVien.Views.UserControls.ThuThu;
using DA_QuanLiThuVien.Views.UserControls.DocGia;
using DA_QuanLiThuVien.ViewModels.Main;
using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel();
            LoadMenu();
        }

        private void LoadMenu()
        {
            if (UserSession.UserRole == "Thủ Thư")
            {
                var menuThuThu = new UcMenuThuThu();
                menuThuThu.OnLogout += HandleLogout;
                MainContent.Content = menuThuThu;
            }
            else
            {
                var menuDocGia = new UcMenuDocGia();
                menuDocGia.OnLogout += HandleLogout;
                MainContent.Content = menuDocGia;
            }
        }

        private void HandleLogout()
        {
            this.Closing -= Window_Closing;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc muốn thoát khỏi ứng dụng?",
                "Xác nhận thoát",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}
