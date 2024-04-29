using abpTemp.IdentityService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace abpTemp.IdentityService;

public abstract class IdentityServiceController : AbpControllerBase
{
    protected IdentityServiceController()
    {
        LocalizationResource = typeof(IdentityServiceResource);
    }
}