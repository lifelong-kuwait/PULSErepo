// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 12-10-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 11-12-2017
// ***********************************************************************
// <copyright file="PersonCertifications.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using TMS.Library.ModelMapper;
using lr = Resources.Resources;

namespace TMS.Library.TMS.Persons.Education
{
    /// <summary>
    /// Class PersonCertifications.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class PersonCertifications : IDataMapper
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>The person identifier.</value>
        public long PersonID { get; set; }

        /// <summary>
        /// Gets or sets the name of the certification p.
        /// </summary>
        /// <value>The name of the certification p.</value>
        [Display(Name = "PersonEducationCertificationsPrimaryTitle", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceName = "PersonEducationCertificationsPrimaryTitleRequired", ErrorMessageResourceType = typeof(lr))]
        public string CertificationP_Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the certification s.
        /// </summary>
        /// <value>The name of the certification s.</value>
        [Display(Name = "PersonEducationCertificationsSecondaryTitle", ResourceType = typeof(lr))]
        public string CertificationS_Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the certification duration.
        /// </summary>
        /// <value>The type of the certification duration.</value>
        [Display(Name = "PersonEducationCertificationsDuration", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceName = "PersonEducationCertificationsDurationTypeRequired", ErrorMessageResourceType = typeof(lr))]
        public CourseDurationType CertificationDurationType { get; set; }

        /// <summary>
        /// Gets or sets the duration of the certification.
        /// </summary>
        /// <value>The duration of the certification.</value>
        [Display(Name = "PersonEducationCertificationsDuration", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceName = "PersonEducationCertificationsDurationRequired", ErrorMessageResourceType = typeof(lr))]
        [Range(1, 1000, ErrorMessageResourceType = typeof(lr), ErrorMessageResourceName = "OneToThousandDurationRange")]
        public int CertificationDuration { get; set; }

        /// <summary>
        /// Gets or sets the certification reference no.
        /// </summary>
        /// <value>The certification reference no.</value>
        [Display(Name = "PersonEducationCertificationsRollNo", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceName = "PersonEducationCertificationsRollNoRequired", ErrorMessageResourceType = typeof(lr))]
        public string CertificationReferenceNo { get; set; }

        /// <summary>
        /// Gets or sets the completion year.
        /// </summary>
        /// <value>The completion year.</value>
        [Display(Name = "PersonEducationCertificationsCompletionYear", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceName = "PersonEducationCertificationsCompletionYearRequired", ErrorMessageResourceType = typeof(lr))]
        public int CompletionYear { get; set; }

        /// <summary>
        /// Gets or sets the awarding body.
        /// </summary>
        /// <value>The awarding body.</value>
        [Display(Name = "PersonEducationCertificationsAwardingBody", ResourceType = typeof(lr))]
        [Required(ErrorMessageResourceName = "PersonEducationCertificationsAwardingBodyRequired", ErrorMessageResourceType = typeof(lr))]
        public string AwardingBody { get; set; }

        /// <summary>
        /// Gets or sets the institute.
        /// </summary>
        /// <value>The institute.</value>
        [Display(Name = "PersonEducationCertificationsInstitution", ResourceType = typeof(lr))]
        public string Institute { get; set; }

        /// <summary>
        /// Gets or sets the duration of the validity.
        /// </summary>
        /// <value>The duration of the validity.</value>
        [Display(Name = "PersonEducationCertificationsValidity", ResourceType = typeof(lr))]
        public int ValidityDuration { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        [Display(Name = "GridCreatedBy", ResourceType = typeof(lr))]
        public long? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        [Display(Name = "GridCreatedDate", ResourceType = typeof(lr))]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        [Display(Name = "GridUpdatedBy", ResourceType = typeof(lr))]
        public long? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        [Display(Name = "GridUpdatedDate", ResourceType = typeof(lr))]
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Maps the properties.
        /// </summary>
        /// <param name="dr">The dr.</param>
        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            PersonID = dr.GetInt64("PersonID");
            CertificationP_Name = dr.GetString("CertificationP_Name");
            CertificationS_Name = dr.GetString("CertificationS_Name");
            CertificationDuration = dr.GetInt32("CertificationDuration");
            CertificationReferenceNo = dr.GetString("CertificationReferenceNo");
            CompletionYear = dr.GetInt32("CompletionYear");
            AwardingBody = dr.GetString("AwardingBody");
            Institute = dr.GetString("Institute");
            ValidityDuration = dr.GetInt32("ValidityDuration");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedDate = dr.GetDateTime("CreatedDate");
            UpdatedBy = dr.GetInt64("UpdatedBy");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
            CertificationDurationType = (CourseDurationType)dr.GetInt32("CertificationDurationType");
        }
    }
}