﻿using Abp.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TMS.Business.Common.DDL;
using TMS.Business.Interfaces.Common.Configuration;
using TMS.Business.Interfaces.Common.DDL;
using TMS.Business.Interfaces.TMS.Organization;
using TMS.Business.Interfaces.TMS.Program;
using TMS.Library;
using TMS.Web.Core;
using static TMS.UtilityFunctions;
using lr = Resources.Resources;

namespace TMS.Web.Controllers
{
    
    public class DDLController : TMSControllerBase
    {
        public readonly IOrganizationBAL _objeobjIOrganizationBAL = null;//For the Resorces Table Interface
        public readonly IDDLBAL _objIDDLBAL = null;//For the Resorces Table Interface
        public readonly IConfigurationBAL _objIConfigBAL = null;//For the Resorces Table Interface
        DDLBAL ddl = new DDLBAL();
        private readonly IClassBAL _ClassBAL;
        public DDLController(IOrganizationBAL objIOrganizationBAL, IClassBAL IClassBAL, IDDLBAL ObjDDLBAL, IConfigurationBAL ObjConfigBAL)
        {
            _objeobjIOrganizationBAL = objIOrganizationBAL;
            _objIDDLBAL = ObjDDLBAL;
            _objIConfigBAL = ObjConfigBAL;
            _ClassBAL = IClassBAL;
        }

