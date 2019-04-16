using System;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ResourceManager;
//using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ServiceBus;
//using Microsoft.Azure.Management.ServiceBus.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;

public static class Management {
        
    private const string AuthenticationContextUrl = "https://login.microsoftonline.com/{tenantId}";
    private const string ResourceAzureUrl = "https://management.core.windows.net/";
    public static async Task CreateResourceGroup(string name) {
        

    }



    private static async Task<AuthenticationResult> GetToken(string tenantId, string clientId, string clientSecret) {

        var context = new AuthenticationContext(AuthenticationContextUrl);
        var tokenResult = await context.AcquireTokenAsync(ResourceAzureUrl, new ClientCredential(clientId, clientSecret));
        return tokenResult ?? throw new Exception("Unable to retrieve access token.");
    }

    public static TokenCredentials CreateTokenCredential(this AuthenticationResult token) {
        return new TokenCredentials(token.AccessToken);
    }

    public static ResourceManagementClient CreateResourceClient(this TokenCredentials credential) {
        return new ResourceManagementClient(credential);
    }

    public static ServiceBusManagementClient Create(this TokenCredentials credential) {
        return new ServiceBusManagementClient(credential);
    }

}