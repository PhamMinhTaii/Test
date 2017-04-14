using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using DTO;
namespace DAO
{
   public class DBConnect
    {
       string cnstr = "";
       protected SqlConnection cn;

       //tao treeview
       SqlCommand cmd;
       SqlDataAdapter da;
       public DBConnect()
       {
           try
           {
               cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
               cn = new SqlConnection(cnstr);
               Connect();
           }
           catch (Exception p)
           {              
               throw p;
           }          
       }
        public void Connect()
        {
            try
            {
                if (cn != null && cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void DisConnect()
        {
            if (cn != null && cn.State!=ConnectionState.Closed)
            {
                cn.Close();
            }
        }
       public SqlDataReader ExcuteData(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
       public int ExecuteNonQuery(string sql,CommandType type,List<SqlParameter>paras)
       {
           SqlCommand cmd = new SqlCommand(sql,cn);
           cmd.CommandType = type;
           try
           {
               if(paras!=null)
               {
                   foreach(SqlParameter par in paras)
                   {
                       cmd.Parameters.Add(par);
                   }
               }
               cmd.ExecuteNonQuery();
               return 1;
           }
           catch (Exception ex )
           {
               
               throw ex;
           }
           finally
           {
               DisConnect();
           }
       }
       //tao treeview
       public SqlConnection getcon()
       {
           return new SqlConnection(cnstr);
       }

       public DataTable TaoBang(string sql)
       {
           cn = getcon();
           SqlDataAdapter da = new SqlDataAdapter(sql, cn);
           DataTable dt = new DataTable();
           da.Fill(dt);
           return dt;
       }

    }
}
