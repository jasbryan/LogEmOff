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
        private String AdminLogin;

        /// <summary>
        /// Stores admin password String
        /// </summary>
        private String AdminPassword;

        /// <summary>
        /// Name for computer on the network
        /// </summary>
        public String ComputerName { get; set; }

        /// <summary>
        /// IP address that the computer is assigned
        /// </summary>
        public String ComputerIP { get; }

        /// <summary>
        /// MAC for the computer to track
        /// </summary>
        public String ComputerMAC { get; }

        #endregion

        #region Constructors

        public Computer(String computerName, String computerIP, String adminLogin, String adminPassword, String computerMAC="")
        {
            ComputerName = computerName;
            ComputerIP = computerIP;
            AdminLogin = adminLogin;
            AdminPassword = encryptPassword(adminPassword);
            ComputerMAC = computerMAC;
        }

        #endregion
        
        #region Methods
        
        private String encryptPassword(String password)
        {
            //some code to encrypt password
        }

        
        /// <summary>
        /// Tests connectivity to Computer object
        /// </summary>
        /// <returns>True if computer is reachable and flase if not</returns>
        public bool pingComputer()
        {

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
