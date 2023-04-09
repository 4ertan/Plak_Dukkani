using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonEfCodeFirst
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public string Sanatci { get; set; }
        public DateTime CikisT { get; set; }
        public Decimal Fiyat { get; set; }
        public int IndirimOrani { get; set; }
        public bool SatisDurum { get; set; }
    }
}
