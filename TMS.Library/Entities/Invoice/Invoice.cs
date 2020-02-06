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
    public class Invoice : IDataMapper
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
        public long Organization_ID { get; set; }
        public long Invoice_Type { get; set; }
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
        public double Tax_Percentage { get; set; }

        /// <summary>
        /// Gets or sets the course vendor identifier.
        /// </summary>
        /// <value>The course vendor identifier.</value>
        //[Display(Name = "CourseVendor", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseVendorRequired")]
        public double Discount { get; set; }


        public double Invoice_Amount_With_Tax { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public double Invoice_Gross_Total { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public TaxType Tax_Type { get; set; }
        public string tax_Value
        {
            get
            {
                return Tax_Type != null ? Fd.GetDisplayName(Tax_Type) : "NotSpecified";
            }
        }
    /// <summary>
    /// Gets or sets the rating.
    /// </summary>
    /// <value>The rating.</value>
    public double Tax_Value { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public double Discount_Value { get; set; }
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
        /// Gets or sets the minimum trainee.
        /// </summary>
        /// <value>The minimum trainee.</value>
        //[Display(Name = "ClassMinimumTrainee", ResourceType = typeof(lr))]
        public InvoiceStatus Invoice_Status { get; set; }
        public string Invoice_StatusString
        {
            get
            {
                return Invoice_Status != null ? Fd.GetDisplayName(Invoice_Status) : "NotSpecified";
            }
        }
        /// <summary>
        /// Gets or sets the course fee.
        /// </summary>
        /// <value>The course fee.</value>
       // [Display(Name = "CourseFee", ResourceType = typeof(lr))]
        public DateTime Due_Date { get; set; }
        /// <summary>
        /// Gets or sets the course fee.
        /// </summary>
        /// <value>The course fee.</value>
       // [Display(Name = "CourseFee", ResourceType = typeof(lr))]
        public string Due_Date2 { get; set; }

        /// <summary>
        /// Gets or sets the fee currency.
        /// </summary>
        /// <value>The fee currency.</value>
        public bool Is_Deposit { get; set; }
        /// <summary>
        /// Gets or sets the fee currency.
        /// </summary>
        /// <value>The fee currency.</value>
        public bool Is_Partial_Deposit { get; set; }
        
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
        public bool Is_Re_Issued { get; set; }

        /// <summary>
        /// Gets or sets the PreRequisites.
        /// </summary>
        /// <value>The  PreRequisites.</value>
       // [Display(Name = "CoursePreRequisites", ResourceType = typeof(lr))]
        public bool Is_Installment { get; set; }
        /// <summary>
        /// Gets or sets the PreRequisites.
        /// </summary>
        /// <value>The  PreRequisites.</value>
       // [Display(Name = "CoursePreRequisites", ResourceType = typeof(lr))]
        public HistoryType invoiceLastActivity { get; set; }
        public string invoiceLastActivityValue
        {
            get
            {
                return invoiceLastActivity != null ? Fd.GetDisplayName(invoiceLastActivity) : "NotSpecified";
            }
        }
        public string INO_GetlatestHistoryCreator { get; set; }
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
        public Entities.Invoice.Customer customer { get; set; }
        public OrganizationModel Organization { get; set; }
        public LoginUsers users { get; set; }
        public List<InvoiceDetail> invoiceDetailslist { get; set; }
        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetLong("ID");
            Invoice_Number = dr.GetString("Invoice_Number");
            Referance_Number = dr.GetString("Referance_Number");
            Organization_ID = dr.GetLong("Organization_ID");
            Invoice_Type = dr.GetLong("Invoice_Type");
            Tax_Type = (TaxType)dr.GetByte("Tax_Type");
            Tax_Percentage = dr.GetDouble("Tax_Percentage");
            Invoice_Amount = dr.GetDouble("Invoice_Amount");
            Tax_Value = dr.GetDouble("Tax_Value");
            Discount = dr.GetDouble("Discount");
            Discount_Value = dr.GetDouble("Discount_Value");
            Invoice_Amount_With_Tax = dr.GetDouble("Invoice_Amount_With_Tax");
            Invoice_Gross_Total = dr.GetDouble("Invoice_Gross_Total");
            Generated_By = dr.GetLong("Generated_By");
            Generated_Date = dr.GetDateTime("Generated_Date");
            Generated_To = dr.GetLong("Generated_To");
            Invoice_Status = (InvoiceStatus)dr.GetInt32("Invoice_Status");
            Due_Date = dr.GetDateTime("Due_Date");
            Due_Date2 = dr.GetString("Due_Date2");
            Is_Deposit = dr.GetBoolean("Is_Deposit");
            Is_Partial_Deposit = dr.GetBoolean("Is_Partial_Deposit"); 
            Deposite_Type_ID = dr.GetLong("Deposit_Type_ID");
            Is_Re_Issued = dr.GetBoolean("Is_Re_Issued");
            invoiceLastActivity = (HistoryType)dr.GetInt32("invoiceLastActivity");
            INO_GetlatestHistoryCreator = dr.GetString("INO_GetlatestHistoryCreator");
            Notes = dr.GetString("Notes");
            IsActive = dr.GetBoolean("IsActive");
            IsDelete = dr.GetBoolean("IsDelete");
        }
    }
    public static class Fd
    {
        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string GetDisplayName(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field == null)
                return String.Empty;

            object[] attribs = field.GetCustomAttributes(typeof(DisplayAttribute), true);
            if (attribs.Length > 0)
            {
                return ((DisplayAttribute)attribs[0]).GetName();
            }
            return value.ToString();
        }
    }
    public class InvoiceDetail : IDataMapper
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
        public long Invoice_ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the secondary.
        /// </summary>
        /// <value>The name of the secondary.</value>
       // [Display(Name = "SecondaryCourseName", ResourceType = typeof(lr))]
        public string Item { get; set; }

        /// <summary>
        /// Gets or sets the course category identifier.
        /// </summary>
        /// <value>The course category identifier.</value>
        //[Display(Name = "CourseCategory", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseCategoryRequired")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the duration of the course.
        /// </summary>
        /// <value>The duration of the course.</value>
        //[Display(Name = "CourseDuration", ResourceType = typeof(lr))]
        public long Qty { get; set; }

        /// <summary>
        /// Gets or sets the type of the course duration.
        /// </summary>
        /// <value>The type of the course duration.</value>
       //[Display(Name = "CourseDurationType", ResourceType = typeof(lr))]
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the course vendor identifier.
        /// </summary>
        /// <value>The course vendor identifier.</value>
        //[Display(Name = "CourseVendor", ResourceType = typeof(lr))]
        //[Required(ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "CourseVendorRequired")]
        public double Sub_Total { get; set; }
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
        public void MapProperties(DbDataReader dr)
        {
           ID = dr.GetLong("ID");
           Item = dr.GetString("Item");
           Description = dr.GetString("Description");
           Qty = dr.GetLong("Qty");
           Price = dr.GetDouble("Price");
           Sub_Total = dr.GetDouble("Sub_Total");
           Invoice_ID = dr.GetLong("Invoice_ID");
           IsDelete = dr.GetBoolean("IsDeleted");
           IsActive = dr.GetBoolean("IsActive");
        }
    }
}