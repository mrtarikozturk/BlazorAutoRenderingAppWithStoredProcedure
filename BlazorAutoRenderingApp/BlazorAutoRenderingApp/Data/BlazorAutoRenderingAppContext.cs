using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorAutoRenderingApp.Models;

namespace BlazorAutoRenderingApp.Data
{
    public class BlazorAutoRenderingAppContext : DbContext
    {
        public BlazorAutoRenderingAppContext (DbContextOptions<BlazorAutoRenderingAppContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorAutoRenderingApp.Models.Student> Student { get; set; } = default!;
    }
}
