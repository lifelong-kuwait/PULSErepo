using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Business.CastleWindsor;
using TMS.Business.Interfaces.TMS.Language;
using TMS.Library.Entities.TMS.Language;
//using TMS.DataObjects.Interfaces.TMS.la;

namespace TMS.Business.TMS.Language
{
   public class LanguageBAL: ILanguageBAL
    {
        private readonly ILanguageDAL DAL;
        public LanguageBAL(ILanguageDAL _LanguageDAL)
        {
            DAL = _LanguageDAL;
        }

        //public LanguageModel CurrentLanguage
        //{
        //    get
        //    {
        //       // return LanguageModel();
        //        throw new NotImplementedException();
        //    }
        //}

        public LanguageModel CurrentLanguages
        {
            get
            {
                throw new NotImplementedException();
            }
        }
      
        public IList<LanguageModel> GetAllLanguagesBAL(long oid)
        {
            return DAL.GetAllLanguagesBAL(oid);
        }

      
    }
}
