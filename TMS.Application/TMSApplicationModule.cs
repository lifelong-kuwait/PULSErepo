using System.Reflection;
using Abp.Modules;

namespace TMS
{
    [DependsOn(typeof(TMSCoreModule))]
    public class TMSApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
