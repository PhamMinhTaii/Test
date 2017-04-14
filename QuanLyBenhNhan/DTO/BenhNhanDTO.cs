using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BenhNhanDTO
    {
        public string MaBN { get; set; }
        public string HoBN { get; set; }
        public string TenBN { get; set; }
        public string GioiTinhBN { get; set; }
        public string DiaChiBN { get; set; }

        public string Hinh { get; set; }
        public string MaBS {get;set;}
        public BenhNhanDTO(string mabn,string hobn,string tenbn,string gioitinhbn,string diachibn,string hinh,string mabs)
        {
            MaBN = mabn;
            HoBN = hobn;
            TenBN = tenbn;
            GioiTinhBN = gioitinhbn;
            DiaChiBN = diachibn;
            Hinh = hinh;
            MaBS=mabs;
        }

    }
}
