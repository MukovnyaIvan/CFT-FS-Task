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
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            Catalog.


        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            CarsSerializer.Serialize(new List<CarDTO>());
        }
    }
}
