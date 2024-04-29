using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace abpTemp;

[Dependency(ReplaceServices = true)]
public class abpTempBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "abpTemp";
}
