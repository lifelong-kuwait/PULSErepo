// ***********************************************************************
// Assembly         : Resource
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 10-12-2016
// ***********************************************************************
// <copyright file="IResourceProvider.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Resources.Abstract
{
    /// <summary>
    /// Interface IResourceProvider
    /// </summary>
    public interface IResourceProvider
    {
        /// <summary>
        /// Gets the resource.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>System.Object.</returns>
        object GetResource(string name, string culture);

        /// <summary>
        /// Clears the cache.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool ClearCache();
    }
}