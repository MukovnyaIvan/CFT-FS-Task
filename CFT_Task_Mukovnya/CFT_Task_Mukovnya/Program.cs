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

            while (true)
            {
                var command = Console.ReadLine();
                switch (command)
                {
                    case "add":
                        var newCar = Console.ReadLine();
                        catalog.Add(Parser.Parse(newCar));
                        break;
                    case "delete":
                        var index = int.Parse(Console.ReadLine());
                        catalog.Delete(index);
                        break;
                    case "print":
                        catalog.Print();
                        break;
 
                }
            }

            void OnProcessExit(object sender, EventArgs e)
            {
                CarsSerializer.Serialize(catalog.Directory);
            }
        }
    }
}
