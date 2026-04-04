using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_QuanLiThuVien.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string TenTK { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public bool GioiTinh { get; set; }
        public string HashMK { get; set; }
        public bool Role { get; set; }
    }
}
