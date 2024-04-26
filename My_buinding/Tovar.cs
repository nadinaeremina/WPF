using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_buinding
{
    class Tovar
    {
        public string Name { get { return "Coffee"; } }
        public string Made { get { return "Nestle"; } }
        public int Cost { get { return 1000; } }
        public override string ToString()
        {
            return $"{Name} {Made} {Cost}";
        }
    }
}
