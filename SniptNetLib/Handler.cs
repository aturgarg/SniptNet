using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace SniptNetLib
{
    public class Handler
    {
        internal Authentication Authentication {get;set;}
        internal Request Request {get;set;}
        internal Response Response {get;set;}

        public Handler()
        {
            Authentication = new Authentication();
            Request = new Request();
            Response = new Response();
        }

        public bool AuthenticateUser()
        {
            string authenticateUrl = string.Format(Request.PRIVATE_AUTHENTICATION_URL, Authentication.UserName, Authentication.APIKey);
            SendGetRequest(authenticateUrl);
            return true;
        }

        private void SendGetRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream resStream = response.GetResponseStream();
            }

        }
    }
}
