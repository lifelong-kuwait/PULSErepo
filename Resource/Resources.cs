using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
    
namespace Resources {
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();
 public static string GetByName(string resname)
        {
            return (string)resourceProvider.GetResource(resname, CultureInfo.CurrentUICulture.Name);
        }
                
        /// <summary>Primary Language Resource</summary>
        public static string PrimaryLanguageResource {
               get {
                   return (string) resourceProvider.GetResource("PrimaryLanguageResource", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Secondary Language Resource</summary>
        public static string SecondaryLanguageResource {
               get {
                   return (string) resourceProvider.GetResource("SecondaryLanguageResource", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Resource Name</summary>
        public static string ResourceName {
               get {
                   return (string) resourceProvider.GetResource("ResourceName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Resource Name Required </summary>
        public static string ResourceNameRequired {
               get {
                   return (string) resourceProvider.GetResource("ResourceNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Resource Value Required</summary>
        public static string PrimaryResourceRequired {
               get {
                   return (string) resourceProvider.GetResource("PrimaryResourceRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Secondary Resource Value Required</summary>
        public static string SecondaryResourceRequired {
               get {
                   return (string) resourceProvider.GetResource("SecondaryResourceRequired", CultureInfo.CurrentUICulture.Name);
               }
            }


        public static string AttendanceTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("AttendanceTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Add</summary>
        public static string AddRecordGeneralTitle {
               get {
                   return (string) resourceProvider.GetResource("AddRecordGeneralTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Edit</summary>
        public static string EditRecordGeneralTitle {
               get {
                   return (string) resourceProvider.GetResource("EditRecordGeneralTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Save</summary>
        public static string SaveRecordGeneralButton {
               get {
                   return (string) resourceProvider.GetResource("SaveRecordGeneralButton", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Exit</summary>
        public static string CencelRecordGeneralButton {
               get {
                   return (string) resourceProvider.GetResource("CencelRecordGeneralButton", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Update</summary>
        public static string UpdateRecordGeneralButton {
               get {
                   return (string) resourceProvider.GetResource("UpdateRecordGeneralButton", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>My Apps</summary>
        public static string MyApps {
               get {
                   return (string) resourceProvider.GetResource("MyApps", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Messages</summary>
        public static string MessagesHead {
               get {
                   return (string) resourceProvider.GetResource("MessagesHead", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add New Resources</summary>
        public static string AddNewResources {
               get {
                   return (string) resourceProvider.GetResource("AddNewResources", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Pre-Requiests</summary>
        public static string MenuPreRequiests {
               get {
                   return (string) resourceProvider.GetResource("MenuPreRequiests", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person</summary>
        public static string MenuPerson {
               get {
                   return (string) resourceProvider.GetResource("MenuPerson", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Trainer</summary>
        public static string MenuTrainer {
               get {
                   return (string) resourceProvider.GetResource("MenuTrainer", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Trainee</summary>
        public static string MenuTrainee {
               get {
                   return (string) resourceProvider.GetResource("MenuTrainee", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course</summary>
        public static string MenuCourse {
               get {
                   return (string) resourceProvider.GetResource("MenuCourse", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Class</summary>
        public static string MenuClass {
               get {
                   return (string) resourceProvider.GetResource("MenuClass", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Session</summary>
        public static string MenuSession {
               get {
                   return (string) resourceProvider.GetResource("MenuSession", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Schedule</summary>
        public static string MenuSchedule {
               get {
                   return (string) resourceProvider.GetResource("MenuSchedule", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>FeadBack</summary>
        public static string MenuFeadBack {
               get {
                   return (string) resourceProvider.GetResource("MenuFeadBack", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Certificate</summary>
        public static string MenuCertificate {
               get {
                   return (string) resourceProvider.GetResource("MenuCertificate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Reports</summary>
        public static string MenuReports {
               get {
                   return (string) resourceProvider.GetResource("MenuReports", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Payment & Account</summary>
        public static string MenuPaymentAccount {
               get {
                   return (string) resourceProvider.GetResource("MenuPaymentAccount", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Manage SMS</summary>
        public static string MenuManageSMS {
               get {
                   return (string) resourceProvider.GetResource("MenuManageSMS", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Admin Section</summary>
        public static string MenuAdminSection {
               get {
                   return (string) resourceProvider.GetResource("MenuAdminSection", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Enter Username</summary>
        public static string LoginEnterUsername {
               get {
                   return (string) resourceProvider.GetResource("LoginEnterUsername", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Enter Password</summary>
        public static string LoginEnterPassword {
               get {
                   return (string) resourceProvider.GetResource("LoginEnterPassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Sign In</summary>
        public static string LoginSignIn {
               get {
                   return (string) resourceProvider.GetResource("LoginSignIn", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Keep Me Sign In</summary>
        public static string LoginKeepMeSignIn {
               get {
                   return (string) resourceProvider.GetResource("LoginKeepMeSignIn", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Password</summary>
        public static string LoginPasswordRequired {
               get {
                   return (string) resourceProvider.GetResource("LoginPasswordRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter UserName</summary>
        public static string LoginUserNameRequired {
               get {
                   return (string) resourceProvider.GetResource("LoginUserNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Valid Email Address</summary>
        public static string LoginUserNameInvalid {
               get {
                   return (string) resourceProvider.GetResource("LoginUserNameInvalid", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Invalid password or username</summary>
        public static string LoginInvalidpassword {
               get {
                   return (string) resourceProvider.GetResource("LoginInvalidpassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>All Rights Reserved</summary>
        public static string AllRightsReserved {
               get {
                   return (string) resourceProvider.GetResource("AllRightsReserved", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>2016.LifeLong</summary>
        public static string CompanyName {
               get {
                   return (string) resourceProvider.GetResource("CompanyName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Resource Page Title</summary>
        public static string ResourcePageTitle {
               get {
                   return (string) resourceProvider.GetResource("ResourcePageTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Dashboard</summary>
        public static string Dashboard {
               get {
                   return (string) resourceProvider.GetResource("Dashboard", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>This Name Already Exist Resource </summary>
        public static string ResourceValidationName {
               get {
                   return (string) resourceProvider.GetResource("ResourceValidationName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Edit Me</summary>
        public static string GridEditText {
               get {
                   return (string) resourceProvider.GetResource("GridEditText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Some Error Occur on Server Side</summary>
        public static string ResourceUpdateValidationError {
               get {
                   return (string) resourceProvider.GetResource("ResourceUpdateValidationError", CultureInfo.CurrentUICulture.Name);
               }
            }
        /// <summary>Some Error Occur on Server Side</summary>
        public static string ClassTrainerCannotAssignAsTrainee
        {
            get
            {
                return (string)resourceProvider.GetResource("ClassTrainerCannotAssignAsTrainee", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Some Error Occur on Server Side</summary>
        public static string ClassTraineeCannotAssignAsTrainee
        {
            get
            {
                return (string)resourceProvider.GetResource("ClassTraineeCannotAssignAsTrainee", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Some Error Occur on Server Side</summary>
        public static string LanguageDublication
        {
            get
            {
                return (string)resourceProvider.GetResource("LanguageDublication", CultureInfo.CurrentUICulture.Name);
            }
        }    /// <summary>Some Error Occur on Server Side</summary>
        public static string DubliocationHappen
        {
            get
            {
                return (string)resourceProvider.GetResource("DubliocationHappen", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Lookup Primary Name</summary>
        public static string LookupPrimaryName {
               get {
                   return (string) resourceProvider.GetResource("LookupPrimaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Lookup Secondary Name</summary>
        public static string LookupSecondaryName {
               get {
                   return (string) resourceProvider.GetResource("LookupSecondaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Lookup ID</summary>
        public static string LookupID {
               get {
                   return (string) resourceProvider.GetResource("LookupID", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add New Lookup</summary>
        public static string LookupAddNewLookup {
               get {
                   return (string) resourceProvider.GetResource("LookupAddNewLookup", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Lookup Details</summary>
        public static string LookupDetailsTabTitle {
               get {
                   return (string) resourceProvider.GetResource("LookupDetailsTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Lookup Details </summary>
        public static string LookupDetailsAdd {
               get {
                   return (string) resourceProvider.GetResource("LookupDetailsAdd", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Server Error</summary>
        public static string ErrorServerError {
               get {
                   return (string) resourceProvider.GetResource("ErrorServerError", CultureInfo.CurrentUICulture.Name);
               }
            }
        /// <summary>Server Error</summary>
        public static string MaximumSessionConflict
        {
            get
            {
                return (string)resourceProvider.GetResource("MaximumSessionConflict", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Server Error</summary>
        public static string MaximumSessionConflictDelete
        {
            get
            {
                return (string)resourceProvider.GetResource("MaximumSessionConflictDelete", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Start  and End Date Conflict</summary>
        public static string StartandEndDateConflict
        {
            get
            {
                return (string)resourceProvider.GetResource("StartandEndDateConflict", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Start  and End Date Conflict</summary>
        public static string StartandEndTimeConflict
        {
            get
            {
                return (string)resourceProvider.GetResource("StartandEndTimeConflict", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Start  and End Date Conflict</summary>
        public static string TrainingTitleAllreadyExists
        {
            get
            {
                return (string)resourceProvider.GetResource("TrainingTitleAllreadyExists", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Created Date</summary>
        public static string GridCreatedDate {
               get {
                   return (string) resourceProvider.GetResource("GridCreatedDate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Updated Date</summary>
        public static string GridUpdatedDate {
               get {
                   return (string) resourceProvider.GetResource("GridUpdatedDate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Updated By</summary>
        public static string GridUpdatedBy {
               get {
                   return (string) resourceProvider.GetResource("GridUpdatedBy", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Created By</summary>
        public static string GridCreatedBy {
               get {
                   return (string) resourceProvider.GetResource("GridCreatedBy", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Delete</summary>
        public static string GridDeleteButtonText {
               get {
                   return (string) resourceProvider.GetResource("GridDeleteButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Delete</summary>
        public static string GridDeleteColumnHeader {
               get {
                   return (string) resourceProvider.GetResource("GridDeleteColumnHeader", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Edit</summary>
        public static string GridEditColumnHeader {
               get {
                   return (string) resourceProvider.GetResource("GridEditColumnHeader", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Active</summary>
        public static string GridIsActiveColumnTitle {
               get {
                   return (string) resourceProvider.GetResource("GridIsActiveColumnTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Lookup Primary Name Required</summary>
        public static string LookupPrimaryNameRequired {
               get {
                   return (string) resourceProvider.GetResource("LookupPrimaryNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Lookup Secondary Name Required</summary>
        public static string LookupSecondaryNameRequired {
               get {
                   return (string) resourceProvider.GetResource("LookupSecondaryNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Lookup Detail Primary Language</summary>
        public static string LookupDetailP_NameColumnTitle {
               get {
                   return (string) resourceProvider.GetResource("LookupDetailP_NameColumnTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Lookup Detail Secondary </summary>
        public static string LookupDetailS_NameColumnTitle {
               get {
                   return (string) resourceProvider.GetResource("LookupDetailS_NameColumnTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Lookup Detail Primary Language</summary>
        public static string LookupDetailP_NameRequired {
               get {
                   return (string) resourceProvider.GetResource("LookupDetailP_NameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Lookup Detail Secondary Language </summary>
        public static string LookupDetailS_NameRequired {
               get {
                   return (string) resourceProvider.GetResource("LookupDetailS_NameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Is Selected </summary>
        public static string GridIsSelected {
               get {
                   return (string) resourceProvider.GetResource("GridIsSelected", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Lookup Detail Primary Name</summary>
        public static string LookupDetailPrimaryName {
               get {
                   return (string) resourceProvider.GetResource("LookupDetailPrimaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Lookup Detail Secondary Name</summary>
        public static string LookupDetailSecondaryName {
               get {
                   return (string) resourceProvider.GetResource("LookupDetailSecondaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Are you Sure you want to Delete this Record?</summary>
        public static string GridDeleteRecordMessage {
               get {
                   return (string) resourceProvider.GetResource("GridDeleteRecordMessage", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>No Record Found </summary>
        public static string GridNoRecordFoundMessage {
               get {
                   return (string) resourceProvider.GetResource("GridNoRecordFoundMessage", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Admin Section </summary>
        public static string AdminPageTitle {
               get {
                   return (string) resourceProvider.GetResource("AdminPageTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Lookup</summary>
        public static string LookupPageTitle {
               get {
                   return (string) resourceProvider.GetResource("LookupPageTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>People – Summary & Quick Actions</summary>
        public static string PersonPageTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonPageTitle", CultureInfo.CurrentUICulture.Name);
               }
            }

        public static string PersonTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("PersonTitle", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Resources</summary>
        public static string ResourcesPageTitle {
               get {
                   return (string) resourceProvider.GetResource("ResourcesPageTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Secondary First Name</summary>
        public static string PersonS_FirstName {
               get {
                   return (string) resourceProvider.GetResource("PersonS_FirstName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Secondary Middle Name</summary>
        public static string PersonS_MiddleName {
               get {
                   return (string) resourceProvider.GetResource("PersonS_MiddleName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Secondary Last Name</summary>
        public static string PersonS_LastName {
               get {
                   return (string) resourceProvider.GetResource("PersonS_LastName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Primary Last Name</summary>
        public static string PersonP_LastName {
               get {
                   return (string) resourceProvider.GetResource("PersonP_LastName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Primary Middle Name</summary>
        public static string PersonP_MiddleName {
               get {
                   return (string) resourceProvider.GetResource("PersonP_MiddleName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Primary First Name</summary>
        public static string PersonP_FirstName {
               get {
                   return (string) resourceProvider.GetResource("PersonP_FirstName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Salutation</summary>
        public static string PersonSalutation {
               get {
                   return (string) resourceProvider.GetResource("PersonSalutation", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Engagement Status</summary>
        public static string PersonEngagementStatus {
               get {
                   return (string) resourceProvider.GetResource("PersonEngagementStatus", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Organization</summary>
        public static string PersonOrganization {
               get {
                   return (string) resourceProvider.GetResource("PersonOrganization", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Department</summary>
        public static string PersonDepartment {
               get {
                   return (string) resourceProvider.GetResource("PersonDepartment", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Notes</summary>
        public static string PersonNotes {
               get {
                   return (string) resourceProvider.GetResource("PersonNotes", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>National Identity</summary>
        public static string PersonNationalIdentity {
               get {
                   return (string) resourceProvider.GetResource("PersonNationalIdentity", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>ID Type</summary>
        public static string PersonOfficialIdentificationType {
               get {
                   return (string) resourceProvider.GetResource("PersonOfficialIdentificationType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>ID #</summary>
        public static string PersonOfficialIDNumber {
               get {
                   return (string) resourceProvider.GetResource("PersonOfficialIDNumber", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Date Of Birth</summary>
        public static string DateOfBirth {
               get {
                   return (string) resourceProvider.GetResource("DateOfBirth", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Marital Status</summary>
        public static string MaritalStatus {
               get {
                   return (string) resourceProvider.GetResource("MaritalStatus", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Gender</summary>
        public static string Gender {
               get {
                   return (string) resourceProvider.GetResource("Gender", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Nationality</summary>
        public static string PersonNationality {
               get {
                   return (string) resourceProvider.GetResource("PersonNationality", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Type</summary>
        public static string PersonType {
               get {
                   return (string) resourceProvider.GetResource("PersonType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Is Coordinator</summary>
        public static string PersonIsCoordinator {
               get {
                   return (string) resourceProvider.GetResource("PersonIsCoordinator", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Client Type</summary>
        public static string PersonClientType {
               get {
                   return (string) resourceProvider.GetResource("PersonClientType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Rating</summary>
        public static string PersonRating {
               get {
                   return (string) resourceProvider.GetResource("PersonRating", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Attached Picture </summary>
        public static string PersonAttachedPicture {
               get {
                   return (string) resourceProvider.GetResource("PersonAttachedPicture", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Documents </summary>
        public static string PersonDocuments {
               get {
                   return (string) resourceProvider.GetResource("PersonDocuments", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Personal Details</summary>
        public static string PersonBasicInfoTab {
               get {
                   return (string) resourceProvider.GetResource("PersonBasicInfoTab", CultureInfo.CurrentUICulture.Name);
               }
            }
       
        /// <summary>Registration Code</summary>
        public static string PersonRegistrationCode {
               get {
                   return (string) resourceProvider.GetResource("PersonRegistrationCode", CultureInfo.CurrentUICulture.Name);
               }
            }
        /// <summary>Registration Code</summary>
        public static string clientstatus
        {
            get
            {
                return (string)resourceProvider.GetResource("clientstatus", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Select Salutation</summary>
        public static string PersonSalutationRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonSalutationRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Type</summary>
        public static string PersonTypeRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonTypeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Gender</summary>
        public static string PersonGenderRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonGenderRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary> Enter First Name</summary>
        public static string PersonP_FirstNameRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonP_FirstNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary> Enter First Name</summary>
        public static string PersonS_FirstNameRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonS_FirstNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Enter Last Name</summary>
        public static string PersonP_LastNameRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonP_LastNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Enter Last Name</summary>
        public static string PersonS_LastNameRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonS_LastNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Enter Display name</summary>
        public static string PersonP_DisplayNameRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonP_DisplayNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Enter Display name</summary>
        public static string PersonS_DisplaynameRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonS_DisplaynameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Display Name</summary>
        public static string PersonS_DisplayName {
               get {
                   return (string) resourceProvider.GetResource("PersonS_DisplayName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Display Name </summary>
        public static string PersonP_DisplayName {
               get {
                   return (string) resourceProvider.GetResource("PersonP_DisplayName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select The Engagement Status </summary>
        public static string PersonEngagementRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEngagementRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Active</summary>
        public static string IsActive {
               get {
                   return (string) resourceProvider.GetResource("IsActive", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Person</summary>
        public static string PersonAddPersonText {
               get {
                   return (string) resourceProvider.GetResource("PersonAddPersonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Dr.</summary>
        public static string SalutationDoctor {
               get {
                   return (string) resourceProvider.GetResource("SalutationDoctor", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Mr.</summary>
        public static string SalutationMister {
               get {
                   return (string) resourceProvider.GetResource("SalutationMister", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Mrs.</summary>
        public static string SalutationMissIs {
               get {
                   return (string) resourceProvider.GetResource("SalutationMissIs", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Ms.</summary>
        public static string SalutationMiss {
               get {
                   return (string) resourceProvider.GetResource("SalutationMiss", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Male</summary>
        public static string GenderMale {
               get {
                   return (string) resourceProvider.GetResource("GenderMale", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Female</summary>
        public static string GenderFemale {
               get {
                   return (string) resourceProvider.GetResource("GenderFemale", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Not Specified</summary>
        public static string NotSpecified {
               get {
                   return (string) resourceProvider.GetResource("NotSpecified", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Married</summary>
        public static string MaritalStatusMarried {
               get {
                   return (string) resourceProvider.GetResource("MaritalStatusMarried", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Single</summary>
        public static string MaritalStatusSingle {
               get {
                   return (string) resourceProvider.GetResource("MaritalStatusSingle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Divorced</summary>
        public static string MaritialStatusDivorced {
               get {
                   return (string) resourceProvider.GetResource("MaritialStatusDivorced", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Name</summary>
        public static string PersonPrimaryName {
               get {
                   return (string) resourceProvider.GetResource("PersonPrimaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Name</summary>
        public static string PersonSecondaryName {
               get {
                   return (string) resourceProvider.GetResource("PersonSecondaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Organization</summary>
        public static string OrganizationSelectLabelOptional {
               get {
                   return (string) resourceProvider.GetResource("OrganizationSelectLabelOptional", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Marital Status</summary>
        public static string MaritalStatusOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("MaritalStatusOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Gender</summary>
        public static string GenderOptionallabel {
               get {
                   return (string) resourceProvider.GetResource("GenderOptionallabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Client Type </summary>
        public static string ClientTypeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("ClientTypeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Salutation</summary>
        public static string SalutationOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("SalutationOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Nationality </summary>
        public static string NationalityOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("NationalityOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select ID type</summary>
        public static string OfficialIDTypeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("OfficialIDTypeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Education </summary>
        public static string PersonEducationTabTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Certification </summary>
        public static string PersonCertificationTabTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonCertificationTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary> Contact Information</summary>
        public static string PersonContactInformationTabTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonContactInformationTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Skill and Interests</summary>
        public static string PersonSkillandInterestsTabTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonSkillandInterestsTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Level</summary>
        public static string PersonPersonLevelTabTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonPersonLevelTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Education</summary>
        public static string PersonDegreeTabTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonDegreeTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Training History</summary>
        public static string PersonTrainingDeliveredTabTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonTrainingDeliveredTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Work Experience</summary>
        public static string PersonWorkExperienceTabTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonWorkExperienceTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Achievement </summary>
        public static string PersonAchievementTabTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonAchievementTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Suggested Training </summary>
        public static string PersonSuggestedTrainingTabTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonSuggestedTrainingTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Phone Numbers</summary>
        public static string PhoneTabTitle {
               get {
                   return (string) resourceProvider.GetResource("PhoneTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Email</summary>
        public static string EmailTabTitle {
               get {
                   return (string) resourceProvider.GetResource("EmailTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Addresses</summary>
        public static string AddressTabTitle {
               get {
                   return (string) resourceProvider.GetResource("AddressTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Online Presence</summary>
        public static string LinkTabTitle {
               get {
                   return (string) resourceProvider.GetResource("LinkTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Availability </summary>
        public static string AvailabilityTabTitle {
               get {
                   return (string) resourceProvider.GetResource("AvailabilityTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Focus Area</summary>
        public static string FocusAreaTitle {
               get {
                   return (string) resourceProvider.GetResource("FocusAreaTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Skill </summary>
        public static string SkillTabTitle {
               get {
                   return (string) resourceProvider.GetResource("SkillTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Field of Interest</summary>
        public static string FieldofInterestTabTitle {
               get {
                   return (string) resourceProvider.GetResource("FieldofInterestTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Degree </summary>
        public static string AddDegreeButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddDegreeButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Certification</summary>
        public static string AddCertificationButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddCertificationButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Training Delivered </summary>
        public static string AddTrainingDeliveredButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddTrainingDeliveredButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary> Add Work Experience</summary>
        public static string AddWorkExperienceButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddWorkExperienceButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Achievement </summary>
        public static string AddAchievementButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddAchievementButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Suggested Training</summary>
        public static string AddSuggestedTrainingButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddSuggestedTrainingButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Phone</summary>
        public static string AddPhoneButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddPhoneButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Email</summary>
        public static string AddEmailButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddEmailButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Secondary Address</summary>
        public static string AddSecondaryAddressButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddSecondaryAddressButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Link</summary>
        public static string AddLinkButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddLinkButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Availability</summary>
        public static string AddAvailabilityButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddAvailabilityButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Focus</summary>
        public static string AddFocusButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddFocusButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Skill</summary>
        public static string AddSkillButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddSkillButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Field of Interest</summary>
        public static string AddFieldofInterestButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddFieldofInterestButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Person Level </summary>
        public static string AddPersonLevelButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddPersonLevelButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Title </summary>
        public static string PersonEducationDegreeTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Title </summary>
        public static string PersonEducationDegreeTitleRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeTitleRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>University/Institute</summary>
        public static string PersonEducationDegreeUniversityInstitute {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeUniversityInstitute", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter University/Institute </summary>
        public static string PersonEducationDegreeUniversityInstituteRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeUniversityInstituteRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>CGPA/Percentage</summary>
        public static string PersonEducationDegreeCGPAPercentageResultType {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeCGPAPercentageResultType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Result Type </summary>
        public static string PersonEducationDegreeCGPAPercentageResultTypeRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeCGPAPercentageResultTypeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Result </summary>
        public static string PersonEducationDegreeCGPAPercentageResultRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeCGPAPercentageResultRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Session</summary>
        public static string PersonEducationDegreeSession {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeSession", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Session </summary>
        public static string PersonEducationDegreeSessionRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeSessionRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Majors </summary>
        public static string PersonEducationDegreeMajors {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeMajors", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Majors</summary>
        public static string PersonEducationDegreeMajorsRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeMajorsRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Description</summary>
        public static string Description {
               get {
                   return (string) resourceProvider.GetResource("Description", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Complete</summary>
        public static string PersonEducationDegreeComplete {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeComplete", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Incomplete</summary>
        public static string PersonEducationDegreeIncomplete {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeIncomplete", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>CGPA/Percentage</summary>
        public static string PersonEducationDegreeCGPAPercentageResult {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeCGPAPercentageResult", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary> Duration (Year)</summary>
        public static string PersonEducationDegreeDurationYear {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeDurationYear", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select  Duration (Year)</summary>
        public static string PersonEducationDegreeDurationYearRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeDurationYearRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Degree Status</summary>
        public static string PersonEducationDegreeStatus {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeStatus", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Title</summary>
        public static string PersonEducationDegreeTitleSecondaryLanguage {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeTitleSecondaryLanguage", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Session</summary>
        public static string PersonEducationDegreeSessionOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeSessionOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Degree Duration</summary>
        public static string PersonEducationDegreeDurationOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeDurationOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary> Select Result Type</summary>
        public static string PersonEducationDegreeResultTypeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeResultTypeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Specify Result Value 0.1 to 100</summary>
        public static string PersonEducationDegreeResultTypeRange {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeResultTypeRange", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Enter Result</summary>
        public static string PersonEducationDegreeResultPlaceHolder {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationDegreeResultPlaceHolder", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Certifications Title</summary>
        public static string PersonEducationCertificationsPrimaryTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsPrimaryTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Certifications  Title</summary>
        public static string PersonEducationCertificationsSecondaryTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsSecondaryTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary> Certifications Roll No</summary>
        public static string PersonEducationCertificationsRollNo {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsRollNo", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Duration</summary>
        public static string PersonEducationCertificationsDuration {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsDuration", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Duration Type</summary>
        public static string CourseDurationTypeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("CourseDurationTypeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Enter Duration </summary>
        public static string PersonEducationCertificationsDurationPlaceHolder {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsDurationPlaceHolder", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Completion Year</summary>
        public static string PersonEducationCertificationsCompletionYear {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsCompletionYear", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Awarding Body </summary>
        public static string PersonEducationCertificationsAwardingBody {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsAwardingBody", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Awarding Body</summary>
        public static string PersonEducationCertificationsAwardingBodyRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsAwardingBodyRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Institution </summary>
        public static string PersonEducationCertificationsInstitution {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsInstitution", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Validity (years)</summary>
        public static string PersonEducationCertificationsValidity {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsValidity", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Title </summary>
        public static string PersonEducationCertificationsPrimaryTitleRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsPrimaryTitleRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Title </summary>
        public static string PersonEducationCertificationsSecondaryTitleRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsSecondaryTitleRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Roll no </summary>
        public static string PersonEducationCertificationsRollNoRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsRollNoRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Duration Type </summary>
        public static string PersonEducationCertificationsDurationTypeRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsDurationTypeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Duration</summary>
        public static string PersonEducationCertificationsDurationRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsDurationRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Completion Year</summary>
        public static string PersonEducationCertificationsCompletionYearRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsCompletionYearRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Completion  Year</summary>
        public static string PersonEducationCertificationsCompletionYearOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsCompletionYearOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>The field {0} must be a My number</summary>
        public static string FieldMustBeNumeric {
               get {
                   return (string) resourceProvider.GetResource("FieldMustBeNumeric", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Value must be Between 1 to 1000</summary>
        public static string OneToThousandDurationRange {
               get {
                   return (string) resourceProvider.GetResource("OneToThousandDurationRange", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Certification Exist with same name and Roll No</summary>
        public static string PersonEducationCertificationsDuplicationMessage {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationCertificationsDuplicationMessage", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Title </summary>
        public static string PersonEducationTrainingPrimaryTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingPrimaryTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Training Title</summary>
        public static string PersonEducationTrainingPrimaryTitleRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingPrimaryTitleRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Title </summary>
        public static string PersonEducationTrainingSecondaryTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingSecondaryTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Learning Objective</summary>
        public static string PersonEducationTrainingLearningObjective {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingLearningObjective", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Learning Objective </summary>
        public static string PersonEducationTrainingLearningObjectiveRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingLearningObjectiveRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Duration </summary>
        public static string PersonEducationTrainingDuration {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingDuration", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Duration Type </summary>
        public static string PersonEducationTrainingDurationOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingDurationOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Training Duration </summary>
        public static string PersonEducationTrainingDurationRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingDurationRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Client Name</summary>
        public static string PersonEducationTrainingClientName {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingClientName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Reference Name </summary>
        public static string PersonEducationTrainingReferenceName {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingReferenceName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Reference Title</summary>
        public static string PersonEducationTrainingReferenceTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingReferenceTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Reference Phone</summary>
        public static string PersonEducationTrainingReferencePhone {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingReferencePhone", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Reference Email</summary>
        public static string PersonEducationTrainingReferenceEmail {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingReferenceEmail", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course Outline</summary>
        public static string PersonEducationTrainingCourseOutline {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingCourseOutline", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Value from 0.01 to 1000</summary>
        public static string PersonEducationTrainingDurationRange {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingDurationRange", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Company Name</summary>
        public static string PersonEducationWorkExperiencesCompanyName {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesCompanyName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Company Name</summary>
        public static string PersonEducationWorkExperiencesCompanyNameRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesCompanyNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Title </summary>
        public static string PersonEducationWorkExperiencesPrimaryTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesPrimaryTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Title </summary>
        public static string PersonEducationWorkExperiencesPrimaryTitleRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesPrimaryTitleRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Title </summary>
        public static string PersonEducationWorkExperiencesSecondaryTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesSecondaryTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Job Status</summary>
        public static string PersonEducationWorkExperiencesJobStatus {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesJobStatus", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Job Status </summary>
        public static string PersonEducationWorkExperiencesJobStatusOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesJobStatusOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Job Status</summary>
        public static string PersonEducationWorkExperiencesJobStatusRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesJobStatusRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Location </summary>
        public static string PersonEducationWorkExperiencesLocation {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesLocation", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter location </summary>
        public static string PersonEducationWorkExperiencesLocationRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesLocationRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Time Period </summary>
        public static string PersonEducationWorkExperiencesTimePeriod {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesTimePeriod", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>From </summary>
        public static string PersonEducationWorkExperiencesFrom {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesFrom", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Present </summary>
        public static string PersonEducationWorkExperiencesPresent {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesPresent", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>To</summary>
        public static string PersonEducationWorkExperiencesTo {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesTo", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select From Period </summary>
        public static string PersonEducationWorkExperiencesTimeFromRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesTimeFromRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select To Time Period </summary>
        public static string PersonEducationWorkExperiencesTimeToRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesTimeToRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Reference Name</summary>
        public static string PersonEducationWorkExperiencesReferenceName {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesReferenceName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Reference Email</summary>
        public static string PersonEducationWorkExperiencesReferenceEmail {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesReferenceEmail", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Reference Phone</summary>
        public static string PersonEducationWorkExperiencesReferencePhone {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesReferencePhone", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Description </summary>
        public static string PersonEducationWorkExperiencesDescription {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesDescription", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Cannot have two Permanent Job same time </summary>
        public static string PersonEducationWorkExperiencesTwoJobCheck {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationWorkExperiencesTwoJobCheck", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Achievement</summary>
        public static string PersonEducationAchievementPrimaryTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationAchievementPrimaryTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Achievement </summary>
        public static string PersonEducationAchievementPrimaryTitleRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationAchievementPrimaryTitleRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Achievement Type </summary>
        public static string PersonEducationAchievementType {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationAchievementType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Achievement Type</summary>
        public static string PersonEducationAchievementTypeRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationAchievementTypeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select  Achievement Type</summary>
        public static string PersonEducationAchievementTypeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationAchievementTypeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Announced Date</summary>
        public static string PersonEducationAchievementAnnouncedDate {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationAchievementAnnouncedDate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Announced Date </summary>
        public static string PersonEducationAchievementAnnouncedDateRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationAchievementAnnouncedDateRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Description </summary>
        public static string PersonEducationAchievementDescription {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationAchievementDescription", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Cannot add same Achievement and same date </summary>
        public static string PersonEducationAchievementDuplication {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationAchievementDuplication", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Title </summary>
        public static string PersonEducationAchievementSecondaryTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationAchievementSecondaryTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Course Outline</summary>
        public static string PersonEducationTrainingCourseOutlineRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingCourseOutlineRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Cannot add same title Training</summary>
        public static string PersonEducationTrainingTitleDuplication {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingTitleDuplication", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>City </summary>
        public static string AddressCity {
               get {
                   return (string) resourceProvider.GetResource("AddressCity", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select City </summary>
        public static string AddressCityOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("AddressCityOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select State/Region</summary>
        public static string AddressStateRegionOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("AddressStateRegionOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select State Region </summary>
        public static string AddressStateRegionRequired {
               get {
                   return (string) resourceProvider.GetResource("AddressStateRegionRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>State/Region </summary>
        public static string AddressStateRegion {
               get {
                   return (string) resourceProvider.GetResource("AddressStateRegion", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Country </summary>
        public static string AddressCountryOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("AddressCountryOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Country </summary>
        public static string AddressCountryRequired {
               get {
                   return (string) resourceProvider.GetResource("AddressCountryRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Country</summary>
        public static string AddressCountry {
               get {
                   return (string) resourceProvider.GetResource("AddressCountry", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Zip Code</summary>
        public static string AddressZipCode {
               get {
                   return (string) resourceProvider.GetResource("AddressZipCode", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Address 1</summary>
        public static string AddressAddressOneRequired {
               get {
                   return (string) resourceProvider.GetResource("AddressAddressOneRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
        /// <summary>Please Enter Address 1</summary>
        public static string AddressAddressDublication
        {
            get
            {
                return (string)resourceProvider.GetResource("AddressAddressDublication", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Please Enter Education Dublication1</summary>
        public static string EducationEducationDublication
        {
            get
            {
                return (string)resourceProvider.GetResource("EducationEducationDublication", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Address 2</summary>

        public static string AddressAddressTwo {
               get {
                   return (string) resourceProvider.GetResource("AddressAddressTwo", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Address1</summary>
        public static string AddressAddressOne {
               get {
                   return (string) resourceProvider.GetResource("AddressAddressOne", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Address </summary>
        public static string AddPrimaryAddressButtonText {
               get {
                   return (string) resourceProvider.GetResource("AddPrimaryAddressButtonText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Type</summary>
        public static string PersonPhoneType {
               get {
                   return (string) resourceProvider.GetResource("PersonPhoneType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Phone Type</summary>
        public static string PersonPhoneTypeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PersonPhoneTypeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Phone Type</summary>
        public static string PersonPhoneTypeRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonPhoneTypeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
        

        /// <summary>Country Code</summary>
        public static string RoleName
        {
            get
            {
                return (string)resourceProvider.GetResource("RoleName", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Country Code</summary>
        public static string PersonPhoneCountryCode {
               get {
                   return (string) resourceProvider.GetResource("PersonPhoneCountryCode", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Country Code</summary>
        public static string PersonPhoneCountryCodeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PersonPhoneCountryCodeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Country Code</summary>
        public static string PersonPhoneCountryCodeRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonPhoneCountryCodeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Number</summary>
        public static string PersonPhoneNumber {
               get {
                   return (string) resourceProvider.GetResource("PersonPhoneNumber", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Number</summary>
        public static string PersonPhoneNumberRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonPhoneNumberRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Extension </summary>
        public static string PersonPhoneExtension {
               get {
                   return (string) resourceProvider.GetResource("PersonPhoneExtension", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary </summary>
        public static string GridIsPrimary {
               get {
                   return (string) resourceProvider.GetResource("GridIsPrimary", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Email</summary>
        public static string PersonContactEmail {
               get {
                   return (string) resourceProvider.GetResource("PersonContactEmail", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Email </summary>
        public static string PersonContactEmailRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonContactEmailRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Email Address is not valid</summary>
        public static string EmailInValid {
               get {
                   return (string) resourceProvider.GetResource("EmailInValid", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Your entered Email Address already Exist</summary>
        public static string PersonContactEmailDuplicationCheck {
               get {
                   return (string) resourceProvider.GetResource("PersonContactEmailDuplicationCheck", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Cannot add more the {0} Email Address</summary>
        public static string PersonContactEmailLimit {
               get {
                   return (string) resourceProvider.GetResource("PersonContactEmailLimit", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Link Type </summary>
        public static string PersonContactLinkType {
               get {
                   return (string) resourceProvider.GetResource("PersonContactLinkType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Link Type </summary>
        public static string PersonContactLinkTypeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PersonContactLinkTypeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Link Type </summary>
        public static string PersonContactLinkTypeRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonContactLinkTypeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Link </summary>
        public static string PersonContactLink {
               get {
                   return (string) resourceProvider.GetResource("PersonContactLink", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Link Type</summary>
        public static string PersonContactLinkRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonContactLinkRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Cannot Add Same Link again </summary>
        public static string PersonContactLinkDuplicationCheck {
               get {
                   return (string) resourceProvider.GetResource("PersonContactLinkDuplicationCheck", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Link Maximum Limit Reached </summary>
        public static string PersonContactLinkMaxLimit {
               get {
                   return (string) resourceProvider.GetResource("PersonContactLinkMaxLimit", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>From Date</summary>
        public static string PersonContactAvailabilityFromDate {
               get {
                   return (string) resourceProvider.GetResource("PersonContactAvailabilityFromDate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select  From Date  </summary>
        public static string PersonContactAvailabilityFromDateRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonContactAvailabilityFromDateRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select To Date</summary>
        public static string PersonContactAvailabilityToDateRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonContactAvailabilityToDateRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>To Date </summary>
        public static string PersonContactAvailabilityToDate {
               get {
                   return (string) resourceProvider.GetResource("PersonContactAvailabilityToDate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person is already engaged for these dates </summary>
        public static string PersonContactAvailabilityDuplicationCheck {
               get {
                   return (string) resourceProvider.GetResource("PersonContactAvailabilityDuplicationCheck", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Skill</summary>
        public static string PersonSkill {
               get {
                   return (string) resourceProvider.GetResource("PersonSkill", CultureInfo.CurrentUICulture.Name);
               }
            }
        public static string VenueOcupaidByOther
        {
            get
            {
                return (string)resourceProvider.GetResource("VenueOcupaidByOther", CultureInfo.CurrentUICulture.Name);
            }
        }
        //public static string Coursescheck
        //{
        //    get
        //    {
        //        return (string)resourceProvider.GetResource("Coursescheck", CultureInfo.CurrentUICulture.Name);
        //    }
        //}

        //public static string Courses
        //{
        //    get
        //    {
        //        return (string)resourceProvider.GetResource("Courses", CultureInfo.CurrentUICulture.Name);
        //    }
        //}

        /// <summary>Please Enter Skill </summary>
        public static string PersonSkillRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonSkillRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Field of Interest</summary>
        public static string PersonFieldofInterestRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonFieldofInterestRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary> Field of Interest </summary>
        public static string PersonFieldofInterest {
               get {
                   return (string) resourceProvider.GetResource("PersonFieldofInterest", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Skill already Exist </summary>
        public static string PersonSkillDuplicationCheck {
               get {
                   return (string) resourceProvider.GetResource("PersonSkillDuplicationCheck", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Field of Interest already exist </summary>
        public static string PersonFieldofInterestDuplicationCheck {
               get {
                   return (string) resourceProvider.GetResource("PersonFieldofInterestDuplicationCheck", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Skills & Areas of Focus</summary>
        public static string PersonSkillAreasofFocusTabTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonSkillAreasofFocusTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Field of Interest </summary>
        public static string PersonFieldofInterestTabTitle {
               get {
                   return (string) resourceProvider.GetResource("PersonFieldofInterestTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Name</summary>
        public static string PersonLevelName {
               get {
                   return (string) resourceProvider.GetResource("PersonLevelName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Name </summary>
        public static string PersonLevelNameRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonLevelNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Description </summary>
        public static string PersonLevelDescriptionRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonLevelDescriptionRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Description</summary>
        public static string PersonLevelDescription {
               get {
                   return (string) resourceProvider.GetResource("PersonLevelDescription", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Address Type </summary>
        public static string AddressTypeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("AddressTypeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Address Type</summary>
        public static string AddressTypeRequired {
               get {
                   return (string) resourceProvider.GetResource("AddressTypeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Address Type </summary>
        public static string AddressType {
               get {
                   return (string) resourceProvider.GetResource("AddressType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Nickname</summary>
        public static string PersonNickName {
               get {
                   return (string) resourceProvider.GetResource("PersonNickName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Alias</summary>
        public static string PersonAlias {
               get {
                   return (string) resourceProvider.GetResource("PersonAlias", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Added by</summary>
        public static string GridAddedBy {
               get {
                   return (string) resourceProvider.GetResource("GridAddedBy", CultureInfo.CurrentUICulture.Name);
               }
            }
        /// <summary>Added by</summary>
        public static string Language
        {
            get
            {
                return (string)resourceProvider.GetResource("Language", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Please Enter Email or Phone Number</summary>
        public static string PersonEmailorPhoneRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonEmailorPhoneRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Country Code also</summary>
        public static string PersonPhoneNumberProvideCountryocde {
               get {
                   return (string) resourceProvider.GetResource("PersonPhoneNumberProvideCountryocde", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Phone Number is not valid</summary>
        public static string PersonPhoneNumberNotValid {
               get {
                   return (string) resourceProvider.GetResource("PersonPhoneNumberNotValid", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Phone Extension is not Valid </summary>
        public static string PhoneExtensionnotValid {
               get {
                   return (string) resourceProvider.GetResource("PhoneExtensionnotValid", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Others</summary>
        public static string OthersTabTitle {
               get {
                   return (string) resourceProvider.GetResource("OthersTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Phone already exist </summary>
        public static string PersonPhoneDuplication {
               get {
                   return (string) resourceProvider.GetResource("PersonPhoneDuplication", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Flags</summary>
        public static string FlagsPageTitle {
               get {
                   return (string) resourceProvider.GetResource("FlagsPageTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Flags</summary>
        public static string Flags {
               get {
                   return (string) resourceProvider.GetResource("Flags", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Flag Color</summary>
        public static string FlagColor {
               get {
                   return (string) resourceProvider.GetResource("FlagColor", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Flag Color</summary>
        public static string FlagColorRequired {
               get {
                   return (string) resourceProvider.GetResource("FlagColorRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Flag Name</summary>
        public static string FlagRequired {
               get {
                   return (string) resourceProvider.GetResource("FlagRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Cannot Enter Duplicate flags</summary>
        public static string FlagDuplicationCheck {
               get {
                   return (string) resourceProvider.GetResource("FlagDuplicationCheck", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add Flags</summary>
        public static string AddNewFlags {
               get {
                   return (string) resourceProvider.GetResource("AddNewFlags", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Are you sure you want to delete this record?</summary>
        public static string Areyousureyouwanttodeletethisrecord {
               get {
                   return (string) resourceProvider.GetResource("Areyousureyouwanttodeletethisrecord", CultureInfo.CurrentUICulture.Name);
               }
        }  /// <summary>Are you sure you want to delete this record?</summary>
        public static string SomeFieldsAreEmpty
        {
            get
            {
                return (string)resourceProvider.GetResource("SomeFieldsAreEmpty", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Are you sure you want to delete this record?</summary>
        public static string SomeFieldsAreEmptyOrNewPasswordMustBeGreater
        {
            get
            {
                return (string)resourceProvider.GetResource("SomeFieldsAreEmptyOrNewPasswordMustBeGreater", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Are you sure you want to delete this record?</summary>
        public static string NewPasswordDoesnotMatch
        {
            get
            {
                return (string)resourceProvider.GetResource("NewPasswordDoesnotMatch", CultureInfo.CurrentUICulture.Name);
            }
        } /// <summary>Are you sure you want to delete this record?</summary>
        public static string NewPasswordDoesnotMatchExplain
        {
            get
            {
                return (string)resourceProvider.GetResource("NewPasswordDoesnotMatchExplain", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Are you sure you want to delete this record?</summary>
        public static string AttandanceMarked
        {
            get
            {
                return (string)resourceProvider.GetResource("AttandanceMarked", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string Oops
        {
            get
            {
                return (string)resourceProvider.GetResource("Oopss", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string PersonAssignedToDiffentClasses
        {
            get
            {
                return (string)resourceProvider.GetResource("PersonAssignedToDiffentClasses", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string SessionAttandanceMarked
        {
            get
            {
                return (string)resourceProvider.GetResource("SessionAttandanceMarked", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Yes</summary>
        public static string confirmYes {
               get {
                   return (string) resourceProvider.GetResource("confirmYes", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Yes, Delete</summary>
        public static string confirmDelete {
               get {
                   return (string) resourceProvider.GetResource("confirmDelete", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>No, Cancel</summary>
        public static string confirmNo {
               get {
                   return (string) resourceProvider.GetResource("confirmNo", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Records</summary>
        public static string confirmRecords {
               get {
                   return (string) resourceProvider.GetResource("confirmRecords", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary> Person added successfully.</summary>
        public static string PersonRecordAddedSuccessfully {
               get {
                   return (string) resourceProvider.GetResource("PersonRecordAddedSuccessfully", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Organization</summary>
        public static string OrganizationTitle {
               get {
                   return (string) resourceProvider.GetResource("OrganizationTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Name</summary>
        public static string OrganizationPrimaryName {
               get {
                   return (string) resourceProvider.GetResource("OrganizationPrimaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Secondary Name</summary>
        public static string OrganizationSecondaryName {
               get {
                   return (string) resourceProvider.GetResource("OrganizationSecondaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>FullName</summary>
        public static string OrganizationFullName {
               get {
                   return (string) resourceProvider.GetResource("OrganizationFullName", CultureInfo.CurrentUICulture.Name);
               }
            }

        /// <summary>FullName</summary>
        public static string OrganizationNameDublicaton
        {
            get
            {
                return (string)resourceProvider.GetResource("OrganizationNameDublicaton", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Short Name</summary>
        public static string OrganizationShortName {
               get {
                   return (string) resourceProvider.GetResource("OrganizationShortName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Logo</summary>
        public static string OrganizationLogo {
               get {
                   return (string) resourceProvider.GetResource("OrganizationLogo", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Type</summary>
        public static string OrganizationType {
               get {
                   return (string) resourceProvider.GetResource("OrganizationType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Organization Type</summary>
        public static string OrganizationTypeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("OrganizationTypeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Handled By </summary>
        public static string OrganizationHandledBy {
               get {
                   return (string) resourceProvider.GetResource("OrganizationHandledBy", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Point Of Contact</summary>
        public static string OrganizationPointOfContact {
               get {
                   return (string) resourceProvider.GetResource("OrganizationPointOfContact", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Country </summary>
        public static string OrganizationCountry {
               get {
                   return (string) resourceProvider.GetResource("OrganizationCountry", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Linked Organization</summary>
        public static string OrganizationLinked {
               get {
                   return (string) resourceProvider.GetResource("OrganizationLinked", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Notes</summary>
        public static string OrganizationNotes {
               get {
                   return (string) resourceProvider.GetResource("OrganizationNotes", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Attachments</summary>
        public static string OrganizationAttachments {
               get {
                   return (string) resourceProvider.GetResource("OrganizationAttachments", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Online presence</summary>
        public static string OrganizationOnlinepresense {
               get {
                   return (string) resourceProvider.GetResource("OrganizationOnlinepresense", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Short Name or Primary Name</summary>
        public static string OrganizationEnterFullNameOrShortName {
               get {
                   return (string) resourceProvider.GetResource("OrganizationEnterFullNameOrShortName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Country</summary>
        public static string OrganizationCountryOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("OrganizationCountryOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Link to</summary>
        public static string PersonRelationTo {
               get {
                   return (string) resourceProvider.GetResource("PersonRelationTo", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Notes</summary>
        public static string NotesTabTitle {
               get {
                   return (string) resourceProvider.GetResource("NotesTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Attachment</summary>
        public static string AttachmentTabTitle {
               get {
                   return (string) resourceProvider.GetResource("AttachmentTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Linked Person </summary>
        public static string RelationLinksPerson {
               get {
                   return (string) resourceProvider.GetResource("RelationLinksPerson", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Point of Contact </summary>
        public static string PointofContactTabTitle {
               get {
                   return (string) resourceProvider.GetResource("PointofContactTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Handled By</summary>
        public static string HandledByOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("HandledByOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Point of Contact </summary>
        public static string PointofContactPerson {
               get {
                   return (string) resourceProvider.GetResource("PointofContactPerson", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Purpose</summary>
        public static string PointofContactPurpose {
               get {
                   return (string) resourceProvider.GetResource("PointofContactPurpose", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Purpose</summary>
        public static string PointofContactPurposeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PointofContactPurposeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Person</summary>
        public static string PointofContactPersonOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PointofContactPersonOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Select Person for Point of contact </summary>
        public static string PointofContactPersonRequired {
               get {
                   return (string) resourceProvider.GetResource("PointofContactPersonRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person already in Point of contacts</summary>
        public static string PointofContactDuplicationMessage {
               get {
                   return (string) resourceProvider.GetResource("PointofContactDuplicationMessage", CultureInfo.CurrentUICulture.Name);
               }
            }
        /// <summary>Person already in Point of contacts</summary>
        public static string CurrentUserPointOfContactAssignIssue
        {
            get
            {
                return (string)resourceProvider.GetResource("CurrentUserPointOfContactAssignIssue", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Person already in Point of contacts</summary>
        public static string PointOfContactAssignIssue
        {
            get
            {
                return (string)resourceProvider.GetResource("PointOfContactAssignIssue", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Cannot Add Same Link again</summary>
        public static string OrganizationContactLinkDuplicationCheck {
               get {
                   return (string) resourceProvider.GetResource("OrganizationContactLinkDuplicationCheck", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Link Maximum Limit Reached</summary>
        public static string OrganizationContactLinkMaxLimit {
               get {
                   return (string) resourceProvider.GetResource("OrganizationContactLinkMaxLimit", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Relation type</summary>
        public static string PersonRelationType {
               get {
                   return (string) resourceProvider.GetResource("PersonRelationType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Person Relation</summary>
        public static string PersonRelationTypeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PersonRelationTypeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Relation</summary>
        public static string PersonRelationTabTitile {
               get {
                   return (string) resourceProvider.GetResource("PersonRelationTabTitile", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Person Relation To</summary>
        public static string PersonRelationToOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PersonRelationToOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }

        public static string CRMUserOptionalLabel
        {
            get
            {
                return (string)resourceProvider.GetResource("CRMUserOptionalLabel", CultureInfo.CurrentUICulture.Name);
            }
        }
        
        /// <summary>Please Select Relation To Person</summary>
        public static string PersonRelationToRequired {
               get {
                   return (string) resourceProvider.GetResource("PersonRelationToRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Relation Exist with this person already </summary>
        public static string PersonRelationDuplicationMessage {
               get {
                   return (string) resourceProvider.GetResource("PersonRelationDuplicationMessage", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Relation To</summary>
        public static string PersonRelationToField {
               get {
                   return (string) resourceProvider.GetResource("PersonRelationToField", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Other</summary>
        public static string DropDownOtherValue {
               get {
                   return (string) resourceProvider.GetResource("DropDownOtherValue", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Link</summary>
        public static string PersonWorkExperienceRelationToOrganization {
               get {
                   return (string) resourceProvider.GetResource("PersonWorkExperienceRelationToOrganization", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Relation to company</summary>
        public static string PersonWorkExperinceRelationToOrganizationOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("PersonWorkExperinceRelationToOrganizationOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Notes</summary>
        public static string TMSNotesText {
               get {
                   return (string) resourceProvider.GetResource("TMSNotesText", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Notes</summary>
        public static string TMSNotesTextRequired {
               get {
                   return (string) resourceProvider.GetResource("TMSNotesTextRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Notes History</summary>
        public static string NotesViewAllHistory {
               get {
                   return (string) resourceProvider.GetResource("NotesViewAllHistory", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>File</summary>
        public static string TMSAttachmentFile {
               get {
                   return (string) resourceProvider.GetResource("TMSAttachmentFile", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>FileName</summary>
        public static string TMSAttachmentFileName {
               get {
                   return (string) resourceProvider.GetResource("TMSAttachmentFileName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select File</summary>
        public static string TMSAttachmentFileRequired {
               get {
                   return (string) resourceProvider.GetResource("TMSAttachmentFileRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>FileType</summary>
        public static string TMSAttachmentFileType {
               get {
                   return (string) resourceProvider.GetResource("TMSAttachmentFileType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Valid Till</summary>
        public static string TMSAttachmentValidTill {
               get {
                   return (string) resourceProvider.GetResource("TMSAttachmentValidTill", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Description </summary>
        public static string TMSAttachmentDescription {
               get {
                   return (string) resourceProvider.GetResource("TMSAttachmentDescription", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Civil ID</summary>
        public static string OfficialIdentificationType_CivilID {
               get {
                   return (string) resourceProvider.GetResource("OfficialIdentificationType_CivilID", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Employee ID</summary>
        public static string OfficialIdentificationType_EmployeeID {
               get {
                   return (string) resourceProvider.GetResource("OfficialIdentificationType_EmployeeID", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>GUST ID</summary>
        public static string OfficialIdentificationType_GUSTID {
               get {
                   return (string) resourceProvider.GetResource("OfficialIdentificationType_GUSTID", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Security ID</summary>
        public static string OfficialIdentificationType_SecurityID {
               get {
                   return (string) resourceProvider.GetResource("OfficialIdentificationType_SecurityID", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Corporate</summary>
        public static string ClientType_External {
               get {
                   return (string) resourceProvider.GetResource("ClientType_External", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Individual</summary>
        public static string ClientType_Internal {
               get {
                   return (string) resourceProvider.GetResource("ClientType_Internal", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>CGPA</summary>
        public static string PersonEducationResultType_CGPA {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationResultType_CGPA", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Percentage</summary>
        public static string PersonEducationResultType_Percentage {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationResultType_Percentage", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Days</summary>
        public static string Duration_Day {
               get {
                   return (string) resourceProvider.GetResource("Duration_Day", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Hours</summary>
        public static string Duration_Hours {
               get {
                   return (string) resourceProvider.GetResource("Duration_Hours", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Months</summary>
        public static string Duration_Months {
               get {
                   return (string) resourceProvider.GetResource("Duration_Months", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Weeks</summary>
        public static string Duration_Weeks {
               get {
                   return (string) resourceProvider.GetResource("Duration_Weeks", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Existing</summary>
        public static string PersonEducationTrainingType_Existing {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingType_Existing", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Consultant</summary>
        public static string PersonEducationPersonJobStatus_Consultant {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationPersonJobStatus_Consultant", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Suggested</summary>
        public static string PersonEducationTrainingType_Suggested {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationTrainingType_Suggested", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Contract</summary>
        public static string PersonEducationPersonJobStatus_Contract {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationPersonJobStatus_Contract", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Full Time</summary>
        public static string PersonEducationPersonJobStatus_FullTime {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationPersonJobStatus_FullTime", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Internee</summary>
        public static string PersonEducationPersonJobStatus_Internee {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationPersonJobStatus_Internee", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Part Time</summary>
        public static string PersonEducationPersonJobStatus_PartTime {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationPersonJobStatus_PartTime", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Academic</summary>
        public static string AchievementType_Academic {
               get {
                   return (string) resourceProvider.GetResource("AchievementType_Academic", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Professional</summary>
        public static string AchievementType_Professional {
               get {
                   return (string) resourceProvider.GetResource("AchievementType_Professional", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Billing</summary>
        public static string AddressType_Billing {
               get {
                   return (string) resourceProvider.GetResource("AddressType_Billing", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary</summary>
        public static string AddressType_Primary {
               get {
                   return (string) resourceProvider.GetResource("AddressType_Primary", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Secondary</summary>
        public static string AddressType_Secondary {
               get {
                   return (string) resourceProvider.GetResource("AddressType_Secondary", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Fax</summary>
        public static string PhoneNumberType_Fax {
               get {
                   return (string) resourceProvider.GetResource("PhoneNumberType_Fax", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Home</summary>
        public static string PhoneNumberType_Home {
               get {
                   return (string) resourceProvider.GetResource("PhoneNumberType_Home", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Mobile</summary>
        public static string PhoneNumberType_Mobile {
               get {
                   return (string) resourceProvider.GetResource("PhoneNumberType_Mobile", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Office</summary>
        public static string PhoneNumberType_Office {
               get {
                   return (string) resourceProvider.GetResource("PhoneNumberType_Office", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Other</summary>
        public static string PhoneNumberType_Other {
               get {
                   return (string) resourceProvider.GetResource("PhoneNumberType_Other", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Blog</summary>
        public static string LinkType_Blog {
               get {
                   return (string) resourceProvider.GetResource("LinkType_Blog", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Facebook</summary>
        public static string LinkType_FaceBook {
               get {
                   return (string) resourceProvider.GetResource("LinkType_FaceBook", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Google+</summary>
        public static string LinkType_GooglePlus {
               get {
                   return (string) resourceProvider.GetResource("LinkType_GooglePlus", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Portfolio</summary>
        public static string LinkType_Portfolio {
               get {
                   return (string) resourceProvider.GetResource("LinkType_Portfolio", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Twitter</summary>
        public static string LinkType_Twitter {
               get {
                   return (string) resourceProvider.GetResource("LinkType_Twitter", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Website</summary>
        public static string LinkType_Website {
               get {
                   return (string) resourceProvider.GetResource("LinkType_Website", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Field Of Interest</summary>
        public static string PersonSKillInterest_Field_Of_Interest {
               get {
                   return (string) resourceProvider.GetResource("PersonSKillInterest_Field_Of_Interest", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Skills</summary>
        public static string PersonSKillInterest_Person_Skills {
               get {
                   return (string) resourceProvider.GetResource("PersonSKillInterest_Person_Skills", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Colleague</summary>
        public static string PersonRelationType_Colleague {
               get {
                   return (string) resourceProvider.GetResource("PersonRelationType_Colleague", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Spouse</summary>
        public static string PersonRelationType_Spouse {
               get {
                   return (string) resourceProvider.GetResource("PersonRelationType_Spouse", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Child</summary>
        public static string PersonRelationType_Child {
               get {
                   return (string) resourceProvider.GetResource("PersonRelationType_Child", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Parent</summary>
        public static string PersonRelationType_Parent {
               get {
                   return (string) resourceProvider.GetResource("PersonRelationType_Parent", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Relative</summary>
        public static string PersonRelationType_Relative {
               get {
                   return (string) resourceProvider.GetResource("PersonRelationType_Relative", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Point of contact</summary>
        public static string PersonWorkExperienceRelationToOrganization_PointOfContact {
               get {
                   return (string) resourceProvider.GetResource("PersonWorkExperienceRelationToOrganization_PointOfContact", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Trainee</summary>
        public static string PersonWorkExperienceRelationToOrganization_Trainee {
               get {
                   return (string) resourceProvider.GetResource("PersonWorkExperienceRelationToOrganization_Trainee", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Employee</summary>
        public static string PersonWorkExperienceRelationToOrganization_Employee {
               get {
                   return (string) resourceProvider.GetResource("PersonWorkExperienceRelationToOrganization_Employee", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Word</summary>
        public static string AttachmentsFileType_Word_doc_docx {
               get {
                   return (string) resourceProvider.GetResource("AttachmentsFileType_Word_doc_docx", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Profile Picture/Logo</summary>
        public static string AttachmentsFileType_ProfilePicture {
               get {
                   return (string) resourceProvider.GetResource("AttachmentsFileType_ProfilePicture", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Other</summary>
        public static string AttachmentsFileType_Other_Unknown {
               get {
                   return (string) resourceProvider.GetResource("AttachmentsFileType_Other_Unknown", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Zip</summary>
        public static string AttachmentsFileType_compressed_zip {
               get {
                   return (string) resourceProvider.GetResource("AttachmentsFileType_compressed_zip", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Video</summary>
        public static string AttachmentsFileType_Video_mp4 {
               get {
                   return (string) resourceProvider.GetResource("AttachmentsFileType_Video_mp4", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Audio</summary>
        public static string AttachmentsFileType_Audio_mp3 {
               get {
                   return (string) resourceProvider.GetResource("AttachmentsFileType_Audio_mp3", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Adobe files</summary>
        public static string AttachmentsFileType_ImageFile_psd {
               get {
                   return (string) resourceProvider.GetResource("AttachmentsFileType_ImageFile_psd", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Image</summary>
        public static string AttachmentsFileType_ImageFile_png_jpeg {
               get {
                   return (string) resourceProvider.GetResource("AttachmentsFileType_ImageFile_png_jpeg", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Text</summary>
        public static string AttachmentsFileType_TextFile_tct_rtf {
               get {
                   return (string) resourceProvider.GetResource("AttachmentsFileType_TextFile_tct_rtf", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>PDF</summary>
        public static string AttachmentsFileType_PortableDocumentFormat_pdf {
               get {
                   return (string) resourceProvider.GetResource("AttachmentsFileType_PortableDocumentFormat_pdf", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Power Point</summary>
        public static string AttachmentsFileType_PowerPoint_pptx {
               get {
                   return (string) resourceProvider.GetResource("AttachmentsFileType_PowerPoint_pptx", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Excel</summary>
        public static string AttachmentsFileType_Excel_xlss {
               get {
                   return (string) resourceProvider.GetResource("AttachmentsFileType_Excel_xlss", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Are you sure you want to delete these records?</summary>
        public static string Areyousureyouwanttodeletetheserecord {
               get {
                   return (string) resourceProvider.GetResource("Areyousureyouwanttodeletetheserecord", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Deleted!</summary>
        public static string confirmDeleted {
               get {
                   return (string) resourceProvider.GetResource("confirmDeleted", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Your records has been deleted!</summary>
        public static string confirmDeletedMessageMultiple {
               get {
                   return (string) resourceProvider.GetResource("confirmDeletedMessageMultiple", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Your record has been deleted!</summary>
        public static string confirmDeletedMessage {
               get {
                   return (string) resourceProvider.GetResource("confirmDeletedMessage", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>You will not be able to recover!</summary>
        public static string Youwillnotbeabletorecover {
               get {
                   return (string) resourceProvider.GetResource("Youwillnotbeabletorecover", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Ok</summary>
        public static string ButtonOk {
               get {
                   return (string) resourceProvider.GetResource("ButtonOk", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>The resource you are looking for has been removed, or is temporarily unavailable</summary>
        public static string ResourceNotFound {
               get {
                   return (string) resourceProvider.GetResource("ResourceNotFound", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Oops...</summary>
        public static string ResourceOops {
               get {
                   return (string) resourceProvider.GetResource("ResourceOops", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>User is Locked please contact system administrator</summary>
        public static string UserLockedOutMessage {
               get {
                   return (string) resourceProvider.GetResource("UserLockedOutMessage", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Username or password incorrect. Attempts remaining:</summary>
        public static string InvalidpasswordWithAttempts {
               get {
                   return (string) resourceProvider.GetResource("InvalidpasswordWithAttempts", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Updated Successfully!</summary>
        public static string RecordUpdatedSuccessfully {
               get {
                   return (string) resourceProvider.GetResource("RecordUpdatedSuccessfully", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Updated</summary>
        public static string confirmUpdated {
               get {
                   return (string) resourceProvider.GetResource("confirmUpdated", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Groups Primary Name</summary>
        public static string GroupsPrimaryName {
               get {
                   return (string) resourceProvider.GetResource("GroupsPrimaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Groups Secondary Name</summary>
        public static string GroupsSecondaryName {
               get {
                   return (string) resourceProvider.GetResource("GroupsSecondaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Groups Secondary Name</summary>
        public static string GroupsSecondaryNameRequired {
               get {
                   return (string) resourceProvider.GetResource("GroupsSecondaryNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Groups Primary Name</summary>
        public static string GroupsPrimaryNameRequired {
               get {
                   return (string) resourceProvider.GetResource("GroupsPrimaryNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Groups</summary>
        public static string GroupsTitle {
               get {
                   return (string) resourceProvider.GetResource("GroupsTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Allow Delete</summary>
        public static string GroupsIsDeleteAllowed {
               get {
                   return (string) resourceProvider.GetResource("GroupsIsDeleteAllowed", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary First Name</summary>
        public static string UserPrimaryFirstName {
               get {
                   return (string) resourceProvider.GetResource("UserPrimaryFirstName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Middle Name</summary>
        public static string UserPrimaryMiddleName {
               get {
                   return (string) resourceProvider.GetResource("UserPrimaryMiddleName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Last Name</summary>
        public static string UserPrimaryLastName {
               get {
                   return (string) resourceProvider.GetResource("UserPrimaryLastName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Display Name</summary>
        public static string UserPrimaryDisplayName {
               get {
                   return (string) resourceProvider.GetResource("UserPrimaryDisplayName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Primary Display Name</summary>
        public static string UserPrimaryDisplayNameRequired {
               get {
                   return (string) resourceProvider.GetResource("UserPrimaryDisplayNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Primary Last Name</summary>
        public static string UserPrimaryLastNameRequired {
               get {
                   return (string) resourceProvider.GetResource("UserPrimaryLastNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Primary First Name</summary>
        public static string UserPrimaryFirstNameRequired {
               get {
                   return (string) resourceProvider.GetResource("UserPrimaryFirstNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Nick Name</summary>
        public static string UserNickNameRequired {
               get {
                   return (string) resourceProvider.GetResource("UserNickNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Nick Name</summary>
        public static string UserNickName {
               get {
                   return (string) resourceProvider.GetResource("UserNickName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Email</summary>
        public static string UserEmail {
               get {
                   return (string) resourceProvider.GetResource("UserEmail", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Email</summary>
        public static string UserEmailRequired {
               get {
                   return (string) resourceProvider.GetResource("UserEmailRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>User Email Already Exist</summary>
        public static string UserEmailAlreadyExist {
               get {
                   return (string) resourceProvider.GetResource("UserEmailAlreadyExist", CultureInfo.CurrentUICulture.Name);
               }
            }
        /// <summary>User Email Already Exist</summary>
        public static string CourseLogisticRequirementID
        {
            get
            {
                return (string)resourceProvider.GetResource("CourseLogisticRequirementID", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Password</summary>
        public static string UserPassword {
               get {
                   return (string) resourceProvider.GetResource("UserPassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Confirm Password</summary>
        public static string UserConfirmPassword {
               get {
                   return (string) resourceProvider.GetResource("UserConfirmPassword", CultureInfo.CurrentUICulture.Name);
               }
            }
        /// <summary>Confirm New Password</summary>
        public static string UserConfirmNewPassword
        {
            get
            {
                return (string)resourceProvider.GetResource("UserConfirmNewPassword", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Confirm Password and Password do not match</summary>
        public static string UserConfirmPasswordNotMatch {
               get {
                   return (string) resourceProvider.GetResource("UserConfirmPasswordNotMatch", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Send Create Password Email</summary>
        public static string UserSendCreatePasswordEmail {
               get {
                   return (string) resourceProvider.GetResource("UserSendCreatePasswordEmail", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Role/Groups</summary>
        public static string UserSecuritgroups {
               get {
                   return (string) resourceProvider.GetResource("UserSecuritgroups", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select Date Of Birth</summary>
        public static string UserDateOfBirthRequired {
               get {
                   return (string) resourceProvider.GetResource("UserDateOfBirthRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please Enter Confirm Password</summary>
        public static string UserConfirmPasswordRequired {
               get {
                   return (string) resourceProvider.GetResource("UserConfirmPasswordRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Change Status</summary>
        public static string EmailTemplateTypeChangeStatus {
               get {
                   return (string) resourceProvider.GetResource("EmailTemplateTypeChangeStatus", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Coordinator Class Assignment</summary>
        public static string EmailTemplateTypeCoordinatorClassAssignment {
               get {
                   return (string) resourceProvider.GetResource("EmailTemplateTypeCoordinatorClassAssignment", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Forgot Password</summary>
        public static string EmailTemplateTypeForgotPassword {
               get {
                   return (string) resourceProvider.GetResource("EmailTemplateTypeForgotPassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Online Evaluation for [[CourseName]]</summary>
        public static string EmailTemplateTypeSendFeedbackLink {
               get {
                   return (string) resourceProvider.GetResource("EmailTemplateTypeSendFeedbackLink", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Trainer Class Assignment</summary>
        public static string EmailTemplateTypeTrainerClassAssignment {
               get {
                   return (string) resourceProvider.GetResource("EmailTemplateTypeTrainerClassAssignment", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Trainee Class Assignment</summary>
        public static string EmailTemplateTypeTraineeClassAssignment {
               get {
                   return (string) resourceProvider.GetResource("EmailTemplateTypeTraineeClassAssignment", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Trainer/Trainee Registration</summary>
        public static string EmailTemplateTypeTrainerTraineeRegistration {
               get {
                   return (string) resourceProvider.GetResource("EmailTemplateTypeTrainerTraineeRegistration", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>User Registration</summary>
        public static string EmailTemplateTypeUserRegistration {
               get {
                   return (string) resourceProvider.GetResource("EmailTemplateTypeUserRegistration", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>User Created successfully but failed to send email.</summary>
        public static string UserEmailNotSendButUserCreated {
               get {
                   return (string) resourceProvider.GetResource("UserEmailNotSendButUserCreated", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Password must be at least {0} characters</summary>
        public static string UserPasswordMinimumLength {
               get {
                   return (string) resourceProvider.GetResource("UserPasswordMinimumLength", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Change Password</summary>
        public static string UserChangePassword {
               get {
                   return (string) resourceProvider.GetResource("UserChangePassword", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Notes</summary>
        public static string PersonNotesPermissionName {
               get {
                   return (string) resourceProvider.GetResource("PersonNotesPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Attachment</summary>
        public static string PersonAttachmentPermissionName {
               get {
                   return (string) resourceProvider.GetResource("PersonAttachmentPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Organization Attachment</summary>
        public static string OrganizationAttachmentPermissionName {
               get {
                   return (string) resourceProvider.GetResource("OrganizationAttachmentPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Organization Notes</summary>
        public static string OrganizationNotesPermissionName {
               get {
                   return (string) resourceProvider.GetResource("OrganizationNotesPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Users</summary>
        public static string UsersTitle {
               get {
                   return (string) resourceProvider.GetResource("UsersTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Organization Addresses</summary>
        public static string OrganizationAddressesPermissionName {
               get {
                   return (string) resourceProvider.GetResource("OrganizationAddressesPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Online Presence</summary>
        public static string PersonOnlinePresencePermissionName {
               get {
                   return (string) resourceProvider.GetResource("PersonOnlinePresencePermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Organization Online Presence</summary>
        public static string OrganizationOnlinePresencePermissionName {
               get {
                   return (string) resourceProvider.GetResource("OrganizationOnlinePresencePermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Certification</summary>
        public static string PersonCertificationPermissionName {
               get {
                   return (string) resourceProvider.GetResource("PersonCertificationPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Education</summary>
        public static string PersonEducationPermissionName {
               get {
                   return (string) resourceProvider.GetResource("PersonEducationPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Phone</summary>
        public static string PersonPhonePermissionName {
               get {
                   return (string) resourceProvider.GetResource("PersonPhonePermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Email</summary>
        public static string PersonEmailPermissionName {
               get {
                   return (string) resourceProvider.GetResource("PersonEmailPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Training History</summary>
        public static string PersonTrainingHistoryPermissionName {
               get {
                   return (string) resourceProvider.GetResource("PersonTrainingHistoryPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Skills & Areas of Focus</summary>
        public static string PersonSkillsAreasofFocusPermissionName {
               get {
                   return (string) resourceProvider.GetResource("PersonSkillsAreasofFocusPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Availability</summary>
        public static string PersonAvailabilityPermissionName {
               get {
                   return (string) resourceProvider.GetResource("PersonAvailabilityPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Achievement</summary>
        public static string PersonAchievementPermissionName {
               get {
                   return (string) resourceProvider.GetResource("PersonAchievementPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Relation</summary>
        public static string PersonRelationPermissionName {
               get {
                   return (string) resourceProvider.GetResource("PersonRelationPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person</summary>
        public static string PersonPermissionName {
               get {
                   return (string) resourceProvider.GetResource("PersonPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Organization</summary>
        public static string OrganizationPermissionName {
               get {
                   return (string) resourceProvider.GetResource("OrganizationPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Flags</summary>
        public static string FlagsPermissionName {
               get {
                   return (string) resourceProvider.GetResource("FlagsPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Work Experience</summary>
        public static string WorkExperiencePermissionName {
               get {
                   return (string) resourceProvider.GetResource("WorkExperiencePermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Office 365</summary>
        public static string Office365Title {
               get {
                   return (string) resourceProvider.GetResource("Office365Title", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Submit</summary>
        public static string Submit {
               get {
                   return (string) resourceProvider.GetResource("Submit", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Course Name</summary>
        public static string PrimaryCourseName {
               get {
                   return (string) resourceProvider.GetResource("PrimaryCourseName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Secondary Course Name</summary>
        public static string SecondaryCourseName {
               get {
                   return (string) resourceProvider.GetResource("SecondaryCourseName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course Category</summary>
        public static string CourseCategory {
               get {
                   return (string) resourceProvider.GetResource("CourseCategory", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Course Category</summary>
        public static string CourseCategoryOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("CourseCategoryOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Primary Course Name</summary>
        public static string PrimaryCourseNameRequired {
               get {
                   return (string) resourceProvider.GetResource("PrimaryCourseNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course Code</summary>
        public static string CourseCode {
               get {
                   return (string) resourceProvider.GetResource("CourseCode", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Course Code</summary>
        public static string CourseCodeRequired {
               get {
                   return (string) resourceProvider.GetResource("CourseCodeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course Duration</summary>
        public static string CourseDuration {
               get {
                   return (string) resourceProvider.GetResource("CourseDuration", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course Duration</summary>
        public static string CourseDurationType {
               get {
                   return (string) resourceProvider.GetResource("CourseDurationType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Vendor</summary>
        public static string CourseVendorRequired {
               get {
                   return (string) resourceProvider.GetResource("CourseVendorRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Vendor</summary>
        public static string CourseVendor {
               get {
                   return (string) resourceProvider.GetResource("CourseVendor", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Minimum Attendance (%)</summary>
        public static string CourseMinimumAttendanceRequirement {
               get {
                   return (string) resourceProvider.GetResource("CourseMinimumAttendanceRequirement", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Minimum Attendance (%)</summary>
        public static string CourseMinimumAttendanceRequirementRequired {
               get {
                   return (string) resourceProvider.GetResource("CourseMinimumAttendanceRequirementRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course Fee</summary>
        public static string CourseFee {
               get {
                   return (string) resourceProvider.GetResource("CourseFee", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Currency </summary>
        public static string CurrencyOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("CurrencyOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Sales Commision (%)</summary>
        public static string CourseSalesCommission {
               get {
                   return (string) resourceProvider.GetResource("CourseSalesCommission", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Pre-Requisites</summary>
        public static string PreRequisitesTitle {
               get {
                   return (string) resourceProvider.GetResource("PreRequisitesTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Notes</summary>
        public static string CourseNotes {
               get {
                   return (string) resourceProvider.GetResource("CourseNotes", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select Course Category</summary>
        public static string CourseCategoryRequired {
               get {
                   return (string) resourceProvider.GetResource("CourseCategoryRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Course Vendor</summary>
        public static string CourseVendorOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("CourseVendorOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Fee Currency</summary>
        public static string CourseFeeCurrencyOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("CourseFeeCurrencyOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Search</summary>
        public static string Search {
               get {
                   return (string) resourceProvider.GetResource("Search", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Reset</summary>
        public static string Reset {
               get {
                   return (string) resourceProvider.GetResource("Reset", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course</summary>
        public static string CoursePermissionName {
               get {
                   return (string) resourceProvider.GetResource("CoursePermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Class</summary>
        public static string CanAddEditAttendance
        {
               get {
                   return (string) resourceProvider.GetResource("CanAddEditAttendance", CultureInfo.CurrentUICulture.Name);
               }
            }

        //public static string CanAddEditSession
        //{
        //    get
        //    {
        //        return (string)resourceProvider.GetResource("CanAddEditSession", CultureInfo.CurrentUICulture.Name);
        //    }
        //}

        public static string CanViewSchedule
        {
            get
            {
                return (string)resourceProvider.GetResource("CanViewSchedule", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ClassPermissionName
        {
            get
            {
                return (string)resourceProvider.GetResource("ClassPermissionName", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string ClassTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("ClassTitle", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string CourseTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("CourseTitle", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Class Title</summary>
        public static string ClassPrimaryTitle {
               get {
                   return (string) resourceProvider.GetResource("ClassPrimaryTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Class Secondary Title</summary>
        public static string ClassSecondaryTitle {
               get {
                   return (string) resourceProvider.GetResource("ClassSecondaryTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course</summary>
        public static string ClassCourse {
               get {
                   return (string) resourceProvider.GetResource("ClassCourse", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Class Name</summary>
        public static string ClassName {
               get {
                   return (string) resourceProvider.GetResource("ClassName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Languages</summary>
        public static string ClassLanguage {
               get {
                   return (string) resourceProvider.GetResource("ClassLanguage", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Class Type</summary>
        public static string ClassType {
               get {
                   return (string) resourceProvider.GetResource("ClassType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Class Duration</summary>
        public static string ClassDuration {
               get {
                   return (string) resourceProvider.GetResource("ClassDuration", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Start Date</summary>
        public static string ClassStartDate {
               get {
                   return (string) resourceProvider.GetResource("ClassStartDate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>End Date</summary>
        public static string ClassEndDate {
               get {
                   return (string) resourceProvider.GetResource("ClassEndDate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Start Time</summary>
        public static string SessionStartTime {
               get {
                   return (string) resourceProvider.GetResource("SessionStartTime", CultureInfo.CurrentUICulture.Name);
               }
            }
        /// <summary>Start Time</summary>
        public static string SessionTimeConflict
        {
            get
            {
                return (string)resourceProvider.GetResource("SessionTimeConflict", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>End Time</summary>
        public static string SessionEndTime {
               get {
                   return (string) resourceProvider.GetResource("SessionEndTime", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Evaluation Link</summary>
        public static string ClassEvaluationLink {
               get {
                   return (string) resourceProvider.GetResource("ClassEvaluationLink", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Follow Up</summary>
        public static string ClassFollowUp {
               get {
                   return (string) resourceProvider.GetResource("ClassFollowUp", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Follow Up Completed</summary>
        public static string ClassFollowUpCompleted {
               get {
                   return (string) resourceProvider.GetResource("ClassFollowUpCompleted", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Minimum Attendance (%)</summary>
        public static string ClassMinimumAttendanceRequirement {
               get {
                   return (string) resourceProvider.GetResource("ClassMinimumAttendanceRequirement", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Maximum Session Per Day</summary>
        public static string ClassMaximumSessionPerDay {
               get {
                   return (string) resourceProvider.GetResource("ClassMaximumSessionPerDay", CultureInfo.CurrentUICulture.Name);
               }
            }

        /// <summary>Maximum Session Per Day</summary>
        public static string VenueAvailabelTimeRange
        {
            get
            {
                return (string)resourceProvider.GetResource("VenueAvailabelTimeRange", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Maximum Session Per Day</summary>
        public static string VenueIsInUse
        {
            get
            {
                return (string)resourceProvider.GetResource("VenueIsInUse", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Maximum Session Per Day</summary>
        public static string CourseIsAssigned 
        {
            get
            {
                return (string)resourceProvider.GetResource("CourseIsAssigned", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Maximum Session Per Day</summary>
        public static string UserOldPassword
        {
            get
            {
                return (string)resourceProvider.GetResource("UserOldPassword", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Maximum Session Per Day</summary>
        public static string VenueAvailabelTimeRangeIssue
        {
            get
            {
                return (string)resourceProvider.GetResource("VenueAvailabelTimeRangeIssue", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Minimum Trainee</summary>
        public static string ClassMinimumTrainee {
               get {
                   return (string) resourceProvider.GetResource("ClassMinimumTrainee", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Send Email</summary>
        public static string ClassSendEmail {
               get {
                   return (string) resourceProvider.GetResource("ClassSendEmail", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Class Fee</summary>
        public static string ClassFee {
               get {
                   return (string) resourceProvider.GetResource("ClassFee", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Currency</summary>
        public static string CourseFeeCurrency {
               get {
                   return (string) resourceProvider.GetResource("CourseFeeCurrency", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Discount (%)</summary>
        public static string ClassDiscount {
               get {
                   return (string) resourceProvider.GetResource("ClassDiscount", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Default Discount</summary>
        public static string ClassDefaultDiscount {
               get {
                   return (string) resourceProvider.GetResource("ClassDefaultDiscount", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Translation Required</summary>
        public static string ClassTranslationRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassTranslationRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Title</summary>
        public static string ClassPrimaryTitleRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassPrimaryTitleRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter class name</summary>
        public static string ClassNameRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Evalution link</summary>
        public static string ClassEvalutionlinkRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassEvalutionlinkRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Follow up</summary>
        public static string ClassFollowUpRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassFollowUpRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Maximum session per day</summary>
        public static string ClassMaximumSessionPerDayRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassMaximumSessionPerDayRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Discount</summary>
        public static string ClassDiscountRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassDiscountRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Start Date</summary>
        public static string ClassStartDateRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassStartDateRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter End Date</summary>
        public static string ClassEndDateRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassEndDateRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select Class duration type</summary>
        public static string ClassDurationTypeRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassDurationTypeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Minimum Attendance</summary>
        public static string ClassMinimumAttendanceRequirementRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassMinimumAttendanceRequirementRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Minimum trainee</summary>
        public static string ClassMinimumTraineeRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassMinimumTraineeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Fee</summary>
        public static string ClassFeeRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassFeeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select Course</summary>
        public static string ClassCourseRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassCourseRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select Language</summary>
        public static string ClassLanguageRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassLanguageRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Duration</summary>
        public static string ClassDurationRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassDurationRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select Class Type</summary>
        public static string ClassTypeRequired {
               get {
                   return (string) resourceProvider.GetResource("ClassTypeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select Fee Currency</summary>
        public static string CourseFeeCurrencyRequired {
               get {
                   return (string) resourceProvider.GetResource("CourseFeeCurrencyRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Course</summary>
        public static string ClassCourseOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("ClassCourseOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Language</summary>
        public static string ClassLanguageOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("ClassLanguageOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Translation Required Language</summary>
        public static string ClassTranslationRequiredOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("ClassTranslationRequiredOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter value Greater 0</summary>
        public static string GeneralGreaterThanZeroRange {
               get {
                   return (string) resourceProvider.GetResource("GeneralGreaterThanZeroRange", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter value from 0.01 to 100</summary>
        public static string GeneralGreaterThanZeroLessThanHundredRange {
               get {
                   return (string) resourceProvider.GetResource("GeneralGreaterThanZeroLessThanHundredRange", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>End Date should be greater than Start Date</summary>
        public static string EndDateShouldBeGreaterThanStartDate {
               get {
                   return (string) resourceProvider.GetResource("EndDateShouldBeGreaterThanStartDate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select Start Time</summary>
        public static string SessionStartTimeRequired {
               get {
                   return (string) resourceProvider.GetResource("SessionStartTimeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Start Time</summary>
        public static string SessionStartTimeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("SessionStartTimeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select End Time</summary>
        public static string SessionEndTimeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("SessionEndTimeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select End Time</summary>
        public static string SessionEndTimeRequired {
               get {
                   return (string) resourceProvider.GetResource("SessionEndTimeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Closed</summary>
        public static string ClassTypeOnsite {
               get {
                   return (string) resourceProvider.GetResource("ClassTypeOnsite", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Other</summary>
        public static string ClassTypeClosed {
               get {
                   return (string) resourceProvider.GetResource("ClassTypeClosed", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Private</summary>
        public static string ClassTypeVenue {
               get {
                   return (string) resourceProvider.GetResource("ClassTypeVenue", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Public</summary>
        public static string ClassTypePublic {
               get {
                   return (string) resourceProvider.GetResource("ClassTypePublic", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Class Type</summary>
        public static string ClassTypeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("ClassTypeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Dates</summary>
        public static string ClassDates {
               get {
                   return (string) resourceProvider.GetResource("ClassDates", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Class added successfully.</summary>
        public static string ClassRecordAddedSuccessfully {
               get {
                   return (string) resourceProvider.GetResource("ClassRecordAddedSuccessfully", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Last Modified</summary>
        public static string LastModified {
               get {
                   return (string) resourceProvider.GetResource("LastModified", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Name</summary>
        public static string VenuePrimaryName {
               get {
                   return (string) resourceProvider.GetResource("VenuePrimaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Secondary Name</summary>
        public static string VenueSecondaryName {
               get {
                   return (string) resourceProvider.GetResource("VenueSecondaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Primary Name</summary>
        public static string VenuePrimaryNameRequired {
               get {
                   return (string) resourceProvider.GetResource("VenuePrimaryNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }

        public static string VenueSecondaryNameRequired
        {
            get
            {
                return (string)resourceProvider.GetResource("VenueSecondaryNameRequired", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Please select Venue Status</summary>
        public static string VenueStatusRequired {
               get {
                   return (string) resourceProvider.GetResource("VenueStatusRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Venue Status</summary>
        public static string VenueStatusOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("VenueStatusOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Venue Status</summary>
        public static string VenueStatus {
               get {
                   return (string) resourceProvider.GetResource("VenueStatus", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Capacity</summary>
        public static string VenueCapacity {
               get {
                   return (string) resourceProvider.GetResource("VenueCapacity", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Capacity</summary>
        public static string VenueCapacityRequired {
               get {
                   return (string) resourceProvider.GetResource("VenueCapacityRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Rating</summary>
        public static string VenueRating {
               get {
                   return (string) resourceProvider.GetResource("VenueRating", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Venue Currency</summary>
        public static string VenueCurrency {
               get {
                   return (string) resourceProvider.GetResource("VenueCurrency", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select Currency</summary>
        public static string CurrencyRequired {
               get {
                   return (string) resourceProvider.GetResource("CurrencyRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Cost</summary>
        public static string VenuesCost {
               get {
                   return (string) resourceProvider.GetResource("VenuesCost", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Cost</summary>
        public static string VenueCostRequired {
               get {
                   return (string) resourceProvider.GetResource("VenueCostRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select Rate Type</summary>
        public static string VenueRateTypeRequired {
               get {
                   return (string) resourceProvider.GetResource("VenueRateTypeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Rate Type</summary>
        public static string VenueRateTypeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("VenueRateTypeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Rate Type</summary>
        public static string VenueRateType {
               get {
                   return (string) resourceProvider.GetResource("VenueRateType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Contact Person</summary>
        public static string VenueContactPerson {
               get {
                   return (string) resourceProvider.GetResource("VenueContactPerson", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Contact Person</summary>
        public static string VenueContactPersonRequired {
               get {
                   return (string) resourceProvider.GetResource("VenueContactPersonRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Contact Person phone number</summary>
        public static string VenueContactPersonPhoneRequired {
               get {
                   return (string) resourceProvider.GetResource("VenueContactPersonPhoneRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Contact Person Phone</summary>
        public static string VenueContactPersonPhone {
               get {
                   return (string) resourceProvider.GetResource("VenueContactPersonPhone", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Contact Person Email</summary>
        public static string VenueContactPersonEmail {
               get {
                   return (string) resourceProvider.GetResource("VenueContactPersonEmail", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Contact Person Email</summary>
        public static string VenueContactPersonEmailRequired {
               get {
                   return (string) resourceProvider.GetResource("VenueContactPersonEmailRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Available From</summary>
        public static string VenueAvailableFrom {
               get {
                   return (string) resourceProvider.GetResource("VenueAvailableFrom", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Available To</summary>
        public static string VenueAvailableTo {
               get {
                   return (string) resourceProvider.GetResource("VenueAvailableTo", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Is Common</summary>
        public static string VenueIsCommon {
               get {
                   return (string) resourceProvider.GetResource("VenueIsCommon", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Setup</summary>
        public static string VenueSetup {
               get {
                   return (string) resourceProvider.GetResource("VenueSetup", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Venue</summary>
        public static string VenuePermissionName {
               get {
                   return (string) resourceProvider.GetResource("VenuePermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Inhouse</summary>
        public static string VenueStatusType_Inhouse {
               get {
                   return (string) resourceProvider.GetResource("VenueStatusType_Inhouse", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Onsite</summary>
        public static string VenueStatusType_Onsite {
               get {
                   return (string) resourceProvider.GetResource("VenueStatusType_Onsite", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Per-Day</summary>
        public static string RateTypePerDay {
               get {
                   return (string) resourceProvider.GetResource("RateTypePerDay", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Per-Hour</summary>
        public static string RateTypePerHour {
               get {
                   return (string) resourceProvider.GetResource("RateTypePerHour", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Address</summary>
        public static string GeneralAddress {
               get {
                   return (string) resourceProvider.GetResource("GeneralAddress", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Venue Code</summary>
        public static string VenueCode {
               get {
                   return (string) resourceProvider.GetResource("VenueCode", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Venue Code</summary>
        public static string VenueCodeRequired {
               get {
                   return (string) resourceProvider.GetResource("VenueCodeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Addresses</summary>
        public static string PersonAddressesPermissionName {
               get {
                   return (string) resourceProvider.GetResource("PersonAddressesPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course added successfully</summary>
        public static string CourseRecordAddedSuccessfully {
               get {
                   return (string) resourceProvider.GetResource("CourseRecordAddedSuccessfully", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Venue</summary>
        public static string VenueTabTitle {
               get {
                   return (string) resourceProvider.GetResource("VenueTabTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Manage Course\Class\Session Venues</summary>
        public static string ProgramVenuesPermissionName {
               get {
                   return (string) resourceProvider.GetResource("ProgramVenuesPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Venue</summary>
        public static string VenueOpenTypeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("VenueOpenTypeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select Venue</summary>
        public static string VenueOpenTypeRequired {
               get {
                   return (string) resourceProvider.GetResource("VenueOpenTypeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Cannot enter duplicate Venue</summary>
        public static string VenueDuplicationCheck {
               get {
                   return (string) resourceProvider.GetResource("VenueDuplicationCheck", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Venue</summary>
        public static string VenueName {
               get {
                   return (string) resourceProvider.GetResource("VenueName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Session Name</summary>
        public static string SessionName {
               get {
                   return (string) resourceProvider.GetResource("SessionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Session Name</summary>
        public static string SessionNameRequired {
               get {
                   return (string) resourceProvider.GetResource("SessionNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select Class</summary>
        public static string SessionClassRequired {
               get {
                   return (string) resourceProvider.GetResource("SessionClassRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Class</summary>
        public static string SessionClass {
               get {
                   return (string) resourceProvider.GetResource("SessionClass", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Schedule Date</summary>
        public static string SessionScheduleDate {
               get {
                   return (string) resourceProvider.GetResource("SessionScheduleDate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Trainer</summary>
        public static string Trainer {
               get {
                   return (string) resourceProvider.GetResource("Trainer", CultureInfo.CurrentUICulture.Name);
               }
            }

        public static string PrimaryRequirementName
        {
            get
            {
                return (string)resourceProvider.GetResource("PrimaryRequirementName", CultureInfo.CurrentUICulture.Name);
            }
        }
        
        public static string TrainerTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("TrainerTitle", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string TrainerPageTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("TrainerPageTitle", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string TrainerLogin
        {
            get
            {
                return (string)resourceProvider.GetResource("TrainerLogin", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Please select Trainer</summary>
        public static string TrainerRequired {
               get {
                   return (string) resourceProvider.GetResource("TrainerRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Trainer</summary>
        public static string TrainerOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("TrainerOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Class</summary>
        public static string SessionClassOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("SessionClassOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Is Last Session</summary>
        public static string SessionIsLastSession {
               get {
                   return (string) resourceProvider.GetResource("SessionIsLastSession", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Lecture Conducted</summary>
        public static string SessionLectureConducted {
               get {
                   return (string) resourceProvider.GetResource("SessionLectureConducted", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Class Session</summary>
        public static string SessionPermissionName {
               get {
                   return (string) resourceProvider.GetResource("SessionPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Manage Roles</summary>
        public static string RolesTabTitile {
               get {
                   return (string) resourceProvider.GetResource("RolesTabTitile", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Role name</summary>
        public static string RolesPrimaryName {
               get {
                   return (string) resourceProvider.GetResource("RolesPrimaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
        /// <summary>Role name</summary>
        public static string PrintReport
        {
            get
            {
                return (string)resourceProvider.GetResource("PrintReport", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Role secondary name</summary>
        public static string RolesSecondaryName {
               get {
                   return (string) resourceProvider.GetResource("RolesSecondaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Is Default Trainer</summary>
        public static string RolesIsDefaultTrainer {
               get {
                   return (string) resourceProvider.GetResource("RolesIsDefaultTrainer", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Role name</summary>
        public static string RolesSecondaryNameRequired
        {
               get {
                   return (string) resourceProvider.GetResource("RolesSecondaryNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }


        public static string RolesPrimaryNameRequired
        {
            get
            {
                return (string)resourceProvider.GetResource("RolesPrimaryNameRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Same name role already exist</summary>
        public static string RolesPrimaryNameDuplicateRole {
               get {
                   return (string) resourceProvider.GetResource("RolesPrimaryNameDuplicateRole", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Roles</summary>
        public static string RolesPermissionName {
               get {
                   return (string) resourceProvider.GetResource("RolesPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Person Roles</summary>
        public static string RolesPersonPermissionName {
               get {
                   return (string) resourceProvider.GetResource("RolesPersonPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Roles</summary>
        public static string RolesTitle {
               get {
                   return (string) resourceProvider.GetResource("RolesTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Role</summary>
        public static string RolesDropDownTitle {
               get {
                   return (string) resourceProvider.GetResource("RolesDropDownTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select Role</summary>
        public static string RolesDropDownTitleRequired {
               get {
                   return (string) resourceProvider.GetResource("RolesDropDownTitleRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Role</summary>
        public static string RolesDropDownTitleOptionalLablel {
               get {
                   return (string) resourceProvider.GetResource("RolesDropDownTitleOptionalLablel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Add more Trainer</summary>
        public static string TrainerAddOtherIfNotInlist {
               get {
                   return (string) resourceProvider.GetResource("TrainerAddOtherIfNotInlist", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Manage Course\Class\Session Trainer</summary>
        public static string ProgramTrainerPermissionName {
               get {
                   return (string) resourceProvider.GetResource("ProgramTrainerPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Cannot enter duplicate Trainer</summary>
        public static string TrainerDuplicationCheck {
               get {
                   return (string) resourceProvider.GetResource("TrainerDuplicationCheck", CultureInfo.CurrentUICulture.Name);
               }
            }
        public static string LogisticDuplicationCheck
        {
            get
            {
                return (string)resourceProvider.GetResource("LogisticDuplicationCheck", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Trainee</summary>
        public static string Trainee {
               get {
                   return (string) resourceProvider.GetResource("Trainee", CultureInfo.CurrentUICulture.Name);
               }
            }

        public static string TraineePageTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("TraineePageTitle", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Trainee</summary>
        public static string ProgramTraineePermissionName {
               get {
                   return (string) resourceProvider.GetResource("ProgramTraineePermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>One of the sessions of class has been marked as last session</summary>
        public static string SessionIsLastAlreadyExist {
               get {
                   return (string) resourceProvider.GetResource("SessionIsLastAlreadyExist", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Minimum trainees of class are not added!</summary>
        public static string SessionClassMinimumTraineesNotAdded {
               get {
                   return (string) resourceProvider.GetResource("SessionClassMinimumTraineesNotAdded", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Cannot proceed</summary>
        public static string CannotProceed {
               get {
                   return (string) resourceProvider.GetResource("CannotProceed", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>The maximum class session has already been added</summary>
        public static string SessionMaximumSessionLimitReached {
               get {
                   return (string) resourceProvider.GetResource("SessionMaximumSessionLimitReached", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Specified date/time for the session conflicts with other sessions of the class</summary>
        public static string SessionIsValidSessionDateTime {
               get {
                   return (string) resourceProvider.GetResource("SessionIsValidSessionDateTime", CultureInfo.CurrentUICulture.Name);
               }
            }
        /// <summary>Specified date/time for the session conflicts with other sessions of the class</summary>
        public static string SessionIsValidSessionTime
        {
            get
            {
                return (string)resourceProvider.GetResource("SessionIsValidSessionTime", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Scheduled date should be between class start and end dates</summary>
        public static string SessionIsValidScheduleDate {
               get {
                   return (string) resourceProvider.GetResource("SessionIsValidScheduleDate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Scheduled date/time conflicts with trainers other sessions date/time</summary>
        public static string SessionIsValidTrainerTime {
               get {
                   return (string) resourceProvider.GetResource("SessionIsValidTrainerTime", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Scheduled date/time conflicts with venues other sessions date/TIME</summary>
        public static string SessionIsValidVenueTime {
               get {
                   return (string) resourceProvider.GetResource("SessionIsValidVenueTime", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>found Session time conflicts for trainees ({0})</summary>
        public static string SessionConflictNames {
               get {
                   return (string) resourceProvider.GetResource("SessionConflictNames", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Schedule Info</summary>
        public static string ScheduleInfo {
               get {
                   return (string) resourceProvider.GetResource("ScheduleInfo", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Vendor Name</summary>
        public static string VendorPrimaryName {
               get {
                   return (string) resourceProvider.GetResource("VendorPrimaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Secondary Name</summary>
        public static string VendorSecondaryName {
               get {
                   return (string) resourceProvider.GetResource("VendorSecondaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Primary Name</summary>
        public static string VendorPrimaryNameRequired {
               get {
                   return (string) resourceProvider.GetResource("VendorPrimaryNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Code</summary>
        public static string VendorCode {
               get {
                   return (string) resourceProvider.GetResource("VendorCode", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Code</summary>
        public static string VendorCodeRequired {
               get {
                   return (string) resourceProvider.GetResource("VendorCodeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Primary Details</summary>
        public static string VendorPrimaryDetailsRequired {
               get {
                   return (string) resourceProvider.GetResource("VendorPrimaryDetailsRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Details</summary>
        public static string VendorPrimaryDetails {
               get {
                   return (string) resourceProvider.GetResource("VendorPrimaryDetails", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Secondary Details</summary>
        public static string VendorSecondaryDetails {
               get {
                   return (string) resourceProvider.GetResource("VendorSecondaryDetails", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Vendor</summary>
        public static string VendorPermissionName {
               get {
                   return (string) resourceProvider.GetResource("VendorPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Vendor</summary>
        public static string VendorTitle {
               get {
                   return (string) resourceProvider.GetResource("VendorTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course vendor with specified code already exists</summary>
        public static string VendorCodeDuplicate {
               get {
                   return (string) resourceProvider.GetResource("VendorCodeDuplicate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Categories</summary>
        public static string CategoryTitle {
               get {
                   return (string) resourceProvider.GetResource("CategoryTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Categories</summary>
        public static string CategoryPermissionName {
               get {
                   return (string) resourceProvider.GetResource("CategoryPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Category Name</summary>
        public static string CategoryPrimaryName {
               get {
                   return (string) resourceProvider.GetResource("CategoryPrimaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Primary Category Name</summary>
        public static string CategoryPrimaryNameRequired {
               get {
                   return (string) resourceProvider.GetResource("CategoryPrimaryNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Secondary Category Name</summary>
        public static string CategorySecondaryName {
               get {
                   return (string) resourceProvider.GetResource("CategorySecondaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Description</summary>
        public static string CategoryPrimaryDescription {
               get {
                   return (string) resourceProvider.GetResource("CategoryPrimaryDescription", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Primary Description</summary>
        public static string CategoryPrimaryDescriptionRequired {
               get {
                   return (string) resourceProvider.GetResource("CategoryPrimaryDescriptionRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Secondary Description</summary>
        public static string CategorySecondaryDescription {
               get {
                   return (string) resourceProvider.GetResource("CategorySecondaryDescription", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Category Code</summary>
        public static string CategoryCode {
               get {
                   return (string) resourceProvider.GetResource("CategoryCode", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Category Code</summary>
        public static string CategoryCodeRequired {
               get {
                   return (string) resourceProvider.GetResource("CategoryCodeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Same Category Code already exist</summary>
        public static string CategoryCodeDuplicate {
               get {
                   return (string) resourceProvider.GetResource("CategoryCodeDuplicate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Type</summary>
        public static string CategoryType {
               get {
                   return (string) resourceProvider.GetResource("CategoryType", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please select Category</summary>
        public static string CategoryTypeRequired {
               get {
                   return (string) resourceProvider.GetResource("CategoryTypeRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course Category</summary>
        public static string CategoryTypeCourseCategory {
               get {
                   return (string) resourceProvider.GetResource("CategoryTypeCourseCategory", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Feedback Category</summary>
        public static string CategoryTypeFeedbackCategory {
               get {
                   return (string) resourceProvider.GetResource("CategoryTypeFeedbackCategory", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Select Category</summary>
        public static string CategoryTypeOptionalLabel {
               get {
                   return (string) resourceProvider.GetResource("CategoryTypeOptionalLabel", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Focus Area</summary>
        public static string FocusAreaPrimaryName {
               get {
                   return (string) resourceProvider.GetResource("FocusAreaPrimaryName", CultureInfo.CurrentUICulture.Name);
               }
            }

        public static string PrimaryMaterial
        {
            get
            {
                return (string)resourceProvider.GetResource("PrimaryMaterial", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Please enter Focus Area</summary>
        public static string FocusArerPrimayNameRequired {
               get {
                   return (string) resourceProvider.GetResource("FocusArerPrimayNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Focus Area already exists!</summary>
        public static string FocusAreaPrimayNameDuplicate {
               get {
                   return (string) resourceProvider.GetResource("FocusAreaPrimayNameDuplicate", CultureInfo.CurrentUICulture.Name);
               }
            }

        public static string CourseMeterialPrimayNameDuplicate
        {
            get
            {
                return (string)resourceProvider.GetResource("CourseMeterialPrimayNameDuplicate", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Secondary Focus Area</summary>
        public static string FocusArerSecondaryName {
               get {
                   return (string) resourceProvider.GetResource("FocusArerSecondaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Focus Area</summary>
        public static string FocusAreasPermissionName {
               get {
                   return (string) resourceProvider.GetResource("FocusAreasPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Material</summary>
        public static string CourseMaterialsPrimaryMaterial {
               get {
                   return (string) resourceProvider.GetResource("CourseMaterialsPrimaryMaterial", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Primary Material</summary>
        public static string CourseMaterialsPrimaryMaterialRequired {
               get {
                   return (string) resourceProvider.GetResource("CourseMaterialsPrimaryMaterialRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Material already exists!</summary>
        public static string CourseMaterialsPrimaryMaterialDuplicate {
               get {
                   return (string) resourceProvider.GetResource("CourseMaterialsPrimaryMaterialDuplicate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Secondary Material</summary>
        public static string CourseMaterialsSecondaryMaterial {
               get {
                   return (string) resourceProvider.GetResource("CourseMaterialsSecondaryMaterial", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course Materials</summary>
        public static string CourseMaterialsTitle {
               get {
                   return (string) resourceProvider.GetResource("CourseMaterialsTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
        /// <summary>Course Materials</summary>
        public static string CLassMaterialsTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("CLassMaterialsTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
        /// <summary>Course Materials</summary>
        public static string CourseMaterialsPermissionName {
               get {
                   return (string) resourceProvider.GetResource("CourseMaterialsPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Degree Certificates</summary>
        public static string DegreeCertificatesPermissionName {
               get {
                   return (string) resourceProvider.GetResource("DegreeCertificatesPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course Logistic Requirements</summary>
        public static string CourseLogisticRequirementsPermissionName {
               get {
                   return (string) resourceProvider.GetResource("CourseLogisticRequirementsPermissionName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Degree/Certificates Name</summary>
        public static string DegreeCertificatesPrimaryName {
               get {
                   return (string) resourceProvider.GetResource("DegreeCertificatesPrimaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Primary Degree Certificates Name</summary>
        public static string DegreeCertificatesPrimaryNameRequired {
               get {
                   return (string) resourceProvider.GetResource("DegreeCertificatesPrimaryNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Secondary Degree/Certificates Name</summary>
        public static string DegreeCertificatesSecondaryName {
               get {
                   return (string) resourceProvider.GetResource("DegreeCertificatesSecondaryName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Degree/Certificates Description</summary>
        public static string DegreeCertificatesPrimaryDescription {
               get {
                   return (string) resourceProvider.GetResource("DegreeCertificatesPrimaryDescription", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Secondary Degree/Certificates Description</summary>
        public static string DegreeCertificatesSecondaryDescription {
               get {
                   return (string) resourceProvider.GetResource("DegreeCertificatesSecondaryDescription", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Degree/Certificates Name already exists!</summary>
        public static string DegreeCertificatesPrimaryNameDuplicate {
               get {
                   return (string) resourceProvider.GetResource("DegreeCertificatesPrimaryNameDuplicate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Degree/Certificates</summary>
        public static string DegreeCertificatesTitle {
               get {
                   return (string) resourceProvider.GetResource("DegreeCertificatesTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Requirement Name</summary>
        public static string CourseLogisticRequirementsPrimaryRequirementName {
               get {
                   return (string) resourceProvider.GetResource("CourseLogisticRequirementsPrimaryRequirementName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Please enter Primary Requirement Name</summary>
        public static string CourseLogisticRequirementsPrimaryRequirementNameRequired {
               get {
                   return (string) resourceProvider.GetResource("CourseLogisticRequirementsPrimaryRequirementNameRequired", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Primary Requirement Name already exists!</summary>
        public static string CourseLogisticRequirementsPrimaryRequirementNameDuplicate {
               get {
                   return (string) resourceProvider.GetResource("CourseLogisticRequirementsPrimaryRequirementNameDuplicate", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Secondary Requirement Name</summary>
        public static string CourseLogisticRequirementsSecondaryRequirementName {
               get {
                   return (string) resourceProvider.GetResource("CourseLogisticRequirementsSecondaryRequirementName", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>Course Logistic Requirements</summary>
        public static string CourseLogisticRequirementsTitle {
               get {
                   return (string) resourceProvider.GetResource("CourseLogisticRequirementsTitle", CultureInfo.CurrentUICulture.Name);
               }
            }
        /// <summary>Course Logistic Requirements</summary>
        public static string ClassLogisticRequirementsTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("ClassLogisticRequirementsTitle", CultureInfo.CurrentUICulture.Name);
            }
        }

        /// <summary>Pre Requisites</summary>
        public static string CoursePreRequisites {
               get {
                   return (string) resourceProvider.GetResource("CoursePreRequisites", CultureInfo.CurrentUICulture.Name);
               }
            }
        public static string AttendanceType
        {
            get
            {
                return (string)resourceProvider.GetResource("AttendanceType", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string TraineeName
        {
            get
            {
                return (string)resourceProvider.GetResource("TraineeName", CultureInfo.CurrentUICulture.Name);
            }
        }


        public static string TraineeRegistrationNo
        {
            get
            {
                return (string)resourceProvider.GetResource("TraineeRegistrationNo", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string RollNo
        {
            get
            {
                return (string)resourceProvider.GetResource("RollNo", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string MarkAllPresent
        {
            get
            {
                return (string)resourceProvider.GetResource("MarkAllPresent", CultureInfo.CurrentUICulture.Name);
            }
        }


        public static string Unmarked
        {
            get
            {
                return (string)resourceProvider.GetResource("Unmarked", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string Present
        {
            get
            {
                return (string)resourceProvider.GetResource("Present", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string Absent
        {
            get
            {
                return (string)resourceProvider.GetResource("Absent", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string LeftEarly
        {
            get
            {
                return (string)resourceProvider.GetResource("LeftEarly", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string Late
        {
            get
            {
                return (string)resourceProvider.GetResource("Late", CultureInfo.CurrentUICulture.Name);
            }
        }
        
            public static string QuitfromClass
        {
            get
            {
                return (string)resourceProvider.GetResource("QuitfromClass", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string TypeID
        {
            get
            {
                return (string)resourceProvider.GetResource("TypeID", CultureInfo.CurrentUICulture.Name);
            }
        }
        
        public static string CivilID
        {
            get
            {
                return (string)resourceProvider.GetResource("CivilID", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EmployeeID
        {
            get
            {
                return (string)resourceProvider.GetResource("EmployeeID", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string GustID
        {
            get
            {
                return (string)resourceProvider.GetResource("GustID", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string SecuerityID
        {
            get
            {
                return (string)resourceProvider.GetResource("SecuerityID", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string IDTypes
        {
            get
            {
                return (string)resourceProvider.GetResource("IDTypes", CultureInfo.CurrentUICulture.Name);
            }
        }


        public static string DelayedCalls
        {
            get
            {
                return (string)resourceProvider.GetResource("DelayedCalls", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string ForwardedCalls
        {
            get
            {
                return (string)resourceProvider.GetResource("ForwardedCalls", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string IncomingVisits
        {
            get
            {
                return (string)resourceProvider.GetResource("IncomingVisits", CultureInfo.CurrentUICulture.Name);
            }
        }
       public static string OutgoingVisits
        {
            get
            {
                return (string)resourceProvider.GetResource("OutgoingVisits", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string DelayedVisits
        {
            get
            {
                return (string)resourceProvider.GetResource("DelayedVisits", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string IncomingCalls
        {
            get
            {
                return (string)resourceProvider.GetResource("IncomingCalls", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string OutgoingCalls
        {
            get
            {
                return (string)resourceProvider.GetResource("OutgoingCalls", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string Name
        {
            get
            {
                return (string)resourceProvider.GetResource("Name", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string ActivitySummaryReport
        {
            get
            {
                return (string)resourceProvider.GetResource("ActivitySummaryReport", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ModifiedBy
        {
            get
            {
                return (string)resourceProvider.GetResource("ModifiedBy", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string SaleAdminstration
        {
            get
            {
                return (string)resourceProvider.GetResource("SaleAdminstration", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string CRMCourseTabTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("CRMCourseTabTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string CRMCourseCategoryTabTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("CRMCourseCategoryTabTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string CRMConfigrationTabTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("CRMConfigrationTabTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string CRMReassignprospectTabTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("CRMReassignprospectTabTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string CRMCourseTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("CRMCourseTitle", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string CRM_PCourseName
        {
            get
            {
                return (string)resourceProvider.GetResource("CRM_PCourseName", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string CRM_SCourseName
        {
            get
            {
                return (string)resourceProvider.GetResource("CRM_SCourseName", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string CRM_Description
        {
            get
            {
                return (string)resourceProvider.GetResource("CRM_Description", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string CRM_OptionName
        {
            get
            {
                return (string)resourceProvider.GetResource("CRM_OptionName", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ProspectsList
        {
            get
            {
                return (string)resourceProvider.GetResource("ProspectsList", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string AssignTo
        {
            get
            {
                return (string)resourceProvider.GetResource("AssignTo", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string taskdate
        {
            get
            {
                return (string)resourceProvider.GetResource("taskdate", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string TaskHistory
        {
            get
            {
                return (string)resourceProvider.GetResource("TaskHistory", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string ScheduleClasses
        {
            get
            {
                return (string)resourceProvider.GetResource("ScheduleClasses", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string HowHeardOptionalLabel
        {
            get
            {
                return (string)resourceProvider.GetResource("HowHeardOptionalLabel", CultureInfo.CurrentUICulture.Name);
            }
        }
        
        public static string LableAssignedTo
        {
            get
            {
                return (string)resourceProvider.GetResource("LableAssignedTo", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string Lead
        {
            get
            {
                return (string)resourceProvider.GetResource("Lead", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string Caller
        {
            get
            {
                return (string)resourceProvider.GetResource("Caller", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string Visitor
        {
            get
            {
                return (string)resourceProvider.GetResource("Visitor", CultureInfo.CurrentUICulture.Name);
            }
        }
        
        public static string CRMClientType
        {
            get
            {
                return (string)resourceProvider.GetResource("CRMClientType", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string Not_Specified
        {
            get
            {
                return (string)resourceProvider.GetResource("Not_Specified", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string Trainees
        {
            get
            {
                return (string)resourceProvider.GetResource("Trainees", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string VisitHistory
        {
            get
            {
                return (string)resourceProvider.GetResource("VisitHistory", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string AssigmentHistory
        {
            get
            {
                return (string)resourceProvider.GetResource("AssigmentHistory", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string CallVisit
        {
            get
            {
                return (string)resourceProvider.GetResource("CallVisit", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string HowHeardTabTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("HowHeardTabTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string AssignedToTabTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("AssignedToTabTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string CourseCategoriesTabTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("CourseCategoriesTabTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string ProposedCoursesTabTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("ProposedCoursesTabTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string ScheduledClassesTabTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("ScheduledClassesTabTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string OptionName
        {
            get
            {
                return (string)resourceProvider.GetResource("OptionName", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Incoming
        {
            get
            {
                return (string)resourceProvider.GetResource("Incoming", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string Outgoing
        {
            get
            {
                return (string)resourceProvider.GetResource("Outgoing", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string Forwarded
        {
            get
            {
                return (string)resourceProvider.GetResource("Forwarded", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Event
        {
            get
            {
                return (string)resourceProvider.GetResource("Event", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Walkin
        {
            get
            {
                return (string)resourceProvider.GetResource("Walkin", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string CourseCoordinatorTitle
        {
            get
            {
                return (string)resourceProvider.GetResource("CourseCoordinatorTitle", CultureInfo.CurrentUICulture.Name);
            }
        }
        public static string Groups
        {
            get
            {
                return (string)resourceProvider.GetResource("Groups", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string PrimaryContents
        {
            get
            {
                return (string)resourceProvider.GetResource("PrimaryContents", CultureInfo.CurrentUICulture.Name);
            }
        }

    }


}
