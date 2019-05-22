using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lr = Resources.Resources;
using TMS.Library.TMS.Persons;
using TMS.Library.ModelMapper;
using System.Data.Common;

namespace TMS.Library.Entities.Coordinator
{
    public class CourseCoordinatorMapping : IDataMapper
    {
        public CourseCoordinatorMapping()
        {
            this.Person = new List<Person>();
        }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }
        public long CID { get; set; }
        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }
        /// <summary>
        /// Gets or sets the salutation identifier.
        /// </summary>
        /// <value>The salutation identifier.</value>
        public long CourseID { get; set; }

        /// <summary>
        /// Gets or sets the first name of the p.
        /// </summary>
        /// <value>The first name of the p.</value>
        public long CoordinateID { get; set; }

        public int CoordinateType { get; set; }

        /// <summary>
        /// Gets or sets the last name of the p.
        /// </summary>
        /// <value>The last name of the p.</value>
        [Display(Name = "GridCreatedBy", ResourceType = typeof(lr))]
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the name of the p middle.
        /// </summary>
        /// <value>The name of the p middle.</value>
        [Display(Name = "GridCreatedDate", ResourceType = typeof(lr))]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        [Display(Name = "GridUpdatedBy", ResourceType = typeof(lr))]
        public long ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        [Display(Name = "GridUpdatedDate", ResourceType = typeof(lr))]
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        public Boolean IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        [Display(Name = "IsActive", ResourceType = typeof(lr))]
        public Boolean IsActive { get; set; }
        
        public string DisplayName { get; set; }

        public List<Person> Person { get; set; }

        public string CoordinateIDs { get; set; }

        private bool _IsNew = false;
        
        public bool IsNew
        {
            get { return _IsNew; }
            set { _IsNew = value; }
        }

        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            CID = dr.GetInt64("ID");
            DisplayName = dr.GetString("DisplayName");
            AddedByAlias = dr.GetString("AddedByAlias");
            UpdatedByAlias = dr.GetString("UpdatedByAlias");
            CourseID = dr.GetInt64("CourseID");
            CoordinateID = dr.GetInt64("CoordinateID");
            CoordinateType = dr.GetInt32("CoordinateType");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedDate = dr.GetDateTime("CreatedDate");
            ModifiedBy = dr.GetInt64("ModifiedBy");
            ModifiedDate = dr.GetDateTime("ModifiedDate");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
            CoordinateIDs = dr.GetString("CoordinateIDs");
        }
    }

    public class CourseCoordinatorAddMapping 
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the salutation identifier.
        /// </summary>
        /// <value>The salutation identifier.</value>
        public long CourseID { get; set; }

        /// <summary>
        /// Gets or sets the first name of the p.
        /// </summary>
        /// <value>The first name of the p.</value>
        public long CoordinateID { get; set; }

        public int CoordinateType { get; set; }

        /// <summary>
        /// Gets or sets the last name of the p.
        /// </summary>
        /// <value>The last name of the p.</value>
        [Display(Name = "GridCreatedBy", ResourceType = typeof(lr))]
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the name of the p middle.
        /// </summary>
        /// <value>The name of the p middle.</value>
        [Display(Name = "GridCreatedDate", ResourceType = typeof(lr))]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        [Display(Name = "GridUpdatedBy", ResourceType = typeof(lr))]
        public long ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        [Display(Name = "GridUpdatedDate", ResourceType = typeof(lr))]
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        public Boolean IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        [Display(Name = "IsActive", ResourceType = typeof(lr))]
        public Boolean IsActive { get; set; }
        
    }

        #region Junk
        public class CourseCoordinate
    {
        //public CoreLanguage()
        //{
        //    this._language = new List<MapLanguage>();
        //}

        //public List<MapLanguage> _language { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the salutation identifier.
        /// </summary>
        /// <value>The salutation identifier.</value>
        [Display(Name = "PersonP_FirstName", ResourceType = typeof(lr))]
        public string PrimaryLanguageName { get; set; }

        /// <summary>
        /// Gets or sets the first name of the p.
        /// </summary>
        /// <value>The first name of the p.</value>
        [Display(Name = "PersonP_FirstName", ResourceType = typeof(lr))]
        public string SecondaryLanguageName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the p.
        /// </summary>
        /// <value>The last name of the p.</value>
        [Display(Name = "GridCreatedBy", ResourceType = typeof(lr))]
        public long? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the name of the p middle.
        /// </summary>
        /// <value>The name of the p middle.</value>
        [Display(Name = "GridCreatedDate", ResourceType = typeof(lr))]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        [Display(Name = "GridUpdatedBy", ResourceType = typeof(lr))]
        public long? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        [Display(Name = "GridUpdatedDate", ResourceType = typeof(lr))]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        [Display(Name = "IsActive", ResourceType = typeof(lr))]
        public bool? IsActive { get; set; }

        public string AddedByAlias { get; set; }
        
    }
    #endregion
}
