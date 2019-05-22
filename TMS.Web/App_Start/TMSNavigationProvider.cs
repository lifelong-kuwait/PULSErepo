// ***********************************************************************
// Assembly         : TMS.Web
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 04-19-2017
// ***********************************************************************
// <copyright file="TMSNavigationProvider.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using Abp.Application.Navigation;
using Abp.Localization;

namespace TMS.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    /// <seealso cref="Abp.Application.Navigation.NavigationProvider" />
    public class TMSNavigationProvider : NavigationProvider
    {
        /// <summary>
        /// Used to set navigation.
        /// </summary>
        /// <param name="context">Navigation context</param>
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", TMSConsts.LocalizationSourceName),
                        url: "",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", TMSConsts.LocalizationSourceName),
                        url: "About",
                        icon: "fa fa-info"
                        )
                );
        }
    }
}
