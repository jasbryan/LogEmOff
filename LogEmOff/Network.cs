using System;
using System.Collections.Generic;
using System.Text;

namespace LogEmOff
{
    /// <summary>
    /// Factory class that will hold all of the Login and User information
    /// </summary>
    static class Network
    {
        #region Properties

        /// <summary>
        /// List of users
        /// </summary>
        private static List<User> networkUsers = new List<User>();

        /// <summary>
        /// List of logins
        /// </summary>
        private static List<Login> netowrkLogins = new List<Login>();

        /// <summary>
        /// List of computers
        /// </summary>
        private static List<Computer> networkComputers = new List<Computer>();

        #endregion

        #region Methods

        
        /// <summary>
        /// Add a new Login to the network
        /// </summary>
        /// <param name="userLogin">Login to be configured</param>
        /// <param name="user">The user that uses this login</param>
        /// <param name="ComputerName">the computer that the login works on</param>
        public static void AddLogin(string userLogin, string user, string ComputerName)
        {


        }


        /// <summary>
        /// Adding a user to control accounts
        /// </summary>
        /// <param name="firstName">First Name of user</param>
        /// <param name="lastName">Last Name of user</param>
        public static void AddUser(string firstName, string lastName)
        {

        }

        /// <summary>
        /// Add a computer and the admin credetials to control accounts on it
        /// </summary>
        /// <param name="adminLogin">Administrator account login</param>
        /// <param name="adminPassword">Administrator account password</param>
        /// <param name="name">Computer Name</param>
        /// <param name="ip">Internet Protocol Address</param>
        /// <param name="mac">Machine Address</param>
        public static void AddComputer(string adminLogin, string adminPassword, string name, string ip="",string mac="")
        {

        }

        /// <summary>
        /// Function retrieves all computers that have been configured
        /// </summary>
        /// <returns>List of Computer objects</returns>
        public static IEnumerable<Computer> GetComputers()
        {
            return networkComputers;
        }

        /// <summary>
        /// Function retrieves all Users that have been configured
        /// </summary>
        /// <returns>List of User objects</returns>
        public static IEnumerable<User> GetUsers()
        {
            return networkUsers;
        }

        /// <summary>
        /// Function retrievs all Logins that have been configured
        /// </summary>
        /// <returns>List of Login objects</returns>
        public static IEnumerable<Login> GetLogins()
        {
            return netowrkLogins;
        }


        #endregion
    }


}
