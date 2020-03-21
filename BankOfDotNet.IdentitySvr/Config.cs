using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace BankOfDotNet.IdentitySvr
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

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

        public static IEnumerable<Client> GetClients() {
            return new List<Client> {
                // Implicit
                new Client() {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    
                    RedirectUris = {
                        "http://localhost:5003/signin-oidc"
                    },
                    PostLogoutRedirectUris = {
                        "http://localhost:5003/signout-callback-oidc"
                    },

                    AllowedScopes = new List<string> {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }
    }
}