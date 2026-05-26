using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels.Main.Librarian.Features
{
    public class ThongKeNangCaoViewModel : BaseViewModel
    {
        private string _tieuDeChucNang = "Thống Kê Nâng Cao";
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
