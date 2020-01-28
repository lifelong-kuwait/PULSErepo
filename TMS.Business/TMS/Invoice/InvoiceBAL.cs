using System.Collections.Generic;
using System.Data;
using TMS.Business.Interfaces.Invoiceing;
using TMS.DataObjects.Interfaces.Invoiceing;
using TMS.DataObjects.TMS.Invoice;
using TMS.Library.Entities.Invoice;


namespace TMS.Business.TMS.Invoice
{
   public class InvoiceBAL: IInvoiceingBAL
    {
        private readonly IInvoiceingDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonBAL"/> class.
        /// </summary>
        public InvoiceBAL()
        {
            DAL = new InvoiceDAL();
        }
        public long create_CustomerBAL(Customer customer)
        {
           return DAL.create_CustomerDAL(customer);
        }
        public long Update_CustomerBAL(Customer customer)
        {
            return DAL.Update_CustomerDAL(customer);
        }
        public long Destroy_CustomerBAL(Customer customer)
        {
            return DAL.Destroy_CustomerDAL(customer);
        }
        public List<Customer> CustomerRead_CustomerBAL(ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID)
        {
            return DAL.CustomerRead_CustomerDAL(ref Total,culture,SearchText,SortExpression,StartRowIndex,page,PageSize,CompanyID);
        }
       

        public long create_InvoiceBAL(Library.TMS.Invoice _invoice)
        {
            return DAL.create_InvoiceDAL(_invoice);
        }
        public long Update_InvoiceBAL(Library.TMS.Invoice _invoice)
        {
            return DAL.Update_InvoiceDAL(_invoice);
        }
        
        public List<Library.TMS.Invoice> Read_InvoiceBAL(ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID)
        {
            return DAL.Read_InvoiceDAL(ref Total, culture, SearchText, SortExpression, StartRowIndex, page, PageSize, CompanyID);
        }
        public List<Library.TMS.InvoiceDetail> Read_InvoiceDetailBAL(long invoiceId)
        {
            return DAL.Read_InvoiceDetailDAL(invoiceId);
        }
        public Library.TMS.Invoice Read_InvoiceByIDBAL(string invoiceId)
        {
            return DAL.Read_InvoiceByIDDAL(invoiceId);
        }
        
        public long create_InvoiceDetailBAL(Library.TMS.InvoiceDetail _invoiceDetail)
        {
            return DAL.create_InvoiceDetailDAL(_invoiceDetail);
        }
        public long Update_InvoiceDetailBAL(Library.TMS.InvoiceDetail _invoiceDetail)
        {
            return DAL.Update_InvoiceDetailDAL(_invoiceDetail);
        }
        
       public DataTable GetInvoiceReportsBAL(long InoID, long companyID)
        {
            return DAL.GetInvoiceReportsDAL( InoID,  companyID);
        }
        public List<InvoiceHistory> Read_InvoiceHistoryBAL(string invoiceId)
        {
            return DAL.Read_InvoiceHistoryDAL(invoiceId);
        }
        public List<ReIssued> Read_InvoiceReIssuedByBAL(string invoiceId)
        {
            return DAL.Read_InvoiceReIssuedByDAL(invoiceId);
        }
       public List<DepositDetail> Read_InvoiceDepositBAL(string invoiceId)
        {
            return DAL.Read_InvoiceDepositDAL(invoiceId);
        }
        public long create_InvoiceReIssueBAL(ReIssued invoiceReIssue)
        {
            return DAL.create_InvoiceReIssueDAL(invoiceReIssue);
        }
       public long create_InvoiceHistoryBAL(InvoiceHistory invoiceHistory)
        {
            return DAL.create_InvoiceHistoryDAL(invoiceHistory);
        }
    }
}
