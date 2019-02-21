using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT_Task_Mukovnya
{
    class Catalog
    {
        public List<CarDTO> Directory { get; set; }

        public Catalog(List<CarDTO> dir)
        {
            Directory = dir;
        }

        public void Prefill()
        {
            Directory.Add(new CarDTO("Skoda", "Octavia", BodyType.Liftback, CarClass.C, 2012));
            Directory.Add(new CarDTO("Chevrolet", "Cruze", BodyType.Sedan, CarClass.C, 2012));
            Directory.Add(new CarDTO("Toyota", "Corolla", BodyType.Sedan, CarClass.B, 2002));
        }

        public void Print()
        {
            for (var i = 0; i < Directory.Count; i++)
                Print(i);
        }
        public void Print(int index)
        {
            Console.WriteLine("| {0} |{1}", index, Directory[index].ToString());
        }

        public void Add(CarDTO car)
        {
            if (IsCorrect(car))
            {
                Directory.Add(car);
                return;
            }
            throw new ArgumentException();
        }

        public void Delete(int index)
        {
            if (!IsInBounds(index))
            {
                Directory.RemoveAt(index);
                return;
            }
            throw new ArgumentException();
        }

        public void Replace(int index, CarDTO car)
        {
            if (IsCorrect(car) && IsInBounds(index))
            {
                Directory[index] = car;
                return;
            }
            throw new ArgumentException();
        }

        private bool IsCorrect(CarDTO car)
        {
            return (car.Manufacturer != null && car.Model != null);
        }

        private bool IsInBounds(int index)
        {
            return index >= 0 && index < Directory.Count;
        }
    }

}
