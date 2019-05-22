using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities.TMS.Language;

namespace TMS.Business.Interfaces.TMS.Language
{
    public interface ILanguageBAL
    {
        LanguageModel CurrentLanguages { get; }
        IList<LanguageModel> GetAllLanguagesBAL(long oid);
    }
}
