using IdentityServer4.Models;
using System.Collections.Generic;

namespace AuthService
{
    public class Config
    {
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("UJournalDAL", "UJournalDAL students data access layer")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };
        }
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource> 
            {
                new ApiResource("UJournalDAL", "Student API for UJournal")
            };
        } 

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>{
                new Client()
                {
                    ClientId ="client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "UJournalDAL" }
                }
            };
        }
    }
}
