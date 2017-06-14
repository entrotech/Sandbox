using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Sandbox.Web.Classes
{
    public class ServiceConfig
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
            return "//"
                + AwsBucket + "." + AwsBaseUrl 
                + "/" + AwsFolder + "/" + fileKey;
        }

        #region private methods

        private static string GetFromConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        #endregion
    }
}