using Abp.Dependency;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using TMS.Business.CastleWindsor;
using TMS.Business.Interfaces.TMS;
using TMS.Business.TMS;

namespace TMS.Web.Core
{
    public partial class Startup
    {
        //
        // The Client ID is used by the application to uniquely identify itself to Azure AD.
        // The Metadata Address is used by the application to retrieve the signing keys used by Azure AD.
        // The AAD Instance is the instance of Azure, for example public Azure or Azure China.
        // The Authority is the sign-in URL of the tenant.
        // The Post Logout Redirect Uri is the URL where the user will be redirected after they sign out.
        //
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];

        private static string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        private static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];
        private static string postLogoutRedirectUri = ConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];

        private string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            //app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
            AuthenticationType=   CookieAuthenticationDefaults.AuthenticationType,
                LoginPath = new Microsoft.Owin.PathString("/Home/Login")
            });
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = clientId,
                    Authority = authority,
                    PostLogoutRedirectUri = postLogoutRedirectUri,
                    RedirectUri = postLogoutRedirectUri,
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthorizationCodeReceived = AuthorizationCodeReceived,
                        RedirectToIdentityProvider = RedirectToIdentityProvider,
                        MessageReceived = OnMessageReceived,
                        AuthenticationFailed = AuthenticationFailed,
                        SecurityTokenValidated = SecurityTokenValidated,
                    }
                });
        }

        private Task AuthorizationCodeReceived(Microsoft.Owin.Security.Notifications.AuthorizationCodeReceivedNotification context)
        {
            var code = context.Code;
            string userID = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.Name).Value;
            var container = new WindsorContainer();

            container.Register(
                    Component.For<ICurrentUserClaims>().ImplementedBy<CurrentUserClaims>().LifestyleSingleton(),
                    Component.For<IOffice365UsersBAL>().ImplementedBy<Office365UsersBAL>().LifestyleSingleton()
                );
            container.Install(new DependencyInjectionBALUserExtension());
            var Users = container.Resolve<ICurrentUserClaims>();
            var _objUser = Users.CheckIfTheUserExistInOurSystem(userID);
            if (_objUser == null)
            {
                context.HandleResponse();
              //  context.OwinContext.Authentication.SignOut(OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
                context.Response.Redirect("Home/UserNotBelongToSystem");
                // throw new System.IdentityModel.Tokens.SecurityTokenValidationException();
            }
            else
            {
                _objUser.IsAZureAD = true;
                var claims = Users.GetCurrentUserAllClaims(_objUser);
                context.AuthenticationTicket.Identity.AddClaims(claims);
                context.OwinContext.Authentication.SignIn(context.AuthenticationTicket.Identity);
                context.HandleResponse();
                context.Response.Redirect("Home/Main");
            }
            
            return Task.FromResult(0);
        }

        private Task AuthenticationFailed(Microsoft.Owin.Security.Notifications.AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> context)
        {
            //context.HandleResponse();
            //context.Response.Redirect("/Error?message=" + context.Exception.Message);
            return Task.FromResult(0);
        }

        private Task SecurityTokenValidated(Microsoft.Owin.Security.Notifications.SecurityTokenValidatedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> context)
        {
            string userID = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.Name).Value;            
            return Task.FromResult(0);
        }

        private static Task RedirectToIdentityProvider(Microsoft.Owin.Security.Notifications.RedirectToIdentityProviderNotification<Microsoft.IdentityModel.Protocols.OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> arg)
        {
            string appBaseUrl = arg.Request.Scheme + "://" + arg.Request.Host + arg.Request.PathBase;
            arg.ProtocolMessage.RedirectUri = appBaseUrl + "/";
            arg.ProtocolMessage.PostLogoutRedirectUri = appBaseUrl;
            arg.ProtocolMessage.Prompt = "login";
            if (arg.ProtocolMessage.State != null)
            {
                var stateQueryString = arg.ProtocolMessage.State.Split('=');
                var protectedState = stateQueryString[1];
                var state = arg.Options.StateDataFormat.Unprotect(protectedState);
                state.Dictionary.Add("mycustomparameter", UtilityFunctions.Encrypt("myvalue"));
                arg.ProtocolMessage.State = stateQueryString[0] + "=" + arg.Options.StateDataFormat.Protect(state);
            }
            return Task.FromResult(0);
        }

        private static Task OnMessageReceived(Microsoft.Owin.Security.Notifications.MessageReceivedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> notification)
        {
            if (notification.ProtocolMessage.State != null)
            {
                string mycustomparameter;
                var protectedState = notification.ProtocolMessage.State.Split('=')[1];
                var state = notification.Options.StateDataFormat.Unprotect(protectedState);
                state.Dictionary.TryGetValue("mycustomparameter", out mycustomparameter);
                if (UtilityFunctions.Decrypt(mycustomparameter) != "myvalue")
                    throw new System.IdentityModel.Tokens.SecurityTokenInvalidIssuerException();
            }
            return Task.FromResult(0);
        }

       
    }
}