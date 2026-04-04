using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_QuanLiThuVien.Helper;
using DA_QuanLiThuVien.Models;

namespace DA_QuanLiThuVien.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private string _errMessage;

        public string Username { get => UserSession.UserName; set { UserSession.UserName = value; OnPropertyChanged(); } }
        public string Password { get => _password; set => _password = value; }
        public string ErrMessage { get => _errMessage; set { _errMessage = value; OnPropertyChanged(); } }

        public RelayCommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(async _ => await Login(), _ => CanExecuteLogin());
            ErrMessage = string.Empty;
        }

        public void UpdateUsernameSession()
        {
            OnPropertyChanged(nameof(Username));
        }

        private bool CanExecuteLogin()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private async Task Login()
        {
            try
            {
                using (var db = new QLThuVienEntities())
                {
                    string hashedPass = SercurityHelper.HashPassword(Password);
                }
            }
            catch (Exception ex)
            {
                ErrMessage = "Lỗi Kết Nối: " + ex.Message;
            }
        }
    }
}