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
            Console.WriteLine(Messages.Welcome);

            while (true)
            {
                var command = Console.ReadLine();
                ProcessCommand(command, catalog);
            }

            void OnProcessExit(object sender, EventArgs e)
            {
                CarsSerializer.Serialize(catalog.Directory);
            }
        }

        private static void ProcessCommand(string command, Catalog catalog)
        {
            switch (command)
            {
                case "add":
                    var newCar = Console.ReadLine();
                    try
                    {
                        catalog.Add(Parser.Parse(newCar));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(Messages.AddError);
                    }
                    break;
                case "delete":
                    var deleteIndex = int.Parse(Console.ReadLine());
                    try
                    {
                        catalog.Delete(deleteIndex);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine(Messages.DeleteError);
                    }
                    break;
                case "edit":
                    var editIndex = int.Parse(Console.ReadLine());
                    try
                    {
                        catalog.Replace(editIndex, Parser.Parse(Console.ReadLine()));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(Messages.EditError);
                    }
                    break;
                case "print":
                    catalog.Print();
                    break;
                case "help":
                    Console.WriteLine(Messages.Help);
                    break;
            }
        }
    }
}
