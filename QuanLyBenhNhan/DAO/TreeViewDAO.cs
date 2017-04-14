using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using DTO;
namespace DAO
{
    public class TreeViewDAO
    {
        DBConnect db;
        public TreeViewDAO()
        {
            db = new DBConnect();
        }
        public DataTable TruyVan(string sql, SqlConnection con)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            return dt;
        }
        public int hienthitw(TreeView tw)
        {
            SqlConnection con = db.getcon();
            con.Open();
            DataTable nodecha = new DataTable();
            DataTable nodecon = new DataTable();
            nodecha = TruyVan("SELECT TenKhoa FROM Khoa", con);
            for(int i=0;i<nodecha.Rows.Count;i++)
            {
                tw.Nodes.Add(nodecha.Rows[i][0].ToString());
                tw.Nodes[i].Tag = "1";
                nodecon = TruyVan("SELECT HoBS+TenBS FROM BacSi",con);// WHERE MaBS='" + nodecha.Rows[i][0] + "'", con);//
                for(int j=0;j<nodecon.Rows.Count;j++)
                {
                    tw.Nodes[i].Nodes.Add(nodecon.Rows[i][0].ToString());
                    tw.Nodes[i].Nodes[j].Tag = "2";
                    
                    
                }
            }
            return 0;

        }

        
    }
    
}
