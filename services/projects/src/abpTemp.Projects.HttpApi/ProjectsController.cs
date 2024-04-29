using abpTemp.Projects.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace abpTemp.Projects;

public abstract class ProjectsController : AbpControllerBase
{
    protected ProjectsController()
    {
        LocalizationResource = typeof(ProjectsResource);
    }
}