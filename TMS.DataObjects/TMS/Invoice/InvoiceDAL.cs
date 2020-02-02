using System;
using System.Collections.Generic;
using System.Linq;
using TMS.DataObjects.Interfaces.Invoiceing;
using TMS.Library.Entities.Invoice;
using Dapper;
using System.Data.SqlClient;
using TMS.DataObjects.Generics;
using TMS.Library.TMS;
using System.Data;
using TMS.Library.TMS.Organization;
using TMS.Library.Users;

namespace TMS.DataObjects.TMS.Invoice
{
    public class InvoiceDAL : DBGenerics, IInvoiceingDAL
    {
        public long create_CustomerDAL(Customer customer) {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("INO_Customer_Create", parameters,
                ParamBuilder.Par("@PName", customer.Customer_PName),
                ParamBuilder.Par("@SName", customer.Customer_SName),
                ParamBuilder.Par("@MName", customer.Customer_MiddleName),
                ParamBuilder.Par("@LName", customer.Customer_LastName),
                ParamBuilder.Par("@Type", customer.Customer_Type),
                ParamBuilder.Par("@EMail", customer.Email),
                ParamBuilder.Par("@PContact", customer.PersonContact),
                ParamBuilder.Par("@Detail", customer.Detail),
                ParamBuilder.Par("@CreatedBy", customer.Created_By),
                ParamBuilder.Par("@CDate", customer.Created_Date),
                ParamBuilder.Par("@OID", customer.Organization_ID));
        }
        public long Update_CustomerDAL(Customer customer)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            return ExecuteScalarSPInt32("INO_Customer_Update",
                ParamBuilder.Par("ID", customer.ID),
                ParamBuilder.Par("@PName", customer.Customer_PName),
                ParamBuilder.Par("@SName", customer.Customer_SName),
                ParamBuilder.Par("@MName", customer.Customer_MiddleName),
                ParamBuilder.Par("@LName", customer.Customer_LastName),
                ParamBuilder.Par("@Type", customer.Customer_Type),
                ParamBuilder.Par("@EMail", customer.Email),
                ParamBuilder.Par("@PContact", customer.PersonContact),
                ParamBuilder.Par("@Detail", customer.Detail),
                ParamBuilder.Par("@CreatedBy", customer.Created_By),
                ParamBuilder.Par("@CDate", customer.Created_Date),
                ParamBuilder.Par("@OID", customer.Organization_ID));
        }
        public long Destroy_CustomerDAL(Customer customer)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            return ExecuteScalarSPInt32("INO_Customer_Destroy",
                ParamBuilder.Par("ID", customer.ID),
                ParamBuilder.Par("@PName", customer.Customer_PName),
                ParamBuilder.Par("@SName", customer.Customer_SName),
                ParamBuilder.Par("@MName", customer.Customer_MiddleName),
                ParamBuilder.Par("@LName", customer.Customer_LastName),
                ParamBuilder.Par("@Type", customer.Customer_Type),
                ParamBuilder.Par("@EMail", customer.Email),
                ParamBuilder.Par("@PContact", customer.PersonContact),
                ParamBuilder.Par("@Detail", customer.Detail),
                ParamBuilder.Par("@CreatedBy", customer.Created_By),
                ParamBuilder.Par("@CDate", customer.Created_Date),
                ParamBuilder.Par("@OID", customer.Organization_ID));
        }
        public List<Customer> CustomerRead_CustomerDAL(ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID)
        {
            List<Customer> _CustomerData = new List<Customer>();
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new {  SearchText = SearchText, culture = culture,  SortExpression = SortExpression, StartRowIndex = StartRowIndex, page = page, PageSize = PageSize, CompanyID = CompanyID });
                using (var multi = conn.QueryMultiple("INO_Get_All_CustomersList", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    _CustomerData = multi.Read<Customer>().AsList<Customer>();
                    Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return _CustomerData.ToList();
        }
        public long create_InvoiceDAL(Library.TMS.Invoice customer)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("INO_Invoice_Create", parameters,
                ParamBuilder.Par("@Invoice_Number", customer.Invoice_Number),
                ParamBuilder.Par("@Referance_Number", customer.Referance_Number),
                ParamBuilder.Par("@Organization_ID", customer.Organization_ID),
                ParamBuilder.Par("@Invoice_Type", customer.Invoice_Type),
                ParamBuilder.Par("@Invoice_Amount", customer.Invoice_Amount),
                ParamBuilder.Par("@Tax_Percentage", customer.Tax_Percentage),
                ParamBuilder.Par("@Discount", customer.Discount),
                ParamBuilder.Par("@Invoice_Amount_With_Tax", customer.Invoice_Amount_With_Tax),
                ParamBuilder.Par("@Invoice_Gross_Total", customer.Invoice_Gross_Total),
                ParamBuilder.Par("@Generated_By", customer.Generated_By),
                ParamBuilder.Par("@Generated_To", customer.Generated_To),
                ParamBuilder.Par("@Generated_Date", customer.Generated_Date),
                ParamBuilder.Par("@Invoice_Status", customer.Invoice_Status),
                ParamBuilder.Par("@Due_Datea", customer.Due_Date),
                ParamBuilder.Par("@Tax_Value", customer.Tax_Value),
                ParamBuilder.Par("@DiscountValue", customer.Discount_Value),
                ParamBuilder.Par("@Tax_Type", customer.Tax_Type),
                ParamBuilder.Par("@Is_Deposit", false),
                ParamBuilder.Par("@Deposit_Type_ID", 0),
                ParamBuilder.Par("@Is_Re_Issued", 0),
                ParamBuilder.Par("@Notes", "")
                );
        }
        public long Update_InvoiceDAL(Library.TMS.Invoice customer)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var parameters = new[] { ParamBuilder.Par("ID", customer.ID) };
            return ExecuteScalarInt32Sp("INO_Invoice_Update", ParamBuilder.Par("ID", customer.ID),
                ParamBuilder.Par("@Invoice_Number", customer.Invoice_Number),
                ParamBuilder.Par("@Referance_Number", customer.Referance_Number),
                ParamBuilder.Par("@Organization_ID", customer.Organization_ID),
                ParamBuilder.Par("@Invoice_Type", customer.Invoice_Type),
                ParamBuilder.Par("@Invoice_Amount", customer.Invoice_Amount),
                ParamBuilder.Par("@Tax_Percentage", customer.Tax_Percentage),
                ParamBuilder.Par("@Discount", customer.Discount),
                ParamBuilder.Par("@Invoice_Amount_With_Tax", customer.Invoice_Amount_With_Tax),
                ParamBuilder.Par("@Invoice_Gross_Total", customer.Invoice_Gross_Total),
                ParamBuilder.Par("@Generated_By", customer.Generated_By),
                ParamBuilder.Par("@Generated_To", customer.Generated_To),
                ParamBuilder.Par("@Generated_Date", customer.Generated_Date),
                ParamBuilder.Par("@Invoice_Status", customer.Invoice_Status),
                ParamBuilder.Par("@Due_Datea", customer.Due_Date),
                ParamBuilder.Par("@Tax_Value", customer.Tax_Value),
                ParamBuilder.Par("@DiscountValue", customer.Discount_Value),
                ParamBuilder.Par("@Tax_Type", customer.Tax_Type),
                ParamBuilder.Par("@Is_Deposit", false),
                ParamBuilder.Par("@Deposit_Type_ID", 0),
                ParamBuilder.Par("@Is_Re_Issued", 0),
                ParamBuilder.Par("@Notes", "")
                );
        }
        
        public long create_InvoiceDetailDAL(Library.TMS.InvoiceDetail customer)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("INO_InvoiceDetail_Create", parameters,
                ParamBuilder.Par("@Invoice_ID", customer.Invoice_ID),
                ParamBuilder.Par("@Item", customer.Item),
                ParamBuilder.Par("@Description", customer.Description),
                ParamBuilder.Par("@Qty", customer.Qty),
                ParamBuilder.Par("@Price", customer.Price),
                ParamBuilder.Par("@Sub_Total", customer.Sub_Total)
                );
        }
        public long Update_InvoiceDetailDAL(Library.TMS.InvoiceDetail customer)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var parameters = new[] { ParamBuilder.Par("ID", customer.ID) };
            return ExecuteScalarInt32Sp("INO_InvoiceDetail_Update", ParamBuilder.Par("ID", customer.ID),
                ParamBuilder.Par("@Invoice_ID", customer.Invoice_ID),
                ParamBuilder.Par("@Item", customer.Item),
                ParamBuilder.Par("@Description", customer.Description),
                ParamBuilder.Par("@Qty", customer.Qty),
                ParamBuilder.Par("@Price", customer.Price),
                ParamBuilder.Par("@Sub_Total", customer.Sub_Total)
                );
        }
        
        public long InvoicePaymentDepositeCreateDAL(DepositDetail invoiceDetail)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("INO_Get_InvoicePayment_Create", parameters,
                ParamBuilder.Par("@InoID", invoiceDetail.Invoice_ID),
                ParamBuilder.Par("@PaymentType", invoiceDetail.Payment_Type),
                ParamBuilder.Par("@detail", invoiceDetail.Detail), 
                ParamBuilder.Par("@payment", invoiceDetail.Payment), 
                ParamBuilder.Par("@createdBy", invoiceDetail.Created_By), 
                ParamBuilder.Par("@createdDate", invoiceDetail.Created_Date),
                ParamBuilder.Par("@organizationId", invoiceDetail.Organization_ID)
                );
        }
        public long create_InvoiceReIssueDAL(ReIssued invoiceDetail)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("INO_Create_InvoiceIssue", parameters,
                ParamBuilder.Par("@InvoiceID", invoiceDetail.Invoice_ID),
                ParamBuilder.Par("@ReIssuedBy", invoiceDetail.Re_Issued_By),
                ParamBuilder.Par("@Date", invoiceDetail.Re_Issued_Date),
                ParamBuilder.Par("@OrganizationID", invoiceDetail.Organization_ID)
               
                );
        }
        public long create_InvoiceHistoryDAL(InvoiceHistory invoiceHistory)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd") + " " + CommonUtility.PersonFlagsClearingTime();
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("INO_Create_Invoice_History", parameters,
                ParamBuilder.Par("@InvoiceID", invoiceHistory.Invoice_Number),
                ParamBuilder.Par("@Name", invoiceHistory.History_Name),
                ParamBuilder.Par("@type", invoiceHistory.Type),
                ParamBuilder.Par("@description", invoiceHistory.Description),
                ParamBuilder.Par("@UserBy", invoiceHistory.User_ID),
                ParamBuilder.Par("@Date", invoiceHistory.Date_TIME),
                ParamBuilder.Par("@OrganizationID", invoiceHistory.Organization_ID)
                );
        }
        public DataTable GetInvoiceReportsDAL(long InoID, long companyID)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;
            SqlCommand cmd = new SqlCommand("INO_InvoiceDetail_Report");
            cmd.Parameters.AddWithValue("@Invoice_ID", InoID);
            cmd.Parameters.AddWithValue("@OrganizationID", companyID);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }
            }
        }
       public DataTable GetInvoiceDepositReportsDAL(long InoID, long DepositId, long companyID)
        {
            DataTable dt = new DataTable();
            var conString = DBHelper.ConnectionString;
            SqlCommand cmd = new SqlCommand("INO_InvoiceDeposit_Report");
            cmd.Parameters.AddWithValue("@Invoice_ID", InoID);
            cmd.Parameters.AddWithValue("@Deposit_ID", DepositId);
            cmd.Parameters.AddWithValue("@OrganizationID", companyID);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda.SelectCommand = cmd;
                    using (DataSet dsCustomers = new DataSet())
                    {
                        sda.Fill(dsCustomers, "Customers");
                        return dsCustomers.Tables[0];
                    }
                }
            }
        }


       public List<Library.TMS.InvoiceDetail> Read_InvoiceDetailDAL(long invoiceId)
        {
            List<Library.TMS.InvoiceDetail> _CustomerData = new List<Library.TMS.InvoiceDetail>();
             using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { InoID = invoiceId });
                using (var multi = conn.QueryMultiple("INO_Get_InvoiceDetail", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    _CustomerData = multi.Read<Library.TMS.InvoiceDetail>().AsList<Library.TMS.InvoiceDetail>();
                }
                conn.Close();
            }
            return _CustomerData.ToList();
        }
        public Library.TMS.Invoice Read_InvoiceByIDDAL(string invoiceId)
        {
            var _PersonData = ExecuteSinglewithSP<Library.TMS.Invoice>("INO_Get_Invoice_By_ID_Read", ParamBuilder.Par("InvoiceId", invoiceId));
           
                if (_PersonData.Generated_To > 0)
                {
                    var x = ExecuteSinglewithSP<Customer>(@"INO_Get_Customer", ParamBuilder.Par("CID", _PersonData.Generated_To));
                _PersonData.customer = x;
                }
                if (_PersonData.Organization_ID > 0)
                {
                    var x = ExecuteSinglewithSP<OrganizationModel>(@"INO_Get_Organization", ParamBuilder.Par("OID", _PersonData.Organization_ID));
                _PersonData.Organization = x;
                }
                if (_PersonData.Generated_By > 0)
                {
                    var x = ExecuteSinglewithSP<LoginUsers>(@"INO_Get_User", ParamBuilder.Par("UID", _PersonData.Generated_By));
                _PersonData.users = x;
                }
                //  Person = _PersonData.Read<Trainer>().AsList<Trainer>();
            
            return _PersonData;
        }
        public List<Library.TMS.Invoice> Read_InvoiceDAL(ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID)
        {
            List<Library.TMS.Invoice> _CustomerData = new List<Library.TMS.Invoice>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { SearchText = SearchText, culture = culture, SortExpression = SortExpression, StartRowIndex = StartRowIndex, page = page, PageSize = PageSize, CompanyID = CompanyID });
                using (var multi = conn.QueryMultiple("INO_Get_All_Invoice_Read", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    _CustomerData = multi.Read<Library.TMS.Invoice>().AsList<Library.TMS.Invoice>();
                    Total = multi.Read<int>().FirstOrDefault<int>();
                }
                conn.Close();
            }
            foreach (var single in _CustomerData)
            {
                if (single.Generated_To > 0)
                {
                    var x = ExecuteSinglewithSP<Customer>(@"INO_Get_Customer", ParamBuilder.Par("CID", single.Generated_To));
                    single.customer = x;
                }
                if (single.Organization_ID > 0)
                {
                    var x = ExecuteSinglewithSP<OrganizationModel>(@"INO_Get_Organization", ParamBuilder.Par("OID", single.Organization_ID));
                    single.Organization = x;
                }
                if (single.Generated_By > 0)
                {
                    var x = ExecuteSinglewithSP<LoginUsers>(@"INO_Get_User", ParamBuilder.Par("UID", single.Generated_By));
                    single.users = x;
                }
                //  Person = _PersonData.Read<Trainer>().AsList<Trainer>();
            }
            return _CustomerData.ToList();
        }
        public List<InvoiceHistory> Read_InvoiceHistoryDAL(string invoiceId)
        {
            List<InvoiceHistory> _CustomerData = new List<InvoiceHistory>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { InoID = invoiceId });
                using (var multi = conn.QueryMultiple("INO_Get_InvoiceHistory", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    _CustomerData = multi.Read<InvoiceHistory>().AsList<InvoiceHistory>();
                }
                conn.Close();
            }
            return _CustomerData.ToList();
        }
        public List<ReIssued> Read_InvoiceReIssuedByDAL(string invoiceId)
        {
            List<ReIssued> _CustomerData = new List<ReIssued>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { InoID = invoiceId });
                using (var multi = conn.QueryMultiple("INO_Get_Invoice_ReIssued", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    _CustomerData = multi.Read<ReIssued>().AsList<ReIssued>();
                }
                conn.Close();
            }
            foreach (var single in _CustomerData)
            {
                if (single.Re_Issued_By > 0)
                {
                    var x = ExecuteSinglewithSP<LoginUsers>(@"INO_Get_User", ParamBuilder.Par("UID", single.Re_Issued_By));
                    single.users = x;
                }
            }
                return _CustomerData.ToList();
        }
       public List<DepositDetail> Read_InvoiceDepositDAL(string invoiceId)
        {
            List<DepositDetail> _CustomerData = new List<DepositDetail>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { InoID = invoiceId });
                using (var multi = conn.QueryMultiple("INO_Get_InvoicePayment", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    _CustomerData = multi.Read<DepositDetail>().AsList<DepositDetail>();
                }
                conn.Close();
            }
            foreach (var single in _CustomerData)
            {
                if (single.Created_By > 0)
                {
                    var x = ExecuteSinglewithSP<LoginUsers>(@"INO_Get_User", ParamBuilder.Par("UID", single.Created_By));
                    single.users = x;
                }
            }
            return _CustomerData.ToList();
        }
        public object InvoiceBalanceCheckDAL(DepositDetail depositDetail)
        {
            return ExecuteScalarwithSP("INO_Get_InvoicePaymentForInvoiceBalanceCheck",
                ParamBuilder.Par("@InoID", depositDetail.Invoice_ID)
                );
            
        }
        public object InvoiceGrossTotalCheckDAL(DepositDetail depositDetail)
        {
            return ExecuteScalarwithSP("INO_Get_InvoicePaymentGrossTotalCheck",
                ParamBuilder.Par("@InoID", depositDetail.Invoice_ID)
                );

        }
        public List<InvoiceChanges> Read_InvoiceChangesDAL(string invoiceId)
        {
            List<InvoiceChanges> _CustomerData = new List<InvoiceChanges>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParam = new DynamicParameters();
                dbParam.AddDynamicParams(new { InoID = invoiceId });
                using (var multi = conn.QueryMultiple("INO_Get_InvoiceChanges", dbParam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    _CustomerData = multi.Read<InvoiceChanges>().AsList<InvoiceChanges>();
                }
                conn.Close();
            }
            foreach (var single in _CustomerData)
            {
                if (single.Created_By > 0)
                {
                    var x = ExecuteSinglewithSP<LoginUsers>(@"INO_Get_User", ParamBuilder.Par("UID", single.Created_By));
                    single.Creator = x;
                }
            }
            return _CustomerData.ToList();
        }
    }
}
