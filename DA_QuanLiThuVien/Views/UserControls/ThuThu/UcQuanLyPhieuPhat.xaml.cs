using System.Collections.Generic;
using System.Windows.Controls;

namespace DA_QuanLiThuVien.Views.UserControls.ThuThu
{
    public partial class UcQuanLyPhieuPhat : UserControl
    {
        public UcQuanLyPhieuPhat()
        {
            InitializeComponent();
            LoadMockData();
        }

        private void LoadMockData()
        {
            if (Helper.UserSession.UserFullName != "Quản Trị Demo") return;

            DgPhieuPhat.ItemsSource = new List<object>
            {
                new { MaPhieu = "PP001", DocGia = "Nguyễn Văn A (DG012)", SachViPham = "Đắc Nhân Tâm", LyDo = "Trả sách trễ 5 ngày", TienPhat = "25,000 VNĐ", TinhTrang = "Chưa nộp" },
                new { MaPhieu = "PP002", DocGia = "Trần Thị B (DG045)", SachViPham = "Harry Potter 1", LyDo = "Làm rách 3 trang sách", TienPhat = "50,000 VNĐ", TinhTrang = "Đã nộp" },
                new { MaPhieu = "PP003", DocGia = "Lê Hoàng C (DG088)", SachViPham = "Lập trình C# cơ bản", LyDo = "Mất sách", TienPhat = "120,000 VNĐ", TinhTrang = "Chưa nộp" },
                new { MaPhieu = "PP004", DocGia = "Phạm Tuấn D (DG102)", SachViPham = "Tôi thấy hoa vàng trên cỏ xanh", LyDo = "Trả sách trễ 2 ngày", TienPhat = "10,000 VNĐ", TinhTrang = "Đã nộp" }
            };
        }
    }
}
