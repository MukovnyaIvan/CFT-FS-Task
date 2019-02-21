using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT_Task_Mukovnya
{
    public class Messages
    {
        public static readonly string Welcome =
@"Welcome to car catalog application. 
If you need some information about commands, enter ""help""
";

        public static readonly string Help =
@"
There are 4 possible commands:
""add"" for adding a new car to dictionary
""delete"" for deleting specified car
""edit"" for editing specified car
""print"" for print the whole dictionary
";

        public static readonly string Add =
@"
Enter the data. Keep in mind, that brand and model are needed at least
";

        public static readonly string Delete =
@"
Enter an index of recording, which you want to delete
";

        public static readonly string Edit =
@"
Enter an index of recording, which you want to edit.
Then enter new data. Keep in mind, that brand and model are needed at least
";

        public static readonly string AddError =
@"
Command argumets are incorrect. Usage is: 
Manufacturer Model (optional)BodyType Class ProductionYear
";

        public static readonly string DeleteError =
@"
Thre is no car with such index
";

        public static readonly string EditError =
@"
Command argumets are incorrect. Data must be in format:
Manufacturer Model (optional)BodyType Class ProductionYear
";




    }
}
