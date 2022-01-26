using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowersSpot.Models;

namespace FlowersSpot.Infrastructure
{
    public class FlowersSpotContext : DbContext
    {
        public FlowersSpotContext(DbContextOptions<FlowersSpotContext>options) :base(options)
        {

        }

        public DbSet<Page> Pages { get; set; }

    }
}
