using System;
using System.Collections.Generic;
using System.Text;

namespace LogEmOff
{
    /// <summary>
    /// The user class will hold computer and login data for each user
    /// </summary>
    public class User
    {
        //private static int lastUserID = 0;

        #region Properties
        /// <summary>
        /// The preson who owns accounts on computers first name
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// The person who owns accounts on computers last name
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// ID to track the user with
        /// </summary>
        public int UserID { get; set; }

        public virtual ICollection<Login> Logins { get; set; }

        #endregion

        #region Constructors

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            //UserID = ++lastUserID;
        }
        #endregion


        #region Methods
        //Not sure yet..

        #endregion
    }
}
