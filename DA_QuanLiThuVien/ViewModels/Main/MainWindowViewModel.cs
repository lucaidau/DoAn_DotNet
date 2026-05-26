using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DA_QuanLiThuVien.Helper;
using DA_QuanLiThuVien.ViewModels.Main.Reader;
using DA_QuanLiThuVien.ViewModels.Main.Librarian;

namespace DA_QuanLiThuVien.ViewModels.Main
{
    public class MainWindowViewModel:BaseViewModel
    {
        public ReaderViewModel ReaderVM { get; }
        public LibrarianViewModel LibrarianVM { get; }

        private object _currentView;
        public object CurrentView 
        {
            get => _currentView; 
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private string _role;
        public string Role
        {
            get => _role;
            set
            {
                if (_role == value)
                {
                    return;
                }

                _role = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(LibrarianVisibility));
                OnPropertyChanged(nameof(ReaderVisibility));
                SetupModules(_role);
            }
        }
        
        public string Title
        {
            get
            {
                if (Role == "Thủ Thư")
                    return "Quản lý danh mục sách, cập nhật nhanh và theo dõi tình trạng hiện tại";
                else
                    return "Tìm kiếm sách, xem lịch sử mượn trả và quản lý giỏ sách";
            }
        }

        public Visibility LibrarianVisibility => Role == "Thủ Thư" ? Visibility.Visible : Visibility.Collapsed;
        public Visibility ReaderVisibility => Role == "Đọc Giả" ? Visibility.Visible : Visibility.Collapsed;


        private void SetupModules(string role)
        {
            if (role == "Thủ Thư")
            {
                CurrentView = LibrarianVM;
            }
            else
            {
                CurrentView = ReaderVM;
            }
        }

        public MainWindowViewModel()
        {
            ReaderVM = new ReaderViewModel();
            LibrarianVM = new LibrarianViewModel();
            Role = UserSession.UserRole;
        }

        public void SwitchToLibrarian()
        {
            Role = "Thủ Thư";
        }

        public void SwitchToReader()
        {
            Role = "Đọc Giả";
        }
    }
}
