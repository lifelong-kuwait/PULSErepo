using Abp.Runtime.Validation;
using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using Kendo.Mvc.UI;
using System;
using lr = Resources.Resources;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TMS.Business.Interfaces;
using TMS.Business.Interfaces.Common;
using TMS.Business.Interfaces.Common.Configuration;
using TMS.Business.Interfaces.TMS;
using TMS.Business.Interfaces.TMS.Program;
using TMS.Library;
using TMS.Library.Common.Attachment;
using TMS.Library.TMS.Persons;
using TMS.Web.Models;
using TMS.Library.Common.Address;
using Kendo.Mvc.Extensions;
using TMS.Business.Interfaces.Jobs;
using TMS.Library.Entities.Jobs;
using TMS.Library.TMS.Education;
using TMS.Business.Interfaces.TMS.Persons.Education;
using TMS.Library.TMS.Persons.Education;

namespace TMS.Web.Controllers
{
    public class JobApplyController : Controller
    {
        
        private readonly IAttachmentBAL _AttachmentBAL;
        private readonly IPersonBAL _PersonBAL;
        private readonly IBALUsers _UserBAL;
        private readonly ITrainerBAL _TrainerBAL;
        private readonly IPersonContactBAL _objPersonContactBAL;
        private readonly IConfigurationBAL _objConfigurationBAL;
        private readonly IClassBAL _ClassBAL;
        private readonly IJobApplicationBAL _JobApplicationBAL;
        private readonly IPersonEducationBAL _PersonEducationBAL;
        private readonly IJobsBAL _IJobsBAL;

        public JobApplyController(IAttachmentBAL objIAttachmentBAL, IJobsBAL _objIJobsBAL, IClassBAL IClassBAL, IConfigurationBAL _objIConfigurationBAL, ITrainerBAL objITrainerBAL, IPersonBAL objIPersonBAL, IBALUsers objUserBAL, IPersonContactBAL _objePersonContact,IJobApplicationBAL jobApplicationBAL, IPersonEducationBAL objIPersonEducationBAL)
        {
            _IJobsBAL = _objIJobsBAL; _objConfigurationBAL = _objIConfigurationBAL; _ClassBAL = IClassBAL; _AttachmentBAL = objIAttachmentBAL; _TrainerBAL = objITrainerBAL; _PersonBAL = objIPersonBAL; _UserBAL = objUserBAL; _objPersonContactBAL = _objePersonContact;_JobApplicationBAL = jobApplicationBAL; _PersonEducationBAL = objIPersonEducationBAL;
        }

        public JobApplyController(IAttachmentBAL objIAttachmentBAL)
        {
            _AttachmentBAL = objIAttachmentBAL;
        }
        // GET: JobApply
        public ActionResult Index()
        {
            var jobsList = _IJobsBAL.Jobs_Requirement_For_EndUser(0);

            return View(jobsList);
        }
        [DisableAbpAntiForgeryTokenValidation]
        [DisableValidation]
        public ActionResult JobApplySave(GModel gModel)
        {
            Person_Create(gModel,4);
            return Json("Succes");
        }

