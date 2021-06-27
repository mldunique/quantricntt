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
    public partial class Hang : Form
    {
        public Hang()
        {
            InitializeComponent();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string mh = txtmahang.Text;
            string th = txttenhang.Text;
            string mcl = txtmachatlieu.Text;
            string sl = txtsoluong.Text;
            string dgn = txtdongianhap.Text;
            string dgb = txtdongiaban.Text;
            string anh = txtanh.Text;
            string ghichu = txtghichu.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "insert into Hang(MaHang, TenHang, MaChatLieu, SoLuong, DonGiaNhap, DonGiaBan, Anh, GhiChu)values(N'" + mh + "',N'" + th + "',N'" + mcl + "',N'" + sl + "',N'" + dgn + "',N'" + dgb + "',N'" + anh + "',N'" + ghichu + "')";
            SqlCommand CMD = new SqlCommand(query, CNN);
            SqlDataAdapter QLHANGHOA = new SqlDataAdapter(CMD);
            DataTable qlnhansu = new DataTable();
            QLHANGHOA.Fill(qlnhansu);
            HienThi.DataSource = qlnhansu;
            CNN.Close();
            load();
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            /*string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "select*from Hang";
            SqlCommand CMD = new SqlCommand(query, CNN);
            SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
            DataTable qlnhansu = new DataTable();
            QLNHANSU.Fill(qlnhansu);
            HienThi.DataSource = qlnhansu;
            CNN.Close();*/

            string sql = "select * from Hang";
            DataTable dt = Conn.getDataTable(sql);
            HienThi.DataSource = dt;

            /*DataSet ds = Conn.getDataSet(sql);
            txtmahang.Text = ds.Tables[0].Rows[0]["DonGia"].ToString();*/
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string mh = txtmahang.Text;
            string th = txttenhang.Text;
            string mcl = txtmachatlieu.Text;
            string sl = txtsoluong.Text;
            string dgn = txtdongianhap.Text;
            string dgb = txtdongiaban.Text;
            string anh = txtanh.Text;
            string ghichu = txtghichu.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "update Hang set  TenHang = N'" + th + "', MaChatLieu = N'" + mcl + "' , SoLuong = N'" + sl + "' , DonGiaNhap = N'" + dgn + "' , DonGiaBan = N'" + dgb + "' , Anh = N'" + anh + "' , GhiChu = N'" + ghichu + "' where Mahang= N'" + mh + "'";
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
            string mh = txtmahang.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "DELETE FROM Hang where Mahang = N'" + mh + "'";
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
            txtmahang.Text = "";
            txttenhang.Text = "";
            txtmachatlieu.Text = "";
            txtsoluong.Text = "";
            txtdongianhap.Text = "";
            txtdongiaban.Text = "";
            txtanh.Text = "";
            txtghichu.Text = "";
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tk = txttimkiem.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "select*from Hang WHERE MaHang like '%" + tk + "%' or TenHang like N'%" + tk + "%' or MaChatLieu like N'%" + tk + "%' or SoLuong like N'%" + tk + "%' or DonGiaNhap like N'%" + tk + "%' or DonGiaBan like N'%" + tk + "%' or Anh like N'%" + tk + "%' or GhiChu like N'%" + tk + "%'";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HienThi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = HienThi.Rows[e.RowIndex];
            txtmahang.Text = row.Cells["MaHang"].Value.ToString();
            txttenhang.Text = row.Cells["TenHang"].Value.ToString();
            txtmachatlieu.Text = row.Cells["MaChatLieu"].Value.ToString();
            txtsoluong.Text = row.Cells["SoLuong"].Value.ToString();
            txtdongianhap.Text = row.Cells["DonGiaNhap"].Value.ToString();
            txtdongiaban.Text = row.Cells["DonGiaBan"].Value.ToString();
            //txtanh.Text = row.Cells["TenHang"].Value.ToString();
            txtghichu.Text = row.Cells["GhiChu"].Value.ToString();

        }
    }
}
