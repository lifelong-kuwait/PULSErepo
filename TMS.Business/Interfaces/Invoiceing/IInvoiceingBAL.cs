﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities.Invoice;
using TMS.Library.TMS;

namespace TMS.Business.Interfaces.Invoiceing
{
    public interface IInvoiceingBAL
    {
        long create_CustomerBAL(Customer customer);
        long Update_CustomerBAL(Customer customer);
        long Destroy_CustomerBAL(Customer customer);
        List<Customer> CustomerRead_CustomerBAL(ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID);
        long create_InvoiceBAL(Invoice customer);
        long Update_InvoiceBAL(Invoice customer);
        List<Invoice> Read_InvoiceBAL(ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID);
        List<InvoiceDetail> Read_InvoiceDetailBAL(long invoiceId);
        Invoice Read_InvoiceByIDBAL(string  invoiceId);
        long create_InvoiceDetailBAL(InvoiceDetail invoiceDetail); 
        long Update_InvoiceDetailBAL(InvoiceDetail invoiceDetail);
        DataTable GetInvoiceReportsBAL(long InoID, long companyID);
        List<InvoiceHistory> Read_InvoiceHistoryBAL(string invoiceId);
        List<ReIssued> Read_InvoiceReIssuedByBAL(string invoiceId);
        List<DepositDetail> Read_InvoiceDepositBAL(string invoiceId);
        long create_InvoiceReIssueBAL(ReIssued invoiceReIssue);
        long create_InvoiceHistoryBAL(InvoiceHistory invoiceHistory);
    }
}
