using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT_Task_Mukovnya
{
    static class Catalog
    {
        public static List<CarDTO> Directory { get; private set; }

        public static void Prefill()
        {
            Directory.Add(new CarDTO("Skoda", "Octavia", BodyType.Liftback, CarClass.C, 2012));
            Directory.Add(new CarDTO("Chevrolet", "Cruze", BodyType.Sedan, CarClass.C, 2012));
            Directory.Add(new CarDTO("Toyota", "Corolla", BodyType.Sedan, CarClass.B, 2002));
        }

    }
}
