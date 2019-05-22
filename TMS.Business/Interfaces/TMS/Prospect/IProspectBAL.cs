using System;
using System.Collections.Generic;
using TMS.Library.TMS.Persons;
using TMS.Library.TMS.Persons.Others;

namespace TMS.Business.Interfaces.TMS { 
    public interface IProspectBAL
    {

        /// <summary>
        /// Persons the insert new person bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>PersonResponse.</returns>
        PersonResponse PersonInsertNewPersonBAL(Person _objPerson);

        IList<Person> Person_GetALLBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Persons the get all by identifier bal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Person.</returns>
        Person Person_GetAllByIdBAL(string ID);

        /// <summary>
        /// Persons the update bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int Person_UpdateBAL(Person _objPerson);

        /// <summary>
        /// Persons the delete bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>System.Int32.</returns>
        int Person_DeleteBAL(Person _objPerson);
    }
}
