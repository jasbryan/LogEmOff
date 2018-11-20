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
        private static int lastComputerID = 0;

        #region Properties
        
        /// <summary>
        /// Strores admin login String
        /// </summary>
        private string AdminLogin { get; set; }

        /// <summary>
        /// Stores admin password String
        /// </summary>
        private string AdminPassword { get; set; }

        /// <summary>
        /// Name for computer on the network
        /// </summary>
        public string ComputerName { get; set; }

        /// <summary>
        /// IP address that the computer is assigned
        /// </summary>
        public string ComputerIP { get; set; }

        /// <summary>
        /// MAC for the computer to track
        /// </summary>
        public string ComputerMAC { get; set; }

        public int ComputerID { get; set; }

        #endregion

        #region Constructors

        public Computer(string computerName, string computerIP, string adminLogin, string adminPassword)
        {
            ComputerName = computerName;
            ComputerIP = computerIP;
            AdminLogin = adminLogin;
            AdminPassword = adminPassword;
            //code to fetch MAC
            ComputerMAC = "";
            ComputerID = ++lastComputerID;
        }

        #endregion
        
        #region Methods
        
        
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
