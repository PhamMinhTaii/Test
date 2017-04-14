using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBenhNhan
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ten="sa";
            string pass="sa";
            if(txtTen.Text.Equals(ten)&&txtPass.Text.Equals(pass))
            {
                MessageBox.Show("Đăng nhập thành công!");
                QuanLyBN ql = new QuanLyBN();
                ql.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ask;
            ask = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không?", "Chương trình QL Bệnh nhân", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (ask == DialogResult.No)
                e.Cancel = true;
        }
    }
}
