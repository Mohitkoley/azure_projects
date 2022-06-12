using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace az204_auth
{
    class Program
    {
        private const string _clientId = "438d3a94-405f-4dc3-9735-3fecaba6bad4";
        private const string _tenantId = "7e9aacc0-700a-48a7-a5e7-2aeee880a8fd";

        public static async Task Main(string[] args)
        {
            
            var app = PublicClientApplicationBuilder
            .Create(_clientId)
            .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
            .WithRedirectUri("http://localhost")
            .Build();

            string[] scopes = { "user.read" };
            
            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();
            Console.WriteLine($"Token:\t{result.AccessToken}");
        }
    }
}
