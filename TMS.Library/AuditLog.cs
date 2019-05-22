using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.ModelMapper;

namespace TMS.Library
{
   public class AuditLog : IDataMapper
    {
        public long ID { get; set; }
        public EventType EventType { get; set; }
        public string AddedByAlias { get; set; }

        
        public string IPAddress { get; set; }
        public string BrowserName { get; set; }
        public string NewValue { get; set; }
        public string OldValue { get; set; }
        public long OrganizationID { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        public long? UpdatedBy { get; set; }

        public void MapProperties(DbDataReader dr)
        {
            ID = dr.GetInt64("ID");
            EventType = (EventType)dr.GetByte("EventType");
            IPAddress = dr.GetString("IPAddress");
            AddedByAlias = dr.GetString("AddedByAlias");
            
            BrowserName = dr.GetString("BrowserName");
            NewValue = dr.GetString("NewValue");
            OldValue = dr.GetString("OldValue");
            OrganizationID = dr.GetInt64("OrganizationID");
            CreatedDate = dr.GetDateTime("CreatedDate");
            CreatedBy = dr.GetInt64("CreatedBy");
            UpdatedDate = dr.GetDateTime("UpdatedDate");
            UpdatedBy = dr.GetInt64("UpdatedBy");
        }

    }
}
