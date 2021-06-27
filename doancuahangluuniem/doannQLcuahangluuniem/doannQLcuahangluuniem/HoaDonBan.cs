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
    public partial class HoaDonBan : Form
    {
        int tien;
        string mahang;
        public HoaDonBan()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
                string query = "select*from HoaDonBan";
                SqlCommand CMD = new SqlCommand(query, CNN);
                SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
                DataTable qlnhansu = new DataTable();
                QLNHANSU.Fill(qlnhansu);
                HienThi.DataSource = qlnhansu;
                CNN.Close();
            
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmahoadonban.Text !="")
                {
                    string mahdb = txtmahoadonban.Text;
                    string mnv = txtmanhanvien.Text;
                    string nb = txtngayban.Text;
                    string mk = txtmakhach.Text;
                    string tongtien = txttongtien.Text;
                    string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
                    SqlConnection CNN = new SqlConnection(SQL);
                    CNN.Open();
                    string query = "insert into HoaDonBan(MaHDBan, MaNhanVien, NgayBan, MaKhach, TongTien)values(N'" + mahdb + "',N'" + mnv + "',N'" + nb + "',N'" + mk + "',N'" + tongtien + "')";
                    SqlCommand CMD = new SqlCommand(query, CNN);
                    SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
                    DataTable qlnhansu = new DataTable();
                    QLNHANSU.Fill(qlnhansu);
                    HienThi.DataSource = qlnhansu;
                    CNN.Close();

                    foreach (var listBoxItem in listBox1.Items)
                    {
                        string them = "insert into ChiTietHoaDonBan(MaHDBan,TenHang)values(N'" + txtmahoadonban.Text + "',N'" + listBoxItem.ToString() + "')";
                        Conn.executeQuery(them);
                    }


                    load();
                }
                
            }
            catch { MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin", "Thông Báo"); }


        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmahoadonban.Text != "")
                {
                    string mahdb = txtmahoadonban.Text;
                    string mnv = txtmanhanvien.Text;
                    string nb = txtngayban.Text;
                    string mk = txtmakhach.Text;
                    string tongtien = txttongtien.Text;
                    string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
                    SqlConnection CNN = new SqlConnection(SQL);
                    CNN.Open();
                    string query = "update HoaDonBan set MaNhanVien = N'" + mnv + "', NgayBan = N'" + nb + "', MaKhach = N'" + mk + "', TongTien = N'" + tongtien + "' where MaHDBan = N'" + mahdb + "'";
                    SqlCommand CMD = new SqlCommand(query, CNN);
                    SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
                    DataTable qlnhansu = new DataTable();
                    QLNHANSU.Fill(qlnhansu);
                    HienThi.DataSource = qlnhansu;
                    CNN.Close();
                    string del = "delete ChiTietHoaDonBan where MaHDBan = '" + mahdb + "'";
                    Conn.executeQuery(del);
                    foreach (var listBoxItem in listBox1.Items)
                    {
                        string them = "insert into ChiTietHoaDonBan(MaHDBan,TenHang)values(N'" + txtmahoadonban.Text + "',N'" + listBoxItem.ToString() + "')";
                        Conn.executeQuery(them);
                    }
                    load();
                }

            }
            catch { MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin", "Thông Báo"); }


        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string mahdb = txtmahoadonban.Text;
            string mnv = txtmanhanvien.Text;
            string nb = txtngayban.Text;
            string mk = txtmakhach.Text;
            string tongtien = txttongtien.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "delete HoaDonBan  where MaHDBan = N'" + mahdb + "'";
            SqlCommand CMD = new SqlCommand(query, CNN);
            SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
            DataTable qlnhansu = new DataTable();
            QLNHANSU.Fill(qlnhansu);
            HienThi.DataSource = qlnhansu;
            CNN.Close();

            string del = "delete ChiTietHoaDonBan where MaHDBan = '" + mahdb + "'";
            Conn.executeQuery(del);
            string del2 = "delete HoaDonBan where MaHDBan = '" + mahdb + "'";
            Conn.executeQuery(del2);

            load();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txtmahoadonban.Text = "";
            txtmanhanvien.Text = "";
            txtngayban.Text = "";
            txtmakhach.Text = "";
            txttongtien.Text = "";
            listBox1.Items.Clear();
            tien = 0;
            dgvshow.DataSource = null;
            load();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tk = txttimkiem.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "select*from HoaDonBan WHERE  MaHDBan like '%" + tk + "%' or NgayBan like N'%" + tk + "%' or MaKhach like N'%" + tk + "%' or TongTien like N'%" + tk + "%'  or MaNhanVien like N'%" + tk + "%'";
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

        private void txtmakhach_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txttongtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void HienThi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = HienThi.Rows[e.RowIndex];
            txtmahoadonban.Text = row.Cells["MaHDBan"].Value.ToString();
            txtmanhanvien.Text = row.Cells["MaNhanVien"].Value.ToString();
            txtngayban.Text = row.Cells["NgayBan"].Value.ToString();
            txtmakhach.Text = row.Cells["MaKhach"].Value.ToString();
            txttongtien.Text = row.Cells["TongTien"].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HoaDonBan_Load(object sender, EventArgs e)
        {
            string sql = "select MaHang,TenHang,DonGiaBan from Hang";
            DataTable dt = Conn.getDataTable(sql);
            dgvhang.DataSource = dt;
        }

        private void dgvhang_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow rowk in dgvhang.SelectedRows)
            {
                listBox1.Items.Add(rowk.Cells[1].Value.ToString());
            }
            DataGridViewRow row = new DataGridViewRow();
            row = dgvhang.Rows[e.RowIndex];
            string sql = "select DonGiaBan from Hang where MaHang = '"+row.Cells[0].Value.ToString()+"'";
            DataSet ds = Conn.getDataSet(sql);
            tien += Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            txttongtien.Text = tien.ToString();
        }

        private void HienThi_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = HienThi.Rows[e.RowIndex];
            string sql = "select TenHang from ChiTietHoaDonBan where MaHDBan = '" + row.Cells[0].Value.ToString() + "'";
            DataTable dt = Conn.getDataTable(sql);
            dgvshow.DataSource = dt;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //listBox1.
        }
    }
}
