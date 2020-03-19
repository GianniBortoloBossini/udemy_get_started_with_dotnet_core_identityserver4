using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace BankOfDotNet.IdentitySvr
{
    public class Config
    {
        public static List<TestUser> GetUsers() {
            return new List<TestUser> {
                new TestUser {
                    SubjectId = "100",
                    Username = "greg",
                    Password = "gecko"
                },
                new TestUser {
                    SubjectId = "101",
                    Username = "gattoboy",
                    Password = "connor"
                }
            };
        }

        public static IEnumerable<ApiResource> GetAllApiResources() {
            return new List<ApiResource> {
                new ApiResource("bankOfDotNetApi", "Customer Api for BankOfDotNet")
            };
        }

        public static IEnumerable<Client> GetClients() {
            return new List<Client> {
                // Client-credentials based grant type: 
                // Can be used for
                // - Machine-2-Machine
                // - Trusted resources (within the company M2M communication)
                new Client() {
                    ClientId= "client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={
                        "bankOfDotNetApi"
                    }
                },

                // Resource owner password
                new Client() {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets= {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        "bankOfDotNetApi"
                    }
                }
            };
        }
    }
}