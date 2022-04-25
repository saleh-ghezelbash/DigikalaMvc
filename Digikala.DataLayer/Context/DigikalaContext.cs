using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Digikala.DataLayer.Entities;
using Digikala.DataLayer.Entities.Brand;
using Digikala.DataLayer.Entities.Category;
using Digikala.DataLayer.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace Digikala.DataLayer.Context
{
    public class DigikalaContext : DbContext
    {
        public DigikalaContext(DbContextOptions<DigikalaContext> options) : base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandCategory> BrandCategories { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        #region category
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<CategoryRating> CategoryRatings { get; set; }
        #endregion

        #region product
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ProductReviewRating> ProductReviewRatings { get; set; }
        public DbSet<RatingAttribute> RatingAttributes { get; set; }

        #endregion

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
