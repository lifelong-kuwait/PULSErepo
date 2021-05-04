using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Business.Interfaces.TMS;
using TMS.Library;
using TMS.DataObjects.Interfaces.Common.Configuration;
using TMS.DataObjects.TMS;
using TMS.DataObjects.TMS.Trainers;
using TMS.Library.TMS.Trainer;
using TMS.DataObjects.Common.Configuration;

namespace TMS.Business.TMS
{
    public class TrainerBAL:ITrainerBAL
    {
        private readonly ITrainerDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonBAL"/> class.
        /// </summary>
        public TrainerBAL()
        {
            DAL = new TrainerDAL();
        }

        /// <summary>
        /// Persons the get allbal.
        /// </summary>
        /// <returns>IList&lt;Person&gt;.</returns>
        public IList<Trainer> Trainer_GetALLBAL()
        {
            return DAL.Trainer_GetALLDAL();
        }

        /// <summary>
        /// Logins the users get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;LoginUsers&gt;.</returns>
        public IList<Trainer> Trainer_GetAllBAL(string culture,long RoleID,string ID,  string SearchText)
        {
            return DAL.Trainer_GetAllDAL(culture,RoleID,ID, SearchText);
        }

        /// <summary>
        /// Trainer Organization get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;Trainer&gt;.</returns>
        public IList<Trainer> TrainerOrganization_GetAllBAL(ref int Total, string culture, long RoleID, string ID,  string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long personID,bool jobFlage)
        {
            return DAL.TrainerOrganization_GetAllDAL(ref Total, culture, RoleID, ID,  SearchText, SortExpression, StartRowIndex,  page,  PageSize,personID,jobFlage);
        }
       public IList<Trainer> DeletedPerson_GetAllBAL(string culture, long ID, string SearchText)
        {
            return DAL.DeletedPerson_GetAllDAL(culture, ID, SearchText);
        }
        /// <summary>
        /// Persons the insert new person bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>PersonResponse.</returns>
        public PersonResponse PersonInsertNewPersonBAL(Trainer _objTrainer,long RoleID)
        {
            string clientType = string.Empty;
            if (_objTrainer.ClientType == ClientType.ClientType_Internal)
                clientType = "I";
            else if (_objTrainer.ClientType == ClientType.ClientType_External)
                clientType = "C";

            if (_objTrainer.SalutationID == 0)
            {
                _objTrainer.SalutationID = Salutation.Not_Specified;
            }
            if (_objTrainer.Gender == 0)
            {
                _objTrainer.Gender = Gender.Not_Specified;
            }
            var result = DAL.PersonInsertNewPersonDAL(_objTrainer, clientType,RoleID);
            if (result.ID != -1)
            {
                if (_objTrainer.Flags != null)
                {
                    IConfigurationDAL ConfigDAL = new ConfigurationDAL();
                    foreach (var flg in _objTrainer.Flags)
                    {
                        ConfigDAL.PersonFlags_InsertByPersonID(flg.ID, result.ID.ToString(), _objTrainer.CreatedBy);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Trainer the update bal.
        /// </summary>
        /// <param name="_objTrainer">The object Trainer.</param>
        /// <returns>System.Int32.</returns>
        public int Trainer_UpdateBAL(Trainer _objTrainer)
        {
            IConfigurationDAL ConfigDAL = new ConfigurationDAL();
            if (_objTrainer.FlagIDs == null)
            {
                if (_objTrainer.Flags != null)
                {
                    for (int i = 0; i < _objTrainer.Flags.Count; i++)
                    {
                        if (_objTrainer.Flags[i] != null)
                        {
                            ConfigDAL.PersonFlags_InsertByPersonID(_objTrainer.Flags[i].ID, _objTrainer.ID.ToString(), _objTrainer.UpdatedBy);
                            _objTrainer.FlagIDs = _objTrainer.FlagIDs + _objTrainer.Flags[i].ID.ToString();
                            if (_objTrainer.Flags.Count - 1 != i)
                            {
                                _objTrainer.FlagIDs = _objTrainer.FlagIDs.ToString() + ",";
                            }
                        }
                    }
                }
            }
            else
            {
                char[] delimiters = new char[] { ',' };
                List<string> _FlagIDs = _objTrainer.FlagIDs.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (_FlagIDs.Count > 0)
                {
                    if (_objTrainer.Flags == null)
                    {
                        for (int i = 0; i < _FlagIDs.Count; i++)
                        {
                            ConfigDAL.PersonFlags_DeleteByPersonID(Convert.ToInt64(_FlagIDs[i]), _objTrainer.ID.ToString(), _objTrainer.UpdatedBy);
                        }
                        //delete all item from the Database
                        _objTrainer.FlagIDs = null;
                    }
                    else if (_objTrainer.Flags.Count == 0)
                    {
                        for (int i = 0; i < _FlagIDs.Count; i++)
                        {
                            ConfigDAL.PersonFlags_DeleteByPersonID(Convert.ToInt64(_FlagIDs[i]), _objTrainer.ID.ToString(), _objTrainer.UpdatedBy);
                        }
                        //delete all item from the Database
                        _objTrainer.FlagIDs = null;
                    }
                    else
                    {
                        if (_objTrainer.Flags.Count > _FlagIDs.Count)
                        {
                            for (int i = 0; i < _objTrainer.Flags.Count; i++)
                            {
                                var _result = _FlagIDs.FirstOrDefault(stringToCheck => stringToCheck.Contains(_objTrainer.Flags[i].ID.ToString()));
                                if (string.IsNullOrEmpty(_result))
                                {
                                    ConfigDAL.PersonFlags_InsertByPersonID(_objTrainer.Flags[i].ID, _objTrainer.ID.ToString(), _objTrainer.UpdatedBy);
                                    _objTrainer.FlagIDs = _objTrainer.FlagIDs + "," + _objTrainer.Flags[i].ID.ToString();
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < _FlagIDs.Count; i++)
                            {
                                var _result = _objTrainer.Flags.FirstOrDefault(s => s.ID == Convert.ToInt64(_FlagIDs[i]));
                                if (_result == null)
                                {
                                    ConfigDAL.PersonFlags_DeleteByPersonID(Convert.ToInt64(_FlagIDs[i]), _objTrainer.ID.ToString(), _objTrainer.UpdatedBy);
                                }
                            }
                            _objTrainer.FlagIDs = "";
                            for (int i = 0; i < _objTrainer.Flags.Count; i++)
                            {
                                _objTrainer.FlagIDs = _objTrainer.FlagIDs + _objTrainer.Flags[i].ID.ToString();
                                if (_objTrainer.Flags.Count - 1 != i)
                                {
                                    _objTrainer.FlagIDs = _objTrainer.FlagIDs.ToString() + ",";
                                }
                            }
                        }
                    }
                }
                else
                {
                }
            }
            return DAL.Trainer_UpdateDAL(_objTrainer);
        }

        /// <summary>
        /// Trainer the delete bal.
        /// </summary>
        /// <param name="_objTrainer">The object Trainer.</param>
        /// <returns>System.Int32.</returns>
        public int Trainer_DeleteBAL(Trainer _objTrainer) => DAL.Trainer_DeleteDAL(_objTrainer);

        /// <summary>
        /// Trainer Detail Card person bal.
        /// </summary>
        /// <param name="_objTrainer">The object Trainer.</param>
        /// <returns>Trainer.</returns>
        public Trainer Trainer_GetAllByIdBALdetailCard(string ID)
        {
            return DAL.Trainer_GetAllByIdDALdetailCard(ID);
        }
    }
}
