using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DTO;


namespace DAO
{
    public class BenhNhanDAO:DBConnect

    {
        
       public DBConnect db;
       //private SqlDataAdapter DaBN;
      // DataSet ds = null;
      // SqlDataAdapter daBN;
        public BenhNhanDAO()//:base()
        {
            db = new DBConnect();
        }
        //public DataSet getAllBenhNhan()
        //{
        //    string SQL = "SELECT * FROM BenhNhan";
        //    try
        //    {
        //        ds = new DataSet();
        //        daBN = new SqlDataAdapter(SQL, cn);
        //        daBN.Fill(ds, "BenhNhan");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
           public List<BenhNhanDTO> getAllBenhNhan(string sql)//string MaBN)
           {
           
               db.Connect();
               try
               {
                   List<BenhNhanDTO> listAll=new List<BenhNhanDTO>();
                   string mabn,hobn,tenbn,gioitinh,diachi,hinh,mabs;
                   //string SQL="SELECT * FROM BenhNhan WHERE MaBN='"+MaBN+"'";
                   SqlDataReader dr = db.ExcuteData(sql);//SQL);
                   while(dr.Read())
                   {
                       mabn = dr.GetString(0);
                       hobn = dr.GetString(1);
                       tenbn= dr.GetString(2);
                       gioitinh = dr.GetString(3);
                       diachi= dr.GetString(4);
                       hinh  = dr.GetString(5);
                       mabs = dr.GetString(6);
                       BenhNhanDTO BenhNhan = new BenhNhanDTO(mabn, hobn, tenbn, gioitinh, diachi,hinh, mabs);
                       listAll.Add(BenhNhan);

                   }
                   dr.Close();
                   return listAll;               
               }
               catch (Exception ex)
               {              
                   throw ex;
               }
               finally
               {
                   db.DisConnect();
                   
               }
           }
           public List<BenhNhanDTO>getBenhNhanByMaBN(string MaBN)
          {
              db.Connect();
              List<BenhNhanDTO> listMaBN = new List<BenhNhanDTO>();
              string mabn, hobn, tenbn, gioitinh, diachi, hinh, mabs;
              string SQL="SELECT * FROM BenhNhan WHERE MaBN='"+MaBN+"'";
              SqlDataReader dr = db.ExcuteData(SQL);//SQL);
              while (dr.Read())
              {
                  mabn = dr.GetString(0);
                  hobn = dr.GetString(1);
                  tenbn = dr.GetString(2);
                  gioitinh = dr.GetString(3);
                  diachi = dr.GetString(4);
                  hinh = dr.GetString(5);
                  mabs = dr.GetString(6);
                  BenhNhanDTO BenhNhan = new BenhNhanDTO(mabn, hobn, tenbn, gioitinh, diachi, hinh, mabs);
                  listMaBN.Add(BenhNhan);

              }
              dr.Close();
              return listMaBN;               

          }
        //Ham Them Benh Nhan
           public int Add(BenhNhanDTO bn)
           {
               List<SqlParameter> parsa = new List<SqlParameter>();
               parsa.Add(new SqlParameter("@Mabn", bn.MaBN));
               parsa.Add(new SqlParameter("@Hobn", bn.HoBN));
               parsa.Add(new SqlParameter("@Tenbn", bn.TenBN));
               parsa.Add(new SqlParameter("@GioiTinh", bn.GioiTinhBN));
               parsa.Add(new SqlParameter("@DiaChiBN", bn.DiaChiBN));
               parsa.Add(new SqlParameter("@Hinh", bn.Hinh));
               parsa.Add(new SqlParameter("@MaBS", bn.MaBS));
               try
               {
                   return db.ExecuteNonQuery("ThemBN", System.Data.CommandType.StoredProcedure, parsa);
               }
               catch (Exception ex)
               {
                   throw ex;
               }
           }
        //Ham Xoa Benh Nhan
           public int Delete(BenhNhanDTO bn)
           {
               List<SqlParameter> parsa = new List<SqlParameter>();
               parsa.Add(new SqlParameter("@MaBN",bn.MaBN));
               try
               {
                   return db.ExecuteNonQuery("XoaBN", System.Data.CommandType.StoredProcedure, parsa);
               }
               catch (Exception ex)
               {
                   
                   throw ex;
               }
           }
        //Ham Sua Benh Nhan
           public int Updata(BenhNhanDTO bn)
           {
               List<SqlParameter> parsa=new List<SqlParameter>();
               parsa.Add(new SqlParameter("@MaBN", bn.MaBN));
               parsa.Add(new SqlParameter("@hobn", bn.HoBN));
               parsa.Add(new SqlParameter("@tenbn", bn.TenBN));
               parsa.Add(new SqlParameter("@gioitinh", bn.GioiTinhBN));
               parsa.Add(new SqlParameter("@diachi", bn.DiaChiBN));
               parsa.Add(new SqlParameter("@hinh", bn.Hinh));
               parsa.Add(new SqlParameter("@mabs", bn.MaBS));
               try
               {
                   return db.ExecuteNonQuery("SuaBN", System.Data.CommandType.StoredProcedure, parsa);

               }
               catch (Exception ex)
               {             
                   throw ex;
               }
           }
        
    }
}
