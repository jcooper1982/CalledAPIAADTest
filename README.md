This is the Downstream API, corresponding to the upstream API from https://github.com/jcooper1982/CallingAPIAADTest

This API is locked down such that it can only be called by callers which have valid roles over the audience "api://CalledAPIAADTest" corresponding to the valid App Registration linked below.

The way this is enforced is via the AddAuthentication section in the Program class, which refers to the AzureAd section in appsettings.json.  In here we specify the tenant/client/audience details corresponding to the valid CalledAPIAADTest App Registration.  This enforces the expectation for authorized API calls that a valid JWT from this AAD tenant must be issued, it must have a matching audience claim, and it must have valid roles.

There is a CalledAPIAADTest.http file included in this solution.  If you get access to a valid JWT for the upstream API you can use that to call this API directly and test it.  This will work locally as well as against the Azure deployment.


Below are links to the relevant Azure resources
Azure App Service - https://portal.azure.com/#@AITM.onmicrosoft.com/resource/subscriptions/a64d1dd5-1f86-4014-96cd-26f66b3e6db5/resourceGroups/calledapiaadtest_group/providers/Microsoft.Web/sites/CalledAPIAADTest/appServices

Valid App Registration with correct Audience
App Reg - https://portal.azure.com/#view/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/~/Overview/appId/7c8764cb-3b9d-4470-8908-d452af7a01c8/isMSAApp~/false
Enterprise App - https://portal.azure.com/#view/Microsoft_AAD_IAM/ManagedAppMenuBlade/~/Users/objectId/3072fe84-b91d-4657-b715-b39ccbeb46cf/appId/7c8764cb-3b9d-4470-8908-d452af7a01c8/preferredSingleSignOnMode~/null/servicePrincipalType/Application/fromNav/

Invalid App Registration with incorrect Audience
App Reg - https://portal.azure.com/#view/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/~/Overview/appId/b3ca3b95-bdc3-458c-ac0c-18dc769f7992/isMSAApp~/false
Enterprise App - https://portal.azure.com/#view/Microsoft_AAD_IAM/ManagedAppMenuBlade/~/Users/objectId/8fde1b61-1155-462e-bb68-a0b847486ad6/appId/b3ca3b95-bdc3-458c-ac0c-18dc769f7992/preferredSingleSignOnMode~/null/servicePrincipalType/Application/fromNav/