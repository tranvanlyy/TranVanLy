using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TranVanLy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string TenDangNhap = "tranvanly";
            string MatKhau = "12345";
            if (TenDangNhap.Equals(tbTen.Text) && MatKhau.Equals(tbMatKhau.Text))
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo");
                Form2 form = new Form2();
                form.ShowDialog();
            }
            else
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Lỗi");
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
