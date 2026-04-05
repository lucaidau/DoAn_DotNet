using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels.Main
{
    public class MainWindowViewModel:BaseViewModel
    {
        public ReaderViewModel ReaderVM { get; set; }
        public LibrarianViewModel LibrarianVM { get; set; }
        private string _role;
        public string Role { get => _role; set { _role = value; OnPropertyChanged(); } }
        public string Title
        {
            get
            {
                if (Role == "Thủ Thư")
                    return "Quản lý danh mục sách, cập nhật nhanh và theo dõi tình trạng hiện tại";
                else
                    return "";
            }
        }

        public Visibility LibrarianVisibility => Role == "Thủ Thư" ? Visibility.Visible : Visibility.Collapsed;
        public Visibility ReaderVisibility => Role == "Đọc Giả" ? Visibility.Visible : Visibility.Collapsed;

        public MainWindowViewModel()
        {
            ReaderVM = new ReaderViewModel();
            LibrarianVM = new LibrarianViewModel();
            Role = UserSession.UserRole;
            OnPropertyChanged(nameof(Title));
        }
    }
}
