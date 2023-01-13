using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper
{
    public class Helpers
    {
        public static void HelperMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public enum Cases
        {
            CreateStatus=1,
            ShareStatus ,
            UpdateStatus,
            GetAllStatuses,
            DeleteStatus,
            GetStatusById,
            FilterStatusByDate,
            Quit
        }



        public const string MenuMessage =
          "1-Create Status\n"
        + "2-Share Status\n"
        + "3-Update Status"
        + "4-Get All Statuses\n"
        + "5-Delete Status\n"
        + "6-Get Status By Id\n"
        + "7-Filter Status By Date\n"
        + "8-Quit\n";
     


        


    }
}
