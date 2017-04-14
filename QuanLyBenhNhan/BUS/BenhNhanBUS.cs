using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAO;

namespace BUS
{
   public class BenhNhanBUS
    {
       BenhNhanDAO bn;
       //public BenhNhanBUS()
       //{
       //    try
       //    {
       //        bn = new BenhNhanDAO();
       //    }
       //    catch (Exception ex)
       //    {

       //        throw ex;
       //    }
       //}
       //public DataSet GetAllBenhNhan()
       //{
       //    DataSet ds = null;
       //    try
       //    {
       //        ds = bn.getAllBenhNhan();
       //    }
       //    catch (Exception)
       //    {

       //        throw new Exception("Không Thể Lấy Danh Sách Bệnh Nhân.");
       //    }
       //    return ds;
       //}
       public List<BenhNhanDTO> ListBenhNhan(string sql)
       {
           try
           {
               return new BenhNhanDAO().getAllBenhNhan(sql);
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }
       public int Add(BenhNhanDTO bn)
       {
           if(bn.HoBN==""||bn.TenBN=="")
           {
               return -2;
           }
           try
           {
               return (new BenhNhanDAO().Add(bn));
           }
           catch (Exception ex )
           {
               
               throw ex;
           }
       }
       public int Delete(BenhNhanDTO bn)
       {
           try
           {
               return(new BenhNhanDAO().Delete(bn));
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }
       public int Updata(BenhNhanDTO bn)
       {
           try
           {
               return (new BenhNhanDAO().Updata(bn));
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }
    }
}
