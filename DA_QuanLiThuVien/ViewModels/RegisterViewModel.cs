using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DA_QuanLiThuVien.Helper;
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
        }


        
        public async Task Register()
        {
            if (string.IsNullOrEmpty(NewUser.FullName) ||
               string.IsNullOrEmpty(NewUser.UserName) ||
               string.IsNullOrEmpty(NewUser.Password) ||
               string.IsNullOrEmpty(NewUser.Email))
            {
                ErrMessage = "Vui lòng điền đầy đủ thông tin.";
                return;
            }
            NewUser.Role = IsLibrarian;
            ErrMessage = "Đăng ký thành công. ";
            await Task.Delay(1000);
           
            AuthViewModel.SelectedTabIndex = 1;
           
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

    }
}
