using System;
using System.Collections.Generic;
using System.Text;

namespace LogEmOff
{
    /// <summary>
    /// This class will represent login data
    /// </summary>
    class Login
    {
        #region Properties

        /// <summary>
        /// The user that this login is for
        /// </summary>
        public User LoginUser { get;}

        /// <summary>
        /// The computer that this login is on
        /// </summary>
        public Computer LoginComputer { get;}

        /// <summary>
        /// The login that is used on this computer for this user
        /// </summary>
        private string LoginID;

        #endregion

        #region Constuctor
        /// <summary>
        /// Creates a Login objest to allow us to set or unset access
        /// </summary>
        /// <param name="user">User that this login is associatted with</param>
        /// <param name="computer">Computer that this login is on</param>
        /// <param name="loginID">The login ID that exists on the computer</param>
        public Login(User user,Computer computer, string loginID)
        {
            LoginUser = user;
            LoginComputer = computer;
            LoginID = loginID;

        }
        #endregion


        #region Methods
        /// <summary>
        /// Test connectvity and if login is active and enabled
        /// </summary>
        /// <returns>True if computer is reachable and we are able to valiadte if account is active</returns>
        public bool IsLoginActive()
        {
            string loginState = LoginComputer.LoginState(LoginID);
            if (loginState == "Enabled") { return true; }
            return false;
        }

        /// <summary>
        /// Test connectvity and if login is disabled
        /// </summary>
        /// <returns>True if computer is reachable and we are able to valiadte if account is disabled</returns>
        public bool IsLoginDisabled()
        {
            string loginState = LoginComputer.LoginState(LoginID);
            if (loginState == "Disabled") { return true; }
            return false;
        }

        /// <summary>
        /// Attempt to disable the login on the computer
        /// </summary>
        /// <returns>True if account is disabled</returns>
        public bool DisableLogin()
        {
            if (IsLoginActive()) { LoginComputer.DisableLogin(LoginID); }
            return IsLoginDisabled();
        }
        
        #endregion
    }
}
