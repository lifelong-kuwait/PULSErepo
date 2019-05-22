using System.Collections.Generic;
using TMS.Library.Entities.TMS.Language;

namespace TMS.Business.TMS.Language
{
    public interface ILanguageDAL
    {
        IList<LanguageModel> GetAllLanguagesBAL(long oid);
    }
}