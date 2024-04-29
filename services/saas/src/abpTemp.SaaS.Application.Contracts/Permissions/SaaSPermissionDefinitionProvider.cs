﻿using abpTemp.SaaS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace abpTemp.SaaS.Permissions;

public class SaaSPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SaaSPermissions.GroupName, L("Permission:SaaS"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SaaSResource>(name);
    }
}