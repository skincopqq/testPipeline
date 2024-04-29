using Volo.Abp.Modularity;

namespace abpTemp.Projects;

[DependsOn(
    typeof(ProjectsApplicationModule),
    typeof(ProjectsDomainTestModule)
    )]
public class ProjectsApplicationTestModule : AbpModule
{

}
