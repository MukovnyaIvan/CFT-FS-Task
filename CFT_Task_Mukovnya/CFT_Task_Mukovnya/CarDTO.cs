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
        public string Manufacturer { get; set; }
        public string Model{ get; set; }
        public BodyType BodyType { get; set; }
        public CarClass Class { get; set; }
        public short ProductionYear { get; set; }

        public CarDTO(string man, string model, BodyType type, CarClass carClass, short year)
        {
            Manufacturer = man;
            Model = model;
            BodyType = type;
            Class = carClass;
            ProductionYear = year;
        }
        public override string ToString()
        {
            return string.Format(" {0,-15}| {1,-12}| {2,-11}| {3,-2}| {4,-5}|", 
            Manufacturer, Model, BodyType.ToString(), Class.ToString(), ProductionYear);
        }
    }
}
