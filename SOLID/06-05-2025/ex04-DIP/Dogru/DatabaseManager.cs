using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex04_DIP.Dogru
{
    internal class DatabaseManager
    {
        private ICrud _veritabani;
        public ICrud PropertyInjection
        {
            get { return _veritabani; }
            set { _veritabani = value; }
        }
        // Constructor Injection
        // Loosely Coupled
        public DatabaseManager(ICrud veritabani)
        {
            _veritabani = veritabani;
        }

        public DatabaseManager()
        {
        }

        public List<string> VerileriListele()
        {
            return _veritabani.Listele();
        }


        // method injection
        public void MethodInjection(ICrud db)
        {
            _veritabani = db;
        }
    }
}
