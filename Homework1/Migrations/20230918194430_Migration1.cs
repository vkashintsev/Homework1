using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Homework1.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "eBay");

            migrationBuilder.CreateTable(
                name: "Buyer",
                schema: "eBay",
                columns: table => new
                {
                    buyer_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    buyer_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.buyer_id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "eBay",
                columns: table => new
                {
                    category_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "Salesman",
                schema: "eBay",
                columns: table => new
                {
                    salesman_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    salesman_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesman", x => x.salesman_id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "eBay",
                columns: table => new
                {
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_name = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    salesman_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Product_Category_category_id",
                        column: x => x.category_id,
                        principalSchema: "eBay",
                        principalTable: "Category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Salesman_salesman_id",
                        column: x => x.salesman_id,
                        principalSchema: "eBay",
                        principalTable: "Salesman",
                        principalColumn: "salesman_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "eBay",
                columns: table => new
                {
                    order_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    price = table.Column<long>(type: "bigint", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    buyer_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Order_Buyer_buyer_id",
                        column: x => x.buyer_id,
                        principalSchema: "eBay",
                        principalTable: "Buyer",
                        principalColumn: "buyer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Product_product_id",
                        column: x => x.product_id,
                        principalSchema: "eBay",
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_buyer_id",
                schema: "eBay",
                table: "Order",
                column: "buyer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_product_id",
                schema: "eBay",
                table: "Order",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_category_id",
                schema: "eBay",
                table: "Product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_salesman_id",
                schema: "eBay",
                table: "Product",
                column: "salesman_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order",
                schema: "eBay");

            migrationBuilder.DropTable(
                name: "Buyer",
                schema: "eBay");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "eBay");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "eBay");

            migrationBuilder.DropTable(
                name: "Salesman",
                schema: "eBay");
        }
    }
}
