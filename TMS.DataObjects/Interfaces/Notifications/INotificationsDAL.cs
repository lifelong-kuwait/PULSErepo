using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities;
using TMS.Library.TMS;

namespace TMS.DataObjects.Interfaces
{
    public interface INotificationsDAL
    {
        long create_NotificationsDAL(Notifications customer);
        List<Notifications> read_NotificationsDAL(long OrganizationID, long personID);
        List<Notifications> read_AllNotificationsDAL(long OrganizationID, long personID);
        int read_NotificationsCountDAL(long OrganizationID, long personID);
        string read_LatestNotificationsForUserDAL(long OrganizationID, long personID, string datetime);

        int Update_NotificationsDAL(Notifications customer);
        long Destroy_NotificationsDAL(Notifications customer);
    }
}
