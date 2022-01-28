using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowersSpot.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FlowersSpot.Infrastructure
{
    public class FlowersSpotContext : IdentityDbContext<AppUser>
    {
        public FlowersSpotContext(DbContextOptions<FlowersSpotContext>options) :base(options)
        {

        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
