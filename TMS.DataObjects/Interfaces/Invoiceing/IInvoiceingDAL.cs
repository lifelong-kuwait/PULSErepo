﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities.Invoice;
using TMS.Library.TMS;

namespace TMS.DataObjects.Interfaces.Invoiceing
{
    public interface IInvoiceingDAL
    {
        long create_CustomerDAL(Customer customer);
        long Update_CustomerDAL(Customer customer);
        long Destroy_CustomerDAL(Customer customer);
        List<Customer> CustomerRead_CustomerDAL(ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID);
        long create_InvoiceDAL(Invoice invoice); 
        long Update_InvoiceDAL(Invoice invoice);
        List<Library.TMS.Invoice> Read_InvoiceDAL(ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID);
        List<Library.TMS.InvoiceDetail> Read_InvoiceDetailDAL(long invoiceId);
        Library.TMS.Invoice Read_InvoiceByIDDAL(string invoiceId);
        
        long create_InvoiceDetailDAL(InvoiceDetail invoiceDetail);
        long Update_InvoiceDetailDAL(InvoiceDetail invoiceDetail);
        DataTable GetInvoiceReportsDAL(long InoID, long companyID);
        DataTable GetInvoiceDepositReportsDAL(long InoID, long DepositId, long companyID);
        List<InvoiceHistory> Read_InvoiceHistoryDAL(string invoiceId); 
        List<ReIssued> Read_InvoiceReIssuedByDAL(string invoiceId);
        List<DepositDetail> Read_InvoiceDepositDAL(string invoiceId); 
        object InvoiceBalanceCheckDAL(DepositDetail depositDetail);
        object InvoiceGrossTotalCheckDAL(DepositDetail depositDetail);
        long InvoicePaymentDepositeCreateDAL(DepositDetail depositDetail);
        long create_InvoiceReIssueDAL(ReIssued invoiceDetail);
        long create_InvoiceHistoryDAL(InvoiceHistory invoiceHistory);
    }
}