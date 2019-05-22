// ***********************************************************************
// Assembly         : ResourceBuilder
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 10-24-2016
// ***********************************************************************
// <copyright file="Program.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Resources.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ResourceBuilder
{
    /// <summary>
    /// Class Program.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Resources.Utility.ResourceBuilder();
            string filePath = builder.Create(new DbResourceProvider(@"data source=.;initial catalog=TMS_GUST;integrated security=True;Pooling=False"),
                summaryCulture: "en-us");
            Console.WriteLine("Created file {0}", filePath);
          
        }
    }
}
