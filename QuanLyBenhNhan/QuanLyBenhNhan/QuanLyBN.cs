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
using BUS;
using DTO;


namespace QuanLyBenhNhan
{
    public partial class QuanLyBN : Form
    {
       // private BenhNhanBUS bn;
        //private List<BenhNhanDTO> list;
        public QuanLyBN()
        {
            InitializeComponent();                  
        }
        private List<BenhNhanDTO> getBenhNhan()
        {            
            string sql = "SELECT * FROM BenhNhan";
            return new BenhNhanBUS().ListBenhNhan(sql);
        }
        
        private void QuanLyBN_Load(object sender, EventArgs e)
        {           
            //btnThem.Enabled = btnXoa.Enabled  = false;
            //btnSuaBS.Hide();
           // txtSex.Hide();
            FormLoad();
           // BuildTreeView();


        }
        //------------------------ su ly TreeView
        private int BuildTreeView()
        {
            return new BuildTree().BuildTree1(TV);
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           /* TreeNode theNode = this.TV.SelectedNode;
            if(theNode.Tag=="1")
            {
                //string sql=""
            }
            else
            {
                if(theNode.Tag=="2")
            }*/
        }
        void FormLoad()
        {
            btnLuu.Hide();
            dgvBenhNhan.DataSource = getBenhNhan();

            dgvBenhNhan.Columns[0].HeaderText = "Mã Bệnh Nhân";
            dgvBenhNhan.Columns[0].Width = 120;
            dgvBenhNhan.Columns[1].HeaderText = "Họ Bệnh Nhân";
            dgvBenhNhan.Columns[2].HeaderText = "Tên Bệnh Nhân";
            dgvBenhNhan.Columns[3].HeaderText = "Giới Tính";
            dgvBenhNhan.Columns[4].HeaderText = "Địa Chỉ";
            dgvBenhNhan.Columns[5].HeaderText = "Hình";
            dgvBenhNhan.Columns[6].Width = 80;
            dgvBenhNhan.Columns[6].HeaderText = "Mã Bác Sĩ Điều Trị";
            dgvBenhNhan.Columns[6].Width = 120;
            //BuildTreeView
           

            
        }
        //------------------------- su ly Them
        private void btnThem_Click(object sender, EventArgs e)
        {
            Add them = new Add();
            them.Show();
           // btnLuu.Show();
            //groupBox1.Hide();          
            txtName.Text = txtAdd.Text = txtMaBS.Text = txtSex.Text = " ";
        }
        //------------------------- su ly Xoa
        private int XoaBN()
        {
            string mabn, hobn, tenbn, gioitinh, diachi, hinh, mabs;
            mabn = dgvBenhNhan.CurrentRow.Cells[0].Value.ToString();
            hobn = dgvBenhNhan.CurrentRow.Cells[1].Value.ToString();
            tenbn = dgvBenhNhan.CurrentRow.Cells[2].Value.ToString();
            gioitinh = dgvBenhNhan.CurrentRow.Cells[3].Value.ToString();
            diachi = dgvBenhNhan.CurrentRow.Cells[4].Value.ToString();
            hinh = dgvBenhNhan.CurrentRow.Cells[5].Value.ToString();
            mabs = dgvBenhNhan.CurrentRow.Cells[6].Value.ToString();
            BenhNhanDTO n = new BenhNhanDTO(mabn, hobn, tenbn, gioitinh, diachi, hinh, mabs);
            BenhNhanBUS bn = new BenhNhanBUS();
            return bn.Delete(n);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult ask;
            ask = MessageBox.Show("Bạn có chắc chắn muốn xóa Bệnh Nhân này?", "Chương trình quản lý bệnh nhân", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            if (ask == DialogResult.OK)
            {
                XoaBN();
            }

            FormLoad();
        }
        //------------------------- su ly Sua
       
        private int SuaBN()
        {
            string mabn, hobn, tenbn, gioitinh, diachi, hinh, mabs;
            mabn = dgvBenhNhan.CurrentRow.Cells[0].Value.ToString();
            hobn = txtName.Text;
            tenbn = txtLastName.Text;
            gioitinh = txtSex.Text;
            diachi = txtAdd.Text;
            mabs = txtMaBS.Text;
            hinh = "1";
            if(gioitinh!="Nam"&&gioitinh!="Nữ")
            {
                MessageBox.Show("Bạn chỉ được nhập Nam hoặc Nữ");//\"Nam\" hoặc \"Nữ\"");
                
            }
            
               BenhNhanDTO n = new BenhNhanDTO(mabn, hobn, tenbn, gioitinh, diachi, hinh, mabs);
               BenhNhanBUS bn = new BenhNhanBUS();
               return bn.Updata(n);
            
           
         }
           
        private void btnSua_Click(object sender, EventArgs e)
        {
            
            //btnThem.Enabled = btnXoa.Enabled =true;
          //  btnThem.Hide();
            
            
            btnLuu.Show();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult ask;
            ask = MessageBox.Show("Bạn có chắc muốn sửa lại Bệnh Nhân này?", "Chương trình quản lý bệnh nhân", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ask==DialogResult.Yes)
            {
                SuaBN();
            }
            FormLoad();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }                     
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
       /*  private void QuanLyBN_FormClosing(object sender, FormClosingEventArgs e)
         {
             DialogResult ask;
             ask = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không?", "Chương trình QL Bệnh nhân", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
             if (ask == DialogResult.No)
                 e.Cancel = true;
         }*/

         private void dgvBenhNhan_SelectionChanged(object sender, EventArgs e)
         {
             txtName.Text = dgvBenhNhan.CurrentRow.Cells[1].Value.ToString();
             txtLastName.Text= dgvBenhNhan.CurrentRow.Cells[2].Value.ToString();
             txtSex.Text = dgvBenhNhan.CurrentRow.Cells[3].Value.ToString();
             txtAdd.Text = dgvBenhNhan.CurrentRow.Cells[4].Value.ToString();
             txtMaBS.Text = dgvBenhNhan.CurrentRow.Cells[6].Value.ToString();
           
         }

         private void groupBox2_Enter(object sender, EventArgs e)
         {

         }
         private void bệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
         {
             //DialogResult ask;
         }

         private void txtName_TextChanged(object sender, EventArgs e)
         {

         }

      

       
     


       
    }
}
