using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity_Framework.Migrations
{
    public partial class ManyToManyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Materials_MaterialsId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MaterialsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MaterialsId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Materials",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductMaterials",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    MaterialId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMaterials", x => new { x.ProductId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_ProductMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMaterials_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMaterials_MaterialId",
                table: "ProductMaterials",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductMaterials");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Materials");

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialsId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MaterialsId",
                table: "Products",
                column: "MaterialsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Materials_MaterialsId",
                table: "Products",
                column: "MaterialsId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
