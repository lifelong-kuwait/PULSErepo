
using System.Collections.Generic;
using TMS.Library.TMS.Persons;

namespace TMS.DataObjects.Interfaces.TMS
{
    public interface IProspectDAL
    {
        /// <summary>
        /// Persons the insert new person dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <param name="clientType">Type of the client.</param>
        /// <returns>PersonResponse.</returns>
        PersonResponse PersonInsertNewPersonDAL(Person _objPerson, string clientType);

        /// <summary>
        /// Persons the get all dal.
        /// </summary>
        /// <returns>IList&lt;Person&gt;.</returns>
        IList<Person> Person_GetALLDAL();

        /// <summary>
        /// Persons the get all by identifier dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Person.</returns>
        Person Person_GetAllByIdDAL(string ID);

        /// <summary>
        /// Persons the update dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int Person_UpdateDAL(Person _objPerson);

        /// <summary>
        /// Persons the delete dal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int Person_DeleteDAL(Person _objPerson);
    }
}
