// ***********************************************************************
// Assembly         : TMS.Common
// Author           : Almas Shabbir
// Created          : 07-09-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-23-2017
// ***********************************************************************
// <copyright file="UtilityFunctions.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TMS.Common.Utilities.Crypt;
using System.Web;
using System.Drawing;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Reflection;
using System.Collections;
using System.Threading;

namespace TMS
{
    /// <summary>
    /// Class UtilityFunctions.
    /// </summary>
    public static class UtilityFunctions
    {

        /// <summary>
        /// This class is used to store the Enum item details. i.e. This can be used
        /// to populate UI controls from the Enum
        /// </summary>
        public class EnumValue
        {
            #region "DataMembers"

            public int _value;
            // numValue stores the value/index of the Enum value
            public string _name;
            // Stores the Enum defined name
            public string _displayName;
            // Stores the Enum friendly name i.e. picked from the description attribute

            #endregion

            /// <summary>
            ///  Default constructore, used to populate the the field members from start
            /// </summary>
            /// <param name="value"></param>
            /// <param name="name"></param>
            /// <param name="displayName"></param>
            /// <remarks></remarks>
            public EnumValue(int value, string name, string displayName)
            {
                // Populate the data members from the given fields
                _value = value;
                _name = name;
                _displayName = displayName;
            }

            #region "Properties"

            /// <summary>
            /// ID stores the value/index of the Enum value
            /// </summary>
            public int Value
            {
                get { return _value; }
                set { _value = value; }
            }

            /// <summary>
            /// Stores the Enum defined name
            /// </summary>
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            /// <summary>
            /// Stores the Enum friendly name i.e. picked from the description attribute
            /// </summary>
            public string DisplayName
            {
                get { return _displayName; }
                set { _displayName = value; }
            }

            #endregion
        }

        /// <summary>
        /// Create a strongly type collection of the EnumValue list
        /// </summary>
        public class EnumValueCollection : List<EnumValue>
        {

        }

     

        /// <summary>
        /// This static class contains the utility functions for the enumeration
        /// access and manipulation
        /// </summary>
        public sealed class EnumManager
        {
            private EnumManager()
            {
            }

            /// <summary>
            /// Returns back the description for the given Enum value
            /// </summary>
            /// <param name="enumValue">Enum Value</param>
            /// <returns></returns>
            public static string GetDescription(Enum enumValue)
            {
                FieldInfo fieldinfo = enumValue.GetType().GetField(enumValue.ToString());

                if (fieldinfo != null)
                {
                    // Now get all the Description attributes of the Enumeration
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldinfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    // Return back the description of the attribute if available
                    return (attributes.Length > 0) ? attributes[0].Description : enumValue.ToString();
                }
                else
                {
                    return "N/A";
                }
            }

            /// <summary>
            /// Returns back the all enumerations descriptions for the given Enum
            /// </summary>
            /// <param name="EnumType">Enum Type</param>
            /// <returns></returns>
            public static string[] GetDescriptions(Type EnumType)
            {
                FieldInfo[] fieldsInfo = EnumType.GetFields();
                string[] descriptions = new string[fieldsInfo.Length - 1];
                int iCounter = 0;

                // Now loop on all the fields
                foreach (FieldInfo field in fieldsInfo)
                {
                    // Continue only for normal fields
                    if (field.IsSpecialName)
                    {
                        iCounter = iCounter - 1;
                        continue;
                    }

                    // Now get all the Description attributes of the Enumeration
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    // Return back the description of the attribute if available
                    descriptions[Math.Max(Interlocked.Increment(ref iCounter), iCounter - 1)] = (attributes.Length > 0) ? attributes[0].Description : field.ToString();
                }
                return descriptions;
            }

            /// <summary>
            /// Returns back a EnumCollection object for the given Enumeration
            /// This EnumCollection object can then be used as a DataSource for the UI 
            /// controls
            /// </summary>
            /// <param name="EnumType"></param>
            /// <returns>EnumValueCollection Object</returns>
            public static EnumValueCollection GetEnumCollection(Type EnumType)
            {
                FieldInfo[] fieldsInfo = EnumType.GetFields();
                EnumValueCollection enumValueCollection = new EnumValueCollection();
                String description = null;

                // Now loop on all the fields
                foreach (FieldInfo field in fieldsInfo)
                {
                    // Continue only for normal fields
                    if (field.IsSpecialName)
                    {
                        continue;
                    }

                    // Now get all the Description attributes of the Enumeration
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    // Generate a friendly name for the Enum value
                    description = (attributes.Length > 0) ? attributes[0].Description : field.GetValue(null).ToString();
                    enumValueCollection.Add(new EnumValue(Convert.ToInt32(field.GetValue(null)), field.GetValue(null).ToString(), description));
                }
                return enumValueCollection;
            }

