using abpTemp.Administration.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace abpTemp.Administration;

public abstract class AdministrationController : AbpControllerBase
{
    protected AdministrationController()
    {
        LocalizationResource = typeof(AdministrationResource);
    }
}