using IdentityServer4.Models;

namespace AuthService
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScope => new List<ApiScope>
        {
            new ApiScope("api1", "My API")
        };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "api1" }
            }
        };
    }
}
