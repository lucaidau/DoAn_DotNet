using System.Windows.Input;

namespace DA_QuanLiThuVien.ViewModels.Main.Librarian
{
    /// <summary>
    /// Đối tượng chứa thông tin của một menu item
    /// </summary>
    public class MenuItem
    {
        public string TenChucNang { get; set; }
        public ICommand Command { get; set; }

        public MenuItem(string tenChucNang, ICommand command)
        {
            TenChucNang = tenChucNang;
            Command = command;
        }
    }
}
