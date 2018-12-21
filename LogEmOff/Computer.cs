using System;
using System.Collections.Generic;
using System.Text;

namespace LogEmOff
{
    /// <summary>
    /// The Computer class will represent the unique device information
    /// </summary>
    public class Computer
    {
        //private static int lastComputerID = 0;

        #region Properties
        
        /// <summary>
        /// Strores admin login String
        /// </summary>
        public string AdminLogin { get; set; }

        /// <summary>
        /// Stores admin password String
        /// </summary>
        public string AdminPassword { get; set; }

        /// <summary>
        /// Name for computer on the network
        /// </summary>
        public string ComputerName { get; set; }

        /// <summary>
        /// IP address that the computer is assigned
        /// </summary>
        public string ComputerIP { get; set; }

        /// <summary>
        /// MAC for the computer to track ( possible for WakeOnLAN )
        /// </summary>
        public string ComputerMAC { get; set; }

        /// <summary>
        /// ID used to track Computer in DB
        /// </summary>
        public int ComputerID { get; set; }

        /// <summary>
        /// Image to represent an online computer
        /// </summary>
        public byte[] GreenImage { get; set; }

        /// <summary>
        /// Image to represent an offline computer
        /// </summary>
        public byte[] RedImage { get; set; }

        public bool Online { get; set; }

        public virtual ICollection<Login> Logins { get; set; }

        #endregion

        #region Constructors

        public Computer()
        {
            //nothing here
            TestConnection();
        }


        public Computer(string computerName, string computerIP, string adminLogin, string adminPassword)
        {
            ComputerName = computerName;
            ComputerIP = computerIP;
            AdminLogin = adminLogin;
            AdminPassword = adminPassword;
            //code to fetch MAC
            /*
            if (String.IsNullOrEmpty(mac) ) { getMAC(); }
            testMAC();
            */
        }
        
        #endregion

        #region Methods

        private void testMAC()
        {
            throw new NotImplementedException();

        }

        private void getMAC()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tests connectivity to Computer object
        /// </summary>
        /// <returns>True if computer is reachable and flase if not</returns>
        public bool PingComputer()
        {
            return true;

        }

        /// <summary>
        /// Login to computer and retrieve state of accountnmae that was passed
        /// </summary>
        /// <param name="loginID">Username on machine</param>
        /// <returns></returns>
        public string LoginState(string LoginName)
        {
            return "Nothing";
        }

        /// <summary>
        /// Logs into computer and attempts to disable the username that was passed
        /// </summary>
        /// <param name="loginID">username to disable</param>
        internal void DisableLogin(string LoginName)
        {
            throw new NotImplementedException();
        }

        public void TestConnection()
        {
            //test connectivity to machine and update online flag
            Online = false;
            ComputerMAC = "";
        }

        public bool RedImageExists()
        {
            
            return false;
        }



        #endregion

    }
}
