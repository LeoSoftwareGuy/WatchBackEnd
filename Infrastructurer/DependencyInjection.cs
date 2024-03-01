﻿using System.Collections.Generic;
using System.Security.Claims;
using Application.Support.Interfaces;
using Dating;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Infrastructurer.Files;
using Infrastructurer.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructurer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure( this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddScoped<IUserManager, UserManagerService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
            services.AddTransient<IXmlFileBuilder, XmlFileBuilder>();
            services.AddTransient<IJsonFileBuilder, JsonFileBuilder>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("WatchShopDatabase")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            if (environment.IsEnvironment("Test"))
            {
                services.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
                    {
                        options.Clients.Add(new Client
                        {
                            ClientId = "WatchBackEnd.IntegrationTests",
                            AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
                            ClientSecrets = { new Secret("secret".Sha256()) },
                            AllowedScopes = { "WatchBackEnd.WebUIAPI", "openid", "profile" }
                        });
                    }).AddTestUsers(new List<TestUser>
                    {
                        new TestUser
                        {
                            SubjectId = "f26da293-02fb-4c90-be75-e4aa51e0bb17",
                            Username = "leonid@lobanov",
                            Password = "leoleoleo!",
                            Claims = new List<Claim>
                            {
                                new Claim(JwtClaimTypes.Email, "leonid@lobanov")
                            }
                        }
                    });
            }
            else
            {
                services.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
            }

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}