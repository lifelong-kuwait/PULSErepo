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
using System.ComponentModel.DataAnnotations;
using lr = Resources.Resources;

namespace TMS.Library.TMS
{
    /// <summary>
    /// Class Course.
    /// </summary>
    public class Invoice
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
        //[Display(Name = "PrimaryCourseName", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "PrimaryCourseNameRequired")]
        public string Invoice_Number { get; set; }

        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
       // [Display(Name = "SecondaryCourseName", ResourceType = typeof(lr))]
        public string Referance_Number { get; set; }

        /// <summary>
        /// Gets or sets the course category identifier.
        /// </summary>
        /// <value>The course category identifier.</value>
        //[Display(Name = "CourseCategory", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseCategoryRequired")]
        public long OrganizationID { get; set; }
        public int Invoice_Type { get; set; }
        /// <summary>
        /// Gets or sets the duration of the course.
        /// </summary>
        /// <value>The duration of the course.</value>
        //[Display(Name = "CourseDuration", ResourceType = typeof(lr))]
        public double Invoice_Amount { get; set; }

        /// <summary>
        /// Gets or sets the type of the course duration.
        /// </summary>
        /// <value>The type of the course duration.</value>
       //[Display(Name = "CourseDurationType", ResourceType = typeof(lr))]
        public float Tax_Percentage { get; set; }

        /// <summary>
        /// Gets or sets the course vendor identifier.
        /// </summary>
        /// <value>The course vendor identifier.</value>
        //[Display(Name = "CourseVendor", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseVendorRequired")]
        public float Discount { get; set; }


        public double Invoice_Amount_With_Tax { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public double Invoice_Gross_Total { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        //[Display(Name = "CourseNotes", ResourceType = typeof(lr))]
        public long Generated_By { get; set; }

        /// <summary>
        /// Gets or sets the minimum attendance requirement.
        /// </summary>
        /// <value>The minimum attendance requirement.</value>
        //[Display(Name = "CourseMinimumAttendanceRequirement", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseMinimumAttendanceRequirementRequired")]
        //[Range(1, 100, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "OneToThousandDurationRange")]
        public DateTime Generated_Date { get; set; }

        /// <summary>
        /// Gets or sets the minimum trainee.
        /// </summary>
        /// <value>The minimum trainee.</value>
        //[Display(Name = "ClassMinimumTrainee", ResourceType = typeof(lr))]
        public long Generated_To { get; set; }

        /// <summary>
        /// Gets or sets the course fee.
        /// </summary>
        /// <value>The course fee.</value>
       // [Display(Name = "CourseFee", ResourceType = typeof(lr))]
        public DateTime Due_Date { get; set; }

        /// <summary>
        /// Gets or sets the fee currency.
        /// </summary>
        /// <value>The fee currency.</value>
        public bool Is_Deposit { get; set; }

        /// <summary>
        /// Gets or sets the course code.
        /// </summary>
        /// <value>The course code.</value>
        //[Display(Name = "CourseCode", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseCodeRequired")]
        public long Deposite_Type_ID { get; set; }

        /// <summary>
        /// Gets or sets the sales commission.
        /// </summary>
        /// <value>The sales commission.</value>
        //  [Display(Name = "CourseSalesCommission", ResourceType = typeof(lr))]
        //[Display(Name = "CourseSalesCommission", ResourceType = typeof(lr))]
        //[Range(1, 100, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "OneToThousandDurationRange")]
        public bool Is_Reschedule { get; set; }

        /// <summary>
        /// Gets or sets the PreRequisites.
        /// </summary>
        /// <value>The  PreRequisites.</value>
       // [Display(Name = "CoursePreRequisites", ResourceType = typeof(lr))]
        public bool Is_Installment { get; set; }

        /// <summary>
        /// Gets or sets the feedback form identifier.
        /// </summary>
        /// <value>The feedback form identifier.</value>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public bool IsDelete { get; set; }

       

    }

}