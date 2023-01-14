using Business.Services;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helper;

namespace LastTaskCsharp.Controllers
{
    public class UserControllers
    {
        private readonly UserService userService;
        private readonly StatusService statusService;

        public UserControllers()
        {
            userService = new();
            statusService = new();
        }

        public void Create()
        {
        CorrectName: Helpers.HelperMessage(ConsoleColor.DarkYellow, "Please write user name");
            string name = Console.ReadLine();
            if (name == "")
            {
                Helpers.HelperMessage(ConsoleColor.Red, "Name can not be empty");
                goto CorrectName;
            }
            User user = new User(name);
            user.Username = name;
            User newUser = userService.Create(user);
            if (newUser == null)
            {
                Helpers.HelperMessage(ConsoleColor.Red, $"User with {name} username already exists");
                return;
            }
            Helpers.HelperMessage(ConsoleColor.Green, $"User --{name}-- is created");

        }

        public void Delete()
        {
            GetAllUsers();
        CorrectID: Helpers.HelperMessage(ConsoleColor.DarkYellow, "Please type ID of user to delete");

            int userId;
            string stringId = Console.ReadLine();
            bool isConverted = int.TryParse(stringId, out userId);
            
            if (isConverted)
            {
                if (userService.Delete(userId) != null)
                {
                    Helpers.HelperMessage(ConsoleColor.Green, $"Username with {userId} ID is deleted");
                    return;
                }
                Helpers.HelperMessage(ConsoleColor.Red, $"Username with {userId} ID does not exist, please choose other ID");
                return;
            }
            Helpers.HelperMessage(ConsoleColor.Red, "Type ID correctly");
            goto CorrectID;
        }

        public void GetAllUsers()
        {
            Helpers.HelperMessage(ConsoleColor.DarkYellow, "User list:");

            foreach (var item in userService.GetAll())
            {
                Helpers.HelperMessage(ConsoleColor.Green, $"ID-{item.Id} Username-{item.Username}");
            }

        }

        public void GetUserById()
        {
            GetAllUsers();
        CorrectID: Helpers.HelperMessage(ConsoleColor.Blue, "Please type user ID");
            int userId;
            string stringId = Console.ReadLine();
            bool isConverted = int.TryParse(stringId, out userId);

            User user = userService.GetUserById(userId);
            if (isConverted)
            {
                if (user != null)
                {
                    Helpers.HelperMessage(ConsoleColor.Blue, $"ID-{userId} user is {user}");
                    return;
                }
                Helpers.HelperMessage(ConsoleColor.Red, $"ID #{userId} does not exist");
                return;
            }
            Helpers.HelperMessage(ConsoleColor.Red, "Type ID correctly");
            goto CorrectID;
        }

        public void GetAllStatusesByUsername()
        {

        }

        public void GetUserByUserName()
        {
            GetAllUsers();

            Helpers.HelperMessage(ConsoleColor.DarkYellow, "Please type username");
            string userName = Console.ReadLine();
            User user = userService.GetUserByUserName(userName);
            if (user != null)
            {
                Helpers.HelperMessage(ConsoleColor.Green, $"Username:{user.Username}, ID:{user.Id}");
                return;
            }
            Helpers.HelperMessage(ConsoleColor.Red, $"There is not any user with username:{userName}");

        }

        public void ShareStatus()
        {
            GetAllUsers();
        CorrectUserId: Helpers.HelperMessage(ConsoleColor.DarkYellow, "Please type ID of user");
            int userId;
            string stringUserId = Console.ReadLine();
            bool userIdConverted = int.TryParse(stringUserId, out userId);
            if (stringUserId == "")
            {
                Helpers.HelperMessage(ConsoleColor.Red, "User ID can not be empty");
                goto CorrectUserId;
            }

            List<Status> userStatuses = userService.GetAllStatusesById(userId);
            if (userIdConverted)
            {
                if (userStatuses.Count > 0)
                {
                    foreach (var item in userStatuses)
                    {
                        Helpers.HelperMessage(ConsoleColor.Green, $"Status ID is:{item.Id} Title:{item.Title} Content:{item.Content}");

                    }
                }
                else
                {
                    Helpers.HelperMessage(ConsoleColor.Red, $"User with {userId} have not any status");
                    return;
                }

            }
            else
            {
                Helpers.HelperMessage(ConsoleColor.Red, "Type ID correctly");
                goto CorrectUserId;
            }



       
        CorrectStatusID: Helpers.HelperMessage(ConsoleColor.DarkYellow, "Please type ID of status to share");

            int statusId;
            string stringStatusId = Console.ReadLine();
            bool statusIdConverted = int.TryParse(stringStatusId, out statusId);
            if (stringUserId == "")
            {
                Helpers.HelperMessage(ConsoleColor.Red, "Status ID can not be empty");
                goto CorrectStatusID;
            }

            Status status = statusService.GetStatusById(statusId);
            if (statusIdConverted)
            {
                if (status != null)
                {
                    Helpers.HelperMessage(ConsoleColor.Green, $"Posted status:\n{status.Title}\n{status.Content}");
                    return;
                }
                Helpers.HelperMessage(ConsoleColor.Red, $"User has not status with {statusId} ID");
                return;
            }
            else
            {
                Helpers.HelperMessage(ConsoleColor.Red, "Type ID correctly");
                goto CorrectStatusID;
            }

        }

        internal void DeleteStatus()
        {
            throw new NotImplementedException();
        }
    }
}
