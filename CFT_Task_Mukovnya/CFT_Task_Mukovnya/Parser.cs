using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT_Task_Mukovnya
{
    static class Parser
    {
        public static CarDTO Parse(string data)
        {
            try
            {
                Enum tmp = BodyType.Sedan;
                string[] splitted = data.Split(' ');

                return new CarDTO(splitted[0], splitted[1], (BodyType)TypeDescriptor.GetConverter(tmp).ConvertFrom(splitted[2]),
                    (CarClass)TypeDescriptor.GetConverter(CarClass.A).ConvertFrom(splitted[3]), short.Parse(splitted[4]));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
