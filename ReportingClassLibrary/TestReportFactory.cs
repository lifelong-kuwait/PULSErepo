using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Business.Interfaces.TMS;
using TMS.Business.TMS.Report;
//using TMS.Web.controllers;

namespace ReportingClassLibrary
{
    public class TestReportFactory
    {
        //protected IReportBAL _ReportBAL;

        //public TestReportFactory(IReportBAL objReportBAL)
        //{
        //    _ReportBAL = objReportBAL;
        //    if (objReportBAL == null)
        //    {
        //        objReportBAL = new ReportBAL();
        //        _ReportBAL = objReportBAL;
        //    }
        //    TrainerDetail_GetAll();
        //}

        public static DataTable TestQuery(int ID)
        {
            DataTable datatable = new DataTable();
            SqlConnection con = new SqlConnection();
            SqlParameter para = new SqlParameter("@ID", SqlDbType.Int, 11);
            para.Value = ID;
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            con.ConnectionString = "data source=WIN-KPPK5C12UBS;initial catalog=TMS_GUST;integrated security=True;Pooling=False";
            cmd.CommandText = "SELECT ID, P_DisplayName AS AddedByAlias,DateOfBirth,PersonRegCode,CreatedDate FROM dbo.Person p  WHERE p.IsDeleted = 0 AND p.IsActive = 1 AND ID=@ID";
            cmd.Parameters.Add(para);
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(datatable);
            return datatable;
        }

        public static DataTable DDlQuery()
        {
            DataTable datatable = new DataTable();
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            con.ConnectionString = "data source=WIN-KPPK5C12UBS;initial catalog=TMS_GUST;integrated security=True;Pooling=False";
            cmd.CommandText = "SELECT ID, P_DisplayName AS AddedByAlias FROM dbo.Person p  WHERE p.IsDeleted = 0 AND p.IsActive = 1";
            cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(datatable);
            return datatable;
        }

        public static DataTable TrainerDetail_GetAll()
        {
            DataTable datatable = new DataTable();
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            con.ConnectionString = "data source=WIN-KPPK5C12UBS;initial catalog=TMS_GUST;integrated security=True;Pooling=False";
            cmd.CommandText = "SELECT distinct  p.P_DisplayName,p.PersonRegCode, C.PrimaryName AS CourseName , CLS.PrimaryClassTitle AS ClassTitle, CLS.StartDate,CLS.EndDate  FROM     Person AS P WITH (NOLOCK)  INNER JOIN TrainerOpenMapping CRT ON P.ID = CRT.PersonID AND CRT.IsDeleted = 0 AND CRT.IsActive = 1 INNER JOIN TMS_Courses C ON CRT.OpenId = C.ID AND C.IsDeleted = 0 AND C.IsActive = 1  INNER JOIN dbo.TMS_Classes CLS ON C.ID = CLS.CourseID  AND CLS.IsDeleted = 0 AND CLS.IsActive = 1  LEFT OUTER JOIN VW_Phone phone ON phone.PersonID = p.ID LEFT OUTER JOIN VW_Email Email ON Email.PersonID = p.ID WHERE(P.IsDeleted = 0 AND P.IsActive = 1 AND p.IsOnline = 0)";
           cmd.Connection = con;
            da.SelectCommand = cmd;
            da.Fill(datatable);
            return datatable;
        }

    }

   
}

//namespace TMS.Web.controllers
//{

//    using System;
//    using System.Linq;
//    using TMS.Business.Interfaces.TMS;
//    using System.Windows.Forms;
//    using ReportingClassLibrary;
//    using Library.TMS.Persons;
//    using System.Collections.Generic;

//    public class TrainarDetailReportController : BaseCollection
//    {
//        private IReportBAL _ReportBAL;
//        private readonly IPersonBAL _PersonBAL;

//        public TrainarDetailReportController(IReportBAL objReportBal)
//        {
//            _ReportBAL = objReportBal;
//            //Report_GetALLBAL();
//        }


//        public IList<Person> Report_GetALLBAL()
//        {
//            _ReportBAL = objReportBAL;
//            if (objReportBAL == null)
//            {
//                objReportBAL = new ReportBAL();
//                _ReportBAL = objReportBAL;
//            }
//            var _report = _ReportBAL.Report_GetALLBAL();
//            return _report;
//        }

//    }
//}
