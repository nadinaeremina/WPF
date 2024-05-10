using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace English_for_kids
{
    [Serializable]
    public class Player
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public int Age { get; set; }
        public string Rating { get; set; }
        public override string ToString()
        {
            return $" {First_name} {Last_name} {Age} {Rating}";
        }
    }
}
