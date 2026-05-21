using System.Collections.Generic;
using System.Windows.Controls;

namespace DA_QuanLiThuVien.Views.UserControls.ThuThu
{
    public partial class UcXyLyYeuCau : UserControl
    {
        public UcXyLyYeuCau()
        {
            InitializeComponent();
            LoadMockData();
        }

        private void LoadMockData()
        {
            if (Helper.UserSession.UserFullName != "Quản Trị Demo") return;

            DgYeuCauMuon.ItemsSource = new List<object>
            {
                new { MaYeuCau = "YC001", DocGia = "Nguyễn Văn A (DG012)", SachYeuCau = "Nhà Giả Kim", NgayTao = "20/11/2023", TrangThai = "Chờ duyệt" },
                new { MaYeuCau = "YC002", DocGia = "Trần Thị B (DG045)", SachYeuCau = "Sapiens - Lược sử loài người", NgayTao = "21/11/2023", TrangThai = "Đã duyệt - Đang giữ sách" },
                new { MaYeuCau = "YC003", DocGia = "Lê Hoàng C (DG088)", SachYeuCau = "Clean Code", NgayTao = "21/11/2023", TrangThai = "Từ chối (Hết sách)" }
            };

            DgGopY.ItemsSource = new List<object>
            {
                new { MaGopY = "GY101", DocGia = "Phạm Tuấn D (DG102)", NoiDung = "Thư viện nên mua thêm sách về Trí tuệ nhân tạo (AI)", NgayGui = "15/11/2023" },
                new { MaGopY = "GY102", DocGia = "Nguyễn Văn A (DG012)", NoiDung = "Điều hòa phòng đọc số 2 hơi yếu, mong ban quản lý kiểm tra lại", NgayGui = "18/11/2023" },
                new { MaGopY = "GY103", DocGia = "Khách vãng lai", NoiDung = "Thủ thư hướng dẫn rất nhiệt tình. Xin cảm ơn!", NgayGui = "20/11/2023" }
            };
        }
    }
}
