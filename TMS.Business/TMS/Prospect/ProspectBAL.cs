using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Business.Interfaces.TMS;
using TMS.DataObjects.Common.Configuration;
using TMS.DataObjects.Interfaces.Common.Configuration;
using TMS.DataObjects.Interfaces.TMS;
using TMS.DataObjects.TMS;
using TMS.Library;
using TMS.Library.TMS.Persons;

namespace TMS.Business.TMS
{
   public class ProspectBAL:IProspectBAL
    {
        private readonly IPersonDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonBAL"/> class.
        /// </summary>
        public ProspectBAL()
        {
            DAL = new PersonDAL();
        }

        /// <summary>
        /// Persons the insert new person bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>PersonResponse.</returns>
        public PersonResponse PersonInsertNewPersonBAL(Person _objPerson)
        {
            string clientType = string.Empty;
            if (_objPerson.ClientType == ClientType.ClientType_Internal)
                clientType = "I";
            else if (_objPerson.ClientType == ClientType.ClientType_External)
                clientType = "C";

            if (_objPerson.SalutationID == 0)
            {
                _objPerson.SalutationID = Salutation.Not_Specified;
            }
            if (_objPerson.Gender == 0)
            {
                _objPerson.Gender = Gender.Not_Specified;
            }
            var result = DAL.PersonInsertNewPersonDAL(_objPerson, clientType,2);
            if (result.ID != -1)
            {
                if (_objPerson.Flags != null)
                {
                    IConfigurationDAL ConfigDAL = new ConfigurationDAL();
                    foreach (var flg in _objPerson.Flags)
                    {
                        ConfigDAL.PersonFlags_InsertByPersonID(flg.ID, result.ID.ToString(), _objPerson.CreatedBy);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Persons the get allbal.
        /// </summary>
        /// <returns>IList&lt;Person&gt;.</returns>
        public IList<Person> Person_GetALLBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return DAL.Person_GetALLDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

        /// <summary>
        /// Persons the get all by identifier bal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Person.</returns>
        public Person Person_GetAllByIdBAL(string ID)
        {
            return DAL.Person_GetAllByIdDAL(ID);
        }

        /// <summary>
        /// Persons the update bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        public int Person_UpdateBAL(Person _objPerson)
        {
            IConfigurationDAL ConfigDAL = new ConfigurationDAL();
            if (_objPerson.FlagIDs == null)
            {
                if (_objPerson.Flags != null)
                {
                    for (int i = 0; i < _objPerson.Flags.Count; i++)
                    {
                        if (_objPerson.Flags[i] != null)
                        {
                            ConfigDAL.PersonFlags_InsertByPersonID(_objPerson.Flags[i].ID, _objPerson.ID.ToString(), _objPerson.UpdatedBy);
                            _objPerson.FlagIDs = _objPerson.FlagIDs + _objPerson.Flags[i].ID.ToString();
                            if (_objPerson.Flags.Count - 1 != i)
                            {
                                _objPerson.FlagIDs = _objPerson.FlagIDs.ToString() + ",";
                            }
                        }
                    }
                }
            }
            else
            {
                char[] delimiters = new char[] { ',' };
                List<string> _FlagIDs = _objPerson.FlagIDs.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (_FlagIDs.Count > 0)
                {
                    if (_objPerson.Flags == null)
                    {
                        for (int i = 0; i < _FlagIDs.Count; i++)
                        {
                            ConfigDAL.PersonFlags_DeleteByPersonID(Convert.ToInt64(_FlagIDs[i]), _objPerson.ID.ToString(), _objPerson.UpdatedBy);
                        }
                        //delete all item from the Database
                        _objPerson.FlagIDs = null;
                    }
                    else if (_objPerson.Flags.Count == 0)
                    {
                        for (int i = 0; i < _FlagIDs.Count; i++)
                        {
                            ConfigDAL.PersonFlags_DeleteByPersonID(Convert.ToInt64(_FlagIDs[i]), _objPerson.ID.ToString(), _objPerson.UpdatedBy);
                        }
                        //delete all item from the Database
                        _objPerson.FlagIDs = null;
                    }
                    else
                    {
                        if (_objPerson.Flags.Count > _FlagIDs.Count)
                        {
                            for (int i = 0; i < _objPerson.Flags.Count; i++)
                            {
                                var _result = _FlagIDs.FirstOrDefault(stringToCheck => stringToCheck.Contains(_objPerson.Flags[i].ID.ToString()));
                                if (string.IsNullOrEmpty(_result))
                                {
                                    ConfigDAL.PersonFlags_InsertByPersonID(_objPerson.Flags[i].ID, _objPerson.ID.ToString(), _objPerson.UpdatedBy);
                                    _objPerson.FlagIDs = _objPerson.FlagIDs + "," + _objPerson.Flags[i].ID.ToString();
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < _FlagIDs.Count; i++)
                            {
                                var _result = _objPerson.Flags.FirstOrDefault(s => s.ID == Convert.ToInt64(_FlagIDs[i]));
                                if (_result == null)
                                {
                                    ConfigDAL.PersonFlags_DeleteByPersonID(Convert.ToInt64(_FlagIDs[i]), _objPerson.ID.ToString(), _objPerson.UpdatedBy);
                                }
                            }
                            _objPerson.FlagIDs = "";
                            for (int i = 0; i < _objPerson.Flags.Count; i++)
                            {
                                _objPerson.FlagIDs = _objPerson.FlagIDs + _objPerson.Flags[i].ID.ToString();
                                if (_objPerson.Flags.Count - 1 != i)
                                {
                                    _objPerson.FlagIDs = _objPerson.FlagIDs.ToString() + ",";
                                }
                            }
                        }
                    }
                }
                else
                {
                }
            }
            return DAL.Person_UpdateDAL(_objPerson);
        }

        /// <summary>
        /// Persons the delete bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        public int Person_DeleteBAL(Person _objPerson) => DAL.Person_DeleteDAL(_objPerson);

    }
}
