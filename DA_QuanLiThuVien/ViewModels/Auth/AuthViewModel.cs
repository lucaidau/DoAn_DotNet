using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        public LoginViewModel LoginVM { get; set; }
        public RegisterViewModel RegisterVM { get; set; }
        public int SelectedTabIndex { get => _selectedTabIndex; 
            set 
            {
                _selectedTabIndex = value; 
                OnPropertyChanged(); 

                if(_selectedTabIndex == 1)
                {
                    LoginVM.UpdateUsernameSession();
                }
            } 
        }

        private int _selectedTabIndex;
        public AuthViewModel()
        {
            LoginVM = new LoginViewModel();
            RegisterVM = new RegisterViewModel(this);
        }

        /// <summary>Chuyển sang tab Đăng nhập, tự điền username vừa đăng ký.</summary>
        public void SwitchToLogin(string prefillUsername = null)
        {
            if (!string.IsNullOrEmpty(prefillUsername))
                LoginVM.Username = prefillUsername;

            SelectedTabIndex = 1;
        }

    }
}
