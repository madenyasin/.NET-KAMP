using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Depo<T>
    {
        public void Ekle(T entity)
        {

        }

        public List<T> Listele()
        {
            return new List<T>();
        }
    }
}
