using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels.Main.Librarian.Features
{
    /// <summary>
    /// ViewModel báo cáo thống kê, xem lịch sử mượn trả, thống kê sử dụng
    /// </summary>
    public class BaoCaoViewModel : BaseViewModel
    {
        private string _tieuDeChucNang = "Báo Cáo Thống Kê";
        public string TieuDeChucNang
        {
            get => _tieuDeChucNang;
            set
            {
                _tieuDeChucNang = value;
                OnPropertyChanged();
            }
        }

        public BaoCaoViewModel()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            // Khởi tạo dữ liệu cho báo cáo
        }
    }
}
