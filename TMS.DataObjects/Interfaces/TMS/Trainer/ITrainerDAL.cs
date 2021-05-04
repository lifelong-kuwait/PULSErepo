using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.TMS.Trainer;

namespace TMS.DataObjects.TMS.Trainers
{
    public interface ITrainerDAL
    {

       

        /// <summary>
        /// Persons the get all dal.
        /// </summary>
        /// <returns>IList&lt;Person&gt;.</returns>
        IList<Trainer> Trainer_GetALLDAL();

        /// <summary>
        /// Trainer get all dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;Trainer&gt;.</returns>
        IList<Trainer> Trainer_GetAllDAL(string culture,long RoleID, string ID,  string SearchText);

        /// <summary>
        /// Trainer by Organizatin get all dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="culture">OrganizationID.</param>
        /// <returns>IList&lt;Trainer&gt;.</returns>
        IList<Trainer> TrainerOrganization_GetAllDAL(ref int Total,string  culture, long RoleID, string ID,  string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize,long personID,bool jobFlage);


        IList<Trainer> DeletedPerson_GetAllDAL(string culture, long ID, string SearchText);
        /// <summary>
        /// Persons the insert new person dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <param name="clientType">Type of the client.</param>
        /// <returns>PersonResponse.</returns>
        PersonResponse PersonInsertNewPersonDAL(Trainer _objTrainer, string clientType,long RoleID);

        /// <summary>
        /// Persons the update dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int Trainer_UpdateDAL(Trainer _objTrainer);

        /// <summary>
        /// Trainer the delete dal.
        /// </summary>
        /// <param name="_objTrainer">The object Trainer.</param>
        /// <returns>System.Int32.</returns>
        int Trainer_DeleteDAL(Trainer _objTrainer);

        /// <summary>
        /// Trainer Detail Card person dal.
        /// </summary>
        /// <param name="_objTrainer">The object Trainer.</param>
        /// <returns>Trainer.</returns>
        Trainer Trainer_GetAllByIdDALdetailCard(string ID);
    }
}
