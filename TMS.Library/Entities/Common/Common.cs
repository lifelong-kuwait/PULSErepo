// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="Common.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data.Common;
using TMS.Library.ModelMapper;

namespace TMS
{
    /// <summary>
    /// Class DDlList.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class DDlList : IDataMapper
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public long Value { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DDlList"/> is selected.
        /// </summary>
        /// <value><c>null</c> if [selected] contains no value, <c>true</c> if [selected]; otherwise, <c>false</c>.</value>
        public bool? Selected { get; set; }

        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            Text = dr.GetString("Text");
            Value = dr.GetInt64("Value");
            Selected = dr.GetBooleanNullable("Selected");
        }
    }
}