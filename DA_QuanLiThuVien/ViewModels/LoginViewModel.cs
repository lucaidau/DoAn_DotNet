using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        
        private string _username;
        private string _password;
        private string _errMessage;
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }
        public string Username { get => _username; set  { _username = value; OnPropertyChanged(); } }
        public string ErrMessage { get => _errMessage; set { _errMessage = value; OnPropertyChanged(); } }

        public LoginViewModel( )
        {
           
            LoginCommand = new RelayCommand(_ => ExecuteLogin(), _ => CanExecuteLogin());
        }


        public RelayCommand LoginCommand { get; }

        public bool CanExecuteLogin()
        {
            if(Password == null)
            {
                ErrMessage = "Vui lòng nhập mật khẩu!";
            }    
            
            return !string.IsNullOrEmpty(Username) ;
        }

        public void ExecuteLogin()
        {
           
        }

        //private async Task<bool> KiemTraDangNhap()
        //{
        //    string conString = ConfigurationManager.ConnectionStrings["ThuVienDB"].ConnectionString;
        //}
    }
}
