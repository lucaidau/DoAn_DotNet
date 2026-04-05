using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA_QuanLiThuVien.Helper;

namespace DA_QuanLiThuVien.ViewModels.Main
{
    public class ReaderViewModel:BaseViewModel
    {
        public List<string> MenuItems { get; } = new List<string>
        {
           
            "Tìm Kiếm Sách",
            "Sách đang mượn",
            "Lịch sử mượn trả",
            "Giỏ sách"
        };
    }
}
