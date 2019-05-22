using Abp.Web.Mvc.Views;
using System.Security.Claims;
using TMS.Web.Core;

namespace TMS.Web.Views
{
    public abstract class TMSWebViewPageBase : TMSWebViewPageBase<dynamic>
    {

    }

    public abstract class TMSWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected TMSWebViewPageBase()
        {
            LocalizationSourceName = TMSConsts.LocalizationSourceName;
        }

        protected TMSUser CurrentUser
        {
            get
            {
                return new TMSUser(this.User as ClaimsPrincipal);
            }
        }

        protected string CurrentCulture
        {
            get
            {
                return UICulture.ToString();
            }
        }
        protected bool IsP//This Gets that current Language is Primary or not
        {
            get
            {
                return TMS.CultureHelper.IsPrimaryLanguage();
            }
        }

        protected string KendoDateFormat//This Gets that current Language is Primary or not
        {
            get
            {
                return TMS.TMSHelper.GetKendoDateFormat();
            }
        }


        protected string DefaultLongDateFormat//This Gets that current Language is Primary or not
        {
            get
            {
                return TMS.TMSHelper.DefaultLongDateFormat();
            }
        }
        

        protected string KendoDateTimeFormat//This Gets that current Language is Primary or not
        {
            get
            {
                return TMS.TMSHelper.DateTimeFormatKendo();
            }
        }
        protected string PLDIR//This Gets that Primary Language Direction
        {
            get
            {
                return TMS.TMSHelper.PLDIR();
            }
        }

        protected string SLDIR//This Gets that Secondary Language Direction
        {
            get
            {
                return TMS.TMSHelper.SLDIR();
            }
        }

        protected string PrimaryLangFlag//This Gets that Primary Language Direction
        {
            get
            {
                return TMS.TMSHelper.PrimaryLangFlag();
            }
        }

        protected string SecondaryLangFlag//This Gets that Secondary Language Direction
        {
            get
            {
                return TMS.TMSHelper.SecondaryLangFlag();
            }
        }


        protected string TimeFormatScript//This Gets that current Language is Primary or not
        {
            get
            {
                return TMS.TMSHelper.GetTimeFormatScript();
            }
        }
        protected string DateFormatScript//This Gets that current Language is Primary or not
        {
            get
            {
                return TMS.TMSHelper.GetDateFormatScript();
            }
        }
        protected string DefaultPicture//This Gets that current Language is Primary or not
        {
            get
            {
                return TMS.TMSHelper.GetDefaultPicture();
            }
        }
       

    }
}