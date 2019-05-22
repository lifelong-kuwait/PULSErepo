// ***********************************************************************
// Assembly         : Resource
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 07-09-2017
// ***********************************************************************
// <copyright file="BaseResourceProvider.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Entities;

namespace Resources.Abstract
{
    /// <summary>
    /// Class BaseResourceProvider.
    /// </summary>
    /// <seealso cref="Resources.Abstract.IResourceProvider" />
    public abstract class BaseResourceProvider: IResourceProvider
    {
        // Cache list of resources
        private static Dictionary<string, ResourceEntry> resources = null;
        private static object lockResources = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseResourceProvider"/> class.
        /// </summary>
        public BaseResourceProvider() {
           // ClearCache();
            Cache = true; // By default, enable caching for performance
        }

        protected bool Cache { get; set; } // Cache resources ?
        private static bool ForceCache { get; set; }
        /// <summary>
        /// Returns a single resource for a specific culture
        /// </summary>
        /// <param name="name">Resorce name (ie key)</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Resource</returns>
        /// <exception cref="ArgumentException">
        /// Resource name cannot be null or empty.
        /// or
        /// Culture name cannot be null or empty.
        /// </exception>
        public object GetResource(string name, string culture)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Resource name cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(culture))
                throw new ArgumentException("Culture name cannot be null or empty.");

            // normalize
            culture = culture.ToLowerInvariant();

            if (Cache && resources == null) {
                // Fetch all resources
                
                lock (lockResources) {

                    if (resources == null) {
                        resources = ReadResources().ToDictionary(r => string.Format("{0}.{1}", r.Culture.ToLowerInvariant(), r.Name));
                    }
                }
            }

            if (Cache) {
          //    ClearCache();
                if (ForceCache)
                {
                    resources = ReadResources().ToDictionary(r => string.Format("{0}.{1}", r.Culture.ToLowerInvariant(), r.Name));
                    ForceCache = false;
                }
                return resources[string.Format("{0}.{1}", culture, name)].Value;
            }

            return ReadResource(name, culture).Value;

        }
        /// <summary>
        /// Clears the cache.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ClearCache()
        {
            ForceCache = true;
            return true;
        }

        /// <summary>
        /// Returns all resources for all cultures. (Needed for caching)
        /// </summary>
        /// <returns>A list of resources</returns>
        protected abstract IList<ResourceEntry> ReadResources();
       

        /// <summary>
        /// Returns a single resource for a specific culture
        /// </summary>
        /// <param name="name">Resorce name (ie key)</param>
        /// <param name="culture">Culture code</param>
        /// <returns>Resource</returns>
        protected abstract ResourceEntry ReadResource(string name, string culture);
        
    }
}



















