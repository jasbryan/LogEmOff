using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogEmOff
{
    /// <summary>
    /// This class will represent login data
    /// </summary>
    public class Login
    {
        #region Properties

        /// <summary>
        /// The user that this login is for
        /// </summary>
        [ForeignKey("Users")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// The computer that this login is on
        /// </summary>
        [ForeignKey("Computers")]
        public int ComputerID { get; set; }

        public virtual Computer Computer { get; set; }

        /// <summary>
        /// The login that is used on this computer for this user
        /// </summary>
        public string LoginName { get; set; }

        public Boolean Enabled { get; set; }

        public int LoginID { get; set; }

        #endregion

        #region Constuctor
        /// <summary>
        /// Creates a Login objest to allow us to set or unset access
        /// </summary>
        /// <param name="user">User that this login is associatted with</param>
        /// <param name="computer">Computer that this login is on</param>
        /// <param name="loginName">The login ID that exists on the computer</param>
        public Login()
        {
            //User = user;
            //Computer = computer;
            //LoginName = loginName;
            //LoginID = loginID;
            //get state of login later
            Enabled = false;

        }
        #endregion


        #region Methods
        /// <summary>
        /// Test connectvity and if login is active and enabled
        /// </summary>
        /// <returns>True if computer is reachable and we are able to valiadte if account is active</returns>
        public bool IsLoginActive()
        {
            string loginState = Computer.LoginState(LoginName);
            if (loginState == "Enabled") { return true; }
            return false;
        }

        /// <summary>
        /// Test connectvity and if login is disabled
        /// </summary>
        /// <returns>True if computer is reachable and we are able to valiadte if account is disabled</returns>
        public bool IsLoginDisabled()
        {
            string loginState = Computer.LoginState(LoginName);
            if (loginState == "Disabled") { return true; }
            return false;
        }

        /// <summary>
        /// Attempt to disable the login on the computer
        /// </summary>
        /// <returns>True if account is disabled</returns>
        public bool DisableLogin()
        {
            if (IsLoginActive()) { Computer.DisableLogin(LoginName); }
            return IsLoginDisabled();
        }
        
        #endregion
    }
}
