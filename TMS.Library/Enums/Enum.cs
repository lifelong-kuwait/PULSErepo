using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using lr = Resources.Resources;

namespace TMS.Library
{
    public enum AttendanceType
    {
        [Display(Name = "Unmarked", ResourceType = typeof(lr))]
        Attendance_Type_Unmarked = 1,
        [Display(Name = "Present", ResourceType = typeof(lr))]
        AttendanceType_Present = 2,
        [Display(Name = "Absent", ResourceType = typeof(lr))]
        AttendanceType_Absent = 3,
        [Display(Name = "LeftEarly", ResourceType = typeof(lr))]
        AttendanceType_OnLeave = 4,
        [Display(Name = "Late", ResourceType = typeof(lr))]
        AttendanceType_Late = 5,
        [Display(Name = "QuitfromClass", ResourceType = typeof(lr))]
        AttendanceType_QuitFromCourse = 6
    }
    public enum Salutation
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "SalutationMister", ResourceType = typeof(lr))]
        Salutation_Mr = 1,

        [Display(Name = "SalutationMissIs", ResourceType = typeof(lr))]
        Salutation_Mrs = 2,

        [Display(Name = "SalutationMiss", ResourceType = typeof(lr))]
        Salutation_Ms = 3,

        [Display(Name = "SalutationDoctor", ResourceType = typeof(lr))]
        Salutation_Dr = 4,
    }

    public enum MaritalStatus
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "MaritalStatusSingle", ResourceType = typeof(lr))]
        MaritalStatus_Single = 1,

        [Display(Name = "MaritalStatusMarried", ResourceType = typeof(lr))]
        MaritalStatus_Married = 2,

    }

    public enum Gender
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "GenderMale", ResourceType = typeof(lr))]
        Gender_Male = 1,

        [Display(Name = "GenderFemale", ResourceType = typeof(lr))]
        Gender_Female = 2,
    }

    public enum personType
    {
        [Display(Name = "Person",ResourceType =typeof(lr))]
        Person=0,

        [Display(Name ="Trainee",ResourceType =typeof(lr))]
        Trainee=1,

        [Display(Name ="Trainer",ResourceType =typeof(lr))]
        Trainer=2,
        [Display(Name = "Prospects", ResourceType = typeof(lr))]
        Prospects = 3,

        [Display(Name ="NotSpecified",ResourceType =typeof(lr))]
        Not_Specified=4,
    }
    public enum IDType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "CivilID", ResourceType = typeof(lr))]
        CivilID = 1,

        [Display(Name = "EmployeeID", ResourceType = typeof(lr))]
        EmployeeID = 2,
             [Display(Name = "GustID", ResourceType = typeof(lr))]
        GustID = 3,
             [Display(Name = "SecuerityID", ResourceType = typeof(lr))]
        SecuerityID = 4
    }

    public enum CRMClientType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,
        [Display(Name = "Lead", ResourceType = typeof(lr))]
        Lead = 1,
        [Display(Name = "Caller", ResourceType = typeof(lr))]
        Caller = 2,
        [Display(Name = "Visitor", ResourceType = typeof(lr))]
        Visitor = 3,
        [Display(Name = "Trainee", ResourceType = typeof(lr))]
        Trainee = 4,

        
    }


    public enum Calltype
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,
        [Display(Name = "Incoming", ResourceType = typeof(lr))]
        Lead = 1,
        [Display(Name = "Outgoing", ResourceType = typeof(lr))]
        Caller = 2,
        [Display(Name = "Forwarded", ResourceType = typeof(lr))]
        Forwarded = 3,

    }

    public enum EventType
    {
        Not_Specified = 0,
        Create =1,
      Update=2,
      Delete=3,
      ActivePerson=4

    }

    public enum Visittype
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,
        [Display(Name = "Walkin", ResourceType = typeof(lr))]
        Lead = 1,
        [Display(Name = "Event", ResourceType = typeof(lr))]
        Caller = 2,

    }

    //public enum Person_Type
    //{
    //    [Display(Name ="Not specified")]
    //    Not_Specified = 0,
    //    [Display(Name ="Corporate")]
    //    ClientType_External = 2,
    //    [Display(Name ="Individual")]
    //    ClientType_Internal = 1
    //}

    public enum ClientType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "ClientType_External", ResourceType = typeof(lr))]
        ClientType_External = 2,

        [Display(Name = "ClientType_Internal", ResourceType = typeof(lr))]
        ClientType_Internal = 1
    }
    

    public enum OfficialIdentificationType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "OfficialIdentificationType_CivilID", ResourceType = typeof(lr))]
        OfficialIdentificationType_CivilID = 1,

        [Display(Name = "OfficialIdentificationType_EmployeeID", ResourceType = typeof(lr))]
        OfficialIdentificationType_EmployeeID = 4,

        [Display(Name = "OfficialIdentificationType_GustID", ResourceType = typeof(lr))]
        OfficialIdentificationType_GustID = 2,

        [Display(Name = "OfficialIdentificationType_SecurityID", ResourceType = typeof(lr))]
        OfficialIdentificationType_SecurityID = 3
    }

   

    #region education

    public enum DegreeStatus
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "PersonEducationDegreeIncomplete", ResourceType = typeof(lr))]
        InComplete = 2,

        [Display(Name = "PersonEducationDegreeComplete", ResourceType = typeof(lr))]
        Completed = 1
    }

    public enum ResultType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "PersonEducationResultType_CGPA", ResourceType = typeof(lr))]
        ResultType_CGPA = 1,

        [Display(Name = "PersonEducationResultType_Percentage", ResourceType = typeof(lr))]
        ResultType_Percentage = 2
    }

    public enum CourseDurationType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "Duration_Day", ResourceType = typeof(lr))]
        CourseDuration_Day = 2,

        [Display(Name = "Duration_Hours", ResourceType = typeof(lr))]
        CourseDuration_Hour = 1,

        [Display(Name = "Duration_Months", ResourceType = typeof(lr))]
        ClassDuration_Months = 4,

        [Display(Name = "Duration_Weeks", ResourceType = typeof(lr))]
        CourseDuration_Week = 3,
    }

    public enum TrainingType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "PersonEducationTrainingType_Existing")]
        TrainingType_Existing = 1,

        [Display(Name = "PersonEducationTrainingType_Suggested")]
        TrainingType_Suggested = 2,
    }

    public enum PersonJobStatus
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        PersonJobStatus_Not_Specified = 0,

        [Display(Name = "PersonEducationPersonJobStatus_Consultant", ResourceType = typeof(lr))]
        PersonJobStatus_Consultant = 4,

        [Display(Name = "PersonEducationPersonJobStatus_Contract", ResourceType = typeof(lr))]
        PersonJobStatus_Contract = 3,

        [Display(Name = "PersonEducationPersonJobStatus_FullTime", ResourceType = typeof(lr))]
        PersonJobStatus_FullTime = 1,

        [Display(Name = "PersonEducationPersonJobStatus_Internee", ResourceType = typeof(lr))]
        PersonJobStatus_Internee = 5,

        [Display(Name = "PersonEducationPersonJobStatus_PartTime", ResourceType = typeof(lr))]
        PersonJobStatus_PartTime = 2
    }

    public enum AchievementType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "AchievementType_Academic", ResourceType = typeof(lr))]
        AchievementType_Academic = 1,

        [Display(Name = "AchievementType_Professional", ResourceType = typeof(lr))]
        AchievementType_Professional = 2,
    }

    public enum AddressType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "AddressType_Billing", ResourceType = typeof(lr))]
        AddressType_Billing = 3,

        [Display(Name = "AddressType_Primary", ResourceType = typeof(lr))]
        AddressType_Primary = 1,

        [Display(Name = "AddressType_Secondary", ResourceType = typeof(lr))]
        AddressType_Secondary = 2,
    }

    public enum PhoneNumberType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "PhoneNumberType_Fax", ResourceType = typeof(lr))]
        PhoneNumberType_Fax = 1,

        [Display(Name = "PhoneNumberType_Home", ResourceType = typeof(lr))]
        PhoneNumberType_Home = 2,

        [Display(Name = "PhoneNumberType_Mobile", ResourceType = typeof(lr))]
        PhoneNumberType_Mobile = 4,

        [Display(Name = "PhoneNumberType_Office", ResourceType = typeof(lr))]
        PhoneNumberType_Office = 3,

        [Display(Name = "PhoneNumberType_Other", ResourceType = typeof(lr))]
        PhoneNumberType_Other = 5,
    }

    #endregion education

    #region "Contact"

    public enum LinkType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "LinkType_Blog", ResourceType = typeof(lr))]
        LinkType_Blog = 5,

        [Display(Name = "LinkType_FaceBook", ResourceType = typeof(lr))]
        LinkType_FaceBook = 1,

        [Display(Name = "LinkType_GooglePlus", ResourceType = typeof(lr))]
        LinkType_GooglePlus = 3,

        [Display(Name = "LinkType_Portfolio", ResourceType = typeof(lr))]
        LinkType_Portfolio = 6,

        [Display(Name = "LinkType_Twitter", ResourceType = typeof(lr))]
        LinkType_Twitter = 2,

        [Display(Name = "PhoneNumberType_Fax", ResourceType = typeof(lr))]
        LinkType_Website = 4,
    }

    #endregion "Contact"

    #region"Skills and Intrest"

    public enum PersonSKillInterest
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "PersonSKillInterest_Field_Of_Interest", ResourceType = typeof(lr))]
        PersonSKillInterest_Field_Of_Interest = 2,

        [Display(Name = "PersonSKillInterest_Person_Skills", ResourceType = typeof(lr))]
        PersonSKillInterest_Person_Skills = 1
    }

    #endregion
    //any way. The links should be classifiable as boss, colleague, spouse, child, parent, relative etc. Selecting a
    #region"Person Relation Type"

    public enum PersonRelationType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "PersonRelationType_Colleague", ResourceType = typeof(lr))]
        PersonRelationType_Colleague = 1,

        [Display(Name = "PersonRelationType_Spouse", ResourceType = typeof(lr))]
        PersonRelationType_Spouse = 2,

        [Display(Name = "PersonRelationType_Child", ResourceType = typeof(lr))]
        PersonRelationType_Child = 3,

        [Display(Name = "PersonRelationType_Parent", ResourceType = typeof(lr))]
        PersonRelationType_Parent = 4,

        [Display(Name = "PersonRelationType_Relative", ResourceType = typeof(lr))]
        PersonRelationType_Relative = 5
    }

    public enum PersonWorkExperienceRelationToOrganization
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "PersonWorkExperienceRelationToOrganization_Employee", ResourceType = typeof(lr))]
        PersonWorkExperienceRelationToOrganization_Employee = 1,

        [Display(Name = "PersonWorkExperienceRelationToOrganization_Trainee", ResourceType = typeof(lr))]
        PersonWorkExperienceRelationToOrganization_Trainee = 2,

        [Display(Name = "PersonWorkExperienceRelationToOrganization_PointOfContact", ResourceType = typeof(lr))]
        PersonWorkExperienceRelationToOrganization_PointOfContact = 3,
    }

    #endregion

    //lost common types are Word Doc, Excel Sheet, PowerPoint Presentation, PDF file, Text File, Image file and others
    public enum AttachmentsFileType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "AttachmentsFileType_Word_doc_docx", ResourceType = typeof(lr))]
        AttachmentsFileType_Word_doc_docx = 1,

        [Display(Name = "AttachmentsFileType_Excel_xlss", ResourceType = typeof(lr))]
        AttachmentsFileType_Excel_xlss = 2,

        [Display(Name = "AttachmentsFileType_PowerPoint_pptx", ResourceType = typeof(lr))]
        AttachmentsFileType_PowerPoint_pptx = 3,

        [Display(Name = "AttachmentsFileType_PortableDocumentFormat_pdf", ResourceType = typeof(lr))]
        AttachmentsFileType_PortableDocumentFormat_pdf = 4,

        [Display(Name = "AttachmentsFileType_TextFile_tct_rtf", ResourceType = typeof(lr))]
        AttachmentsFileType_TextFile_tct_rtf = 5,

        [Display(Name = "AttachmentsFileType_ImageFile_png_jpeg", ResourceType = typeof(lr))]
        AttachmentsFileType_ImageFile_png_jpeg = 6,

        [Display(Name = "AttachmentsFileType_ImageFile_psd", ResourceType = typeof(lr))]
        AttachmentsFileType_ImageFile_psd = 7,

        [Display(Name = "AttachmentsFileType_Audio_mp3", ResourceType = typeof(lr))]
        AttachmentsFileType_Audio_mp3 = 8,

        [Display(Name = "AttachmentsFileType_Video_mp4", ResourceType = typeof(lr))]
        AttachmentsFileType_Video_mp4 = 9,

        [Display(Name = "AttachmentsFileType_compressed_zip", ResourceType = typeof(lr))]
        AttachmentsFileType_compressed_zip = 10,

        [Display(Name = "AttachmentsFileType_Other_Unknown", ResourceType = typeof(lr))]
        AttachmentsFileType_Other_Unknown = 11,

        [Display(Name = "AttachmentsFileType_ProfilePicture", ResourceType = typeof(lr))]
        AttachmentsFileType_ProfilePicture = 12,
    }

    public enum EmailTemplateType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        NOT_SPECIFIED = 0,

        [Display(Name = "EmailTemplateTypeUserRegistration", ResourceType = typeof(lr))]
        UserRegistration = 1,

        [Display(Name = "EmailTemplateTypeForgotPassword", ResourceType = typeof(lr))]
        ForgotPassword = 2,

        [Display(Name = "EmailTemplateTypeChangeStatus", ResourceType = typeof(lr))]
        ChangeStatus = 3,

        [Display(Name = "EmailTemplateTypeTrainerTraineeRegistration", ResourceType = typeof(lr))]
        TrainerTraineeRegistration = 4,

        [Display(Name = "EmailTemplateTypeTraineeClassAssignment", ResourceType = typeof(lr))]
        TraineeClassAssignment = 5,

        [Display(Name = "EmailTemplateTypeCoordinatorClassAssignment", ResourceType = typeof(lr))]
        CoordinatorClassAssignment = 6,

        [Display(Name = "EmailTemplateTypeSendFeedbackLink", ResourceType = typeof(lr))]
        SendFeedbackLink = 7,

        [Display(Name = "EmailTemplateTypeTrainerClassAssignment", ResourceType = typeof(lr))]
        TrainerClassAssignment = 8,
    }

    public enum Days
    {
        [Description("Not specified")]
        Days_NotSpecified = 0,
        [Description("Sunday")]
        Days_Sunday = 1,
        [Description("Monday")]
        Days_Monday = 2,
        [Description("Tuesday")]
        Days_Tuesday = 3,
        [Description("Wednesday")]
        Days_Wednesday = 4,
        [Description("Thursday")]
        Days_Thursday = 5,
        [Description("Friday")]
        Days_Friday = 6,
        [Description("Saturday")]
        Days_Saturday = 7
    }

    public enum Month
    {
        [Description("Not specified")]
        Not_Specified = 0,
        [Description("January")]
        Month_January = 1,
        [Description("Feburary")]
        Month_Feburary = 2,
        [Description("March")]
        Month_March = 3,
        [Description("April")]
        Month_April = 4,
        [Description("May")]
        Month_May = 5,
        [Description("June")]
        Month_June = 6,
        [Description("July")]
        Month_July = 7,
        [Description("August")]
        Month_August = 8,
        [Description("September")]
        Month_September = 9,
        [Description("October")]
        Month_0ctober = 10,
        [Description("November")]
        Month_November = 11,
        [Description("December")]
        Month_December = 12,
    }
    public enum ClassType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "ClassTypeOnsite", ResourceType = typeof(lr))]
        ClassType_Onsite = 2,

        [Display(Name = "ClassTypeClosed", ResourceType = typeof(lr))]
        ClassType_Closed = 4,

        [Display(Name = "ClassTypeVenue", ResourceType = typeof(lr))]
        ClassType_Venue = 1,

        [Display(Name = "ClassTypePublic", ResourceType = typeof(lr))]
        ClassType_Public = 3,
    }

    #region Venue

    public enum RateType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "RateTypePerDay", ResourceType = typeof(lr))]
        RateType_Day = 2,

        [Display(Name = "RateTypePerHour", ResourceType = typeof(lr))]
        RateType_Hour = 1
    }

    //public enum VenueType
    //{
    //    [Description("Not specified")]
    //    Not_Specified = 0,
    //    [Description("Class Venues")]
    //    VenueType_ClassVenue = 2,
    //    [Description("Course Venues")]
    //    VenueType_CourseVenue = 1
    //}

    public enum VenueStatusType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Not_Specified = 0,

        [Display(Name = "VenueStatusType_Inhouse", ResourceType = typeof(lr))]
        VenueStatus_Inhouse = 1,

        [Display(Name = "VenueStatusType_Onsite", ResourceType = typeof(lr))]
        VenueStatus_Onsite = 2,
    }



    #endregion
    #region Log4NET

   

    public enum Logs
    {
        [Display(Name = "Login_Susscess", ResourceType = typeof(lr))]
        Login_Susscess = 0,

        [Display(Name = "Login_Attempt", ResourceType = typeof(lr))]
        Login_Attempt = 1,

        [Display(Name = "Login_Locked", ResourceType = typeof(lr))]
        Login_Locked = 2,
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Error = 3,

        [Display(Name = "Insert_Success", ResourceType = typeof(lr))]
        Insert_Success = 4,

        [Display(Name = "Delete_Success", ResourceType = typeof(lr))]
        Delete_Success = 5,
        [Display(Name = "Update_Success", ResourceType = typeof(lr))]
        Update_Success = 6,

        [Display(Name = "View_Success", ResourceType = typeof(lr))]
        View_Success = 7,

        [Display(Name = "Certificate_Success", ResourceType = typeof(lr))]
        Certificate_Success = 8,

        [Display(Name = "Report_View", ResourceType = typeof(lr))]
        Report_View = 9,
    }



    #endregion
    #region Category
    public enum CategoryType
    {
        [Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        CategoryType_NotSpecified = 0,
        //[Display(Name = "CategoryTypeFeedbackCategory", ResourceType = typeof(lr))]
        //CategoryType_Feedback_Category = 1,
        [Display(Name = "CategoryTypeCourseCategory", ResourceType = typeof(lr))]
        CategoryType_Course_Category = 2,
    }
    public enum TaxType
    {
        //[Display(Name = "NotSpecified", ResourceType = typeof(lr))]
        Tax_Exclusive = 1,
        //[Display(Name = "CategoryTypeFeedbackCategory", ResourceType = typeof(lr))]
        //CategoryType_Feedback_Category = 1,
        // [Display(Name = "CategoryTypeCourseCategory", ResourceType = typeof(lr))]
        Tax_Inclusive = 2,
        NoTax=3,
    }
    #endregion

    #region
    public enum TaskType
    {
        [Display(Name = "Call", ResourceType = typeof(lr))]
        call=1,
        [Display(Name = "Visit", ResourceType = typeof(lr))]
        visit=2,
        [Display(Name = "Other", ResourceType = typeof(lr))]
        other=3,
    }
    #endregion
}