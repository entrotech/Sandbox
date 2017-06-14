using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Mvc;

namespace Sandbox.Web.Services
{
    public class SmsService : ISmsService
    {
        //Twilio Account Info
        private string accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
        private string authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
        private string fromNumber = ConfigurationManager.AppSettings["TwilioPhoneNumber"];

        public string Send(string toNumber, string message)
        {
            TwilioRestClient client = new TwilioRestClient(accountSid, authToken);

            Message msg = client.SendMessage(fromNumber, toNumber, message);
            if(msg.ErrorCode == null)
            {
                return null;
            }
            return msg.ErrorCode.ToString() + ": " + msg.ErrorMessage;
        }

        public string SendToSiteAdmin(string message)
        {
            string toNumber = ConfigurationManager.AppSettings["SiteAdminSmsNumber"];
            return Send(toNumber, message);

        }

    }
}