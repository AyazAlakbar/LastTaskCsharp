using LastTaskCsharp.Controllers;
using Utilities.Helper;


Helpers.HelperMessage(ConsoleColor.Green, Helpers.MenuMessage);

UserControllers userController = new();
StatusControllers statusController = new();
bool whileResult = true;
while (whileResult)
{
    Helpers.HelperMessage(ConsoleColor.Blue, Helpers.ButtonMessage);

    int menuNumber;
    string selectedButton = Console.ReadLine();
    bool isConverted = int.TryParse(selectedButton, out menuNumber);

    if (isConverted && menuNumber < 13 && menuNumber > 0)
    {
        switch (menuNumber)
        {
            case (int)Helpers.Cases.CreateUser:
                userController.Create();
                break;

            case (int)Helpers.Cases.DeleteUser:
                userController.Delete();
                break;

            case (int)Helpers.Cases.GetAllUsers:
                userController.GetAllUsers();
                break;

            case (int)Helpers.Cases.GetUserById:
                userController.GetUserById();
                break;
           

            case (int)Helpers.Cases.CreateStatus:
                statusController.CreateStatus();
                break;

            case (int)Helpers.Cases.DeleteStatus:
                userController.DeleteStatus();
                break;

            case (int)Helpers.Cases.GetStatusInfo:
                statusController.GetStatusInfo();
                break;

            case (int)Helpers.Cases.ShareStatus:
                userController.ShareStatus();
                break;

            case (int)Helpers.Cases.GetAllStatuses:
                statusController.GetAllStatuses();
                break;

            case (int)Helpers.Cases.GetStatusById:
                statusController.GetStatusById();
                break;

            case (int)Helpers.Cases.FilterStatusByDate:
                statusController.FilterStatusByDate();
                break;

            case (int)Helpers.Cases.GetAllStatusesByUsername:
                statusController.GetAllStatusesByUsername();
                break;

            case (int)Helpers.Cases.GetUserByUserName:
                userController.GetUserByUserName();
                break;

            case (int)Helpers.Cases.Quit:
                whileResult = false;
                break;

            default:
                break;
        }
    }
    else
    {
        Helpers.HelperMessage(ConsoleColor.Red, "Choose correct button");
    }
}