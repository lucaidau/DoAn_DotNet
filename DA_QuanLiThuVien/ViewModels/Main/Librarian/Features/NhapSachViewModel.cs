using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels.Main.Librarian.Features
{
    public class NhapSachViewModel : BaseViewModel
    {
        private string _tieuDeChucNang = "Nhập Sách";
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
