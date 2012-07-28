using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniptNetLib
{
    internal class Request
    {
        internal const string PRIVATE_AUTHENTICATION_URL = @"https://snipt.net/api/private/?username={0}&api_key={1}";
        internal const string GET_PRIVATE_SNIPTS_URL = @"https://snipt.net/api/private/snipt/?format=json&username={0}&api_key={1}";
    }
}
