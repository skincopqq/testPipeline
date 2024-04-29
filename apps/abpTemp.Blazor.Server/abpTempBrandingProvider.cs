using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace abpTemp.Blazor.Server;

[Dependency(ReplaceServices = true)]
public class abpTempBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "abpTemp";
}
