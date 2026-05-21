using System.Collections.Generic;
using System.Windows.Controls;

namespace DA_QuanLiThuVien.Views.UserControls.ThuThu
{
    public partial class UcMuonTra : UserControl
    {
        public UcMuonTra()
        {
            InitializeComponent();
            LoadMockData();
        }

        private void LoadMockData()
        {
            if (Helper.UserSession.UserFullName != "Quản Trị Demo") return;

            DgMuonTra.ItemsSource = new List<object>
            {
                new { LoanId = "PM001", ReaderName = "Nguyễn Văn A (DG012)", BookTitle = "Đắc Nhân Tâm", LoanDate = "01/10/2023", DueDate = "15/10/2023", ReturnDate = "10/10/2023", Status = "Đã trả", FineAmount = 0 },
                new { LoanId = "PM002", ReaderName = "Trần Thị B (DG045)", BookTitle = "Harry Potter 1", LoanDate = "10/11/2023", DueDate = "24/11/2023", ReturnDate = "", Status = "Đang mượn", FineAmount = 0 },
                new { LoanId = "PM003", ReaderName = "Lê Hoàng C (DG088)", BookTitle = "Lập trình C# cơ bản", LoanDate = "01/11/2023", DueDate = "15/11/2023", ReturnDate = "", Status = "Quá hạn", FineAmount = 50000 },
                new { LoanId = "PM004", ReaderName = "Phạm Tuấn D (DG102)", BookTitle = "Tôi thấy hoa vàng trên cỏ xanh", LoanDate = "15/11/2023", DueDate = "29/11/2023", ReturnDate = "20/11/2023", Status = "Đã trả", FineAmount = 0 }
            };
        }
    }
}
