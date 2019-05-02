using System;
using LocalMarketplace.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LocalMarketplace.Areas.Identity.IdentityHostingStartup))]
namespace LocalMarketplace.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LocalMarketplaceContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LocalMarketplaceIdentityConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<LocalMarketplaceContext>();
            });
        }
    }
}