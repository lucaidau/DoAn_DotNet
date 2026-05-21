using System.Collections.Generic;
using System.Windows.Controls;

namespace DA_QuanLiThuVien.Views.UserControls.ThuThu
{
    public partial class UcQuanLyDanhMuc : UserControl
    {
        public UcQuanLyDanhMuc()
        {
            InitializeComponent();
            LoadMockData();
        }

        private void LoadMockData()
        {
            if (Helper.UserSession.UserFullName != "Quản Trị Demo") return;

            DgTheLoai.ItemsSource = new List<object>
            {
                new { MaTL = "TL001", TenTL = "Khoa học Viễn tưởng", GhiChu = "Sách về vũ trụ, công nghệ tương lai" },
                new { MaTL = "TL002", TenTL = "Văn học Cổ điển", GhiChu = "Tác phẩm kinh điển" },
                new { MaTL = "TL003", TenTL = "Kỹ năng sống", GhiChu = "Self-help, phát triển bản thân" },
                new { MaTL = "TL004", TenTL = "Lịch sử & Địa lý", GhiChu = "Các tài liệu nghiên cứu lịch sử" }
            };

            DgTacGia.ItemsSource = new List<object>
            {
                new { MaTG = "TG001", TenTG = "Nguyễn Nhật Ánh", QuocTich = "Việt Nam", GhiChu = "Nhà văn viết cho thiếu nhi" },
                new { MaTG = "TG002", TenTG = "J.K. Rowling", QuocTich = "Anh", GhiChu = "Tác giả Harry Potter" },
                new { MaTG = "TG003", TenTG = "Dale Carnegie", QuocTich = "Mỹ", GhiChu = "Tác giả Đắc Nhân Tâm" }
            };

            DgNhaXuatBan.ItemsSource = new List<object>
            {
                new { MaNXB = "NXB01", TenNXB = "NXB Trẻ", DiaChi = "161B Lý Chính Thắng, TP.HCM", LienHe = "028 3931 6289" },
                new { MaNXB = "NXB02", TenNXB = "Kim Đồng", DiaChi = "55 Quang Trung, Hà Nội", LienHe = "1900 571 595" },
                new { MaNXB = "NXB03", TenNXB = "Nhã Nam", DiaChi = "59 Đỗ Quang, Hà Nội", LienHe = "024 3514 6876" }
            };
        }
    }
}
