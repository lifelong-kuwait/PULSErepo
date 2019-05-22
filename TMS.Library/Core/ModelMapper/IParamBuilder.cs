// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 05-10-2017
// ***********************************************************************
// <copyright file="IParamBuilder.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Data.Common;

namespace TMS.Library.ModelMapper
{
    /// <summary>
    /// Interface IParamBuilder
    /// </summary>
    public interface IParamBuilder
    {
        /// <summary>
        /// Pars the specified pname.
        /// </summary>
        /// <param name="pname">The pname.</param>
        /// <param name="pval">The pval.</param>
        /// <returns>DbParameter.</returns>
        DbParameter Par(string pname, object pval);

      //  DbParameter ParDate(string pname, DateTime pval);

        /// <summary>
        /// Outs the par.
        /// </summary>
        /// <param name="pname">The pname.</param>
        /// <param name="val">The value.</param>
        /// <returns>DbParameter.</returns>
        DbParameter OutPar(string pname, object val);

        /// <summary>
        /// Pars the n variable character.
        /// </summary>
        /// <param name="pname">The pname.</param>
        /// <param name="pval">The pval.</param>
        /// <param name="size">The size.</param>
        /// <returns>DbParameter.</returns>
        DbParameter ParNVarChar(string pname, string pval, int size);

        /// <summary>
        /// Pars the n variable character maximum.
        /// </summary>
        /// <param name="pname">The pname.</param>
        /// <param name="pval">The pval.</param>
        /// <returns>DbParameter.</returns>
        DbParameter ParNVarCharMax(string pname, string pval);

        /// <summary>
        /// Pars the table.
        /// </summary>
        /// <param name="pname">The pname.</param>
        /// <param name="pval">The pval.</param>
        /// <returns>DbParameter.</returns>
        DbParameter ParTable(string pname, DataTable pval);
    }
}