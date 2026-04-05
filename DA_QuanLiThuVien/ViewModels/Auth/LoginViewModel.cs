using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DA_QuanLiThuVien.Helper;
using DA_QuanLiThuVien.Models;
using DA_QuanLiThuVien.Views;

namespace DA_QuanLiThuVien.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private string _errMessage;

        public string Username { get => UserSession.UserFullName; set { UserSession.UserFullName = value; OnPropertyChanged(); } }
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

        public Action OnLoginSuccess;
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
                    var res = db.sp_DangNhap
                        (
                            Username,
                            hashedPass
                        ).FirstOrDefault();

                    if(res != null && res.Result == 1)
                    {
                        UserSession.UserID = res.IDTaiKhoan;
                        UserSession.UserFullName = res.HoTen;
                        UserSession.UserRole = res.Role == 1 ? "Thủ Thư" : "Đọc Giả";
                        ErrMessage = "Đăng Nhập Thành Công!";

                        await Task.Delay(1000);

                        OnLoginSuccess?.Invoke();
                        MessageBox.Show("Thông tin người dùng: " + UserSession.UserFullName + " - " + UserSession.UserRole, "Thông Tin Đăng Nhập", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        ErrMessage = "Đăng Nhập Thất Bại: Sai Tên Đăng Nhập Hoặc Mật Khẩu!";
                    }
                }

                
            }
            catch (Exception ex)
            {
                ErrMessage = "Lỗi Kết Nối: " + ex.Message;
            }
        }
    }
}