// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="DBHelper.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Configuration;

namespace TMS.DataObjects.Generics
{
    /// <summary>
    /// Class DBHelper.
    /// </summary>
    public class DBHelper
    {
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public static String ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Default"].ToString(); }
        }
    }
}