using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CFT_Task_Mukovnya
{
    class Program
    {
        private static Catalog catalog;

        static void Main(string[] args)
        {

            List<CarDTO> directory = CarsSerializer.Deserialize();
            catalog = new Catalog(directory);

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
        }

        private static void ProcessCommand(string command, Catalog catalog)
        {
            switch (command)
            {
                case "add":
                    Console.WriteLine(Messages.Add);
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
                    Console.WriteLine(Messages.Delete);
                    try
                    {
                        var deleteIndex = int.Parse(Console.ReadLine());
                        catalog.Delete(deleteIndex);
                    }
                    catch (Exception)
                    { 
                        Console.WriteLine(Messages.DeleteError);
                    }
                    break;

                case "edit":
                    Console.WriteLine(Messages.Edit);
                    try
                    {
                    var editIndex = int.Parse(Console.ReadLine());
                    catalog.Replace(editIndex, Parser.Parse(Console.ReadLine()));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(Messages.DeleteError);
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

                default:
                    Console.WriteLine(Messages.Help);
                    break;
            }
            CarsSerializer.Serialize(catalog.Directory);
        }
    }
}
