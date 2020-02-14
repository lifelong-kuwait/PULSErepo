// ***********************************************************************
// Assembly         : Resource
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 10-12-2016
// ***********************************************************************
// <copyright file="DbResourceProvider.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Resources.Abstract;
using Resources.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace Resources.Concrete
{
    /// <summary>
    /// Class DbResourceProvider.
    /// </summary>
    /// <seealso cref="Resources.Abstract.BaseResourceProvider" />
    public class DbResourceProvider : BaseResourceProvider
    {
        // public long compnayID { get; set; }
        //  public System.Web.SessionState.HttpSessionState Session { get; }
        // Database connection string
        private static string connectionString = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbResourceProvider"/> class.
        /// </summary>
        public DbResourceProvider()
        {

            connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        }
        //IBALUsers _BALUsers;
        /// <summary>
        /// Initializes a new instance of the <see cref="DbResourceProvider"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public DbResourceProvider(string connection)
        {

            connectionString = connection;
        }


        Resources rss = new Resources();

        //  Session["CompnayID"]=connectionString;
        protected override IList<ResourceEntry> ReadResources(string culture)
        {
          //  ClearCache();
            //Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            //Response.Cache.SetNoStore();
            var resources = new List<ResourceEntry>();
            //  long org = 238;
            //  var res = Session["CompnayID"];
            long CompnayID = 0;
            long MaxNo = 0;
            //if (HttpContext.Current != null)
            //{
            CompnayID = Convert.ToInt64(HttpContext.Current.Session["CompanyID"]);
            //HttpContext.Current.Session.Remove("CompanyID");
            //   }
            string count = "select COUNT(Name) from dbo.Resources where OrganizationID=" + CompnayID + "; ";

            using (var conn = new SqlConnection(connectionString))
            {
                var cmdd = new SqlCommand(count, conn);
                conn.Open();
                MaxNo = Convert.ToInt64(cmdd.ExecuteScalar());

            }

            string sql = "";
            if (MaxNo > 0)
                sql = "select Culture, Name, Value from dbo.Resources where OrganizationID=" + CompnayID + " and Culture='" + culture + "'; ";
            else
                sql = "select Culture, Name, Value from dbo.Resources where OrganizationID=-2 and Culture='" + culture + "'; ";
            
            using (var con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(sql, con);

                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resources.Add(new ResourceEntry
                        {
                            Name = reader["Name"].ToString(),
                            Value = reader["Value"].ToString(),
                            Culture = reader["Culture"].ToString()
                        });
                    }

                    if (!reader.HasRows) throw new Exception("No resources were found");
                }
            }

            return resources;
        }

        protected override ResourceEntry ReadResource(string name, string culture)
        {
            ResourceEntry resource = null;
           // ClearCache();
            const string sql = "select Culture, Name, Value from dbo.Resources where culture = @culture and name = @name;";

            using (var con = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@culture", culture);
                cmd.Parameters.AddWithValue("@name", name);

                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        resource = new ResourceEntry
                        {
                            Name = reader["Name"].ToString(),
                            Value = reader["Value"].ToString(),
                            Culture = reader["Culture"].ToString()
                        };
                    }

                    if (!reader.HasRows) throw new Exception(string.Format("Resource {0} for culture {1} was not found", name, culture));
                }
            }

            return resource;
        }
    }
}