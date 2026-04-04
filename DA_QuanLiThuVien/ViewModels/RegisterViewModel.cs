using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DA_QuanLiThuVien.Helper;
using DA_QuanLiThuVien.Models;

namespace DA_QuanLiThuVien.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
       
        private UserModel _newUser;

        public UserModel NewUser
        { 
            get => _newUser;
            set
            {
                _newUser = value;
                OnPropertyChanged();
            }
        }


        private string _errMessage;
        public string ErrMessage { get => _errMessage; set { _errMessage = value; OnPropertyChanged(); } }

        public bool IsLibrarian
        {
            get=> NewUser.Role;
            set
            {
                if(value)
                {
                    NewUser.Role = true;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsReader));
                }
            }
        }

        public bool IsReader
        {
            get => !NewUser.Role;
            set
            {
                if (value)
                {
                    NewUser.Role = false;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsLibrarian));
                }
            }
        }

        public string[] GenderOptions { get; } = new[] { "Nam", "Nữ" };
        private string _selectedGender;

        public string SelectedGender 
        {
            get => _selectedGender; 
            set
            {
                _selectedGender = value;
                
                OnPropertyChanged();
                NewUser.GioiTinh = _selectedGender == "Nam";
            }
        }

        public RelayCommand RegisterCommand { get; }

        private bool CanRegister()
        {
            return !string.IsNullOrEmpty(NewUser.HoTen) &&
                   !string.IsNullOrEmpty(NewUser.TenTK) &&
                   !string.IsNullOrEmpty(NewUser.SDT) &&
                   !string.IsNullOrEmpty(NewUser.Email) &&
                   !string.IsNullOrEmpty(NewUser.HashMK);
        }

        private async Task ExecuteRegister()
        {
            try
            {
                string rawPass = NewUser.HashMK;
                string hashedPass = SercurityHelper.HashPassword(rawPass);
                NewUser.HashMK = hashedPass;

                bool isSuccess = await ThemTaiKhoanToDB();
                if (isSuccess)
                {
                    
                    ErrMessage = "Đăng ký thành công!\n";

                    await Task.Delay(1000);
                    if (_authVM != null)
                    {
                        _authVM.SelectedTabIndex = 1;
                        ErrMessage = string.Empty;

                    }
                    NewUser = new UserModel();
                }

                else
                {
                    ErrMessage = "Tên đăng nhập hoặc số điện thoại đã tồn tại!!";
                    System.Windows.MessageBox.Show("Hàm trả về FALSE - Kiểm tra lại SQL!");
                }
            }
            catch (Exception ex) 
            {
                System.Windows.MessageBox.Show("Lỗi tại: "+ ex.Message);
            }

            

        }

        private AuthViewModel _authVM;
        public RegisterViewModel(AuthViewModel authVM)
        {
            NewUser = new UserModel();
            RegisterCommand = new RelayCommand(async _ => await ExecuteRegister(), _ => CanRegister());
            _authVM = authVM;
        }

        public async Task<bool> ThemTaiKhoanToDB()
        {
            string conString = ConfigurationManager.ConnectionStrings["ThuVienDB"].ConnectionString;
            
            using (SqlConnection conn = new SqlConnection(conString))
            {
                try
                {
                    await conn.OpenAsync();
                    Console.WriteLine("Kết nối thành công");
                    SqlCommand cmd = new SqlCommand("sp_DangKi", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@fullName", NewUser.HoTen);
                    cmd.Parameters.AddWithValue("@userName", NewUser.TenTK);
                    cmd.Parameters.AddWithValue("@phoneNumber", NewUser.SDT);
                    cmd.Parameters.AddWithValue("@email", NewUser.Email);
                    cmd.Parameters.AddWithValue("@gender", NewUser.GioiTinh);
                    cmd.Parameters.AddWithValue("@hashPass", NewUser.HashMK);
                    cmd.Parameters.AddWithValue("@role", NewUser.Role);
                    
                    object result = await cmd.ExecuteScalarAsync();
                    return Convert.ToInt32(result) == 1;
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString(), "Lỗi SQL Chi Tiết");
                    return false;
                }
            }
        }
    }
}
