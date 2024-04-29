import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'abpTemp',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'http://localhost:8081/',
    redirectUri: baseUrl,
    clientId: 'abpTemp_App',
    clientSecret: '1q2w3e*',
    responseType: 'code',
    scope: 'IdentityService AdministrationService SaasService',
    requireHttps: false,
  },
  apis: {
    default: {
      url: 'http://localhost:7500',
      rootNamespace: 'abpTemp',
    },
  },
} as Environment;
