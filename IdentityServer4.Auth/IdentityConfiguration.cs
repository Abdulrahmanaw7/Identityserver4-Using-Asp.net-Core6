using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServer4.Auth
{
    public class IdentityConfiguration
    {
        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new IdentityResource[]
            {
            new IdentityResources.OpenId(),
        new IdentityResources.Profile()


    };
        }

        public static IEnumerable<TestUser> Users()
        {
            return new[]
              {
        new TestUser
        {
            SubjectId = "1",
            Username = "mail@filipekberg.se",
            Password = "password"

        }
            };
        }

        internal static IEnumerable<Client> Clients()
        {
            return new[]
            {

        new Client
        {
            ClientId = "IdentityServer4",
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            AllowedScopes = new [] { "IdentityServer4" }
        },
           new Client
        {
            ClientId = "IdentityServer4_MVC_Implicit",
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedGrantTypes = GrantTypes.Implicit,
            // where to redirect to after login
            RedirectUris = { "https://localhost:44329/signin-oidc" },
            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:44329/signout-callback-oidc" },
              AllowedScopes = new [] {
                  IdentityServerConstants.StandardScopes.OpenId,
                  IdentityServerConstants.StandardScopes.Profile,
                  "IdentityServer4" },
              AllowAccessTokensViaBrowser = true


        },
         new Client
        {
            ClientId = "IdentityServer4_MVC_Code",
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedGrantTypes = GrantTypes.Hybrid,
            // where to redirect to after login
            RedirectUris = { "https://localhost:44329/signin-oidc" },
            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:44329/signout-callback-oidc" },
              AllowedScopes = new [] {
                  IdentityServerConstants.StandardScopes.OpenId,
                  IdentityServerConstants.StandardScopes.Profile,
                  IdentityServerConstants.StandardScopes.Email,
                  "IdentityServer4" },
              AllowOfflineAccess  =true,
              AllowAccessTokensViaBrowser = true


        }


    };
}

public static IEnumerable<ApiScope> ApiScopes =>
new List<ApiScope>
{
        new ApiScope("IdentityServer4", "Identity Server4")
};

public static IEnumerable<ApiResource> ApiResources()
{
    return new[]
    {
                new ApiResource("IdentityServer4", "Identity Server4")
            };
}

    }
}
