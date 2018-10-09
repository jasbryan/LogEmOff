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
        /// Name for computer on the network
        /// </summary>
        public String ComputerName { get; set; }

        /// <summary>
        /// IP address that the computer is assigned
        /// </summary>
        public String ComputerIP { get; set; }

        /// <summary>
        /// MAC for the computer to track
        /// </summary>
        public String ComputerMAC { get; set; }

        #endregion

    }
}
