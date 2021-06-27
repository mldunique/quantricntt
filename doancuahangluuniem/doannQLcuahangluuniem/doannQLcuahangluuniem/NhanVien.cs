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
    public partial class NhanVien : Form
    {
        public NhanVien()
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
            string query = "select*from NhanVien";
            SqlCommand CMD = new SqlCommand(query, CNN);
            SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
            DataTable qlnhansu = new DataTable();
            QLNHANSU.Fill(qlnhansu);
            HienThi.DataSource = qlnhansu;
            CNN.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string mnv = txtmanhanvien.Text;
            string tnv = txttennhanvien.Text;
            string gtnv = txtgioitinhnv.Text;
            string dcnv = txtdiachinv.Text;
            string sdtnv = txtsodienthoainv.Text;
            string nsnv = txtngaysinhnv.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "insert into NhanVien(MaNhanVien,TenNhanVien,GioiTinh,DiaChi,DienThoai,NgaySinh)values(N'" + mnv + "',N'" + tnv + "',N'" + gtnv + "',N'" + dcnv + "',N'" + sdtnv + "',N'" + nsnv + "')";
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
            string mnv = txtmanhanvien.Text;
            string tnv = txttennhanvien.Text;
            string gtnv = txtgioitinhnv.Text;
            string dcnv = txtdiachinv.Text;
            string sdtnv = txtsodienthoainv.Text;
            string nsnv = txtngaysinhnv.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "update NhanVien set TenNhanVien = N'" + tnv + "', GioiTinh = N'" + gtnv + "', DiaChi = N'" + dcnv + "', DienThoai = N'" + sdtnv + "',NgaySinh = N'" + nsnv + "' where MaNhanVien = N'" + mnv + "'";
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
            string mnv = txtmanhanvien.Text;
            string tnv = txttennhanvien.Text;
            string gtnv = txtgioitinhnv.Text;
            string dcnv = txtdiachinv.Text;
            string sdtnv = txtsodienthoainv.Text;
            string nsnv = txtngaysinhnv.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "delete NhanVien where MaNhanVien = N'" + mnv + "'";
            SqlCommand CMD = new SqlCommand(query, CNN);
            SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
            DataTable qlnhansu = new DataTable();
            QLNHANSU.Fill(qlnhansu);
            HienThi.DataSource = qlnhansu;
            CNN.Close();
            load();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtmanhanvien.Text = "";
            txttennhanvien.Text = "";
            txtdiachinv.Text = "";
            txtsodienthoainv.Text = "";
            txtgioitinhnv.Text = "";
            txtngaysinhnv.Text = "";
            load();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string tk = txttimkiem.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "select*from NhanVien WHERE MaNhanVien like '%" + tk + "%' or TenNhanVien like N'%" + tk + "%' or DiaChi like N'%" + tk + "%' or DienThoai like N'%" + tk + "%' or  NgaySinh like N'%" + tk + "%' or  GioiTinh like N'%" + tk + "%' ";
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

        private void HienThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HienThi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = HienThi.Rows[e.RowIndex];
            txtmanhanvien.Text = row.Cells["MaNhanVien"].Value.ToString();
            txttennhanvien.Text = row.Cells["TenNhanVien"].Value.ToString();
            txtdiachinv.Text = row.Cells["DiaChi"].Value.ToString();
            txtsodienthoainv.Text = row.Cells["DienThoai"].Value.ToString();
            txtgioitinhnv.Text = row.Cells["GioiTinh"].Value.ToString();
            txtngaysinhnv.Text = row.Cells["NgaySinh"].Value.ToString();
        }

        private void txtngaysinhnv_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
