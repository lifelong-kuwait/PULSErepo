// ***********************************************************************
// Assembly         : Resource
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 10-12-2016
// ***********************************************************************
// <copyright file="XmlResourceProvider.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Resources.Abstract;
using Resources.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Resources.Concrete
{
    /// <summary>
    /// Class XmlResourceProvider.
    /// </summary>
    /// <seealso cref="Resources.Abstract.BaseResourceProvider" />
    public class XmlResourceProvider : BaseResourceProvider
    {
        // File path
        private static string filePath = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlResourceProvider"/> class.
        /// </summary>
        public XmlResourceProvider() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlResourceProvider"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <exception cref="FileNotFoundException"></exception>
        public XmlResourceProvider(string filePath)
        {
            XmlResourceProvider.filePath = filePath;

            if (!File.Exists(filePath)) throw new FileNotFoundException(string.Format("XML Resource file {0} was not found", filePath));
        }

        protected override IList<ResourceEntry> ReadResources()
        {
            // Parse the XML file
            return XDocument.Parse(File.ReadAllText(filePath))
                .Element("resources")
                .Elements("resource")
                .Select(e => new ResourceEntry
                {
                    Name = e.Attribute("name").Value,
                    Value = e.Attribute("value").Value,
                    Culture = e.Attribute("culture").Value
                }).ToList();
        }

        protected override ResourceEntry ReadResource(string name, string culture)
        {
            // Parse the XML file
            return XDocument.Parse(File.ReadAllText(filePath))
                .Element("resources")
                .Elements("resource")
                .Where(e => e.Attribute("name").Value == name && e.Attribute("culture").Value == culture)
                .Select(e => new ResourceEntry
                {
                    Name = e.Attribute("name").Value,
                    Value = e.Attribute("value").Value,
                    Culture = e.Attribute("culture").Value
                }).FirstOrDefault();
        }
    }
}