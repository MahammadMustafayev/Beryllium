using Beryllium_Back.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beryllium_Back.DAL
{
    public class AppDbcontext:DbContext
    {
        public AppDbcontext(DbContextOptions options):base(options)
        {
        }
        public DbSet<FirstSlider> FirstSliders { get; set; }
    }
}
