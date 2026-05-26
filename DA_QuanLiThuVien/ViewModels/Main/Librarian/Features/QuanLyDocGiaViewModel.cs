using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels.Main.Librarian.Features
{
    /// <summary>
    /// ViewModel quản lý thông tin độc giả, cập nhật tài khoản, khóa tài khoản
    /// </summary>
    public class QuanLyDocGiaViewModel : BaseViewModel
    {
        private string _tieuDeChucNang = "Quản Lý Độc Giả";
        public string TieuDeChucNang
        {
            get => _tieuDeChucNang;
            set
            {
                _tieuDeChucNang = value;
                OnPropertyChanged();
            }
        }

        public QuanLyDocGiaViewModel()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            // Khởi tạo dữ liệu cho quản lý độc giả
        }
    }
}
