using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SniptNetLib
{
    internal class Authentication
    {
        internal string UserName { get; set; }

        internal string UserId { get; set; }

        internal string APIKey { get; set; }

        internal Authentication()
        {
            UserName = ConfigurationManager.AppSettings["UserName"].ToString();
            UserId = ConfigurationManager.AppSettings["UserId"].ToString();
            APIKey = ConfigurationManager.AppSettings["APIKey"].ToString();
        }
    }
}
