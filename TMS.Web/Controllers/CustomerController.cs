using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Linq;
using System.Web.Mvc;
using TMS.Business.Interfaces.TMS;
using TMS.Library;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using TMS.Library.Entities.Invoice;
using TMS.Business.Interfaces.Invoiceing;

namespace TMS.Web.Controllers
{
    public class CustomerController : TMSControllerBase
    {
       
        private readonly IBALUsers _UserBAL;
        private readonly IInvoiceingBAL _CustomerBAL;
        public CustomerController( IBALUsers objUserBAL, IInvoiceingBAL customerBAL)
        {
             _UserBAL = objUserBAL; _CustomerBAL = customerBAL;
        }
        // GET: Customer
        [ClaimsAuthorize("CanViewCustomer")]

        public ActionResult Index()
        {
            return View();
        }
        [DontWrapResult]
        [ClaimsAuthorize("CanViewCustomer")]

        public ActionResult Customer_Read([DataSourceRequest]DataSourceRequest request)
        {
            var kendoRequest = new Kendo.Mvc.UI.DataSourceRequest
            {
                Filters = request.Filters,
                Sorts = request.Sorts,
                Groups = request.Groups,
                Aggregates = request.Aggregates
            };
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            var DeletedPerson = Request.Form["DeletedPerson"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }

            
                IList<Customer> _person;
                if (kendoRequest.Filters.Count > 0)
                {
                    // ref int Total, string culture, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long CompanyID
                    _person = this._CustomerBAL.CustomerRead_CustomerBAL(ref Total, CurrentCulture, SearchText, GridHelper.GetSortExpression(request, "ID").ToString(), startRowIndex, request.Page, 10000, CurrentUser.CompanyID);

                }
                else
                {
                    _person = this._CustomerBAL.CustomerRead_CustomerBAL(ref Total, CurrentCulture,  SearchText, GridHelper.GetSortExpression(request, "ID").ToString(), startRowIndex, request.Page, request.PageSize, CurrentUser.CompanyID);

                }
                //var _person = _PersonBAL.PersonOrganization_GetALLBAL(Convert.ToString(CurrentUser.CompanyID));,string SortExpression,int StartRowIndex,int page,int PageSize
                _person = _person.Distinct().ToList();
                var data = _person.ToDataSourceResult(kendoRequest);
                var result = new DataSourceResult()
                {
                    AggregateResults = data.AggregateResults,
                    Data = data.Data,
                    Errors = data.Errors,
                    Total = Total
                };
                return Json(result);
            
        }

       // [DisableValidation]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditCustomer")]

        public ActionResult Customer_Create([DataSourceRequest] DataSourceRequest request,Customer customer )
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(customer);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to insert Customer " + DateTime.UtcNow, "", 0, "Customer", "Customer_Create", json.ToString(), CurrentUser.CompanyID);

                customer.Created_By = CurrentUser.NameIdentifierInt64;
                customer.Created_Date = DateTime.UtcNow;
                customer.Organization_ID = CurrentUser.CompanyID;
                var ID = _CustomerBAL.create_CustomerBAL(customer);
                customer.ID = ID;
                var resultData2 = new[] { customer };
                return Json(resultData2.ToDataSourceResult(request, ModelState));
            }
            var resultData = new[] { customer };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditCustomer")]

        public ActionResult Customer_Update([DataSourceRequest] DataSourceRequest request, Customer customer)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(customer);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Update_Success.ToString(), System.Environment.MachineName, "User tried to insert Customer " + DateTime.UtcNow, "", 0, "Customer", "Customer_Update", json.ToString(), CurrentUser.CompanyID);
              
                var ID = _CustomerBAL.Update_CustomerBAL(customer);
                customer.ID = ID;
                var resultData2 = new[] { customer };
                return Json(resultData2.ToDataSourceResult(request, ModelState));
            }
            var resultData = new[] { customer };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }
        [DontWrapResult] 
        [ClaimsAuthorize("CanDeleteCustomer")]

        public ActionResult Customer_Destroy([DataSourceRequest] DataSourceRequest request, Customer customer)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(customer);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Update_Success.ToString(), System.Environment.MachineName, "User tried to insert Customer " + DateTime.UtcNow, "", 0, "Customer", "Customer_Update", json.ToString(), CurrentUser.CompanyID);
                var ID = _CustomerBAL.Destroy_CustomerBAL(customer);
                customer.ID = ID;
                var resultData2 = new[] { customer };
                return Json(resultData2.ToDataSourceResult(request, ModelState));
            }
            var resultData = new[] { customer };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }
    }
}
