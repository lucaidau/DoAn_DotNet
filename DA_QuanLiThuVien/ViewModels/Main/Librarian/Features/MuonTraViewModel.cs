using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels.Main.Librarian.Features
{
    /// <summary>
    /// ViewModel quản lý mượn trả sách, xử lý yêu cầu mượn, trả sách
    /// </summary>
    public class MuonTraViewModel : BaseViewModel
    {
        private string _tieuDeChucNang = "Mượn Trả Sách";
        public string TieuDeChucNang
        {
            get => _tieuDeChucNang;
            set
            {
                _tieuDeChucNang = value;
                OnPropertyChanged();
            }
        }

        public MuonTraViewModel()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            // Khởi tạo dữ liệu cho mượn trả
        }
    }
}
