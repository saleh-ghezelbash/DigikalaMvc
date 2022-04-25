using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Digikala.DataLayer.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaTitle = table.Column<string>(maxLength: 300, nullable: false),
                    EnTitle = table.Column<string>(maxLength: 300, nullable: false),
                    CreteDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    ImgName = table.Column<string>(maxLength: 100, nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    BrandID = table.Column<int>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    OtherTitleForSearch = table.Column<string>(maxLength: 500, nullable: true),
                    MainPrice = table.Column<int>(nullable: true),
                    PromotionPrice = table.Column<int>(nullable: true),
                    PromotionEndDate = table.Column<DateTime>(nullable: true),
                    DiscountType = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RatingAttributes",
                columns: table => new
                {
                    RatingAttributeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingAttributes", x => x.RatingAttributeId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryId);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgName = table.Column<string>(maxLength: 100, nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageId);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    ProductReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Summary = table.Column<string>(maxLength: 2000, nullable: true),
                    ShortReview = table.Column<string>(maxLength: 2000, nullable: true),
                    Review = table.Column<string>(nullable: true),
                    Positive = table.Column<string>(maxLength: 500, nullable: true),
                    Negative = table.Column<string>(maxLength: 500, nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.ProductReviewId);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryRatings",
                columns: table => new
                {
                    CategoryRatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    RatingAttributeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRatings", x => x.CategoryRatingId);
                    table.ForeignKey(
                        name: "FK_CategoryRatings_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryRatings_RatingAttributes_RatingAttributeId",
                        column: x => x.RatingAttributeId,
                        principalTable: "RatingAttributes",
                        principalColumn: "RatingAttributeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviewRatings",
                columns: table => new
                {
                    ProductReviewRatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    RatingAttributeId = table.Column<int>(nullable: false),
                    Value = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviewRatings", x => x.ProductReviewRatingId);
                    table.ForeignKey(
                        name: "FK_ProductReviewRatings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductReviewRatings_RatingAttributes_RatingAttributeId",
                        column: x => x.RatingAttributeId,
                        principalTable: "RatingAttributes",
                        principalColumn: "RatingAttributeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRatings_CategoryId",
                table: "CategoryRatings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRatings_RatingAttributeId",
                table: "CategoryRatings",
                column: "RatingAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewRatings_ProductId",
                table: "ProductReviewRatings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviewRatings_RatingAttributeId",
                table: "ProductReviewRatings",
                column: "RatingAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandID",
                table: "Products",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryRatings");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductReviewRatings");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "RatingAttributes");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
