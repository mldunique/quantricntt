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
    public partial class dangki : Form
    {
        public dangki()
        {
            InitializeComponent();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {

                if (txtmk.Text == txtmkl.Text)
                {
                    string sql = "insert into DangNhap (TenDangNhap,MatKhau) values (N'" + txttk.Text + "',N'" + txtmkl.Text + "')";
                    Conn.executeQuery(sql);
                    MessageBox.Show("Them Thanh Cong", "Thông Báo");
                }
                else
                    MessageBox.Show("Mật Khẩu Nhập Lại Không Đúng", "Thông Báo");
                Login form = new Login();
            form.Show();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form = new Login();
            form.Show();
        }
    }
}
