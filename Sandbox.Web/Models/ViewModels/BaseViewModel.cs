using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;
using Sandbox.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sandbox.Web.Classes;

namespace Sandbox.Web.Models.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseViewModel
    {
        #region Fields

        private string _title;

        #endregion

        #region Properties

        #region Authorization / Authentication settings

        public bool IsLoggedIn { get; set; }
        public string[] Roles { get; set; }
        public string MainRole { get; set; }
        public string HomeUrl { get; set; }

        #endregion

        #region Environment settings

        public string Environment { get { return SiteConfig.Environment; } }
        public string BrandName { get { return SiteConfig.BrandName; } }
        public string BrandLogo { get { return SiteConfig.BrandLogo; } }
        public string SiteDomain { get { return SiteConfig.SiteDomain; } }
        public string BaseUrl { get { return SiteConfig.BaseUrl; } }
        public string SiteAdminEmailAddress { get { return SiteConfig.SiteAdminEmailAddress; } }

        #endregion

        #region Keys

        public string AwsBaseUrl { get { return SiteConfig.AwsBaseUrl; } }
        public string AwsBucket { get { return SiteConfig.AwsBucket; } }
        public string AwsFolder { get { return SiteConfig.AwsFolder; } }
        public string AwsPrefix { get { return SiteConfig.AwsPrefix; } }
        public string GoogleMapsApiKey { get { return SiteConfig.GoogleMapsApiKey; } }
        public static string SendGridApiKey { get { return SiteConfig.SendGridApiKey; } }
        public static string TwilioAccountSid { get { return SiteConfig.TwilioAccountSid; } }
        public static string TwilioAuthToken { get { return SiteConfig.TwilioAuthToken; } }
        public static string TwilioPhoneNumber { get { return SiteConfig.TwilioPhoneNumber; } }

        #endregion

        #endregion

        #region Page Title

        /// <summary>
        /// Specify Page Title to be merged with Brand Name for 
        /// Browser Tab
        /// </summary>
        public string Title
        {
            get {
                if (_title == null)
                {
                    _title = String.Empty;
                }
                return _title; }
            set {
                _title = value;
            }
        }


        /// <summary>
        /// Page Title + BrandName
        /// </summary>
        public string PageTitle
        {
            get
            {
                return (Title == "" ? "" : Title + " - ")
                    + BrandName ?? "";
            }
        }

        #endregion
    }
}