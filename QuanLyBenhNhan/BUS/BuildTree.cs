using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
using BUS;
using DAO;
namespace BUS
{
    public class BuildTree
    {
       
        public int BuildTree1(TreeView tv)
        {
            try
            {
                return new TreeViewDAO().hienthitw(tv);
            }
            catch (Exception ex)
            {               
               throw ex;
            }           
        }
    }
}
            
               
           
	
           
        
       
