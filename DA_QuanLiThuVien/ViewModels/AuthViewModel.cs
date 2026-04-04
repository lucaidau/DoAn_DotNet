using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_QuanLiThuVien.Helper;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace DA_QuanLiThuVien.ViewModels
{
    public class AuthViewModel:BaseViewModel
    {
        private int _selectedTabIndex;
        public int SelectedTabIndex { get => _selectedTabIndex; set { _selectedTabIndex = value; OnPropertyChanged(); } }
        public LoginViewModel LoginVM { get; set; }
        public RegisterViewModel RegisterVM { get; set; }

        public AuthViewModel()
        {
            LoginVM = new LoginViewModel();
            RegisterVM = new RegisterViewModel(this);
        }
    }
}
