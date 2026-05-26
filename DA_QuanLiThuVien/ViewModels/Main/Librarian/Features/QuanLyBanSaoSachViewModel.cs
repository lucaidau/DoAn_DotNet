using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels.Main.Librarian.Features
{
    public class QuanLyBanSaoSachViewModel : BaseViewModel
    {
        private string _tieuDeChucNang = "Quản Lý Bản Sao Sách";
        public string TieuDeChucNang
        {
            get => _tieuDeChucNang;
            set
            {
                _tieuDeChucNang = value;
                OnPropertyChanged();
            }
        }
    }
}
