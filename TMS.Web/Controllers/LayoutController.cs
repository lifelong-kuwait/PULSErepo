using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Localization;
using Abp.Threading;
using TMS.Web.Models.Layout;
using System;
using System.Web;
using TMS.Library.Entities.TMS.Language;
using System.Collections.Generic;
using TMS.Business.Interfaces.TMS.Language;

namespace TMS.Web.Controllers
{
    public class LayoutController : TMSControllerBase
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly ILocalizationManager _localizationManager;
        private readonly ILanguageBAL _Language;


        public LayoutController(IUserNavigationManager userNavigationManager, ILocalizationManager localizationManager, ILanguageBAL Language)
        {
            _userNavigationManager = userNavigationManager;
            _localizationManager = localizationManager;
            _Language = Language;

        }

        [ChildActionOnly]
        public PartialViewResult TopMenu(string activeMenu = "")
        {
            var model = new TopMenuViewModel
                        {
                            MainMenu = AsyncHelper.RunSync(() => _userNavigationManager.GetMenuAsync("MainMenu", AbpSession.UserId)),
                            ActiveMenuItemName = activeMenu
                        };

            return PartialView("_TopMenu", model);
        }

        [ChildActionOnly]
        public PartialViewResult LanguageSelection()
        {
            var model = new LanguageSelectionViewModel
                        {
                            CurrentLanguage = _localizationManager.CurrentLanguage,
                            Languages = _localizationManager.GetAllLanguages()
                        };

            return PartialView("_LanguageSelection", model);
        }
       
        public PartialViewResult LanguageForLogin()
        {
            var model = new LanguageSelectionViewModel
            {
                CurrentLanguage = _localizationManager.CurrentLanguage,
                Languages = _localizationManager.GetAllLanguages()
            };

            return PartialView("_LanguageLogin", model);
        }

        //public PartialViewResult HeaderLanguage()
        //{
        //    var model = new LanguageSelectionViewModel
        //    {
        //        CurrentLanguage = _localizationManager.CurrentLanguage,
        //        Languages = _localizationManager.GetAllLanguages()
        //    };

        //    return PartialView("_headerLanguage", model);
        //}

        public PartialViewResult HeaderLanguage()
        {
            var model = new LanguageSelectionViewModel
            {
                CurrentLanguage = _localizationManager.CurrentLanguage,
                Languagess = _Language.GetAllLanguagesBAL(CurrentUser.CompanyID)
            };

            return PartialView("_headerLanguage", model);
        }
        public ActionResult ChangeCulture(string cultureName, string returnUrl = "")
        {
            //if (!GlobalizationHelper.IsValidCultureCode(cultureName))
            //{
            //    throw new AbpException("Unknown language: " + cultureName + ". It must be a valid culture!");
            //}
            cultureName = CultureHelper.GetImplementedCulture(cultureName);

            //Response.Cookies.Add(new HttpCookie("Abp.Localization.CultureName", cultureName) { Expires = DateTime.Now.AddYears(2) });

            HttpCookie cookie = Request.Cookies["_cultureTMS"];
            if (cookie != null)
                cookie.Value = cultureName;   // update cookie value
            else
            {
                cookie = new HttpCookie("_cultureTMS")
                {
                    Value = cultureName,
                    Expires = DateTime.Now.AddYears(2)
                };
            }
            Response.Cookies.Add(cookie);
            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return Redirect("/");
        }
    }
}