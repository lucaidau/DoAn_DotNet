using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels.Main.Librarian.Features
{
    /// <summary>
    /// ViewModel quản lý tài khoản độc giả, cấp quyền, khóa tài khoản
    /// </summary>
    public class QuanLyTaiKhoanDocGiaViewModel : BaseViewModel
    {
        private string _tieuDeChucNang = "Quản Lý Tài Khoản Độc Giả";
        public string TieuDeChucNang
        {
            get => _tieuDeChucNang;
            set
            {
                _tieuDeChucNang = value;
                OnPropertyChanged();
            }
        }

        public QuanLyTaiKhoanDocGiaViewModel()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            // Khởi tạo dữ liệu cho quản lý tài khoản độc giả
        }
    }
}
