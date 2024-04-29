using abpTemp.SaaS.Localization;
using Volo.Abp.Application.Services;

namespace abpTemp.SaaS;

public abstract class SaaSAppService : ApplicationService
{
    protected SaaSAppService()
    {
        LocalizationResource = typeof(SaaSResource);
        ObjectMapperContext = typeof(SaaSApplicationModule);
    }
}