using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Sandbox.Web.Classes
{
    public static class SiteConfig
    {
        #region Properties

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

        public static string AwsPrefix
        {
            get {
                return "https://"
              + AwsBucket + "." + AwsBaseUrl + "/" + AwsFolder + "/"; 
            }
        }

        public static string GoogleMapsApiKey
        {
            get { return GetFromConfig("GoogleMapsApiKey"); }
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

        #endregion

        #region Public Methods

        public static string GetAwsUrlForFile(string fileKey)
        {
            return AwsPrefix + fileKey;
        }

        #endregion

        #region private helper methods

        private static string GetFromConfig(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }

        #endregion

    }
}