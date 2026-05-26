using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DA_QuanLiThuVien.Helper;
using DA_QuanLiThuVien.ViewModels.Main.Librarian.Features;

namespace DA_QuanLiThuVien.ViewModels.Main.Librarian
{
    /// <summary>
    /// ViewModel chính cho Thủ Thư - quản lý tất cả các chức năng liên quan đến thủ thư
    /// </summary>
    public class LibrarianViewModel : BaseViewModel
    {
        // ===== Properties cho các Feature ViewModels =====
        public QuanLySachViewModel quanLySachVM { get; }
        public QuanLyTacGiaViewModel quanLyTacGiaVM { get; }
        public QuanLyBanSaoSachViewModel quanLyBanSaoSachVM { get; }
        public NhapSachViewModel nhapSachVM { get; }
        public MuonTraViewModel muonTraVM { get; }
        public QuanLyDocGiaViewModel quanLyDocGiaVM { get; }
        public BaoCaoViewModel baoCaoVM { get; }
        public ThongKeNangCaoViewModel thongKeNangCaoVM { get; }
        public CaiDatViewModel caiDatVM { get; }
        public QuanLyTaiKhoanDocGiaViewModel quanLyTaiKhoanDocGiaVM { get; }

        // ===== Properties cho UI hiển thị =====
        private object _viewModelHienTai;
        public object ViewModelHienTai
        {
            get => _viewModelHienTai;
            set
            {
                _viewModelHienTai = value;
                OnPropertyChanged();
            }
        }

        private string _tieuDeChucNang;
        public string TieuDeChucNang
        {
            get => _tieuDeChucNang;
            set
            {
                _tieuDeChucNang = value;
                OnPropertyChanged();
            }
        }

        // ===== Commands =====
        public ICommand ChuyenQuanLySachCommand { get; }
        public ICommand ChuyenQuanLyTacGiaCommand { get; }
        public ICommand ChuyenQuanLyBanSaoSachCommand { get; }
        public ICommand ChuyenNhapSachCommand { get; }
        public ICommand ChuyenMuonTraCommand { get; }
        public ICommand ChuyenQuanLyDocGiaCommand { get; }
        public ICommand ChuyenBaoCaoCommand { get; }
        public ICommand ChuyenThongKeNangCaoCommand { get; }
        public ICommand ChuyenCaiDatCommand { get; }
        public ICommand ChuyenQuanLyTaiKhoanCommand { get; }

        // ===== Menu Items =====
        public List<MenuItem> DanhSachChucNang { get; }

        public LibrarianViewModel()
        {
            // Khởi tạo tất cả feature ViewModels
            quanLySachVM = new QuanLySachViewModel();
            quanLyTacGiaVM = new QuanLyTacGiaViewModel();
            quanLyBanSaoSachVM = new QuanLyBanSaoSachViewModel();
            nhapSachVM = new NhapSachViewModel();
            muonTraVM = new MuonTraViewModel();
            quanLyDocGiaVM = new QuanLyDocGiaViewModel();
            baoCaoVM = new BaoCaoViewModel();
            thongKeNangCaoVM = new ThongKeNangCaoViewModel();
            caiDatVM = new CaiDatViewModel();
            quanLyTaiKhoanDocGiaVM = new QuanLyTaiKhoanDocGiaViewModel();

            // Khởi tạo Commands
            ChuyenQuanLySachCommand = new RelayCommand(_ => ChuyenQuanLySach());
            ChuyenQuanLyTacGiaCommand = new RelayCommand(_ => ChuyenQuanLyTacGia());
            ChuyenQuanLyBanSaoSachCommand = new RelayCommand(_ => ChuyenQuanLyBanSaoSach());
            ChuyenNhapSachCommand = new RelayCommand(_ => ChuyenNhapSach());
            ChuyenMuonTraCommand = new RelayCommand(_ => ChuyenMuonTra());
            ChuyenQuanLyDocGiaCommand = new RelayCommand(_ => ChuyenQuanLyDocGia());
            ChuyenBaoCaoCommand = new RelayCommand(_ => ChuyenBaoCao());
            ChuyenThongKeNangCaoCommand = new RelayCommand(_ => ChuyenThongKeNangCao());
            ChuyenCaiDatCommand = new RelayCommand(_ => ChuyenCaiDat());
            ChuyenQuanLyTaiKhoanCommand = new RelayCommand(_ => ChuyenQuanLyTaiKhoan());

            // Khởi tạo Menu Items với Commands
            DanhSachChucNang = new List<MenuItem>
            {
                new MenuItem("Quản Lý Sách", ChuyenQuanLySachCommand),
                new MenuItem("Quản Lý Tác Giả/NXB/Thể Loại", ChuyenQuanLyTacGiaCommand),
                new MenuItem("Quản Lý Bản Sao", ChuyenQuanLyBanSaoSachCommand),
                new MenuItem("Nhập Sách", ChuyenNhapSachCommand),
                new MenuItem("Mượn Trả", ChuyenMuonTraCommand),
                new MenuItem("Quản Lý Độc Giả", ChuyenQuanLyDocGiaCommand),
                new MenuItem("Quản Lý Tài Khoản", ChuyenQuanLyTaiKhoanCommand),
                new MenuItem("Báo Cáo", ChuyenBaoCaoCommand),
                new MenuItem("Thống Kê Nâng Cao", ChuyenThongKeNangCaoCommand),
                new MenuItem("Cài Đặt", ChuyenCaiDatCommand)
            };

            // Mặc định hiển thị Quản Lý Sách
            ChuyenQuanLySach();
        }

        // ===== Methods chuyển đổi chức năng =====
        private void ChuyenQuanLySach()
        {
            ViewModelHienTai = quanLySachVM;
            TieuDeChucNang = "Quản Lý Sách";
        }

        private void ChuyenQuanLyTacGia()
        {
            ViewModelHienTai = quanLyTacGiaVM;
            TieuDeChucNang = "Quản Lý Tác Giả, NXB, Thể Loại";
        }

        private void ChuyenQuanLyBanSaoSach()
        {
            ViewModelHienTai = quanLyBanSaoSachVM;
            TieuDeChucNang = "Quản Lý Bản Sao Sách";
        }

        private void ChuyenNhapSach()
        {
            ViewModelHienTai = nhapSachVM;
            TieuDeChucNang = "Nhập Sách";
        }

        private void ChuyenMuonTra()
        {
            ViewModelHienTai = muonTraVM;
            TieuDeChucNang = "Mượn Trả Sách";
        }

        private void ChuyenQuanLyDocGia()
        {
            ViewModelHienTai = quanLyDocGiaVM;
            TieuDeChucNang = "Quản Lý Độc Giả";
        }

        private void ChuyenBaoCao()
        {
            ViewModelHienTai = baoCaoVM;
            TieuDeChucNang = "Báo Cáo Thống Kê";
        }

        private void ChuyenThongKeNangCao()
        {
            ViewModelHienTai = thongKeNangCaoVM;
            TieuDeChucNang = "Thống Kê Nâng Cao";
        }

        private void ChuyenCaiDat()
        {
            ViewModelHienTai = caiDatVM;
            TieuDeChucNang = "Cài Đặt Hệ Thống";
        }

        private void ChuyenQuanLyTaiKhoan()
        {
            ViewModelHienTai = quanLyTaiKhoanDocGiaVM;
            TieuDeChucNang = "Quản Lý Tài Khoản Độc Giả";
        }
    }
}
