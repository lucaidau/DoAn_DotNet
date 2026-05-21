using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace DA_QuanLiThuVien.Views.UserControls.ThuThu
{
    public partial class UcBaoCao : UserControl
    {
        public UcBaoCao()
        {
            InitializeComponent();
            LoadMockData();
        }

        private void LoadMockData()
        {
            if (Helper.UserSession.UserFullName != "Quản Trị Demo") return;

            var mockContext = new
            {
                ReportFromDate = new DateTime(2023, 11, 1),
                ReportToDate = new DateTime(2023, 11, 30),
                ReportTypes = new List<string> { "Báo cáo mượn trả", "Báo cáo doanh thu phạt", "Báo cáo nhập sách" },
                SelectedReportType = "Báo cáo mượn trả",
                BorrowChartData = new List<object>
                {
                    new { Label = "T8", BarWidth = 120, Value = 120 },
                    new { Label = "T9", BarWidth = 150, Value = 150 },
                    new { Label = "T10", BarWidth = 90, Value = 90 },
                    new { Label = "T11", BarWidth = 180, Value = 180 },
                    new { Label = "T12", BarWidth = 50, Value = 50 }
                },
                ReportItems = new List<object>
                {
                    new { Label = "Tổng sách cho mượn:", Value = "540 cuốn" },
                    new { Label = "Sách quá hạn:", Value = "12 cuốn" },
                    new { Label = "Sách thất lạc:", Value = "2 cuốn" },
                    new { Label = "Tiền phạt thu được:", Value = "150,000 đ" },
                    new { Label = "Độc giả đăng ký mới:", Value = "45 người" }
                }
            };
            this.DataContext = mockContext;
        }
    }
}
