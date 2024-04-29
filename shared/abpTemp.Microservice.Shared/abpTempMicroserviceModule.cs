using abpTemp.Administration.EntityFrameworkCore;
using abpTemp.Hosting.Shared;
using Volo.Abp.Modularity;

namespace abpTemp.Microservice.Shared;

[DependsOn(
    typeof(abpTempHostingModule),
    typeof(AdministrationEntityFrameworkCoreModule)
)]
public class abpTempMicroserviceModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}