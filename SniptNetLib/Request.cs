using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniptNetLib
{
    /// <summary>
    /// Class to handle the requests. 
    /// </summary>
    internal class Request
    {
        /// <summary>
        /// Constant for authentication url
        /// </summary>
        internal const string PRIVATE_AUTHENTICATION_URL = @"https://snipt.net/api/private/?username={0}&api_key={1}";
        
        /// <summary>
        /// Constant for private snipts url
        /// </summary>
        internal const string GET_PRIVATE_SNIPTS_URL = @"https://snipt.net/api/private/snipt/?format=json&username={0}&api_key={1}&order_by=created&limit={2}";
    }
}
