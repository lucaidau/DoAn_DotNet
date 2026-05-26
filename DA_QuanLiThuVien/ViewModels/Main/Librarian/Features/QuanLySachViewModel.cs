using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels.Main.Librarian.Features
{
    /// <summary>
    /// ViewModel quản lý danh sách sách, thêm, xóa, cập nhật thông tin sách
    /// </summary>
    public class QuanLySachViewModel : BaseViewModel
    {
        private string _tieuDeChucNang = "Quản Lý Sách";
        public string TieuDeChucNang
        {
            get => _tieuDeChucNang;
            set
            {
                _tieuDeChucNang = value;
                OnPropertyChanged();
            }
        }

        public QuanLySachViewModel()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            // Khởi tạo dữ liệu cho quản lý sách
        }
    }
}
