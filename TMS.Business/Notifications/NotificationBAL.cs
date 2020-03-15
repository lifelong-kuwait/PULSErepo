using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Business.Interfaces;
using TMS.Business.Interfaces.CRM;
using TMS.DataObjects.CRM;
using TMS.DataObjects.Interfaces;
using TMS.DataObjects.Interfaces.CRM;
using TMS.Library.Entities.CRM;
using TMS.Library.TMS;

namespace TMS.Business.CRM
{
    public class NotificationBAL : INotificationBAL
    {
        private readonly INotificationsDAL DAL;
        public NotificationBAL()
        {
            DAL = new NotificationDAL();
        }
        public long create_NotificationsBAL(Notifications customer)
        {
            return DAL.create_NotificationsDAL(customer);
        }
        public List<Notifications> read_NotificationsBAL(long OrganizationID, long personID)
        {
            return DAL.read_NotificationsDAL(OrganizationID, personID);
        }
        public List<Notifications> read_AllNotificationsBAL(long OrganizationID, long personID)
        {
            return DAL.read_AllNotificationsDAL(OrganizationID, personID);
        }
        public int read_NotificationsCountBAL(long OrganizationID, long personID)
        {
            return DAL.read_NotificationsCountDAL(OrganizationID, personID);
        }
        public string read_LatestNotificationsForUserBAL(long OrganizationID, long personID, string datetime)
        {
            return DAL.read_LatestNotificationsForUserDAL(OrganizationID, personID, datetime);
        }

        public long Destroy_NotificationsBAL(Notifications customer)
        {
            return DAL.Destroy_NotificationsDAL(customer);

        }

        public int Update_NotificationsBAL(Notifications customer)
        {
            return DAL.Update_NotificationsDAL(customer);

        }
    }
}
