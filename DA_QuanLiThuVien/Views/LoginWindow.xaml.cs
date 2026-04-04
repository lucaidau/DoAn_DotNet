using System.Windows;
using System.Windows.Controls;
using DA_QuanLiThuVien.ViewModels;



namespace DA_QuanLiThuVien.Views
{
    public partial class LoginWindow : Window
    {
        

        public LoginWindow()
        {
            InitializeComponent();
            
        }

        private void PasswordInput_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            LoginViewModel loginVM = PasswordInput.DataContext as LoginViewModel;
        }

        private void reg_PassBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            RegisterViewModel registerVM = reg_PassBox.DataContext as RegisterViewModel;
            if(registerVM != null)
            {
                registerVM.NewUser.Password = reg_PassBox.Password;
            }
        }
    }
}
