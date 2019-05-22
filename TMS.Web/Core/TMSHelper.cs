using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TMS
{
    public static class TMSHelper
    {
        public static string GetKendoDateFormat()
        {
            return GetConfigurationValue("DateFormatKendo");
        }
        public static string DateTimeFormatKendo()
        {
            return GetConfigurationValue("DateTimeFormatKendo");
        }
        
        public static string GetDateFormatScript()
        {
            return GetConfigurationValue("DateFormat");
        }
        public static string GetDefaultPicture()
        {
          return GetConfigurationValue("DefaultPicture");
        }
        public static string GetTimeFormatScript()
        {
            return GetConfigurationValue("TimeFormatScript");
        }
        public static string DefaultLongDateFormat()
        {
            return GetConfigurationValue("DefaultLongDateFormat");
        }

        
        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        public static string RemoveUnWantedCharacter(this string input)
        {
            var name = Regex.Replace(input, @"^[^A-Za-z_]+|\W+", String.Empty);
            return name;
        }

        #region"Contact"
        public static int GetPersonEmailLimit()
        {
            return Convert.ToInt32(GetConfigurationValue("PersonEmailLimit"));
        }
        public static int GetPersonLinksLimit()
        {
            return Convert.ToInt32(GetConfigurationValue("PersonLinksLimit"));
        }
        
        #endregion

        public static int PersonEducationCertificationsPreviousYear()
        {
            return Convert.ToInt32(GetConfigurationValue("PersonEducationCertificationsPreviousYear")) - 1;
        }

        public static int PersonEducationSessionPreviousYear()
        {
            return Convert.ToInt32(GetConfigurationValue("PersonEducationSessionPreviousYear")) - 1;
        }

        public static int PersonEducationDegreeTotolDuration()
        {
            return Convert.ToInt32(GetConfigurationValue("PersonEducationDegreeTotolDuration")) - 1;
        }

        #region Culture

        public static string PrimaryLangName()
        {
            return GetConfigurationValue("PrimaryLanguageName");
        }
        public static string PrimaryLanguageCode()
        {
            return GetConfigurationValue("PrimaryLanguageCode");
        }
        
        public static string PrimaryLangFlag()
        {
            return GetConfigurationValue("PrimaryLanguageFlagName");
        }

        public static string PLDIR()
        {
            return GetConfigurationValue("PrimaryLanguageDirection");
        }

        public static string SecondaryLangName()
        {
            return GetConfigurationValue("SecondryLanguageName");
        }

        public static string SecondaryLangFlag()
        {
            return GetConfigurationValue("SecondryLanguageFlagName");
        }

        public static string SLDIR()
        {
            return GetConfigurationValue("SecondryLanguageDirection");
        }
        public static string DefaultPicture()
        {
            return GetConfigurationValue("DefaultPicture");
        }

        #endregion Culture

        #region Default

        public static string GetConfigurationValue(string _Key)
        {
            try
            {
                string _Value = System.Configuration.ConfigurationManager.AppSettings[_Key];
                return _Value ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion Default

        #region "Attachments Configuration"
        public static int AttachmentValidTillPeriodInMonths()
        {
            return Convert.ToInt32(GetConfigurationValue("AttachmentValidTillPeriodInMonths")) - 1;
        }
        #endregion
        #region"Login User"
        public static int FormAuthenticationLockedOutAttemptMax()
        {
            return Convert.ToInt32(GetConfigurationValue("FormAuthenticationLockedOutAttemptMax"));
        }
        public static int FormAuthenticationLockedOutAttemptNotifyUser()
        {
            return Convert.ToInt32(GetConfigurationValue("FormAuthenticationLockedOutAttemptNotifyUser"));
        }
        #endregion
    }
}