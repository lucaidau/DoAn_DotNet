using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels.Main.Librarian.Features
{
    public class QuanLyTacGiaViewModel : BaseViewModel
    {
        private string _tieuDeChucNang = "Quản Lý Tác Giả, NXB, Thể Loại";
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
