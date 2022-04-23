using System;
using System.Collections.Generic;
using System.Text;
using Digikala.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Digikala.DataLayer.Context
{
    public class DigikalaContext: DbContext
    {
        public DigikalaContext(DbContextOptions<DigikalaContext> options) : base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
    }
}
