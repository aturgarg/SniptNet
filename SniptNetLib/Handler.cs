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
    /// Primary class to handle the snipts
    /// </summary>
    public class Handler
    {
        #region Properties

        /// <summary>
        /// Gets or sets Authetication object
        /// </summary>
        internal Authentication Authentication { get; set; }

        /// <summary>
        /// Gets or sets request object
        /// </summary>
        internal Request Request { get; set; }

        /// <summary>
        /// Gets or sets response object
        /// </summary>
        internal Response Response { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Default constructor for Handler class
        /// </summary>
        public Handler()
        {
            Authentication = new Authentication();
            Request = new Request();
            Response = new Response();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Method to authenticate user credentials
        /// </summary>
        /// <returns>true if authenticated, false otherwise</returns>
        public bool AuthenticateUser()
        {
            string authenticateUrl = string.Format(Request.PRIVATE_AUTHENTICATION_URL, Authentication.UserName, Authentication.APIKey);
            return ValidateAuthentication(authenticateUrl);
        }

        /// <summary>
        /// Method to fetch snipts from Snipt.net
        /// </summary>
        /// <param name="sniptsLimit">Max number of snipts to fetch</param>
        /// <returns>List of snipts</returns>
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
                    // TODO : log error message - not all snipts are fetched
                }

                foreach (JToken objectToken in objectTokens)
                {
                    SniptObjectCollection.Add(ParseJObject(objectToken));
                }
            }

            return SniptObjectCollection;
        }

        /// <summary>
        /// Authenticate user on the privided url
        /// </summary>
        /// <param name="url">Url for user to authenticate</param>
        /// <returns>true if status code is Ok (authenticated), false otherwise</returns>
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
        /// Converts HttWebResponse into string
        /// </summary>
        /// <param name="response">HttpWebResponse</param>
        /// <returns>string as response</returns>
        private string GetResponseString(HttpWebResponse response)
        {
            Stream resStream = response.GetResponseStream();

            StreamReader responseReader = new System.IO.StreamReader(resStream, Encoding.UTF8);
            return responseReader.ReadToEnd();
        }

        /// <summary>
        /// Parse the given JToken object
        /// </summary>
        /// <param name="objectToken">JToken object to parse</param>
        /// <returns>SniptObject craeted from parse JToken object</returns>       
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

        #endregion Methods
    }
}
