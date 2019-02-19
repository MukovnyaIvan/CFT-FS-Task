using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CFT_Task_Mukovnya
{
    class CarsSerializer
    {
        private static readonly BinaryFormatter formatter = new BinaryFormatter();
        private static readonly string path = "catalog.dat";

        public static void Serialize(List<CarDTO> list)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                formatter.Serialize(fs, list);
        }

        public static List<CarDTO> Deserialize()
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                    return (List<CarDTO>)formatter.Deserialize(fs);
            }
            catch (SerializationException)
            {
                return new List<CarDTO>();
            }
        }
    }
}
