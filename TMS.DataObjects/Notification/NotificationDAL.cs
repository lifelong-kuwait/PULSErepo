using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.CRM;
using TMS.Library.Entities.CRM;
using Dapper;
using System.Data.SqlClient;
using TMS.DataObjects.Interfaces;
using TMS.Library.TMS;

namespace TMS.DataObjects.CRM
{
    public class NotificationDAL : DBGenerics, INotificationsDAL
    {
        public long create_NotificationsDAL(Notifications notifications)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("SYS_Notification_Create", parameters,
                        ParamBuilder.Par("NotificationText", notifications.NotificationText),
                        ParamBuilder.Par("ActionUrl", notifications.ActionUrl),
                        ParamBuilder.Par("CreatedDate", notifications.CreatedDate),
                        ParamBuilder.Par("ToUser", notifications.ToUser),
                        ParamBuilder.Par("Organization_ID", notifications.Organization_ID),
                        ParamBuilder.Par("FromUser", notifications.FromUser),
                        ParamBuilder.Par("Event_ID", notifications.Event_ID)
                        );
        }
        public List<Notifications> read_NotificationsDAL(long OrganizationID, long personID)
        {
            List<Notifications> _CustomerData = new List<Notifications>();
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { CompanyID = OrganizationID, Touser = personID });
                using (var multi = conn.QueryMultiple("SYS_Notification_ReadTopFive", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    _CustomerData = multi.Read<Notifications>().AsList<Notifications>();

                }

                conn.Close();
            }
            return _CustomerData.ToList();
        }
        public List<Notifications> read_AllNotificationsDAL(long OrganizationID, long personID)
        {
            List<Notifications> _CustomerData = new List<Notifications>();
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { CompanyID = OrganizationID, Touser = personID });
                using (var multi = conn.QueryMultiple("SYS_Notification_Read", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    _CustomerData = multi.Read<Notifications>().AsList<Notifications>();

                }

                conn.Close();
            }
            return _CustomerData.ToList();
        }
        public int read_NotificationsCountDAL(long OrganizationID, long personID)
        {

            return ExecuteScalarSPInt32("SYS_Notification_CountRead",
                        ParamBuilder.Par("CompanyID", OrganizationID),
                        ParamBuilder.Par("Touser", personID)
                        );
        }
        public string read_LatestNotificationsForUserDAL(long OrganizationID, long personID, string datetime)
        {
            return ExecuteScalarNvarchar("SYS_Notification_GetLatestTextRead",
                        ParamBuilder.Par("CompanyID", OrganizationID),
                        ParamBuilder.Par("Touser", personID),
                        ParamBuilder.Par("DateTime", datetime)
                        );
        }
        public long Destroy_NotificationsDAL(Notifications customer)
        {
            throw new NotImplementedException();
        }

        public int Update_NotificationsDAL(Notifications customer)
        {
            return ExecuteScalarInt32Sp("SYS_Notification_MarkAsRead",
                        ParamBuilder.Par("ID", customer.ID),
                        ParamBuilder.Par("ReadDateTime", customer.ReadDateTime)
                        );
        }
    }
}