            /// <summary>
            /// Returns a Hash Table for the given enum Type. This has table will contain
            /// value/index of the Enum as Key and the friendly name as the Value. This is
            /// ideal for binding the Enum value with Dropdown/List controls
            /// </summary>
            /// <param name="EnumType"></param>
            /// <returns>HashTable object containing Enum Key/Value pairs</returns>
            public static Hashtable EnumHashTable(Type EnumType)
            {
                FieldInfo[] fieldsInfo = EnumType.GetFields();
                Hashtable enumHashTable__1 = new Hashtable();
                String description = null;

                // Now loop on all the fields
                foreach (FieldInfo field in fieldsInfo)
                {
                    // Continue only for normal fields
                    if (field.IsSpecialName)
                    {
                        continue;
                    }

                    // Now get all the Description attributes of the Enumeration
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    // Generate a friendly name for the Enum value
                    description = (attributes.Length > 0) ? attributes[0].Description : field.GetValue(null).ToString();

                    //Add the value/ID as the key, and friendly name as the description
                    enumHashTable__1.Add(Convert.ToInt32(field.GetValue(null)), description);
                }
                return enumHashTable__1;
            }
        }




        public static string GetEnumDescrptionFromObjectValue(Type _Type, object _Val)
        {
            try
            {
                var _MemberIfo = _Type.GetMember(Enum.GetName(_Type, _Val));
                var _Attributes = _MemberIfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute),
                    false);

                return ((System.ComponentModel.DescriptionAttribute)_Attributes[0]).Description;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Encrypts the specified string input.
        /// </summary>
        /// <param name="strInput">The string input.</param>
        /// <returns>System.String.</returns>
        public static string Encrypt(string strInput)
        {
            return EISEncryption.EncryptString128Bit(strInput, GetConfigurationValue("EISEncryption"));
        }

        public static void FillDropDownWithYears(DropDownList objDdlCurrentList, int comingYears, int pastYears, bool setCurruntYear)
        {
            try
            {
                objDdlCurrentList.Items.Clear();
                int yearStart = DateTime.Now.Year - pastYears;
                int count = comingYears + pastYears;
                for (int i = 0; i <= count; i++)
                {
                    string value = Convert.ToString((yearStart + i));
                    objDdlCurrentList.Items.Add(new ListItem(value, value));
                }
                if (setCurruntYear)
                {
                    objDdlCurrentList.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
                }
            }
            catch (Exception)
            { throw; }
        }

        public static void GetMyMonthList(DropDownList ddlMonthList, bool SetCurruntMonth)
        {
            DateTime month = Convert.ToDateTime("1/1/2000");
            for (int i = 0; i < 12; i++)
            {
                DateTime NextMont = month.AddMonths(i);
                ListItem list = new ListItem();
                list.Text = NextMont.ToString("MMMM");
                list.Value = NextMont.Month.ToString();
                ddlMonthList.Items.Add(list);
            }
            if (SetCurruntMonth)
            {
                ddlMonthList.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
            }
        }


        public static DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

        public static Color GetRandomColor(List<Color> CurrentColors)
        {
            //Color randomColor;
            var random = new Random();
            var color = String.Format("#{0:X6}", random.Next(0x1000000) & 0x7F7F7F);

            Color Rand_Color = ColorTranslator.FromHtml(color); //Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));

            while (CurrentColors.Contains(Rand_Color))
                Rand_Color = GetRandomColor(CurrentColors);

            System.Threading.Thread.Sleep(100);
            //string color = Rand_Color.ToArgb().ToString();
            //randomColor = CurrentColors.Contains(ColorTranslator.FromHtml(color)) ? GetRandomColor(CurrentColors) : ColorTranslator.FromHtml(color);
            return Rand_Color;
        }
        /// <summary>
        /// <para>Description : This method will Decrypt the input string.</para>
        /// <para>Created By: Ehsan </para>
        /// <para>Created Date: 09/27/2013 </para>
        /// </summary>
        /// <param name="strInput">Decrypted string</param>
        /// <returns>System.String.</returns>
        public static string Decrypt(string strInput)
        {
            return EISEncryption.DecryptString128Bit(strInput, GetConfigurationValue("EISEncryption"));
        }


        /// <summary>
        /// <para>Description : Fill Data Source to DropDown list</para>
        /// <para>Created By: Ehsan </para> 
        /// <para>Created Date: 09/27/2013 </para>  
        /// </summary>
        /// <param name="CurrentDropDownList">DropDownList objcet</param>
        /// <param name="SourceEnums">EnumValueCollection objcet</param>
        /// <param name="IsIncludeDefaultValue">bool is default value include of not</param>
        /// <param name="DefaultValueText">Default</param>
        public static void FillDropDownListFromEnumCollection(DropDownList CurrentDropDownList, EnumValueCollection SourceEnums, bool IsIncludeDefaultValue, string DefaultValueText)
        {
            CurrentDropDownList.Items.Clear();
            foreach (EnumValue objEnumValue in SourceEnums)
            {
                if ((objEnumValue.Value != 0))
                {
                    CurrentDropDownList.Items.Add(new ListItem(objEnumValue.DisplayName, Convert.ToString(objEnumValue.Value)));
                }
            }


            CurrentDropDownList.DataTextField = "DisplayName";
            CurrentDropDownList.DataValueField = "Value";


            CurrentDropDownList.DataBind();

            if ((IsIncludeDefaultValue))
            {
                CurrentDropDownList.Items.Insert(0,
                                                 DefaultValueText.Trim() != string.Empty
                                                     ? new ListItem(" Select " + DefaultValueText, "0")
                                                     : new ListItem(" Select...", "0"));
            }
        }

