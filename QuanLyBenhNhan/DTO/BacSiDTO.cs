using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BacSiDTO
    {
        public string MaBS { get; set; }
        public string HoBS { get; set; }
        public string TenBS { get; set; }
        public string GioiTinhBS { get; set; }
        public string DiaChiBS { get; set; }
        public string SdtBS { get; set; }
        public string MaKhoa { get; set; }

        public BacSiDTO(string mabs,string hobs,string tenbs,string gioitinhbs,string diachids,string sdtbs,string makhoa)
        {
            MaBS = mabs;
            HoBS = hobs;
            TenBS = tenbs;
            GioiTinhBS = gioitinhbs;
            DiaChiBS = diachids;
            SdtBS = sdtbs;
            MaKhoa = makhoa;
        }
    }
}
