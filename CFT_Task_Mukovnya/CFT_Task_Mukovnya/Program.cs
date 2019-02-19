using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT_Task_Mukovnya
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CarDTO> directory = CarsSerializer.Deserialize();
            
            Catalog catalog = new Catalog(directory);

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            if (catalog.Directory.Count == 0)
            {
                catalog.Prefill();
            }

            catalog.Print();

            Console.ReadLine();

            void OnProcessExit(object sender, EventArgs e)
            {
                CarsSerializer.Serialize(catalog.Directory);
            }
        }
    }
}
