using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using DA_QuanLiThuVien.Helper;
using DA_QuanLiThuVien.Models;
using DA_QuanLiThuVien.Models.Auth;

namespace DA_QuanLiThuVien.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
        public NewUserModel NewUser { get; set; }
        private AuthViewModel _authViewModel;
        private string _errMessage;
        public string ErrMessage { get => _errMessage; set { _errMessage = value; OnPropertyChanged(); } }

        public AuthViewModel AuthViewModel { get => _authViewModel; set => _authViewModel = value; }
        public RelayCommand RegisterCommand { get; }


        private bool _isLibrarian;
        private bool _isReader = true;
        public bool IsLibrarian 
        {
            get => _isLibrarian; 
            set
            {
                _isLibrarian = value;
                OnPropertyChanged();
            }
        }
        public bool IsReader { get => _isReader; set { _isReader = value; OnPropertyChanged(); }}

        public List<string> GenderOptions { get; set; } = new List<string> { "Nam", "Nữ" };

        private string _selectedGender;
        public string SelectedGender { get => _selectedGender; 
            set 
            {
                _selectedGender = value;
                OnPropertyChanged(); 

                if(NewUser != null)
                {
                    NewUser.Gender = (_selectedGender == "Nam");
                }
            }
        }

        public RegisterViewModel(AuthViewModel parent)
        {
            NewUser = new NewUserModel();

            AuthViewModel = parent;
            RegisterCommand = new RelayCommand(async _ =>await Register(), _ => CanExecuteRegister());
            SelectedGender = GenderOptions.FirstOrDefault();
        }


        
        public async Task Register()
        {
            if(!Validate())
            {
                return;
            }

            NewUser.Role = IsLibrarian;

            try
            {
                using (var db = new QLThuVienEntities())
                {
                    var res = db.sp_DangKi
                        (
                        NewUser.FullName,
                        NewUser.UserName,
                        NewUser.PhoneNumber,
                        NewUser.Email,
                        NewUser.Gender,
                        SercurityHelper.HashPassword(NewUser.Password),
                        NewUser.Role
                        ).FirstOrDefault();

                    if (res == 1) ErrMessage = "Đăng kí thành công";
                    else if (res == 0) ErrMessage = "Tên tài khoản đã tồn tại. Vui lòng chọn tên khác.";
                    else ErrMessage = "Đăng kí thất bại. Vui lòng thử lại.";
                }
                UserSession.UserFullName = NewUser.UserName;

                

                await Task.Delay(1000);

                if (AuthViewModel != null)
                {
                    AuthViewModel.SelectedTabIndex = 1;
                }


                NewUser = new NewUserModel();
                OnPropertyChanged(nameof(NewUser));
                ErrMessage = "";
            }
            catch (Exception ex)
            {
                ErrMessage = "Lỗi Kết Nối: " + ex.Message;
               
            }

           
        }

        public bool CanExecuteRegister()
        {
            if (string.IsNullOrEmpty(NewUser.FullName) ||
               string.IsNullOrEmpty(NewUser.UserName) ||
               string.IsNullOrEmpty(NewUser.Password) ||
               string.IsNullOrEmpty(NewUser.Email))
            {
              
                return false;
            }
            
            return true;
        }

        private bool Validate()
        {
            if(string.IsNullOrEmpty(NewUser.FullName) ||
               string.IsNullOrEmpty(NewUser.UserName) ||
               string.IsNullOrEmpty(NewUser.Password) ||
               string.IsNullOrEmpty(NewUser.Email))
            {
                ErrMessage = "Vui lòng điền đầy đủ thông tin.";
                return false;
            }
           
            if(NewUser.Password.Length <8)
            {
                ErrMessage = "Mật khẩu phải có ít nhất 8 ký tự.";
                return false;
            }
            if(!NewUser.Email.Contains("@") || !NewUser.Email.Contains("."))
            {
                ErrMessage = "Email không hợp lệ.";
                return false;
            }
            string  partenn = @"^0\d{9}$";
            if (string.IsNullOrEmpty(NewUser.PhoneNumber) || !Regex.IsMatch(NewUser.PhoneNumber, partenn))
            {
                ErrMessage = "Số điện thoại không hợp lệ. Vui lòng nhập số điện thoại 10 chữ số bắt đầu bằng 0.";
                return false;
            }
            
            return true;
        }
    }
}
