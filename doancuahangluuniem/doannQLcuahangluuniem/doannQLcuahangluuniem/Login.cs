using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace doannQLcuahangluuniem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            SqlConnection CNT = new SqlConnection(@"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True");
            try
            {
                CNT.Open();
                string tk = txttk.Text;
                string mk = txtmk.Text;
                string sql = "select * FROM DangNhap where TenDangNhap = '" + tk + "' and MatKhau = '" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, CNT);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    Menu KD = new Menu();
                    KD.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("ĐĂNG NHẬP THẤT BẠI!");
                }

            }
            catch
            {
                MessageBox.Show("Lỗi kết nối!");

                throw;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dangki form = new dangki();
            form.Show();
        }
    }
}
