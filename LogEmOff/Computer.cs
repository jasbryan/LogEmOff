using System;
using System.Collections.Generic;
using System.Text;

namespace LogEmOff
{
    /// <summary>
    /// The Computer class will represent the unique device information
    /// </summary>
    class Computer
    {
        #region Properties
        
        /// <summary>
        /// Strores admin login String
        /// </summary>
        private string AdminLogin;

        /// <summary>
        /// Stores admin password String
        /// </summary>
        private string AdminPassword;

        /// <summary>
        /// Name for computer on the network
        /// </summary>
        public string ComputerName { get; set; }

        /// <summary>
        /// IP address that the computer is assigned
        /// </summary>
        public string ComputerIP { get; }

        /// <summary>
        /// MAC for the computer to track
        /// </summary>
        public string ComputerMAC { get; }

        #endregion

        #region Constructors

        public Computer(string computerName, string computerIP, string adminLogin, string adminPassword, string computerMAC ="")
        {
            ComputerName = computerName;
            ComputerIP = computerIP;
            AdminLogin = adminLogin;
            AdminPassword = encryptPassword(adminPassword);
            ComputerMAC = computerMAC;
        }

        #endregion
        
        #region Methods
        
        private string encryptPassword(string password)
        {
            //some code to encrypt password
            return "testy";
        }

        
        /// <summary>
        /// Tests connectivity to Computer object
        /// </summary>
        /// <returns>True if computer is reachable and flase if not</returns>
        public bool pingComputer()
        {
            return true;

        }

        /// <summary>
        /// Login to computer and retrieve state of accountnmae that was passed
        /// </summary>
        /// <param name="loginID">Username on machine</param>
        /// <returns></returns>
        public string LoginState(string loginID)
        {
            return "Nothing";
        }

        /// <summary>
        /// Logs into computer and attempts to disable the username that was passed
        /// </summary>
        /// <param name="loginID">username to disable</param>
        internal void DisableLogin(string loginID)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
