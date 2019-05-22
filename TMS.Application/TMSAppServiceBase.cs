using Abp.Application.Services;

namespace TMS
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class TMSAppServiceBase : ApplicationService
    {
        protected TMSAppServiceBase()
        {
            LocalizationSourceName = TMSConsts.LocalizationSourceName;
        }
    }
}