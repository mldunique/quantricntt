using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doannQLcuahangluuniem
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChatLieu cl = new ChatLieu();
            cl.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hang hang = new Hang();
            hang.Show();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChiTietHoaDonBan ctdhb = new ChiTietHoaDonBan();
            ctdhb.Show();
        }

        private void nhaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonBan hdb = new HoaDonBan();
            hdb.Show();
        }

        private void kháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Khach khach = new Khach();
            khach.Show();
        }

        private void nhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonBan hdb = new HoaDonBan();
            hdb.Show();
        }

        private void chiTiếtHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ảnhSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnhSanPham asp = new AnhSanPham();
            asp.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
        }
    }
}