        /// <summary>
        /// Gets the configuration value.
        /// </summary>
        /// <param name="_Key">The key.</param>
        /// <returns>System.String.</returns>
        public static string GetConfigurationValue(string _Key)
        {
            try
            {
                string _Value = ConfigurationManager.AppSettings[_Key];
                return _Value ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// <para>Description: This method will return the given datetime object into long datetime format as string.</para>
        /// <para>Created By: Ehsan </para> 
        /// <para>Created Date: 09/27/2013 </para>  
        /// </summary>
        /// <param name="_ObjDt">DateTime object</param>
        /// <returns>It returns the date in long format.</returns>
        public static string GetShortDateString(DateTime _ObjDt)
        {
            string _DefaultDateFormat = ConfigurationManager.AppSettings["DateFormat"];
            if (!string.IsNullOrEmpty(_DefaultDateFormat))
                return _ObjDt.ToString(_DefaultDateFormat);
            else
                return _ObjDt.ToString();
        }

   

        #region QueryString

        /// <summary>
        /// Adds the querystring variable.
        /// </summary>
        /// <param name="strURL">The string URL.</param>
        /// <param name="QuerystringKey">The querystring key.</param>
        /// <param name="QuerystringValue">The querystring value.</param>
        /// <returns>System.String.</returns>
        public static string AddQuerystringVar(string strURL, string QuerystringKey, string QuerystringValue)
        {
            strURL = RemoveQuerystring(strURL, QuerystringKey);
            if (!strURL.Contains("?"))
            {
                strURL = strURL + "?" + QuerystringKey + "=" + Encrypt(QuerystringValue);
                return strURL;
            }
            else
            {
                strURL = strURL + "&" + QuerystringKey + "=" + Encrypt(QuerystringValue);
                return strURL;
            }
        }

        /// <summary>
        /// Removes the querystring.
        /// </summary>
        /// <param name="strURL">The string URL.</param>
        /// <param name="QuerystringKey">The querystring key.</param>
        /// <returns>System.String.</returns>
        public static string RemoveQuerystring(string strURL, string QuerystringKey)
        {
            Regex re = new Regex("(.*)(\\?|&)" + QuerystringKey + "=[^&]+?(&)(.*)", RegexOptions.IgnoreCase);
            strURL = re.Replace(strURL + "&", "$1$2$4");
            strURL = strURL.Substring(0, (strURL.Length - 1));
            return strURL;
        }

        /// <summary>
        /// Gets the query string.
        /// </summary>
        /// <param name="_Key">The key.</param>
        /// <returns>System.String.</returns>
        public static string GetQueryString(string _Key)
        {
            try
            {
                string _StrUrl = "";
                HttpContext _HttpCon = HttpContext.Current;
                _StrUrl = _HttpCon.Request.QueryString[_Key];

                _StrUrl = ReplacePlusSign(_StrUrl);
                _StrUrl = Decrypt(_StrUrl);

                if (_StrUrl == null) _StrUrl = "0";
                return _StrUrl;
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// Replaces the plus sign.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        public static string ReplacePlusSign(string input)
        {
            return input.Replace(" ", "+");
        }

        /// <summary>
        /// Checks the query string.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool CheckQueryString(string Key)
        {
            HttpContext httpCon = HttpContext.Current;
            if (string.IsNullOrEmpty(httpCon.Request.QueryString[Key]))
                return false;
            else
                return true;
        }

        #endregion

        #region Map object Values

        /// <summary>
        /// <para>Description: This is a generic method to convert object to any given data type.</para>
        /// <para>Created By: Ehsan </para>
        /// <para>Created Date: 09/27/2013 </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_ObjValueFrom">The object value from.</param>
        /// <param name="_MyType">My type.</param>
        /// <returns>T.</returns>
        /// <return>Returns T(generic data data Type)</return>
        public static T MapValue<T>(object _ObjValueFrom, Type _MyType) where T : IConvertible
        {
            try
            {
                return (T)Convert.ChangeType(_ObjValueFrom, _MyType);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// <para>Description: This is a generic method to convert string to any given data type.</para>
        /// <para>Created By: Ehsan </para>
        /// <para>Created Date: 09/27/2013 </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_ObjValueFrom">The object value from.</param>
        /// <param name="_MyType">My type.</param>
        /// <returns>T.</returns>
        /// <return>Returns T(generic data data Type)</return>
        public static T MapValue<T>(string _ObjValueFrom, Type _MyType) where T : IConvertible
        {
            try
            {
                return (T)Convert.ChangeType(_ObjValueFrom.Trim(), _MyType);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
    }
}
