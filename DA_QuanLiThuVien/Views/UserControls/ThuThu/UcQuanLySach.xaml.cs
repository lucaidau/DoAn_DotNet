using System.Collections.Generic;
using System.Windows.Controls;

namespace DA_QuanLiThuVien.Views.UserControls.ThuThu
{
    public partial class UcQuanLySach : UserControl
    {
        public UcQuanLySach()
        {
            InitializeComponent();
            LoadMockData();
        }

        private void LoadMockData()
        {
            if (Helper.UserSession.UserFullName != "Quản Trị Demo") return;

            DgSach.ItemsSource = new List<object>
            {
                new { Title = "Đắc Nhân Tâm", Author = "Dale Carnegie", Category = "Kỹ năng sống", Isbn = "9786043120152", PublishYear = 2021, IsAvailable = true },
                new { Title = "Nhà Giả Kim", Author = "Paulo Coelho", Category = "Tiểu thuyết", Isbn = "9786045330364", PublishYear = 2020, IsAvailable = true },
                new { Title = "Lập trình C# cơ bản", Author = "Nguyễn Văn A", Category = "Giáo trình IT", Isbn = "9786049987654", PublishYear = 2022, IsAvailable = false },
                new { Title = "Harry Potter và Hòn đá Phù thủy", Author = "J.K. Rowling", Category = "Thiếu nhi", Isbn = "9786041098765", PublishYear = 2019, IsAvailable = true }
            };
        }
    }
}
