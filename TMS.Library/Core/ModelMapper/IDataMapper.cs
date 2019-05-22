// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="IDataMapper.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data.Common;

namespace TMS.Library.ModelMapper
{
    /// <summary>
    /// Interface IDataMapper
    /// </summary>
    public interface IDataMapper
    {
        //an object that implements this interface can set its own properties from the passed in data reader
        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        void MapProperties(DbDataReader dr);
    }
}