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
    public partial class Khach : Form
    {
        public Khach()
        {
            InitializeComponent();
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        
            {
                load();
            }
            public void load()
            {
                string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
                SqlConnection CNN = new SqlConnection(SQL);
                CNN.Open();
                string query = "select*from Khach";
                SqlCommand CMD = new SqlCommand(query, CNN);
                SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
                DataTable qlnhansu = new DataTable();
                QLNHANSU.Fill(qlnhansu);
                HienThi.DataSource = qlnhansu;
                CNN.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string mk = txtmakhach.Text;
            string tk = txttenkhach.Text;
            string dc = txtdiachikh.Text;
            string sdt = txtsodienthoaikh.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "insert into Khach(MaKhach,TenKhach,DiaChiKH,DienThoaiKH)values(N'" + mk + "',N'" + tk + "',N'" + dc + "',N'" + sdt + "')";
            SqlCommand CMD = new SqlCommand(query, CNN);
            SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
            DataTable qlnhansu = new DataTable();
            QLNHANSU.Fill(qlnhansu);
            HienThi.DataSource = qlnhansu;
            CNN.Close();
            load();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string mk = txtmakhach.Text;
            string tk = txttenkhach.Text;
            string dc = txtdiachikh.Text;
            string sdt = txtsodienthoaikh.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "update Khach set TenKhach = N'" + tk + "', DiaChiKH = N'" + dc + "', DienThoaiKH = N'" + sdt + "' where MaKhach = N'" + mk + "'";
            SqlCommand CMD = new SqlCommand(query, CNN);
            SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
            DataTable qlnhansu = new DataTable();
            QLNHANSU.Fill(qlnhansu);
            HienThi.DataSource = qlnhansu;
            CNN.Close();
            load();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mk = txtmakhach.Text;
            string tk = txttenkhach.Text;
            string dc = txtdiachikh.Text;
            string sdt = txtsodienthoaikh.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "delete Khach where Makhach = N'" + mk + "'";
            SqlCommand CMD = new SqlCommand(query, CNN);
            SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
            DataTable qlnhansu = new DataTable();
            QLNHANSU.Fill(qlnhansu);
            HienThi.DataSource = qlnhansu;
            CNN.Close();
            load();
        }

        private void HienThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtmakhach.Text = "";
            txttenkhach.Text = "";
            txtdiachikh.Text = "";
            txtsodienthoaikh.Text = "";
            load();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tk = txttimkiem.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "select*from Khach WHERE MaKhach like '%" + tk + "%' or TenKhach like N'%" + tk + "%' or DiaChiKH like N'%" + tk + "%' or DienThoaiKH like N'%" + tk + "%' ";
            SqlCommand CMD = new SqlCommand(query, CNN);
            SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
            DataTable qlnhansu = new DataTable();
            QLNHANSU.Fill(qlnhansu);
            HienThi.DataSource = qlnhansu;
            CNN.Close();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
              ("Bạn có chắc muốn thoát không?", "Error", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit();
        }

        private void HienThi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = HienThi.Rows[e.RowIndex];
            txtmakhach.Text = row.Cells["MaKhach"].Value.ToString();
            txttenkhach.Text = row.Cells["TenKhach"].Value.ToString();
            txtdiachikh.Text = row.Cells["DiaChiKH"].Value.ToString();
            txtsodienthoaikh.Text = row.Cells["DienThoaiKH"].Value.ToString();
        }
    }
}
