using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace My_MVVM
{
    public class JsonSerialFile : IFileService
    {
        public List<Tovar> Open(string filename)
        {
            List<Tovar> tovars = new List<Tovar>();

            // создаем об-т сериализации
            DataContractJsonSerializer jF = new DataContractJsonSerializer(typeof(List<Tovar>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                tovars = jF.ReadObject(fs) as List<Tovar>;
            }
            return tovars;
        }

        public void Save(string filename, List<Tovar> tovar_List)
        {
            DataContractJsonSerializer jF = new DataContractJsonSerializer(typeof(List<Tovar>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                jF.WriteObject(fs, tovar_List);
            }
        }
    }

    public interface IFileService
    {
        List<Tovar> Open(string filename);
        void Save(string filename, List<Tovar> tovar_list);
    }
}
