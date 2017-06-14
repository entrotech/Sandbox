using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Sandbox.Web.Classes
{
    public static class SiteConfig
    {

        public static string Environment
        {
            get { return GetFromConfig("Environment"); }
        }

        public static string SiteDomain
        {
            get { return GetFromConfig("SiteDomain"); }
        }

        public static string BaseUrl
        {
            get { return GetFromConfig("BaseURL"); }
        }

        public static string BrandName
        {
            get { return GetFromConfig("BrandName"); }
        }

        public static string BrandLogo
        {
            get { return GetFromConfig("BrandLogo"); }
        }

        public static string SiteAdminEmailAddress
        {
            get { return GetFromConfig("SiteAdminEmailAddress"); }
        }

        public static string AwsBucket
        {
            get { return GetFromConfig("AWSBucket"); }
        }

        public static string AwsBaseUrl
        {
            get { return GetFromConfig("AWSBaseUrl"); }
        }

        public static string AwsFolder
        {
            get { return GetFromConfig("AWSFolder"); }
        }

        public static string GetUrlForFile(string fileKey)
        {
            return "https://"
                + AwsBucket + "." + AwsBaseUrl + "/" + AwsFolder + "/" + fileKey;
        }

        public static string Indeed
        {
            get { return GetFromConfig("Indeed"); }
        }

        public static string ZipRecruiter
        {
            get { return GetFromConfig("ZipRecruiter"); }
        }

        public static string UsaJobs
        {
            get { return GetFromConfig("UsaJobs"); }
        }

        public static string Host
        {
            get { return GetFromConfig("Host"); }
        }

        public static string UserAgent
        {
            get { return GetFromConfig("UserAgent"); }
        }

        public static string SendGridApiKey
        {
            get { return GetFromConfig("SendGridApiKey"); }
        }

        public static string TwilioAccountSid
        {
            get { return GetFromConfig("TwilioAccountSid"); }
        }

        public static string TwilioAuthToken
        {
            get { return GetFromConfig("TwilioAuthToken"); }
        }

        public static string TwilioPhoneNumber
        {
            get { return GetFromConfig("TwilioPhoneNumber"); }
        }

        #region private methods

        private static string GetFromConfig(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }

        #endregion

    }
}