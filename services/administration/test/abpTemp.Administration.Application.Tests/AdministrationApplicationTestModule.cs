using Volo.Abp.Modularity;

namespace abpTemp.Administration;

[DependsOn(
    typeof(AdministrationApplicationModule),
    typeof(AdministrationDomainTestModule)
    )]
public class AdministrationApplicationTestModule : AbpModule
{

}
