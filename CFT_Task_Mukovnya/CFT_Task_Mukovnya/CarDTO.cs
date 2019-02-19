using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT_Task_Mukovnya
{
    [Serializable]
    class CarDTO
    {
        public string Manufacturer {
            get { return Manufacturer; }
            set
            {
                if (value is string && value != null)
                    Manufacturer = value;
                else throw new ArgumentException();
            } }
        private string Model
        {
            get { return Model; }
            set
            {
                if (value is string && value != null)
                    Model = value;
                else throw new ArgumentException();
            }
        }
        private BodyType BodyType { get; set; }
        private CarClass Class { get; set; }
        private short ProductionYear { get; set; }

        public CarDTO(string man, string model, BodyType type, CarClass carClass, short year)
        {
            Manufacturer = man;
            Model = model;
            BodyType = type;
            Class = carClass;
            ProductionYear = year;
        }
    }
}
