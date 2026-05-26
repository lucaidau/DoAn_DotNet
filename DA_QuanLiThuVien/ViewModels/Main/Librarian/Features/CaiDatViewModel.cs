using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels.Main.Librarian.Features
{
    /// <summary>
    /// ViewModel cài đặt hệ thống, quản lý cấu hình ứng dụng
    /// </summary>
    public class CaiDatViewModel : BaseViewModel
    {
        private string _tieuDeChucNang = "Cài Đặt";
        public string TieuDeChucNang
        {
            get => _tieuDeChucNang;
            set
            {
                _tieuDeChucNang = value;
                OnPropertyChanged();
            }
        }

        public CaiDatViewModel()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            // Khởi tạo dữ liệu cho cài đặt
        }
    }
}
