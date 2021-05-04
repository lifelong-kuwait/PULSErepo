using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS.Library;

namespace TMS.Web.Models
{
    public class GModel
    {
        public Item item { get; set; }
        public IList<Education> education { get; set; }
        public IList<Referances> referances { get; set; }
        public IList<EmployementHistory> employementHistories { get; set; }
        public IList<int> fileids { get; set; }

    }
    public class Item
    {
        ///<summary>
        /// The ID of your object with the name of the ItemName
        ///</summary>
        public int JobID { get; set; }
        ///<summary>
        /// A string with the name of the ItemName
        ///</summary>
        public Salutation SalutationID { get; set; }

        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public Gender Gender { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string P_FirstName { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string P_MiddleName { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string P_LastName { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string NickName { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public MaritalStatus MaritalStatus { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string Email { get; set; }
        ///<summary>

        /// A string with the description of the object

        ///</summary>
        public DateTime DateOfBirth { get; set; }
        ///<summary>

        /// A string with the description of the object

        ///</summary>
        public string NationalIdentity { get; set; }
        ///<summary>

        /// A string with the description of the object

        ///</summary>
        public int CountriesID { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public int CountriesRegionsID { get; set; }
        ///<summary>

        /// A string with the description of the object

        ///</summary>
        public string ContactNumber { get; set; }       

        ///<summary>
        /// The ModuleId of where the object was created and gets displayed
        ///</summary>
        public string Extension { get; set; }

        ///<summary>
        /// An integer for the user id of the user who created the object
        ///</summary>
        public bool PsychoMeterTest { get; set; }
        ///<summary>
        /// An integer for the user id of the user who created the object
        ///</summary>
        public int FileID { get; set; }
        ///<summary>
        /// An integer for the user id of the user who created the object
        ///</summary>
        public decimal ExpectedSalary { get; set; }
        ///<summary>
        /// An integer for the user id of the user who created the object
        ///</summary>
        public DateTime JoiningDate { get; set; }
    }
    public enum EmploymentDesire
    {
        Fulltime,
        PartTime,
        Seasonal
    }
    public class Education
    {
        ///<summary>
        /// The ID of your object with the name of the ItemName
        ///</summary>
        public string P_Title { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string University { get; set; }
        ///<summary>
        /// A string with the name of the ItemName
        ///</summary>
        public double Result { get; set; }

        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public ResultType ResultTypeID { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string Session { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public int Duration { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string Major { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public DegreeStatus DegreeStatus { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string Description { get; set; }

    }
    public class Referances
    {  
        
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string Name { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string Title { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string Comapany { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string Phone { get; set; }
    }
    public class EmployementHistory
    {
        ///<summary>
        /// The ID of your object with the name of the ItemName
        ///</summary>
        public int EmployementHistoryId { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public int EmploymentFormID { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string Employer { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string JobTitle { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string WorkPhone { get; set; }

        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public DateTime WorkFrom { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public DateTime WorkTo { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string Salary { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string Address { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string City { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string State { get; set; }
        ///<summary>
        /// A string with the description of the object
        ///</summary>
        public string Zip { get; set; }
    }
}