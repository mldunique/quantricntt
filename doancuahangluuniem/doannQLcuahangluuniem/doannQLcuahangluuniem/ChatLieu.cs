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
    public partial class ChatLieu : Form
    {
        public ChatLieu()
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
            string query = "select*from ChatLieu";
            SqlCommand CMD = new SqlCommand(query, CNN);
            SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
            DataTable qlnhansu = new DataTable();
            QLNHANSU.Fill(qlnhansu);
            HienThi.DataSource = qlnhansu;
            CNN.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string mcl = txtmachatlieu.Text;
            string tcl = txttenchatlieu.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "insert into ChatLieu(MaChatLieu, TenChatLieu)values(N'" + mcl + "',N'" + tcl + "')"; 
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
            string mcl = txtmachatlieu.Text;
            string tcl = txttenchatlieu.Text;   
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "update ChatLieu set TenChatLieu = N'" + tcl + "' where MaChatLieu = N'" + mcl + "'";
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
            string mcl = txtmachatlieu.Text;
            string tcl = txttenchatlieu.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "delete ChatLieu where MaChatLieu = N'" + mcl + "'";
            SqlCommand CMD = new SqlCommand(query, CNN);
            SqlDataAdapter QLNHANSU = new SqlDataAdapter(CMD);
            DataTable qlnhansu = new DataTable();
            QLNHANSU.Fill(qlnhansu);
            HienThi.DataSource = qlnhansu;
            CNN.Close();
            load();
        }

        private void ChatLieu_Load(object sender, EventArgs e)
        {

        }

        private void HienThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tk = txttimkiem.Text;
            string SQL = @"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True";
            SqlConnection CNN = new SqlConnection(SQL);
            CNN.Open();
            string query = "select*from ChatLieu WHERE MaChatLieu like '%" + tk + "%' or TenChatLieu like N'%" + tk + "%'";
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

        private void button1_Click(object sender, EventArgs e)
        {
            txtmachatlieu.Text = "";
            txttenchatlieu.Text = "";
            load();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void HienThi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = HienThi.Rows[e.RowIndex];
            txtmachatlieu.Text = row.Cells["MaChatLieu"].Value.ToString();
            txttenchatlieu.Text = row.Cells["TenChatLieu"].Value.ToString();

        }
    }
}
