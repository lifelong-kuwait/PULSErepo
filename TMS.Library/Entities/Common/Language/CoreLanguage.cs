using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMS.Library.ModelMapper;
using System.Threading.Tasks;
using lr = Resources.Resources;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace TMS.Library.Entities.Language
{
    public class MapLanguage: IDataMapper
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
        public long LanguageID { get; set; }

        /// <summary>
        /// Gets or sets the last name of the p.
        /// </summary>
        /// <value>The last name of the p.</value>
        [Display(Name = "GridCreatedBy", ResourceType = typeof(lr))]
        public long CreatedBy { get; set; }

        [Display(Name = "PersonP_FirstName", ResourceType = typeof(lr))]
        public string PrimaryLanguageName { get; set; }

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
        public Boolean? IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the display name of the p.
        /// </summary>
        /// <value>The display name of the p.</value>
        [Display(Name = "IsActive", ResourceType = typeof(lr))]
        public Boolean? IsActive { get; set; }

        public string AddedByAlias { get; set; }
        public string UpdatedByAlias { get; set; }
        public long ID2 { get; set; }

        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            LanguageID = dr.GetInt64("LanguageID");
            PrimaryLanguageName = dr.GetString("PrimaryLanguageName");
          
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedDate = dr.GetDateTime("CreatedDate");
            ModifiedBy = dr.GetInt64("ModifiedBy");
            ModifiedDate = dr.GetDateTime("ModifiedDate");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
            AddedByAlias = dr.GetString("AddedByAlias");
            UpdatedByAlias = dr.GetString("UpdatedByAlias");
            ID2= dr.GetInt64("MapperId");
        }
    }

    /// <summary>
    /// Language.
    /// </summary>
    /// <seealso cref="TMS.Library.ModelMapper.IDataMapper" />
    public class CoreLanguage:IDataMapper
    {
        public CoreLanguage()
        {
            this._language = new List<MapLanguage>();
        }

        public List<MapLanguage> _language { get; set; }

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

   //     public long LanguageID { get; set; }

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
        public string UpdatedByAlias { get; set; }


        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
          //  LanguageID = dr.GetInt64("LanguageID");
            PrimaryLanguageName = dr.GetString("PrimaryLanguageName");
            SecondaryLanguageName = dr.GetString("SecondaryLanguageName");
            CreatedBy = dr.GetInt64("CreatedBy");
            CreatedDate = dr.GetDateTime("CreatedDate");
            ModifiedBy = dr.GetInt64("ModifiedBy");
            ModifiedDate = dr.GetDateTime("ModifiedDate");
            IsDeleted = dr.GetBoolean("IsDeleted");
            IsActive = dr.GetBoolean("IsActive");
            AddedByAlias = dr.GetString("AddedByAlias");
            UpdatedByAlias = dr.GetString("UpdatedByAlias");
        }

    }
}
