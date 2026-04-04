using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_QuanLiThuVien.Models.Auth
{
    public class NewUserModel
    {
        private string _fullName;
        private string _userName;
        private string _password;
        private string _phoneNumber;
        private string _email;
        private bool _gender;
        private bool _role;

        public string FullName { get => _fullName; set => _fullName = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Email { get => _email; set => _email = value; }
        public bool Gender { get => _gender; set => _gender = value; }
        public bool Role { get => _role; set => _role = value; }
    }
}
