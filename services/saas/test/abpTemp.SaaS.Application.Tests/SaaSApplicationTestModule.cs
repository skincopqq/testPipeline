using Volo.Abp.Modularity;

namespace abpTemp.SaaS;

[DependsOn(
    typeof(SaaSApplicationModule),
    typeof(SaaSDomainTestModule)
    )]
public class SaaSApplicationTestModule : AbpModule
{

}
