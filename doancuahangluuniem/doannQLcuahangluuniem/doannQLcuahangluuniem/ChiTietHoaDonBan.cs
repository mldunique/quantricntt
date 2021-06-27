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
    public partial class ChiTietHoaDonBan : Form
    {
        int thanhtien;
        public ChiTietHoaDonBan()
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
            string query = "select*from ChiTietHoaDonBan";
            SqlCommand CMD = new SqlCommand(query, CNN);
            SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
            DataTable qlnhansu = new DataTable();
            QLNHANSU.Fill(qlnhansu);
            HienThi.DataSource = qlnhansu;
            CNN.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string mahdb = txtmahoadonban.Text;
            string mh = txtmahang.Text;
            string sl = txtsoluong.Text;
            string dg = txtdongia.Text;
            string gg = txtgiamgia.Text;
            string tt = txtthanhtien.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "insert into ChiTietHoaDonBan(MaHDBan, MaHang, SoLuong, DonGia, GiamGia, ThanhTien)values(N'" + mahdb + "',N'" + mh + "',N'" + sl + "',N'" + dg + "',N'" + gg + "',N'" + tt + "')";
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
            string mahdb = txtmahoadonban.Text;
            string mh = txtmahang.Text;
            string sl = txtsoluong.Text;
            string dg = txtdongia.Text;
            string gg = txtgiamgia.Text;
            string tt = txtthanhtien.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "update ChiTietHoaDonBan set MaHang = N'" + mh + "', SoLuong = N'" + sl + "', DonGia = N'" + dg + "', GiamGia = N'" + gg + "', ThanhTien = N'" + tt + "' where MaHDBan = N'" + mahdb + "'";
            SqlCommand CMD = new SqlCommand(query, CNN);
            SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
            DataTable qlnhansu = new DataTable();
            QLNHANSU.Fill(qlnhansu);
            HienThi.DataSource = qlnhansu;
            CNN.Close();
            load();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string mahdb = txtmahoadonban.Text;
            string mh = txtmahang.Text;
            string sl = txtsoluong.Text;
            string dg = txtdongia.Text;
            string gg = txtgiamgia.Text;
            string tt = txtthanhtien.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "delete ChiTietHoaDonBan where MaHDBan = N'" + mahdb + "'";
            SqlCommand CMD = new SqlCommand(query, CNN);
            SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
            DataTable qlnhansu = new DataTable();
            QLNHANSU.Fill(qlnhansu);
            HienThi.DataSource = qlnhansu;
            CNN.Close();
            load();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txtmahoadonban.Text = "";
            txtmahang.Text = "";
            txtsoluong.Text = "";
            txtdongia.Text = "";
            txtgiamgia.Text = "";
            txtthanhtien.Text = "";
            load();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tk = txttimkiem.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "select*from ChiTietHoaDonBan  WHERE  MaHDBan like '%" + tk + "%' or MaHang like N'%" + tk + "%' or SoLuong like N'%" + tk + "%' or DonGia like N'%" + tk + "%'  or GiamGia like N'%" + tk + "%' or ThanhTien like N'%" + tk + "%'";
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int tien = ((Convert.ToInt32(txtdongia.Text) * Convert.ToInt32(txtsoluong.Text)) * Convert.ToInt32(txtgiamgia.Text)) / 100;
                txtthanhtien.Text = ((Convert.ToInt32(txtdongia.Text) * Convert.ToInt32(txtsoluong.Text)) - tien).ToString();
            }
            catch { }
        }

        private void txtdongia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int tien = ((Convert.ToInt32(txtdongia.Text) * Convert.ToInt32(txtsoluong.Text)) * Convert.ToInt32(txtgiamgia.Text)) / 100;
                txtthanhtien.Text = ((Convert.ToInt32(txtdongia.Text) * Convert.ToInt32(txtsoluong.Text)) - tien).ToString();
            }
            catch { }

        }

        private void txtgiamgia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int tien = ((Convert.ToInt32(txtdongia.Text) * Convert.ToInt32(txtsoluong.Text)) * Convert.ToInt32(txtgiamgia.Text)) / 100;
                txtthanhtien.Text = ((Convert.ToInt32(txtdongia.Text) * Convert.ToInt32(txtsoluong.Text)) - tien).ToString();
            }
            catch { }
        }

        private void txtthanhtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void HienThi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*DataGridViewRow row = new DataGridViewRow();
            row = HienThi.Rows[e.RowIndex];
            txtmahoadonban.Text = row.Cells["MaChatLieu"].Value.ToString();
            txt.Text = row.Cells["TenChatLieu"].Value.ToString();
            txtmachatlieu.Text = row.Cells["MaChatLieu"].Value.ToString();
            txttenchatlieu.Text = row.Cells["TenChatLieu"].Value.ToString();
            txtmachatlieu.Text = row.Cells["MaChatLieu"].Value.ToString();
            txttenchatlieu.Text = row.Cells["TenChatLieu"].Value.ToString();*/
        }
    }
}
