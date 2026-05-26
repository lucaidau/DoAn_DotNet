using System.Windows;
using DA_QuanLiThuVien.ViewModels.Main;

namespace DA_QuanLiThuVien.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Closing -= Window_Closing;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
