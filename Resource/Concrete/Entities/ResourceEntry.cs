// ***********************************************************************
// Assembly         : Resource
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 10-13-2016
// ***********************************************************************
// <copyright file="ResourceEntry.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Resources.Entities
{
    /// <summary>
    /// Class ResourceEntry.
    /// </summary>
    public class ResourceEntry
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        /// <value>The culture.</value>
        public string Culture { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceEntry"/> class.
        /// </summary>
        public ResourceEntry()
        {
            Type = "string";
        }
    }
}