using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using DA_QuanLiThuVien.ViewModels;
using DA_QuanLiThuVien.Views;



namespace DA_QuanLiThuVien.Views
{
    public partial class LoginWindow : Window
    {
        

        public LoginWindow()
        {
            InitializeComponent();


            this.Loaded += (s, e) =>
            {
                
                if (DataContext is AuthViewModel authVM && authVM.LoginVM != null)
                {
                    
                    authVM.LoginVM.OnLoginSuccess += () =>
                    {
                        
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Closing -= Window_Closing;

                            this.Close();
                        });
                    };
                }
            };
        }

        private void PasswordInput_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            LoginViewModel loginVM = PasswordInput.DataContext as LoginViewModel;
            if (loginVM != null)
            {
                loginVM.Password = PasswordInput.Password;
            }
        }

        private void reg_PassBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            RegisterViewModel registerVM = reg_PassBox.DataContext as RegisterViewModel;
            if(registerVM != null)
            {
                registerVM.NewUser.Password = reg_PassBox.Password;
            }
        }

        private void NumberOnly(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "[0-9]");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn thoát?","Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
