using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SniptNetLib
{
    /// <summary>
    /// 
    /// </summary>
    public class Handler
    {
        internal Authentication Authentication { get; set; }
        internal Request Request { get; set; }
        internal Response Response { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Handler()
        {
            Authentication = new Authentication();
            Request = new Request();
            Response = new Response();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AuthenticateUser()
        {
            string authenticateUrl = string.Format(Request.PRIVATE_AUTHENTICATION_URL, Authentication.UserName, Authentication.APIKey);
            return ValidateAuthentication(authenticateUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sniptsLimit"></param>
        /// <returns></returns>
        public List<SniptObject> GetSnipts(int sniptsLimit)
        {
            int totalCount = 0;
            string getSniptUrl = string.Format(Request.GET_PRIVATE_SNIPTS_URL, Authentication.UserName, Authentication.APIKey, sniptsLimit);

            List<SniptObject> SniptObjectCollection = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getSniptUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK && request.HaveResponse == true)
            {
                JObject jsonObject = JObject.Parse(GetResponseString(response));
                SniptObjectCollection = new List<SniptObject>();

                JEnumerable<JToken> metaTokens = ((jsonObject["meta"])).Children();

                foreach (JToken metaToken in metaTokens)
                {
                    if (((JProperty)metaToken).Name == "total_count")
                    {
                        totalCount = Convert.ToInt32((((JValue)((((JProperty)(metaToken))).Value))).Value);
                        break;
                    }
                }

                JEnumerable<JToken> objectTokens = ((jsonObject["objects"])).Children();

                if (totalCount > objectTokens.Count())
                {
                    // error message - not all snipts are fetched
                }

                foreach (JToken objectToken in objectTokens)
                {
                    SniptObjectCollection.Add(ParseJObject(objectToken));
                }
            }

            return SniptObjectCollection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool ValidateAuthentication(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private string GetResponseString(HttpWebResponse response)
        {
            Stream resStream = response.GetResponseStream();

            StreamReader responseReader = new System.IO.StreamReader(resStream, Encoding.UTF8);
            return responseReader.ReadToEnd();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectToken"></param>
        /// <param name="sniptObject"></param>
        private SniptObject ParseJObject(JToken objectToken)
        {
            SniptObject sniptObject = new SniptObject();

            foreach (JProperty propertyToken in objectToken.Children())
            {
                switch ((((JProperty)(propertyToken))).Name)
                {
                    case "absolute_url":
                        sniptObject.AbsoluteUrl = (((JProperty)(propertyToken))).Value.ToString();
                        break;
                    case "full_absolute_url":
                        sniptObject.FullAbsoluteUrl = (((JProperty)(propertyToken))).Value.ToString();
                        break;
                    case "embed_url":
                        sniptObject.EmbedUrl = (((JProperty)(propertyToken))).Value.ToString();
                        break;
                    case "resource_uri":
                        sniptObject.ResourceUri = (((JProperty)(propertyToken))).Value.ToString();
                        break;
                    case "id":
                        sniptObject.Id = Convert.ToInt32((((JProperty)(propertyToken))).Value.ToString());
                        break;
                    case "key":
                        sniptObject.Key = (((JProperty)(propertyToken))).Value.ToString();
                        break;
                    case "lexer":
                        sniptObject.Lexer = (((JProperty)(propertyToken))).Value.ToString();
                        break;
                    case "line_count":
                        sniptObject.LineCount = Convert.ToInt32((((JProperty)(propertyToken))).Value.ToString());
                        break;
                    case "slug":
                        sniptObject.Slug = (((JProperty)(propertyToken))).Value.ToString();
                        break;
                    case "title":
                        sniptObject.Title = (((JProperty)(propertyToken))).Value.ToString();
                        break;
                    case "code":
                        sniptObject.Code = (((JProperty)(propertyToken))).Value.ToString();
                        break;
                    case "public":
                        sniptObject.IsPublic = Convert.ToBoolean((((JProperty)(propertyToken))).Value.ToString());
                        break;
                    case "created":
                        sniptObject.CreateDate = (((JProperty)(propertyToken))).Value.ToString();
                        break;
                    case "modified":
                        sniptObject.ModifiedDate = (((JProperty)(propertyToken))).Value.ToString();
                        break;
                    default:
                        break;

                }
            }

            return sniptObject;
        }
    }
}
