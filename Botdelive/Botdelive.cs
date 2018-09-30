using System;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace Botdelive
{
    /// <summary>  
    ///  BotDelive is a Push Notification and 2-factor authentication 
    ///  API service that works over the chat bots
    ///  (Telegram and Messenger).  
    /// </summary>  
    public class Botdelive
    {
        public Dictionary<string, string> Parametres { get; set; }

        public Botdelive(string appId, string secretKey)
        {
            this.Parametres = new Dictionary<string, string>()
            {
                { "appId", appId }, { "secretKey", secretKey }
            };
        }

        /// <summary>
        ///  Verify the "Access Code"
        /// </summary>
        /// <param name="accessCode"></param>
        /// <returns>json string type</returns>
        public string Verify(string accessCode)
        {
            if (string.IsNullOrEmpty(accessCode)) throw new ArgumentException(message: "Access Code must be required.", paramName: nameof(accessCode));

            this.Parametres.Add("accessCode",accessCode);  
        
            return this._sendRequest(Constants.VerifyUserUrl);
        }

        /// <summary>
        ///  Send 2-factor authentication request (long polling)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>json string type</returns>
        public string Auth(string userId)
        {
            if(string.IsNullOrEmpty(userId)) throw new ArgumentException(message: "User ID must be required.", paramName: nameof(userId));

            this.Parametres.Add("userId",userId);

            return this._sendRequest(Constants.AuthenticateUrl);
        }

        /// <summary>
        ///  Send Push Notification request
        /// </summary>
        /// <param name="userId"></param>
        ///  /// <param name="message"></param>
        /// <returns>json string type</returns>
        public string Push(string userId,string message)
        {
            if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(message)) throw new ArgumentException(message: "User ID and Message must be required.");

            this.Parametres.Add("userId",userId);
            this.Parametres.Add("message",message);

            return this._sendRequest(Constants.PushNotificationUrl);
        }

        /// <summary>
        ///  Send GET request to BotDelive url with query string
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns>json string type</returns>
        private string _sendRequest(string requestUrl)
        {
            string url = this._urlFormat(requestUrl);
          
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        ///  Build http query string
        /// </summary>
        /// <param name="url"></param>
        /// <returns>json string type</returns>
        private string _urlFormat(string url)
        {
            string queryString = "?platform=csharp";
      
            foreach (var parameter in this.Parametres)
            {
                queryString += "&" + parameter.Key + "=" + parameter.Value;
            }

            return url += queryString;
        }
    }   
}
