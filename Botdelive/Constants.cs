using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botdelive
{
    public static class Constants
    {
        public const string Endpoint = "https://botdelive.com/api/";
        public const string VerifyUserUrl = Endpoint + "verifyAC";
        public const string AuthenticateUrl = Endpoint + "sendAuth";
        public const string PushNotificationUrl = Endpoint + "sendPush";
    }
}