        [DontWrapResult]
        public JsonResult Organization()
        {
            return Json(_objeobjIOrganizationBAL.OrganizationAllbyCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);
        }
        [DontWrapResult]
        public JsonResult OrganizationForTrainer(string email)
        {
            var x = _objeobjIOrganizationBAL.OrganizationAllForTrainerbyCultureBAL(CurrentCulture, email);
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        [DontWrapResult]
        public JsonResult OrganizationForWork()
        {
            var Orgvalues = _objeobjIOrganizationBAL.OrganizationAllbyCultureBAL(CurrentCulture);
            Orgvalues.Add(new DDlList { Value = -1, Text = lr.DropDownOtherValue, });
            return Json(Orgvalues, JsonRequestBehavior.AllowGet);
        }

        [DontWrapResult]
        public JsonResult PersonEducationDegreeSessions()
        {
            List<DDlList> _SessionList = new List<DDlList>(); int ConfiguredYear = TMSHelper.PersonEducationSessionPreviousYear();

            _SessionList = Utility.FillDropDownRecentYears(ConfiguredYear);
            return Json(_SessionList, JsonRequestBehavior.AllowGet);
        }

        [DontWrapResult]
        public JsonResult PersonEducationDegreeDuration()
        {
            List<DDlList> _SessionList = new List<DDlList>();
            int Duration = TMSHelper.PersonEducationDegreeTotolDuration(); for (int count = 1; count <= Duration; count++) { _SessionList.Add(new DDlList { Text = count.ToString(), Value = count }); }
            return Json(_SessionList, JsonRequestBehavior.AllowGet);
        }

        #region "Course"

        [DontWrapResult]
        public JsonResult PersonEducationCertificationsYears()
        {
            List<DDlList> _SessionList = new List<DDlList>(); int ConfiguredYear = TMSHelper.PersonEducationCertificationsPreviousYear();
            _SessionList = Utility.FillDropDownRecentYears(ConfiguredYear);
            return Json(_SessionList, JsonRequestBehavior.AllowGet);
        }
        [DontWrapResult]
        public JsonResult CertificateDDL()
        {
           var _SessionList = _objeobjIOrganizationBAL.CertificatesByOiDBAL(Convert.ToInt64(CurrentUser.CompanyID));
            return Json(_SessionList, JsonRequestBehavior.AllowGet);
        }
        #endregion "Course"

        #region Course Language
        [DontWrapResult]
        public JsonResult CourseLanguages()
        {
            return Json(this._objIDDLBAL.CoreLanguage_GetAllByCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Course Coordinator

        [DontWrapResult]
        public JsonResult CourseCoordinator()
        {
            return Json(this._objIDDLBAL.Coordinator_GetAllByCultureBAL(CurrentCulture,CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "Address"

        [DontWrapResult]
        public JsonResult CoreCountries()
        {
            //if (CurrentUser.CompanyID > 0)
            //{
            //    return Json(_objIDDLBAL.CoreCountries_GetAllbyCultureBALbyOrganization(CurrentCulture,Convert.ToString(CurrentUser.CompanyID)), JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            return Json(_objIDDLBAL.CoreCountries_GetAllbyCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);
            // }

        }

        [DontWrapResult]
        public JsonResult CoreRegion(string CountryId)
        {
            //if (CurrentUser.CompanyID > 0)
            //{
            //    return Json(_objIDDLBAL.CoreRegionState_GetAllbyCultureBALbyOrganization(CurrentCulture, Convert.ToInt32(CountryId),Convert.ToString(CurrentUser.CompanyID)), JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            return Json(_objIDDLBAL.CoreRegionState_GetAllbyCultureBAL(CurrentCulture, Convert.ToInt32(CountryId)), JsonRequestBehavior.AllowGet);
            //}
        }

        [DontWrapResult]
        public JsonResult CoreCities(string RegionId)
        {
            //if (CurrentUser.CompanyID > 0)
            //{
            //    return Json(_objIDDLBAL.CoreCitiesRegion_GetAllbyCultureBALbyOrganization(CurrentCulture, Convert.ToInt32(RegionId),Convert.ToString(CurrentUser.CompanyID)), JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            return Json(_objIDDLBAL.CoreCitiesRegion_GetAllbyCultureBAL(CurrentCulture, Convert.ToInt32(RegionId)), JsonRequestBehavior.AllowGet);
            // }

        }

        #endregion "Address"

        #region "Contact"

        [DontWrapResult]
        public JsonResult CountryCode()
        {
            DDlList obj = new DDlList();
            obj.Text = "Not Selected";
            obj.Value = -1;
            obj.Selected = true;
            var value = _objIDDLBAL.CountryCode_GetAllByCultureBAL(CurrentCulture);
            value.Insert(0,obj);
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        [DontWrapResult]
        public JsonResult NationalityCode()
        {
            return Json(_objIDDLBAL.NationalityCode_GetAllByCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);
        }

        #endregion "Contact"

        #region Flags

        [DontWrapResult]
        public JsonResult Flags()
        {
            if (CurrentUser.CompanyID > 0)
            {
                return Json(_objIConfigBAL.PersonFlags_GetAllCultureBAL(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
                // return Json(_objIConfigBAL.PersonFlags_GetAllCultureDdlBAL(CurrentCulture), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(_objIConfigBAL.PersonFlag_GetAllCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);

            }
        }
        #endregion Flags

        #region Organization

        [DontWrapResult]
        public JsonResult OrganizationTypes()
        {
            return Json(_objIDDLBAL.OrganizationTypes_GetAllByCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);
        }

        [DontWrapResult]
        public JsonResult PersonAll()
        {
            return Json(_objIDDLBAL.PersonGetAllforDDL_BAL(CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        }

        [DontWrapResult]
        public JsonResult CRM_Classes()
        {
            var CrmClasses = _objIDDLBAL.CRMClasses(CurrentCulture, CurrentUser.CompanyID);
            return Json(CrmClasses, JsonRequestBehavior.AllowGet);
        }
        [DontWrapResult]
        public JsonResult CRM_Courses()
        {
            return Json(_objIDDLBAL.CRM_Courses(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        }
        [DontWrapResult]
        public JsonResult HowHeard()
        {
            return Json(_objIDDLBAL.HowHeard(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        }

        [DontWrapResult]
        public JsonResult CRM_Users()
        {
            return Json(_objIDDLBAL.CRM_Users(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        }
        
        [DontWrapResult]
        public JsonResult UserAll()
        {
            return Json(_objIDDLBAL.UserGetAllforDDL_BAL(CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        }

        [DontWrapResult]
        public JsonResult UserGetAllUnassigned()
        {
            return Json(_objIDDLBAL.UserGetAllUnassignedforDDL_BAL(), JsonRequestBehavior.AllowGet);
        }

        [DontWrapResult]
        public JsonResult GetAllClasses() => Json(_objIDDLBAL.GetAllClasses(), JsonRequestBehavior.AllowGet);

        [DontWrapResult]
        public JsonResult OrganizationPersonRelationTypes()
        {
            return Json(_objIDDLBAL.OrganizationPersonRelationTypes_GetAllByCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);
        }

        #endregion Organization



        #region Resources

        public JsonResult Resources()
        {
            return Json(_objIDDLBAL.Resources_GetAllbyCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);


        }

        #endregion Resources


        #region Program Course

        [DontWrapResult]
        public JsonResult CourseCategories(int id)
        {
            //for course categories please pass the 1 or for feedback please pass the 2
            return Json(_objIDDLBAL.CourseCategories_GetAllByCultureBAL(CurrentCulture, id, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        }

        [DontWrapResult]
        public JsonResult CourseVendors()
        {
            return Json(_objIDDLBAL.CourseVendors_GetAllByCultureBAL(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        }

        [DontWrapResult]
        public ActionResult CourseVendorsData()
        {
            return PartialView("DropDownData", _objIDDLBAL.CourseVendors_GetAllByCultureBAL(CurrentCulture, CurrentUser.CompanyID));
        }

        [DontWrapResult]
        public ActionResult CourseVenue()
        {
            if (CurrentUser.CompanyID > 0)
            {
                return Json(_objIConfigBAL.Venues_GetAllByCultureBAL(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(_objIConfigBAL.Venues_GetAllByCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);
            }
        }

        [DontWrapResult]
        public ActionResult Currencies()
        {
            //if (CurrentUser.CompanyID > 0)
            //{
            //    return Json(_objIDDLBAL.CurrenciesbyOrganization_GetAllByCultureBAL(CurrentCulture,CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            return Json(_objIDDLBAL.Currencies_GetAllByCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);
            //  }

        }

        public ActionResult CurrenciesData()
        {
            return PartialView("DropDownData", _objIDDLBAL.Currencies_GetAllByCultureBAL(CurrentCulture));
        }

        #endregion Program Course

        #region Class

        [DontWrapResult]
        public JsonResult Course()
        {
            var list = this._ClassBAL.personRoleGroups(CurrentUser.NameIdentifierInt64);
            long PersonId = 0;
            if (list.Count == 1 && list[0].PrimaryGroupName == "Trainer")
            {
                PersonId = CurrentUser.NameIdentifierInt64;
            }
            return Json(_objIDDLBAL.Courses_GetAllByCultureBAL(CurrentCulture, CurrentUser.CompanyID, PersonId), JsonRequestBehavior.AllowGet);
        }
        [DontWrapResult]
        public JsonResult Classes()
        {
            return Json(_objIDDLBAL.ClassDDLBAL(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        }
      
           
        #endregion Class

        #region SystemDefined Languages

        [DontWrapResult]
        public JsonResult Lang() => Json(_objIDDLBAL.ProgramLanguages_GetAllByCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);

        [DontWrapResult]
        public JsonResult LanguageDDL(long courseId) => Json(_objIDDLBAL.ProgramLanguages_GetAllByCourseCultureBAL(Convert.ToString( courseId)), JsonRequestBehavior.AllowGet);
        [DontWrapResult]
        public JsonResult LanguageClassDDL(long ClassID) => Json(_objIDDLBAL.ProgramLanguages_GetAllByClassCultureBAL(Convert.ToString(ClassID)), JsonRequestBehavior.AllowGet);

        public ActionResult LangData() => PartialView("DropDownData", _objIDDLBAL.ProgramLanguages_GetAllByCultureBAL(CurrentCulture));

        #endregion SystemDefined Languages

        [DontWrapResult]
        public JsonResult Venues(int OpenType, long OpenId) => Json(_objIConfigBAL.Venues_GetAllByCultureBAL(CurrentCulture, OpenType, OpenId, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
       
        [DontWrapResult]
        public JsonResult VenuesForClass(int OpenType, long OpenId) => Json(_objIConfigBAL.Venues_GetAllByClassBAL(CurrentCulture, OpenType, OpenId, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);

        [DontWrapResult]
        public JsonResult ClasesbyCourseId()
        {
            var CourseId = Request.Form["CourseId"];
            if (string.IsNullOrEmpty(CourseId))
            {
                CourseId = "0";
            }

            return Json(_objIDDLBAL.Classes_ByCourseIdAndCultureBAL(CurrentCulture, CourseId, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        }


        [DontWrapResult]
        public JsonResult Roles() => Json(_objIDDLBAL.Roles_GetAllByCultureBAL(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        [DontWrapResult]
        public JsonResult Trainer(int OpenType, long OpenId) => Json(_objIConfigBAL.ManageTrainer_GetAllByCultureBAL(CurrentCulture, OpenType, OpenId, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        [DontWrapResult]
        public JsonResult VenueByClassId(int OpenType, long OpenId) => Json(_objIConfigBAL.ManageVenue_GetAllByCultureBAL(CurrentCulture, OpenType, OpenId, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);

        [DontWrapResult]
        public JsonResult DDLTrainer() => Json(ddl.TrainerDDLBAL(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        [DontWrapResult]
        public JsonResult DDLVenue() => Json(ddl.VenueDDLBAL(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        [DontWrapResult]
        public JsonResult GetAllCourseCategories()
        {
            return Json(ddl.GetAllCourseCategories(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        }
        [DontWrapResult]
        public JsonResult ClassTypeDDL ()
        {
            return Json(EnumManager.GetEnumCollection(typeof(ClassType)), JsonRequestBehavior.AllowGet);
        }
        //

        [DontWrapResult]
        public JsonResult CourseLogistic() => Json(_objIConfigBAL.CourseLogistic_GetAllByCultureBALL(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        //    [DontWrapResult]
        //public JsonResult CourseLogistic()
        //{
        //    var logistic = _objIConfigBAL.CourseLogistic_GetAllByCultureBALL(CurrentCulture, CurrentUser.CompanyID);
        //  return  Json(logistic, JsonRequestBehavior.AllowGet);
        //}ddl.Class_TraineeDDLBAL(CurrentCulture, CompanyID, Convert.ToInt64(DdlClass.SelectedValue)
        //[DontWrapResult]
        //public JsonResult ClassTrainer() => Json(ddl.Class_TraineeDDLBAL(CurrentCulture, CurrentUser.CompanyID,), JsonRequestBehavior.AllowGet);


        [DontWrapResult]
        public JsonResult CourseMeterial() => Json(_objIConfigBAL.CourseMeterial_GetAllByCultureBAL(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        [DontWrapResult]
        public JsonResult PersonsForInvoice() => Json(_objIConfigBAL.PersonsForInvoice_GetAllByCultureBAL(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);

    }
}