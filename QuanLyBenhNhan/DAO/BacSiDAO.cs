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
    public class BacSiDAO
    {
        public DBConnect db;
        public BacSiDAO()
        {
            db = new DBConnect();
        }
        public List<BacSiDTO>GetBacSi(string sql)
        {
            db.Connect();
            try
            {
                List<BacSiDTO> list = new List<BacSiDTO>();
                string mabs, hobs, tenbs, gioitinh, diachibs,sdt, makhoa;
                SqlDataReader dr = db.ExcuteData(sql);
                while (dr.Read())
                {

                    mabs = dr.GetString(0);
                    hobs = dr.GetString(1);
                    tenbs = dr.GetString(2);
                    gioitinh = dr.GetString(3);
                    diachibs = dr.GetString(4);
                    sdt = dr.GetString(5);
                    makhoa = dr.GetString(6);
                    BacSiDTO BacSi = new BacSiDTO(mabs, hobs, tenbs, gioitinh, diachibs, sdt, makhoa);
                    list.Add(BacSi);
                }
                dr.Close();
                return list;
                    
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
       
    }
}
