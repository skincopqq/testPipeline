﻿using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace abpTemp.SaaS;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SaaSHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class SaaSConsoleApiClientModule : AbpModule
{

}
