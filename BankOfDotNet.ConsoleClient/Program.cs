using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BankOfDotNet.ConsoleClient
{
    class Program
    {
        static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync() 
        {
            HttpClient client = new HttpClient();

            // *** Resource-Owner flow ***
            var discoRO = await client.GetDiscoveryDocumentAsync("http://localhost:5000"); 
            if(discoRO.IsError)  
            {
                Console.WriteLine(discoRO.Error);
                return;
            }

            var responseRO = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = discoRO.TokenEndpoint,
                ClientId = "ro.client",
                ClientSecret = "secret",
                Scope = "bankOfDotNetApi",
                UserName = "gattoboy",
                Password = "connor"
            });
            if(responseRO.IsError)
            {
                Console.WriteLine(responseRO.Error);
                return;
            }

            Console.WriteLine(responseRO.Json);
            Console.WriteLine("\n\n");

            client.SetBearerToken(responseRO.AccessToken);

            var getCustomerResponseRO = await client.GetAsync("http://localhost:5001/Customers");
            if(!getCustomerResponseRO.IsSuccessStatusCode)
            {
                Console.WriteLine(getCustomerResponseRO.StatusCode);
            }
            else
            {
                var content = await getCustomerResponseRO.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }



            // *** Client-Credentials flow ***

            // // Discover all the endpoints metadata of Identity Server
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000"); 
            if(disco.IsError)  
            {
                Console.WriteLine(disco.Error);
                return;
            }

            // // Grab a bearer token
            // var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            // var tokenResponse = await tokenClient.RequestClientCredentialsTokenAsync("bankOfDotNetApi");

            var response = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "bankOfDotNetApi"
            });
            if(response.IsError)
            {
                Console.WriteLine(response.Error);
                return;
            }
            
            Console.WriteLine(response.Json);
            Console.WriteLine("\n\n");

            client.SetBearerToken(response.AccessToken);

            var customerInfo = new StringContent(
                JsonConvert.SerializeObject(
                    new {
                        FirstName = "Gianni",
                        LastName = "Bossini"
                    }
                ), Encoding.UTF8, "application/json"
            );

            var createCustomerResponse = await client.PostAsync("http://localhost:5001/Customers", customerInfo);
            if(!createCustomerResponse.IsSuccessStatusCode)
            {
                Console.WriteLine(createCustomerResponse.StatusCode);
            }

            var getCustomerResponse = await client.GetAsync("http://localhost:5001/Customers");
            if(!getCustomerResponse.IsSuccessStatusCode)
            {
                Console.WriteLine(getCustomerResponse.StatusCode);
            }
            else
            {
                var content = await getCustomerResponse.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
