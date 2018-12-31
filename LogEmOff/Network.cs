using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace LogEmOff
{
    /// <summary>
    /// Factory class that will hold all of the Login and User information
    /// </summary>
    public static class Network
    {
        #region Properties


        /*
        /// <summary>
        /// List of users
        /// </summary>
        private static List<User> networkUsers = new List<User>();

        /// <summary>
        /// List of logins
        /// </summary>
        private static List<Login> networkLogins = new List<Login>();

        /// <summary>
        /// List of computers
        /// </summary>
        private static List<Computer> networkComputers = new List<Computer>();
        */

        private static NetworkModel db = new NetworkModel();
               
        #endregion

        #region Methods


        /// <summary>
        /// Add a new Login to the network
        /// </summary>
        /// <param name="userLogin">Login to be configured</param>
        /// <param name="user">The user that uses this login</param>
        /// <param name="ComputerName">the computer that the login works on</param>
        public static Login AddLogin(int userID, int computerID, string userLogin)
        {
            var tempLogin = new Login
            {
                UserID = userID,
                ComputerID = computerID,
                LoginName = userLogin
            };

            //networkLogins.Add(tempLogin);
            db.Logins.Add(tempLogin);
            db.SaveChanges();
            return tempLogin;

        }


        /// <summary>
        /// Adding a user to control accounts
        /// </summary>
        /// <param name="firstName">First Name of user</param>
        /// <param name="lastName">Last Name of user</param>
        public static User AddUser(string firstName, string lastName)
        {
            var newUser = new User(firstName, lastName);
            //networkUsers.Add(newUser);
            db.Users.Add(newUser);
            db.SaveChanges();
            return newUser;

        }

        /// <summary>
        /// Add a computer and the admin credetials to control accounts on it
        /// </summary>
        /// <param name="adminLogin">Administrator account login</param>
        /// <param name="adminPassword">Administrator account password</param>
        /// <param name="name">Computer Name</param>
        /// <param name="ip">Internet Protocol Address</param>
        /// <param name="mac">Machine Address</param>
        public static Computer AddComputer(string name, string ip , string adminLogin, string adminPassword)
        {
            var tempComputer = new Computer(name, ip, adminLogin, adminPassword);
            //networkComputers.Add(tempComputer);
            db.Computers.Add(tempComputer);
            db.SaveChanges();
            return tempComputer;

        }


        public static string GetComputerIP(string computerName)
        {
            //code to fetch computer IP address
            return "192.168.0.1";
        }

        /// <summary>
        /// Function retrieves all computers that have been configured
        /// </summary>
        /// <returns>List of Computer objects</returns>
        public static IEnumerable<Computer> GetComputers()
        {
            //return networkComputers;
            return db.Computers;
        }

        /// <summary>
        /// Function retrieves all Users that have been configured
        /// </summary>
        /// <returns>List of User objects</returns>
        public static IEnumerable<User> GetUsers()
        {
            //return networkUsers;
            return db.Users;
        }

        public static IEnumerable<Login> GetBigLogins()
        {
            var logins = db.Logins.Include(l => l.Computer).Include(l => l.User).ToList();
            return logins;
        }


        /// <summary>
        /// Function retrievs all Logins that have been configured
        /// </summary>
        /// <returns>List of Login objects</returns>
        public static IEnumerable<Login> GetLogins()
        {
            //return networkLogins;
            return db.Logins;
        }

        public static Login GetLoginById(int id)
        {
            var tempLogin = db.Logins.SingleOrDefault(a => a.LoginID == id);
            return tempLogin;
            //throw new NotImplementedException();

        }

        public static IEnumerable<Login> GetLoginsByUserId(int id)
        {
            var tempLogins = db.Logins.Where(a => a.UserID == id);
            return tempLogins;
            //throw new NotImplementedException();

        }

        public static IEnumerable<Login> GetLoginsByComputerId(int id)
        {
            var tempLogins = db.Logins.Where(a => a.ComputerID == id);
            return tempLogins;
            //throw new NotImplementedException();

        }

        public static Computer GetComputerByID(int computerID)
        {
            //return networkComputers.SingleOrDefault(a => a.ComputerID == computerID);
            return db.Computers.SingleOrDefault(a => a.ComputerID == computerID);

        }

        public static User GetUserByID(int userID)
        {
            //return networkUsers.SingleOrDefault(a => a.UserID == userID);
            return db.Users.SingleOrDefault(a => a.UserID == userID);
        }

        public static void EditUser(User user)
        {
            var oldUser = Network.GetUserByID(user.UserID);
            oldUser.FirstName = user.FirstName;
            oldUser.LastName = user.LastName;
            db.Update(oldUser);
            db.SaveChanges();

        }

        public static void EditComputer(Computer computer)
        {
            var oldComp = Network.GetComputerByID(computer.ComputerID);
            oldComp.AdminLogin = computer.AdminLogin;
            oldComp.AdminPassword = computer.AdminPassword;
            oldComp.ComputerIP = computer.ComputerIP;
            oldComp.ComputerMAC = computer.ComputerMAC;
            oldComp.ComputerName = computer.ComputerName;

            db.Update(oldComp);
            db.SaveChanges();

        }

        public static void EditLogin(Login login)
        {
            var oldLogin = Network.GetLoginById(login.LoginID);
            oldLogin.UserID = login.UserID;
            oldLogin.ComputerID = login.ComputerID;
            oldLogin.LoginName = login.LoginName;
            oldLogin.Enabled = login.Enabled;

            db.Update(oldLogin);
            db.SaveChanges();

        }

        public static bool DeleteUser(int id)
        {
            
            if( db.Logins.Any(a => a.UserID == id ) )
            {
                return false;
            }
            var usrToDelete = Network.GetUserByID(id);
            db.Users.Remove(usrToDelete);
            db.SaveChanges();
            return true;

        }

        public static bool DeleteComputer(int id)
        {

            if (db.Logins.Any(a => a.ComputerID == id))
            {
                return false;
            }
            var compsToDelete = Network.GetUserByID(id);
            db.Users.Remove(compsToDelete);
            db.SaveChanges();
            return true;
        }

        public static bool UserExists(int id)
        {
            return db.Users.Any(e => e.UserID == id);
        }



        public static string EncryptPassword(string password)
        {
            //run code to encrypt password
            return $"ENCRYPTED__{password}";
        }




        #endregion
    }


}
