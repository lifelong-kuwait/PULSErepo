// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 05-10-2017
// ***********************************************************************
// <copyright file="CommonUtility.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace TMS.DataObjects
{
    /// <summary>
    /// Class CommonUtility.
    /// </summary>
    public static class CommonUtility
    {
        /// <summary>
        /// Persons the flags clearing time.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string PersonFlagsClearingTime()
        {
            return GetConfigurationValue("PersonFlagsClearingTime");
        }

        #region Default

        /// <summary>
        /// Gets the configuration value.
        /// </summary>
        /// <param name="_Key">The key.</param>
        /// <returns>System.String.</returns>
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
    }
}