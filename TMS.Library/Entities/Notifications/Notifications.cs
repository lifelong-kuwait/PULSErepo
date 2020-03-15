// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-14-2018
// ***********************************************************************
// <copyright file="Course.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Globalization;
using System.Reflection;
using TMS.Library.ModelMapper;
using TMS.Library.TMS.Organization;
using TMS.Library.Users;
using lr = Resources.Resources;

namespace TMS.Library.TMS
{
    /// <summary>
    /// Class Course.
    /// </summary>
    public class Notifications : IDataMapper
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }


        /// <summary>
        /// Gets or sets the name of the primary.
        /// </summary>
        /// <value>The name of the primary.</value>
        [Display(Name = "InvoiceNumber", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "InvoiceNumberRequired")]
        public string NotificationText { get; set; }

        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
       [Display(Name = "ReferanceNumber", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "ReferanceNumberRequired")]
        public string ActionUrl { get; set; }
        /// <summary>
        /// Gets or sets the course category identifier.
        /// </summary>
        /// <value>The course category identifier.</value>
        [Display(Name = "InvoiceType", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseCategoryRequired")]
        public long FromUser { get; set; }
        /// <summary>
                                          /// Gets or sets the course category identifier.
                                          /// </summary>
                                          /// <value>The course category identifier.</value>
        [Display(Name = "InvoiceType", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseCategoryRequired")]
        public long ToUser { get; set; }
        /// <summary>
        /// Gets or sets the minimum attendance requirement.
        /// </summary>
        /// <value>The minimum attendance requirement.</value>
        [Display(Name = "CreatedDate", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseMinimumAttendanceRequirementRequired")]
        //[Range(1, 100, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "OneToThousandDurationRange")]
        public DateTime CreatedDate { get; set; }
       
        
        /// <summary>
        /// Gets or sets the duration of the course.
        /// </summary>
        /// <value>The duration of the course.</value>
        [Display(Name = "InvoiceAmount", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "InvoiceAmountRequired")]

        public bool IsRead { get; set; }

        /// <summary>
        /// Gets or sets the type of the course duration.
        /// </summary>
        /// <value>The type of the course duration.</value>
       [Display(Name = "taxPercentage", ResourceType = typeof(lr))]
       [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "taxPercentageRequired")]

        public DateTime ReadDateTime { get; set; }
        /// <summary>
        /// Gets or sets the course vendor identifier.
        /// </summary>
        /// <value>The course vendor identifier.</value>
        [Display(Name = "Discount", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "DiscountRequired")]
        public long Event_ID { get; set; }
        /// <summary>
        /// Gets or sets the course category identifier.
        /// </summary>
        /// <value>The course category identifier.</value>
        [Display(Name = "OrganizationID", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseCategoryRequired")]
        public long Organization_ID { get; set; }
        

       
        // <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public bool IsDelete { get; set; }
        public string Primary_Name { get; set; }
        
        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetLong("ID");
            NotificationText = dr.GetString("NotificationText");
            ActionUrl = dr.GetString("Referance_Number");
            FromUser = dr.GetLong("FromUser");
            ToUser = dr.GetLong("ToUser");
            CreatedDate = dr.GetDateTime("CreatedDate");
            IsRead = dr.GetBoolean("IsRead");
            ReadDateTime = dr.GetDateTime("ReadDateTime");
            Event_ID = dr.GetLong("Event_ID");
            IsActive = dr.GetBoolean("IsActive");
            IsDelete = dr.GetBoolean("IsDelete");
            Organization_ID = dr.GetLong("Organization_ID");
            Primary_Name = dr.GetString("Primary_Name");


        }
    }
   
   
    
}