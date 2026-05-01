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
        public ReaderViewModel ReaderVM { get; set; }
        public LibrarianViewModel LibrarianVM { get; set; }

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
        public string Role { get => _role; set { _role = value; OnPropertyChanged(); } }
        
        public string Title
        {
            get
            {
                if (Role == "Thủ Thư")
                    return "Quản lý danh mục sách, cập nhật nhanh và theo dõi tình trạng hiện tại";
                else
                    return "Tìm kiếm sách, ";
            }
        }

        public Visibility LibrarianVisibility => Role == "Thủ Thư" ? Visibility.Visible : Visibility.Collapsed;
        public Visibility ReaderVisibility => Role == "Đọc Giả" ? Visibility.Visible : Visibility.Collapsed;


        private void SetupModules(string role)
        {
            if (Role == "Thủ Thư")
            {
                LibrarianVM = new LibrarianViewModel();
                CurrentView = LibrarianVM;
            }
            else
            {
                ReaderVM = new ReaderViewModel();
                CurrentView = ReaderVM;
            }
        }

        public MainWindowViewModel()
        {
            Role = UserSession.UserRole;
            OnPropertyChanged(nameof(Title));
            SetupModules(Role);
        }
    }
}