        //[ValidateAntiForgeryToken]
        [DisableAbpAntiForgeryTokenValidation]
        [DisableValidation]
        public ActionResult TMSSaveAttachment(HttpPostedFileBase fileupload, long oid, int otype, int fileType)
        {
            var extention = Path.GetExtension(fileupload.FileName);
            TMS_Attachments _Attachments = new TMS_Attachments
            {
                FileParentRootFolder = DateTime.Now.Ticks.ToString()
            };
            string targetString;
            if (otype == 1)
            {
                targetString = "~/Attachment/TMS/Person/" + oid + "/Attachment/" + _Attachments.FileParentRootFolder + "/";
            }
            else
            {
                targetString = "~/Attachment/TMS/Organization/" + oid + "/Attachment/" + _Attachments.FileParentRootFolder + "/"; ;
            }
            string targetSource = Utility.CreateDirectory(Path.Combine(Server.MapPath(targetString)));
            var physicalPath = Path.Combine(targetSource, fileupload.FileName);
            _Attachments.CreatedBy = 10001;
            _Attachments.CreatedDate = DateTime.Now;
            _Attachments.FileExtension = Path.GetExtension(fileupload.FileName);
            _Attachments.FileName = fileupload.FileName;
            _Attachments.FilePath = targetString;
            _Attachments.FileSize = fileupload.ContentLength;
            _Attachments.FileType = (AttachmentsFileType)fileType;
            _Attachments.OpenID = oid;
            _Attachments.OpenType = otype;
            var result = _AttachmentBAL.TMS_Attachment_CreateBAL(_Attachments);
            fileupload.SaveAs(physicalPath);
            return Json(new { parentFoldername = _Attachments.FileParentRootFolder, aid = result }, "text/plain");
        }
        public ActionResult RemoveTMSAttachment(string parentFoldername, string fileNames, long oid, int Opentype, long aid)
        {
            RemoveTMSFileFromDisk(parentFoldername, fileNames, oid, Opentype, aid);
            return Content("");
        }
        [NonAction]
        internal void RemoveTMSFileFromDisk(string parentFoldername, string name, long oid, int Opentype, long aid)
        {
            string targetPath;
            if (Opentype == 1)
            {
                targetPath = "~/Attachment/TMS/Person/" + oid + "/Attachment/" + parentFoldername + "/";
            }
            else
            {
                targetPath = "~/Attachment/TMS/Organization/" + oid + "/Attachment/" + parentFoldername + "/"; ;
            }
            var fileName = Path.GetFileName(name);
            var physicalPath = Path.Combine(Server.MapPath(targetPath));
            if (System.IO.File.Exists(physicalPath + "/" + name))
            {

                System.IO.File.Delete(physicalPath + "/" + name);
                TMS_Attachments _Attachments = new TMS_Attachments
                {
                    UpdatedBy = 10001,
                    UpdatedDate = DateTime.Now,
                    ID = aid
                };
                _AttachmentBAL.TMS_Attachment_DeleteBAL(_Attachments);
                System.IO.DirectoryInfo di = new DirectoryInfo(physicalPath);
                di.Delete();
            }
        }
        [NonAction]
        public long Person_Create( GModel _person, long RoleID)
        {
            JobApplication jobApplication = new JobApplication();
            jobApplication.ExpectedSalary = _person.item.ExpectedSalary;
            jobApplication.JoiningDate = _person.item.JoiningDate;
            jobApplication.OrganizationID = -4;
            jobApplication.JobRequirementApplicationID = _person.item.JobID;
            var ApplicationID=_JobApplicationBAL.Jobs_Application_Create(jobApplication);
            Person person = new Person();            
                person.SalutationID = _person.item.SalutationID;
                person.Gender = _person.item.Gender;
                person.P_FirstName = _person.item.P_FirstName;
                person.P_MiddleName = _person.item.P_FirstName;
                person.P_LastName = _person.item.P_FirstName;
                person.NickName = _person.item.NickName;
                person.Email = _person.item.Email;
                person.MaritalStatus = _person.item.MaritalStatus;
                person.NationalIdentity = _person.item.NationalIdentity;
                person.CountryCode = _person.item.CountriesID;
                person.ContactNumber = _person.item.ContactNumber;
                person.Extension = _person.item.Extension;
                person.SalutationID = _person.item.SalutationID;
                person.CreatedDate = DateTime.Now;
                person.DateOfBirth = _person.item.DateOfBirth;
                person.AvailabilityFrom = _person.item.JoiningDate;
                person.AvailabilityTo = _person.item.JoiningDate;
                person.OrganizationID = -4;
                person.P_DisplayName = _person.item.P_FirstName+ _person.item.P_MiddleName+ _person.item.P_LastName;
            bool _valid = false;
                var json = new JavaScriptSerializer().Serialize(_person);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to insert Person " + DateTime.UtcNow, "", 0, "People", "Person_Create", json.ToString(), -4);
                if (_person.item.Email == null  && RoleID == 2)//when Email is Provided
                    {
                        ModelState.AddModelError(lr.PersonEmailorPhoneRequired, lr.PersonEmailorPhoneRequired);
                        _valid = false;
                    }
                    else if (_person.item.ContactNumber != null)//when Contact number is provided
                    {
                        if (_person.item.CountriesID == 0)//when country code is  provided
                        {
                            _person.item.CountriesID = 134;
                            _valid = true;
                            //ModelState.AddModelError(lr.PersonPhoneCountryCode, lr.PersonPhoneNumberProvideCountryocde);
                        }
                        else
                        {
                            _valid = true;
                        }
                    }
                    else
                    {
                        _valid = true;
                        //ModelState.AddModelError(lr.PersonContactEmail, lr.PersonEmailorPhoneRequired);
                    }

                   

                    if (_valid)
                    {
                        //  _person.ProfilePicture = HandlePersonProfilePicture(filename, _person.ID, aid);
                        person.CreatedBy = 100010;
                        person.CreatedDate = DateTime.Now;
                        person.OrganizationID = -2;
                        string _profilePict = string.Empty;
                        if (_person.item.DateOfBirth == null)
                            person.DateOfBirth = DateTime.Now.AddYears(-10);
                        
                       
                        if (person.ClientType == null)
                            person.ClientType = ClientType.Not_Specified;
                        var Resp = SavePersonData(person, ref _profilePict, RoleID);
                      _JobApplicationBAL.Jobs_ApplicationPersonMapping_Create(ApplicationID, Resp.ID);

                         string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (string.IsNullOrEmpty(ip))
                            ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                        _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, -4, 100010, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);
                        person.AddedByAlias = "100010";
                        person.ID = Resp.ID;
                        person.PersonRegCode = Resp.PersonRegCode;
                        person.ProfilePicture = _profilePict;
                        if (person.ID != long.MinValue)
                        {
                            if (person.ContactNumber != null)//when ContactNumber is Provided
                            {
                                PhoneNumbers _objPhoneNumbers = new PhoneNumbers
                                {
                                    ContactNumber = person.ContactNumber,
                                    CountryCode = person.CountryCode,
                                    IsPrimary = true,
                                    Extension = person.Extension,
                                    CreatedBy = 100010,
                                    CreatedDate = DateTime.Now,

                                };
                                person.PhoneID = _objPersonContactBAL.PersonPhoneNumbers_CreateBAL(_objPhoneNumbers, person.ID);
                            }
                            if (person.Email != null)//when Email is Provided
                            {


                                EmailAddresses _objEmailAddresses = new EmailAddresses
                                {
                                    Email = person.Email,
                                    IsPrimary = true,
                                    CreatedBy = 01110,
                                    CreatedDate = DateTime.Now,
                                    PersonID = person.ID,
                                    OrganizationID = -4
                                };
                                person.EmailID = _objPersonContactBAL.PersonEmailAddress_CreateBAL(_objEmailAddresses, person.ID);
                            }if (_person.education != null)
                    {
                        foreach (var item in _person.education)
                        {


                            PersonDegrees _personDegree = new PersonDegrees();
                            _personDegree.P_Title = item.P_Title;
                            _personDegree.University = item.University;
                            _personDegree.P_Title = item.P_Title;
                            _personDegree.ResultTypeID = item.ResultTypeID;
                            _personDegree.Result = item.Result;
                            _personDegree.Session = item.Session;
                            _personDegree.Duration = item.Duration;
                            _personDegree.DegreeStatus = item.DegreeStatus;
                            _personDegree.Major = item.Major;
                            _personDegree.Description = item.Description;
                            _personDegree.CreatedBy = 100010;
                            _personDegree.CreatedDate = DateTime.Now;
                            _personDegree.PersonID = Convert.ToInt64(Resp.ID);
                            _personDegree.ID = _PersonEducationBAL.PersonEducationDegrees_CreateBAL(_personDegree);
                        }
                    }
                            if(_person.referances!=null)
                    {
                        foreach (var item in _person.referances)
                        {

                            JobReferance jobReferance = new JobReferance();
                            jobReferance.JobTitle = item.Title;
                            jobReferance.ReferName = item.Name;
                            jobReferance.PhoneNumber = item.Phone;
                            jobReferance.Company = item.Title;
                            jobReferance.PersonID = Resp.ID;
                            jobReferance.Relation = item.Title;

                            _JobApplicationBAL.Jobs_Referance_Create_BAL(jobReferance);

                        }
                    }
                            if(_person.employementHistories!=null)
                    {
                        foreach (var item in _person.employementHistories)
                        {
                            WorkExperiences _personWorkExperiences = new WorkExperiences();
                            _personWorkExperiences.CompanyName = item.Employer;
                            _personWorkExperiences.P_Title = item.JobTitle;
                            _personWorkExperiences.ReferencePhone = item.WorkPhone;
                            _personWorkExperiences.StartTimePeriod = item.WorkFrom;
                            _personWorkExperiences.EndTimePeriod = item.WorkTo;
                            _personWorkExperiences.Location = item.Address;
                            _personWorkExperiences.CreatedBy = 100010; ;
                            _personWorkExperiences.CreatedDate = DateTime.Now;
                            _personWorkExperiences.PersonID = Convert.ToInt64(Resp.ID); 
                            _personWorkExperiences.StartTimePeriod = new DateTime(_personWorkExperiences.StartTimePeriod.Year, _personWorkExperiences.StartTimePeriod.Month, 1);
                            if (_personWorkExperiences.OrganizationID == -1)
                            { _personWorkExperiences.OrganizationID = 0; }
                            var result = _PersonEducationBAL.PersonEducationWorkExperiences_CreateDAL(_personWorkExperiences);
                            if (result == -1)
                            {
                                ModelState.AddModelError(lr.ErrorServerError, lr.PersonEducationCertificationsDuplicationMessage);
                            }
                            else
                            {
                                _personWorkExperiences.ID = result;
                            }
                            _AttachmentBAL.TMS_Attachment_UpdateForJobBAL(Resp.ID, _person.item.FileID);
                        }
                    }

                           
                        }
                    

                }
            
            person.RoleName = null;

            var resultData = new[] { _person };
            return 150;
        }
        [NonAction]
        public PersonResponse SavePersonData(Person _person, ref string _profilePict, long RoleID)
        {
            var result = _PersonBAL.PersonInsertNewPersonBAL(_person, RoleID);
            _profilePict = "/images/i/people.png"; // _profilePict=   HandlePersonAttachment(filename, result.ID);
            return result;
        }
    }
}