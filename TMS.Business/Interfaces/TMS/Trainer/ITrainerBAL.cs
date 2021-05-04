using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.TMS.Persons.Others;
using TMS.Library.TMS.Trainer;

namespace TMS.Business.Interfaces.TMS
{
    public interface ITrainerBAL
    {

        IList<Trainer> Trainer_GetALLBAL();
        /// <summary>
        /// Trainer get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;Trainer&gt;.</returns>
        IList<Trainer> Trainer_GetAllBAL(string culture,long RoleID,string ID,  string SearchText);

        /// <summary>
        /// Trainer By Organization get all bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;Trainer&gt;.</returns>
        IList<Trainer> TrainerOrganization_GetAllBAL(ref int Total, string culture, long RoleID, string ID,string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize, long personID,bool jobFlage);

        IList<Trainer> DeletedPerson_GetAllBAL(string culture, long ID, string SearchText);

        /// <summary>
        /// Persons the insert new person bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>PersonResponse.</returns>
        PersonResponse PersonInsertNewPersonBAL(Trainer _objTrainer,long RoleID);

        /// <summary>
        /// Trainer the update bal.
        /// </summary>
        /// <param name="_objTrainer">The object person.</param>
        /// <returns>System.Int32.</returns>
        int Trainer_UpdateBAL(Trainer _objTrainer);

        /// <summary>
        /// Trainer the delete bal.
        /// </summary>
        /// <param name="_objTrainer">The object person.</param>
        /// <returns>System.Int32.</returns>
        int Trainer_DeleteBAL(Trainer _objTrainer);

        /// <summary>
        /// Trainer Detail Card person bal.
        /// </summary>
        /// <param name="_objTrainer">The object Trainer.</param>
        /// <returns>Trainer.</returns>
        Trainer Trainer_GetAllByIdBALdetailCard(string ID);
    }
}
