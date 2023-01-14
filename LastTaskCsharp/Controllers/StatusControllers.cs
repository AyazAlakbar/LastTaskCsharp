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
    public class StatusControllers
    {
        private readonly UserService userService;
        private readonly StatusService statusService;
        private readonly UserControllers usersController;
        
        
        public StatusControllers()
        {
            usersController = new UserControllers();
            statusService = new StatusService();
            userService= new UserService();
        }


        public void CreateStatus()
        {
            CorrectTitle: Helpers.HelperMessage(ConsoleColor.Green, "Type Title");
            string stringTitle = Console.ReadLine();
            if (stringTitle=="")
            {
                Helpers.HelperMessage(ConsoleColor.Green, "Can not be empty");
                goto CorrectTitle;
            }
            
        
           CorrectContent: Helpers.HelperMessage(ConsoleColor.Green, "Type Content");
            string stringContent = Console.ReadLine();
            if (stringContent == "")
            {
                Helpers.HelperMessage(ConsoleColor.Green, "Can not be empty");
                goto CorrectContent;
            }


            usersController.GetAllUsers();
        CorrectId: Helpers.HelperMessage(ConsoleColor.Green, "Chose ID for create status");
            int id;
            string stringId=Console.ReadLine();
            bool isConverted=int.TryParse(stringId, out id);
            if (stringId=="")
            {
                Helpers.HelperMessage(ConsoleColor.Green, "ID can not be empty");
                goto CorrectId;
            }

            if (isConverted)
            {
                if (userService.GetUserById(id)==null)
                {
                    Helpers.HelperMessage(ConsoleColor.Green, $"user {id} not exist");
                    goto CorrectId;
                }
            }
            else
            {
                Helpers.HelperMessage(ConsoleColor.Green, "type correct");
                
            }

            Status status = new(stringTitle, stringContent);
            Status newStatus = statusService.Create(status, id);
            if (newStatus!=null)
            {
                Helpers.HelperMessage(ConsoleColor.Green, $"Status created");
                return;
                
            }
            Helpers.HelperMessage(ConsoleColor.Green, "status doesnt created");
            
        }


        public void DeleteStatus()
        {
            GetAllStatuses();
        CorrectId: Helpers.HelperMessage(ConsoleColor.DarkYellow, "Choose ID of user to delete status");
            int result;
            string stringId = Console.ReadLine();
            bool isConverted = int.TryParse(stringId, out result);
            if (isConverted)
            {
                if (statusService.Delete(result) != null)
                {
                    Helpers.HelperMessage(ConsoleColor.Green, $"status {result} is deleted");
                    return;
                }
                Helpers.HelperMessage(ConsoleColor.Red, "ID does not exist, please choose correct ID");

            }
            else
            {
                Helpers.HelperMessage(ConsoleColor.Red, "Type correct ID");
                goto CorrectId;
            }
        }


        public void GetStatusById()
        {
           GetAllStatuses();
        CorrectId: Helpers.HelperMessage(ConsoleColor.Green, "Choose Id");

            int id;
            string stringId = Console.ReadLine();
            bool isConverted=int.TryParse(stringId, out id);
            if (stringId=="")
            {
                Helpers.HelperMessage(ConsoleColor.Green, "Id can't be empty");
            }
            Status status=statusService.GetStatusById(id);
            if (isConverted)
            {
                if (status!=null)
                {
                    Helpers.HelperMessage(ConsoleColor.Green, $"ID-{status.Id} Title-{status.Title} Content-{status.Content} Shared Date-{status.SharedDate}");
                    return;
                }
                Helpers.HelperMessage(ConsoleColor.Green, $"Status with ID {id} doesn't exist");
                return ;
            }
            Helpers.HelperMessage(ConsoleColor.Green, "Correct ID");
        }


        public void GetAllStatuses()
        {
            Helpers.HelperMessage(ConsoleColor.Green, "Statuses");
            foreach (var item in statusService.GetAll())
            {
                Helpers.HelperMessage(ConsoleColor.Green, $"ID-{item.Id} Title-{item.Title} Content-{item.Content} Shared Date-{item.SharedDate}");
            }
        }


        public void GetStatusInfo()
        {
            GetAllStatuses();
        CorrectId: Helpers.HelperMessage(ConsoleColor.Green, "Choose ID");

            int id;
            string stringId = Console.ReadLine();
            bool isConverted = int.TryParse(stringId, out id);
            if (stringId == "")
            {
                Helpers.HelperMessage(ConsoleColor.Green, "Id can't be empty");
            }
            Status status = statusService.GetStatusInfo(id);
            if (isConverted)
            {
                if (status != null)
                {
                    TimeSpan sharedAgo=(DateTime.Now.Subtract(status.SharedDate));
                    Helpers.HelperMessage(ConsoleColor.Green, $"ID-{status.Id} Title-{status.Title} Content-{status.Content} Shared Date-{status.SharedDate}");
                    return;
                }
                Helpers.HelperMessage(ConsoleColor.Green, $"Status with ID {id} doesn't exist");
                return;
            }
            Helpers.HelperMessage(ConsoleColor.Green, "Correct ID");
            goto CorrectId;

        }


        public void FilterStatusByDate()
        {
            usersController.GetAllUsers();
            CorrectId: Helpers.HelperMessage(ConsoleColor.Green, "Choose ID");

            int id;
            string stringId = Console.ReadLine();
            bool isConverted = int.TryParse(stringId, out id);
            if (stringId == "")
            {
                Helpers.HelperMessage(ConsoleColor.Green, "Id can't be empty");
                goto CorrectId;
            }
            if (isConverted)
            {
                User existUser = userService.GetUserById(id);
                if (existUser==null)
                {
                    Helpers.HelperMessage(ConsoleColor.Green, $"User with {id} doesn't exist");
                    goto CorrectId;
                }

            }
            else
            {
                Helpers.HelperMessage(ConsoleColor.Green, "Correct ID");
                goto CorrectId;
            }



            User user = userService.GetUserById(id);

        CorrectYear: Helpers.HelperMessage(ConsoleColor.DarkYellow, "Please type year");
            Helpers.HelperMessage(ConsoleColor.DarkGreen, "Example:'2001' or '2022'");

            int year;
            string stringYear = Console.ReadLine();
            bool yeaIsConverted = int.TryParse(stringYear, out year);
            if (stringYear == "")
            {
                Helpers.HelperMessage(ConsoleColor.Red, "Year can not be empty");
                goto CorrectYear;
            }
            if (!yeaIsConverted || year < 2000 || year > 2023)
            {
                Helpers.HelperMessage(ConsoleColor.Red, "Type year correctly, look at example");
                goto CorrectYear;
            }

            if (!yeaIsConverted)
            {
                Helpers.HelperMessage(ConsoleColor.Red, "Type year correctly");
                goto CorrectYear;
            }

        CorrectMonth: Helpers.HelperMessage(ConsoleColor.DarkYellow, "Please type month");
            Helpers.HelperMessage(ConsoleColor.DarkGreen, "Example:'07' or '11'");

            int month;
            string stringMonth = Console.ReadLine();
            bool monthIsConverted = int.TryParse(stringMonth, out month);
            if (stringMonth == "")
            {
                Helpers.HelperMessage(ConsoleColor.Red, "Month can not be empty");
                goto CorrectMonth;
            }
            if (!monthIsConverted || month == 0 || month > 13)
            {
                Helpers.HelperMessage(ConsoleColor.Red, "Type month correctly, look at example");
                goto CorrectMonth;
            }

        CorrectDay: Helpers.HelperMessage(ConsoleColor.DarkYellow, "Please type day");
            Helpers.HelperMessage(ConsoleColor.DarkGreen, "Example:'03' or '23' or '31'");

            int day;
            string stringDay = Console.ReadLine();
            bool dayIsConverted = int.TryParse(stringDay, out day);
            if (stringDay == "")
            {
                Helpers.HelperMessage(ConsoleColor.Red, "Day can not be empty");
                goto CorrectDay;
            }
            if (!dayIsConverted || day == 0 || day > 32)
            {
                Helpers.HelperMessage(ConsoleColor.Red, "Type day correctly,look at example");
                goto CorrectDay;
            }

            if (isConverted)
            {
                if (user != null)
                {
                    if (statusService.FilterStatusByDate(id, new DateTime(year, month, day)) != null)
                    {
                        foreach (var item in statusService.FilterStatusByDate(id, new DateTime(year, month, day)))
                        {
                            Helpers.HelperMessage(ConsoleColor.Green, $"{item.Title} - {item.Content}");
                            return;
                        }
                        throw new NotFoundException("alooo");
                    }
                    Helpers.HelperMessage(ConsoleColor.Red, $"There is not any status after providen period");

                    return;
                }
                Helpers.HelperMessage(ConsoleColor.Red, $"Status with ID #{id} does not exist");
                return;
            }
            Helpers.HelperMessage(ConsoleColor.Red, "Type ID correctly");

        }


        public void GetAllStatusesByUsername()
        {
            //userController.GetAllUsers();

            List<User> users = userService.GetAll();
            foreach (var item in users)
            {
                Helpers.HelperMessage(ConsoleColor.Green, $"ID:{item.Id} Username:{item.Username}");
            }

            Helpers.HelperMessage(ConsoleColor.DarkYellow, "Please type username");
            string userName = Console.ReadLine();
            List<Status> statuses = statusService.GetAllStatusesByUsername(userName);
            if (userService.GetUserByUserName(userName) != null)
            {
                if (statuses.Count > 0)
                {
                    Helpers.HelperMessage(ConsoleColor.Green, $"{userName} username statuses are:");
                    foreach (var item in statuses)
                    {
                        Helpers.HelperMessage(ConsoleColor.Green, $"Title:{item.Title}. Content:{item.Content}");
                    }
                    return;
                }
                else
                    Helpers.HelperMessage(ConsoleColor.Red, $"{userName} username has not any status");
            }
            else
                Helpers.HelperMessage(ConsoleColor.Red, $"{userName} username, does not exist");
        }

    }





}

    

