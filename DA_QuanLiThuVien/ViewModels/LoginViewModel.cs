using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels
{
    public class LoginViewModel
    {
        private string _username;
        private string _password;

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }

        public LoginViewModel() 
        {
            Username = UserSession.UserName;
        }

    }
}
