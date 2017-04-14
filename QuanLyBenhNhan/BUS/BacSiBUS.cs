using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BacSiBUS
    {
        public List<BacSiDTO>GetBS(string sql)
        {
            try
            {
                return new BacSiDAO().GetBacSi(sql);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
