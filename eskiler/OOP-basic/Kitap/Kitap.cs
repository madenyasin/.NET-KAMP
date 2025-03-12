using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap
{
    internal class Kitap
    {
        private DateTime basimTarihi;

        public int Id { get; set; }
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public string YayınEvi { get; set; }
        public DateTime BasimTarihi
        {
            get { return basimTarihi; }
            set { basimTarihi = value; }
        }

    }
}
