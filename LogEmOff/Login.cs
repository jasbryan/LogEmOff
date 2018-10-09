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
        public User user { get; set; }

        /// <summary>
        /// The computer that this login is on
        /// </summary>
        public Computer computer { get; set; }

        /// <summary>
        /// The login that is used on this computer for this user
        /// </summary>
        public String UserLogin { get; set; }
        
        #endregion
    }
}
