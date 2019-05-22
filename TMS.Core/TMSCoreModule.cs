using System.Reflection;
using Abp.Modules;

namespace TMS
{
    public class TMSCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
