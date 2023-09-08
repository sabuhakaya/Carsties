using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            //changed this section
            new ApiScope("auctionApp", "Auction app full access"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            //removed all methods inside here

            new Client
            {
                ClientId = "postman",
                ClientName = "Postman",
                AllowedScopes =  {"openid", "profile", "auctionApp"},
                RedirectUris = {"https://www.postman.com/oauth2/callback"},
                ClientSecrets = new [] { new Secret("NotASecret".Sha256())},
                AllowedGrantTypes = {GrantType.ResourceOwnerPassword}
            }

        };
}
