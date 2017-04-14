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
using System.Configuration;
using BUS;
using DAO;
using DTO;

namespace QuanLyBenhNhan
{
    public partial class Add : Form
    {
        DBConnect db = new DBConnect();
        
        public Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemBN();
            
           /* SqlDataAdapter da = new SqlDataAdapter();
            string sql = "INSERT INTO BenhNhan (MaBN,HoBN,TenBN,GioiTinh,DiaChi,Hinh,MaBS)values(@MaBN,@HoBN,@TenBN,@GioiTinh,@Hinh,@MaBS)";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add()*/
        }
        private int ThemBN()
        {
            string mabn, hobn, tenbn, gioitinh, diachibn, hinh, mabs;
            mabn = txtAddMaBN.Text;
            hobn = txtAddLastName.Text;
            tenbn = txtAddFirstName.Text;
            gioitinh = txtAddSex.Text;
            diachibn = txtAddAdd.Text;
            hinh = null;
            mabs = txtAddMaBS.Text;
            BenhNhanDTO bn = new BenhNhanDTO(mabn, hobn, tenbn, gioitinh, diachibn, hinh, mabs);
            BenhNhanBUS bnBUS = new BenhNhanBUS();
            return bnBUS.Add(bn);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
