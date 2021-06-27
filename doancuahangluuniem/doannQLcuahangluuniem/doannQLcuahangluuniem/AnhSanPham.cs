using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace doannQLcuahangluuniem
{
    public partial class AnhSanPham : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-MBJQMRD\SQLSERVER;Initial Catalog=QuanLyBanHangLN;Integrated Security=True");
        public AnhSanPham()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from AnhSanPham", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] b = ImageToByteArray(pictureBox1.Image);
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into AnhSanPham values(@MaHang, @HinhAnh)", conn);
                cmd.Parameters.Add("@MaHang", txtTenHinh.Text);
                cmd.Parameters.Add("@HinhAnh", b);
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();
            }
            catch { }

        }
        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        byte[] PathToByteArray(string path)
        {
            MemoryStream m = new MemoryStream();
            Image img = Image.FromFile(path);
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        public void loaddulieu()
        {
            string load = "select * from AnhSanPham";
            DataTable dt = Conn.getDataTable(load);
            dataGridView1.DataSource = dt;
        }
            
        private void AnhSanPham_Load(object sender, EventArgs e)
        {
            loaddulieu();

            /*//create a DataGridView Image Column
            //create a DataGridView Image Column
            DataGridViewImageColumn dgvImage = new DataGridViewImageColumn();
            //set a header test to DataGridView Image Column
            dgvImage.HeaderText = "Image";
            dgvImage.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridViewTextBoxColumn dgvId = new DataGridViewTextBoxColumn();
            dgvId.HeaderText = "Id";

            dataGridView1.Columns.Add(dgvId);
            dataGridView1.Columns.Add(dgvImage);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 120;

            dataGridView1.AllowUserToAddRows = false;*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }
    }
}
