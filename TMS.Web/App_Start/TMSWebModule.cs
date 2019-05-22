// ***********************************************************************
// Assembly         : TMS.Web
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 07-16-2017
// ***********************************************************************
// <copyright file="TMSWebModule.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Localization.Sources;
using Abp.Modules;
using Abp.Web.Mvc;
using System.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TMS.Web
{
    /// <summary>
    /// Class TMSWebModule.
    /// </summary>
    /// <seealso cref="Abp.Modules.AbpModule" />
    [DependsOn(
        typeof(AbpWebMvcModule))]
    public class TMSWebModule : AbpModule
    {
        /// <summary>
        /// This is the first event called on application startup.
        /// Codes can be placed here to run before dependency injection registrations.
        /// </summary>
        public override void PreInitialize()
        {
            #region "default section"

            //Add/remove languages for your application
            //Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            //Configuration.Localization.Languages.Add(new LanguageInfo("ar-KW", "العربى", "famfamfam-flag-kw"));
            //Configuration.Localization.Languages.Add(new LanguageInfo("zh-CN", "简体中文", "famfamfam-flag-cn"));
            //Configuration.Localization.Languages.Add(new LanguageInfo("ja", "日本語", "famfamfam-flag-jp"));

            #endregion "default section"

            //following code is added on request to customize the language option on the TMS project team to configure the project from web.config
            var mainConfiguration = ConfigurationManager.AppSettings["LanguageEnabled"].ToString();
            if (!string.IsNullOrEmpty(mainConfiguration))
            {
                if (mainConfiguration == "true")
                {
                    var PrimaryLanguageCode = ConfigurationManager.AppSettings["PrimaryLanguageCode"].ToString();
                    var PrimaryLanguageName = ConfigurationManager.AppSettings["PrimaryLanguageName"].ToString();
                    var PrimaryLanguageFlagName = ConfigurationManager.AppSettings["PrimaryLanguageFlagName"].ToString();
                    Configuration.Localization.Languages.Add(new LanguageInfo(PrimaryLanguageCode, PrimaryLanguageName, PrimaryLanguageFlagName, true));
                    var SecondaryLanguageCode = ConfigurationManager.AppSettings["SecondryLanguageCode"].ToString();
                    var SecondaryLanguageName = ConfigurationManager.AppSettings["SecondryLanguageName"].ToString();
                    var SecondaryLanguageFlagName = ConfigurationManager.AppSettings["SecondryLanguageFlagName"].ToString();
                    Configuration.Localization.Languages.Add(new LanguageInfo(SecondaryLanguageCode, SecondaryLanguageName, SecondaryLanguageFlagName));
                }
                else
                {
                    Configuration.Localization.Languages.Add(new LanguageInfo("en-US", "English", "flag-icon flag-icon-gb", true));
                    Configuration.Localization.Languages.Add(new LanguageInfo("ar-KW", "العربى", "flag-icon flag-icon-kw"));
                }
            }
            else
            {
                Configuration.Localization.Languages.Add(new LanguageInfo("en-US", "English", "flag-icon flag-icon-gb", true));
                Configuration.Localization.Languages.Add(new LanguageInfo("ar-KW", "العربى", "flag-icon flag-icon-kw"));
            }

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    TMSConsts.LocalizationSourceName,
                    new XmlFileLocalizationDictionaryProvider(
                        HttpContext.Current.Server.MapPath("~/Localization/TMS")
                        )
                    )
                );
            //add
            Configuration.Localization.Sources.Extensions.Add(
                new LocalizationSourceExtensionInfo("AbpWeb",
                    new XmlFileLocalizationDictionaryProvider(
                        HttpContext.Current.Server.MapPath("~/Localization/TMS")
                        )
                    )
                );

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<TMSNavigationProvider>();
            //Configuration. .AbpWeb().AntiForgery.IsEnabled = false;
        }

        /// <summary>
        /// This method is used to register dependencies for this module.
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}