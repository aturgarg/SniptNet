using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniptNetLib
{
    /// <summary>
    /// 
    /// </summary>
    internal class Request
    {
        /// <summary>
        /// 
        /// </summary>
        internal const string PRIVATE_AUTHENTICATION_URL = @"https://snipt.net/api/private/?username={0}&api_key={1}";
        
        /// <summary>
        /// 
        /// </summary>
        internal const string GET_PRIVATE_SNIPTS_URL = @"https://snipt.net/api/private/snipt/?format=json&username={0}&api_key={1}";
    }
}
