using System.Collections.Generic;
using Abp.Localization;
using TMS.Library.Entities.TMS.Language;

namespace TMS.Web.Models.Layout
{
    public class LanguageSelectionViewModel
    {
        public LanguageModel CurrentLanguages { get; set; }
        public IList<LanguageModel> Languagess { get; set; }
        //lan
        public LanguageInfo CurrentLanguage { get; set; }

        public IReadOnlyList<LanguageInfo> Languages { get; set; }
    }
}