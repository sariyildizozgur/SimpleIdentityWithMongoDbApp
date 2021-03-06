// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace SimpleIdentityWithMongoDbApp
{
    
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.Email(),
                       new IdentityResources.OpenId(),
                       new IdentityResources.Profile(),
                       new IdentityResource(){ Name="roles", DisplayName="Roles", Description="Kullanıcı rolleri", UserClaims=new []{ "role"}}
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { new ApiScope("catalog_fullpermission","Catalog API full access"),
                new ApiScope("photo_stock_fullpermission","Photo Stock API full access"),
                     new ApiScope("basket_fullpermission","Basket API  full access"),
                            new ApiScope("discount_fullpermission","Discount API full access"),
                             new ApiScope("order_fullpermission","Order API için full access"),
                                 new ApiScope("payment_fullpermission","Payment API için full access"),
                                   new ApiScope("gateway_fullpermission","Gateway API için full access"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)};

        public static IEnumerable<Client> Clients =>
            new Client[] 
            { new Client
                {
                   ClientName="Asp.Net Core MVC",
                    ClientId="WebMvcClient",
                    ClientSecrets= {new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes={ "catalog_fullpermission","photo_stock_fullpermission", "gateway_fullpermission", IdentityServerConstants.LocalApi.ScopeName }
                },
                new Client
                {
                   ClientName="Asp.Net Core MVC",
                    ClientId="WebMvcClientForUser",
                    AllowOfflineAccess=true,
                    ClientSecrets= {new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                    AllowedScopes={ "basket_fullpermission", "order_fullpermission", "gateway_fullpermission", IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile, IdentityServerConstants.StandardScopes.OfflineAccess, IdentityServerConstants.LocalApi.ScopeName,"roles" },
                    AccessTokenLifetime=1*60*60,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime= (int) (DateTime.Now.AddDays(60)- DateTime.Now).TotalSeconds,
                    RefreshTokenUsage= TokenUsage.ReUse
                }};
    }
}