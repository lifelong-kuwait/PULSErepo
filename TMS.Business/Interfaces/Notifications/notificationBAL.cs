using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities;
using TMS.Library.TMS;

namespace TMS.Business.Interfaces
{
    public interface INotificationBAL
    {
        long create_NotificationsBAL(Notifications customer);
        List<Notifications> read_NotificationsBAL(long OrganizationID,long personID);
        List<Notifications> read_AllNotificationsBAL(long OrganizationID,long personID);
        int read_NotificationsCountBAL(long OrganizationID,long personID);
        string read_LatestNotificationsForUserBAL(long OrganizationID,long personID,string datetime);
        
        int Update_NotificationsBAL(Notifications customer);
        long Destroy_NotificationsBAL(Notifications customer);
    }
}
