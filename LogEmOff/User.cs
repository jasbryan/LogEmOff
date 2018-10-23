using System;
using System.Collections.Generic;
using System.Text;

namespace LogEmOff
{
    /// <summary>
    /// The user class will hold computer and login data for each user
    /// </summary>
    class User
    {
        #region Properties
        /// <summary>
        /// The preson who owns accounts on computers first name
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// The person who owns accounts on computers last name
        /// </summary>
        public string LastName { get; }

        #endregion

        #region Constructors

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        #endregion


        #region Methods
        //Not sure yet..

        #endregion
    }
}
