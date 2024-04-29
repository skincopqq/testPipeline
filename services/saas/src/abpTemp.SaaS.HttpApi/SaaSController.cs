using abpTemp.SaaS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace abpTemp.SaaS;

public abstract class SaaSController : AbpControllerBase
{
    protected SaaSController()
    {
        LocalizationResource = typeof(SaaSResource);
    }
}