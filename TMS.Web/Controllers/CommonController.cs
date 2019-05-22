using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Linq;
using System.Web.Mvc;
using TMS.Business.Interfaces.Common;
using TMS.Library.Common;
using lr = Resources.Resources;

namespace TMS.Web.Controllers
{
    public class CommonController : TMSControllerBase
    {
        private readonly ICommonBAL CommonBAL;

        public CommonController(ICommonBAL CommonBAL)
        {
            this.CommonBAL = CommonBAL;
        }

        #region"Notes"

        [DontWrapResult]
        [ContentAuthorize]
        [ClaimsAuthorize("CanViewPersonNotes", "CanViewOrganizationNotes")]
        public ActionResult OpenNotes(string OpenId, int Opentype)
        {
            ViewData["OpenType"] = Opentype;
            return PartialView("_OpenNotes", OpenId);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonNotes", "CanViewOrganizationNotes")]
        public ActionResult OpenNotes_Read([DataSourceRequest] DataSourceRequest request, int Opentype, long OpenId)
        {
            if (CurrentUser.CompanyID > 0)
            {
                var TMS_Attachment = this.CommonBAL.TMS_NotesByOrganization_GetByIdAndTypeBAL(OpenId, Opentype,Convert.ToString(CurrentUser.CompanyID));
                return Json(TMS_Attachment.ToDataSourceResult(request, ModelState));
            }
            else
            {
                var TMS_Attachment = this.CommonBAL.TMS_Notes_GetByIdAndTypeBAL(OpenId, Opentype);
                return Json(TMS_Attachment.ToDataSourceResult(request, ModelState));
            }
        }
        [HttpGet]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonNotes", "CanViewOrganizationNotes")]
        public ActionResult OpenNotes_GetbyIdType(int Opentype, long OpenId)
        {
            var TMS_Attachment = this.CommonBAL.TMS_Notes_GetByIdAndTypeBAL(OpenId, Opentype);
            return Json(TMS_Attachment, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonNotes", "CanAddEditOrganizationNotes")]
        public ActionResult OpenNotes_Create([DataSourceRequest] DataSourceRequest request, TMS_Notes _TMS_Notes, long OpenId,int Opentype )
        {
            if (ModelState.IsValid)
            {
                _TMS_Notes.CreatedBy = CurrentUser.NameIdentifierInt64;
                _TMS_Notes.CreatedDate = DateTime.Now;
                _TMS_Notes.OrganizationID = CurrentUser.CompanyID;
                _TMS_Notes.OpenID = OpenId;
                _TMS_Notes.OpenType = Opentype;
                _TMS_Notes.ID = this.CommonBAL.TMS_Notes_CreateBAL(_TMS_Notes);
            }
            var resultData = new[] { _TMS_Notes };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonNotes","CanAddEditOrganizationNotes")]
        public ActionResult OpenNotes_Update([DataSourceRequest] DataSourceRequest request, TMS_Notes _TMS_Notes)
        {
            if (ModelState.IsValid)
            {
                _TMS_Notes.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _TMS_Notes.UpdatedDate = DateTime.Now;
                var result = this.CommonBAL.TMS_Notes_UpdateBAL(_TMS_Notes);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _TMS_Notes };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanDeletePersonNotes", "CanDeleteOrganizationNotes")]
        public ActionResult OpenNotes_Destroy([DataSourceRequest] DataSourceRequest request, TMS_Notes _TMS_Notes)
        {
            if (ModelState.IsValid)
            {
                _TMS_Notes.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _TMS_Notes.UpdatedDate = DateTime.Now;
                var result = this.CommonBAL.TMS_Notes_DeleteBAL(_TMS_Notes);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _TMS_Notes };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion
    }
}