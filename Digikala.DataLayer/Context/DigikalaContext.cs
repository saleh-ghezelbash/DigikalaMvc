using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digikala.DataLayer.Entities;
using Digikala.DataLayer.Entities.Brand;
using Digikala.DataLayer.Entities.Category;
using Microsoft.EntityFrameworkCore;

namespace Digikala.DataLayer.Context
{
    public class DigikalaContext: DbContext
    {
        public DigikalaContext(DbContextOptions<DigikalaContext> options) : base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandCategory> BrandCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
