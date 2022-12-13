using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using InteractiveMap.Models;

namespace InteractiveMap.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new InteractiveMapContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<InteractiveMapContext>>()))
        {
            // Look for any Audiences.
            if (context.Audience.Any())
            {
                return;   // DB has been seeded
            }
            context.Audience.AddRange(
                new Audience
                {
                    SvgCode = "Default",
                    aud = "999",
                    imgWay = "999",
                    imgSvg="999"
                }

            ); ;
            context.SaveChanges();
        }
    }
}