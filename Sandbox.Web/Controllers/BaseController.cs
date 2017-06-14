using Sandbox.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sandbox.Web.Controllers
{
    public class BaseController : Controller
    {
        public new ViewResult View()
        {
            BaseViewModel model = GetViewModel<BaseViewModel>();
            DecorateViewModel(model);
            return base.View(model);
        }

        public new ViewResult View(string viewString)
        {
            BaseViewModel model = GetViewModel<BaseViewModel>();
            DecorateViewModel(model);
            return base.View(viewString, model); //is this viewString supposed to be the name of the view to rendered? What's the use for this method?
        }

        public ViewResult View(BaseViewModel baseVM)

        {
            if (baseVM != null)
            {
                baseVM = DecorateViewModel<BaseViewModel>(baseVM);
            }
            return base.View(baseVM);
        }

        public ViewResult View(string viewString, BaseViewModel baseVM)
        {
            if (baseVM != null)
            {
                baseVM = DecorateViewModel<BaseViewModel>(baseVM);
            }
            return base.View(viewString, baseVM);
        }

        //Strongly Typed Layout Views
        //Sabio.layout.model to move out to layout
        protected T GetViewModel<T>() where T : BaseViewModel, new()
        {
            T model = new T();
            return DecorateViewModel(model);
        }

        protected T DecorateViewModel<T>(T model) where T : BaseViewModel
        {
            ////the below method checks if the user is logged in when it gets their UserId 
            //string complexUserId = UserService.GetCurrentUserId();
            //if (!string.IsNullOrEmpty(complexUserId))
            //{
            //    model.IsLoggedIn = true;
            //    //grab the user's userBase and fill in values for their role flags
            //    model.CurrentUser = UserService.SelectCurrentUserBaseById(complexUserId);
            //    if (!string.IsNullOrEmpty(model.CurrentUser.KeyName))
            //    {
            //        model.CurrentUserAvatar = model.AWSCreateUrl + '/' + model.CurrentUser.KeyName;
            //    }
            //    SetUserRoleFlags(model.CurrentUser.UserRoles, model);
            //    model.CurrentUserId = model.CurrentUser.Id;

            //}
            return model;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

    }
}