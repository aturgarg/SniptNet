using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SniptNetLib
{
    /// <summary>
    /// Entity class for authentication
    /// </summary>
    internal class Authentication
    {
        #region Properties

        /// <summary>
        /// Gets or sets username
        /// </summary>
        internal string UserName { get; set; }

        /// <summary>
        /// Gets or sets userid
        /// </summary>
        internal string UserId { get; set; }

        /// <summary>
        /// Gets or sets APIKey
        /// </summary>
        internal string APIKey { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Default constructor for Authentication class
        /// </summary>
        internal Authentication()
        {
            UserName = ConfigurationManager.AppSettings["UserName"].ToString();
            UserId = ConfigurationManager.AppSettings["UserId"].ToString();
            APIKey = ConfigurationManager.AppSettings["APIKey"].ToString();
        }

        #endregion Constructor
    }
}
