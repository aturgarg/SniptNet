using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            //SendGetRequest(authenticateUrl);

            string getSniptUrl = string.Format(Request.GET_PRIVATE_SNIPTS_URL, Authentication.UserName, Authentication.APIKey);
            GetSnipts(getSniptUrl);

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

        private void GetSnipts(string url)
        {
            int totalCount = 0;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK && request.HaveResponse == true)
            {
                Stream resStream = response.GetResponseStream();

                StreamReader responseReader = new System.IO.StreamReader(resStream, Encoding.UTF8);
                string responseString = responseReader.ReadToEnd();               
                
                JObject jsonObject = JObject.Parse(responseString);
                //((jsonObject["meta"])).Children()

                JEnumerable<JToken> metaTokens = ((jsonObject["meta"])).Children();

                foreach (JToken metaToken in metaTokens)
                {
                    if (((JProperty)metaToken).Name == "total_count")
                    {
                        totalCount = Convert.ToInt32((((JValue)((((JProperty)(metaToken))).Value))).Value);
                        break;
                    }
                }
              
            }
        }
    }
}
