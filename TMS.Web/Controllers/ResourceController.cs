using Abp.Web.Models;
using ExtensionMethods;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Resources.Abstract;
using Resources.Concrete;
using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using TMS.Business.Admin;
using TMS.Business.Interfaces.Admin;
using TMS.Library.Admin;
using TMS.Library.Admin.Lookup;
using lr = Resources.Resources;

namespace TMS.Web.Controllers
{
    public class ResourceController : TMSControllerBase
    {
        #region"Constructer"
        public readonly ITMSResourcesBAL _objeResources = null;//For the Resorces Table Interface
        public readonly ILookupBAL _objeIookupBAL = null;

        public ResourceController(ITMSResourcesBAL objeResources,
            ILookupBAL objeIookupBAL)
        {
            _objeResources = objeResources;
            _objeIookupBAL = objeIookupBAL;
        }

        #endregion

        #region"Lookup"

        [Authorize]
        public ActionResult Lookup()
        {
            return View();
        }

        [DontWrapResult]
        public ActionResult Lookup_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var tt = _objeIookupBAL.GetLookupDataBAL(true, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            if (CurrentUser.CompanyID > 0)
            {
                tt = _objeIookupBAL.GetLookupDataBAL_byOrganization(true, Convert.ToString(CurrentUser.CompanyID), startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
                // return Json(tt.ToDataSourceResult(request));
            }

            var result = new DataSourceResult()
            {
                Data = tt, // Process data (paging and sorting applied)
                Total = Total // Total number of records
            };
            return Json(result);
        }

        [DontWrapResult]
        public ActionResult Lookup_Create([DataSourceRequest] DataSourceRequest request, Lookup Lookup)
        {
            Lookup.Createdby = Convert.ToInt64(CurrentUser.NameIdentifier);
            Lookup.OrganizationID = CurrentUser.CompanyID;
            var Result = _objeIookupBAL.InsertLookupRecordBAL(Lookup);
            Lookup.LookupID = Result;
            Lookup.CreatedDate = DateTime.Now;
            Lookup.IsActive = true;
            return Json(new[] { Lookup }.ToDataSourceResult(request, ModelState));
        }

        [DontWrapResult]
        public ActionResult Lookup_Update([DataSourceRequest] DataSourceRequest request, Lookup objLookup)
        {
            objLookup.Updatedby = Convert.ToInt64(CurrentUser.NameIdentifier);
            objLookup.UpdatedDate = DateTime.Now;
            var Resp = _objeIookupBAL.UpdateLookupRecordBAL(objLookup);
            if (Resp != 1)
            {
                ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
            }
            var resultData = new[] { objLookup };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region"LookupDetail"

        [DontWrapResult]
        public ActionResult LookupDetail_Read([DataSourceRequest] DataSourceRequest request, string LookupId)
        {
            var _ResultData = _objeIookupBAL.GetLookupDetailDataBAL(Convert.ToInt64(LookupId));
            return Json(_ResultData.ToDataSourceResult(request));
        }

        [DontWrapResult]
        public ActionResult LookupDetail_Create([DataSourceRequest] DataSourceRequest request, string LookupIdCreate, LookupDetail _LookupDetail)
        {
            _LookupDetail.Createdby = Convert.ToInt64(CurrentUser.NameIdentifier);
            _LookupDetail.LookupID = Convert.ToInt64(LookupIdCreate); ;
            _LookupDetail.CreatedDate = DateTime.Now;
            var Result = _objeIookupBAL.InsertLookupDetailRecordBAL(_LookupDetail);
            _LookupDetail.LookupDetaiId = Result;
            return Json(new[] { _LookupDetail }.ToDataSourceResult(request, ModelState));
        }

        [DontWrapResult]
        public ActionResult LookupDetail_Update([DataSourceRequest] DataSourceRequest request, LookupDetail objLookup)
        {
            objLookup.Updatedby = Convert.ToInt64(CurrentUser.NameIdentifier);
            objLookup.UpdatedDate = DateTime.Now;
            var Resp = _objeIookupBAL.UpdateLookupDetailRecordBAL(objLookup);
            if (Resp != 1)
            {
                ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
            }
            var resultData = new[] { objLookup };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [DontWrapResult]
        public ActionResult LookupDetail_Destroy([DataSourceRequest] DataSourceRequest request, LookupDetail objLookup)
        {
            objLookup.Updatedby = Convert.ToInt64(CurrentUser.NameIdentifier);
            objLookup.UpdatedDate = DateTime.Now;
            var Resp = _objeIookupBAL.DeleteLookupDetailRecordBAL(objLookup);
            if (Resp != 1)
            {
                ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
            }
            var resultData = new[] { objLookup };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region "Resource Editing"

        [Authorize]
        public ActionResult Index()
        { if(User.IsInRole("CanAddEditResource"))
                {
                ViewBag.IsAdmin = true;
            }else
            {
                ViewBag.IsAdmin = false;
            }
            
            return View();
        }

        [DontWrapResult]
        public ActionResult Resource_Read([DataSourceRequest] DataSourceRequest request)
        {

            var SearchText = Request.Form["SearchText"];

            var startRowIndex = (request.Page - 1) * request.PageSize;
            var value = GridHelper.GetSortExpression(request, "P_Resourceid");
            int Total = 0;
            var resources = _objeResources.GetTMSResourceBAL(request.Page, request.PageSize, ref Total, SearchText,Convert.ToString(CurrentUser.CompanyID)).ToList();
            //if (CurrentUser.CompanyID > 0)
            //{
            //    resources = _objeResources.GetTMSResourceBALbyOrganization(request.Page, request.PageSize, ref Total, Convert.ToString(-2), SearchText).ToList();
            //}
            // var startRowIndex = (request.Page - 1) * request.PageSize;
            //var value = GridHelper.GetSortExpression(request, "P_Resourceid");
            //int Total = 0;
            //var resources = _objeResources.GetTMSResourceBAL(startRowIndex, request.PageSize, ref Total, value, SearchText);
            //if (CurrentUser.CompanyID > 0)
            //{
            //    resources = _objeResources.GetTMSResourceBALbyOrganization(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "IDP_Resourceid"), SearchText, Convert.ToString(CurrentUser.CompanyID)).ToList();
            //}

            if (request.Sorts.Any())
            {
                foreach (SortDescriptor sortDescriptor in request.Sorts)
                {
                    if (sortDescriptor.SortDirection == ListSortDirection.Ascending)
                    {
                        switch (sortDescriptor.Member)
                        {
                            case "Name":
                                resources = resources.OrderBy(order => order.Name).ToList();
                                break;
                            case "P_Value":
                                resources = resources.OrderBy(order => order.P_Value).ToList();
                                break;
                            case "S_Value":
                                resources = resources.OrderBy(order => order.S_Value).ToList();
                                break;
                            //case "OrganizationName":
                            //    resources = resources.OrderByDescending(order => order.OrganizationName).ToList();
                            //    break;
                            case "CreatedDate":
                                resources = resources.OrderBy(order => order.CreatedDate).ToList();
                                break;
                            case "CreatedBy":
                                resources = resources.OrderBy(order => order.CreatedBy).ToList();
                                break;
                        }
                    }
                    else
                    {
                        switch (sortDescriptor.Member)
                        {
                            case "Name":
                                resources = resources.OrderByDescending(order => order.Name).ToList();
                                break;
                            case "P_Value":
                                resources = resources.OrderByDescending(order => order.P_Value).ToList();
                                break;
                            case "S_Value":
                                resources = resources.OrderByDescending(order => order.S_Value).ToList();
                                break;
                            //case "OrganizationName":
                            //    resources = resources.OrderByDescending(order => order.OrganizationName).ToList();
                            //    break;
                            case "CreatedDate":
                                resources = resources.OrderByDescending(order => order.CreatedDate).ToList();
                                break;
                            case "CreatedBy":
                                resources = resources.OrderByDescending(order => order.CreatedBy).ToList();
                                break;
                        }
                    }
                }
            }
            else
            {
                //EF cannot page unsorted data.
                resources = resources.OrderBy(o => o.P_Resourceid).ToList();
            }
            var result = new DataSourceResult()
            {
                Data = resources, // Process data (paging and sorting applied)
                Total = Total // Total number of records

            };

            return Json(result);
        }


        [DontWrapResult]
        public ActionResult Resource_CreateOrganization([DataSourceRequest] DataSourceRequest request, TMSResource Resources, long oid)
        {
            //  ITMSResourcesBAL _objeResources = new TMSResourcesBAL();
            if (_objeResources.LanguageExistCountBAL(oid) <= 0)
            {
                return Json("Please Enter Language!", JsonRequestBehavior.AllowGet);

            }
            if (ModelState.IsValid)
            {
                Resources.OrganizationID = oid;
                Resources.CreatedBy = Convert.ToInt64(CurrentUser.NameIdentifier);
                //Resources.Name = Resources.Name.RemoveWhitespace();//Remove any unwanted Space
                // Resources.Name = Resources.Name.RemoveUnWantedCharacter();//to make this Proper Variblename
                var Resp = _objeResources.InsertOrgResourceBAL(Resources);
                Resources.CreatedDate = DateTime.Now;
                //  Resources.P_Resourceid = Resp.P_Resourceid;
                // Resources.S_Resourceid = Resp.S_Resourceid;
                //return Json(new[] { Resources }.ToDataSourceResult(request, ModelState));
            }
            var resultData = new[] { Resources };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }



        [DontWrapResult]
        public ActionResult Resource_Create([DataSourceRequest] DataSourceRequest request, TMSResource Resources)
        {
            // ITMSResourcesBAL _objeResources = new TMSResourcesBAL();
            if (_objeResources.ResourceExistCountBAL(Resources.Name) > 0)
            {
                ModelState.AddModelError(lr.ResourceName, lr.ResourceValidationName);
            }
            if (ModelState.IsValid)
            {
                Resources.OrganizationID = CurrentUser.CompanyID;
                Resources.CreatedBy = Convert.ToInt64(CurrentUser.NameIdentifier);
                Resources.Name = Resources.Name.RemoveWhitespace();//Remove any unwanted Space
                Resources.Name = Resources.Name.RemoveUnWantedCharacter();//to make this Proper Variblename
                var Resp = _objeResources.InsertDualTMSResourceBAL(Resources);
                Resources.CreatedDate = DateTime.Now;
                Resources.P_Resourceid = Resp.P_Resourceid;
                Resources.S_Resourceid = Resp.S_Resourceid;
                //return Json(new[] { Resources }.ToDataSourceResult(request, ModelState));
            }
            var resultData = new[] { Resources };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [DontWrapResult]
        public ActionResult Resource_Update([DataSourceRequest] DataSourceRequest request, TMSResource Resources)
        {
            Resources.UpdatedBy = Convert.ToInt64(CurrentUser.NameIdentifier);
            Resources.Name = Resources.Name.RemoveWhitespace();//Removeany uunwanted Space
            Resources.Name = Resources.Name.RemoveUnWantedCharacter();//to make this Proper Variblename
            var Resp = _objeResources.UpdateDualTMSResourceBAL(Resources);
            if (Resp != 2)
            {
                ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
            }
            var resultData = new[] { Resources };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region "Resource Defaults"

        // GET: /Resource/GetResources
        private const int durationInSeconds = 2 * 60 * 60;  // 2 hours.

        //[OutputCache(VaryByCustom = "culture", Duration = durationInSeconds)]
        [DontWrapResultAttribute]
        [OutputCache(Location = OutputCacheLocation.Server, Duration = durationInSeconds, VaryByCustom = "culture")]
        public JsonResult GetResources()
        {
            var tt = Json(
                typeof(lr)
                .GetProperties()
                .Where(p => !p.Name.IsLikeAny("ResourceManager", "Culture")) // Skip the properties you don't need on the client side.
                .ToDictionary(p => p.Name, p => p.GetValue(null) as string)
                 , JsonRequestBehavior.AllowGet);
            return tt;
            // Or the following
            /*
            return Json(new Dictionary<string, string> {
                {"Age", Resource.Age},
                {"FirstName", Resource.FirstName},
                {"LastName", Resource.LastName},
                {"EnterNumber", Resource.EnterNumber}
            }, JsonRequestBehavior.AllowGet);
            */
        }

        public ActionResult InvalidateCacheForResources()
        {
            IResourceProvider resourceProvider = new DbResourceProvider();
            resourceProvider.ClearCache();
            string path = Url.Action("GetResources");
            Response.RemoveOutputCacheItem(path);
            return Content("cache invalidated, you could now go back to the index action");
        }

        #endregion
    }
}