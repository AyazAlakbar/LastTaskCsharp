using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper
{
    public static class Helpers
    {
        public static void HelperMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public enum Cases
        {

            CreateUser = 1,
            DeleteUser,
            GetAllUsers,
            GetUserById,
            CreateStatus,
            DeleteStatus,
            GetStatusInfo,
            ShareStatus,
            GetAllStatuses,
            GetStatusById,
            FilterStatusByDate,
            GetAllStatusesByUsername,
            GetUserByUserName,
            Quit = 0
        }


        public const string ButtonMessage = "Click button to continue";
        public const string MenuMessage = 
            "1 - Create User\n" +
            "2 - Delete User\n" +
            "3 - Get All Users\n" +
            "4 - Get User By Id\n" +
            "5 - Create Status\n" +
            "6 - Delete Status\n"+
            "7 - Get Status Info\n" +
            "8 - Share Status\n" +
            "9 - Get All Statuses\n" +
            "10 - Get Status by ID\n" +
            "11 - Filter Status by Date\n" +
            "12 - Get All Statuses By Username\n" +
            "13 - Get User By User Name\n" +
            "0 - Quit";






    }
}
