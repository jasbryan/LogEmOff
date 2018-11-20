using System;

namespace LogEmOff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********************");
            Console.WriteLine("Welcome to LogEm Off");
            Console.WriteLine("**********************");
            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Add a User");
                Console.WriteLine("2. Add a Computer");
                Console.WriteLine("3. Add a Login");
                Console.WriteLine("4. Print all Login Info");
                Console.Write("Please select an option:");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.WriteLine("Please enter the First Name:");
                            var fName = Console.ReadLine();
                            Console.Write("Please Last Name:");
                            var lName = Console.ReadLine();
                            var tempUser = Network.AddUser(fName, lName);
                            Console.WriteLine($"FN: {tempUser.FirstName}, LN: {tempUser.LastName}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Something crazy went wrong adding a User:{ex.Message}");
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.Write("Enter name of Computer:");
                            var computerName = Console.ReadLine();
                            var testIP = Network.GetComputerIP(computerName);
                            if(String.IsNullOrEmpty(testIP))
                            {
                                Console.WriteLine("Can not fetch IP address by name, Please enter it here:");
                                testIP = Console.ReadLine();
                            }
                            Console.Write("Enter the Admin Login of the Computer:");
                            var adminLogin = Console.ReadLine();
                            Console.Write("Enter the Admin Password of the Computer:");
                            var adminPassword = Network.EncryptPassword(Console.ReadLine());
                            var newComputer = Network.AddComputer(computerName, testIP, adminLogin, adminPassword);
                            Console.WriteLine($"Computer: {newComputer.ComputerName}, with IP, {newComputer.ComputerIP} was added");
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"{ax.Message}");
                        }
                        break;
                    case "3":
                        PrintAllUsers();
                        try
                        {
                            Console.Write("Eneter User# to add Login for:");
                            var userID = Convert.ToInt32(Console.ReadLine());
                            PrintAllComputers();
                            Console.Write("Enter ComputerId to add Login for:");
                            var computerID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter login to control");
                            var userLogin = Console.ReadLine();
                            var newLogin = Network.AddLogin(userID, computerID, userLogin);
                            Console.WriteLine($"Login: {newLogin.LoginID}, has been added");
                        }
                        catch (FormatException fx)
                        {
                            Console.WriteLine($"{fx.Message}");
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"{ax.Message}");
                        }
                        break;
                    case "4":
                        PrintAllLogins();
                        break;
                    default:
                        break;
                }
            }




        }

        private static void PrintAllLogins()
        {
            //throw new NotImplementedException();
            var daLogins = Network.GetLogins();
            foreach (var tempLogin in daLogins)
            {
                Console.WriteLine($"LoginID: {tempLogin.LoginID}, LoginEnabled: {tempLogin.Enabled} ");
            }
        }

        private static void PrintAllComputers()
        {
            //throw new NotImplementedException();
            var daComputers = Network.GetComputers();
            foreach(var tempComp in daComputers)
            {
                Console.WriteLine($"ComputerID: {tempComp.ComputerName}, ComputerName: {tempComp.ComputerName}");
            }
        }

        private static void PrintAllUsers()
        {
            //throw new NotImplementedException();
            var daUsers = Network.GetUsers();
            foreach (var tempUser in daUsers)
            {
                Console.WriteLine($"UserID: {tempUser.UserID}, UserName: {tempUser.FirstName} {tempUser.LastName}");
            }
        }
    }
}
