using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySystem.API.Migrations
{
    public partial class ProductSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string GetAllProductsSp = 
                @"CREATE OR ALTER PROCEDURE Inventory_Product_GetAll
                    AS
                    BEGIN
                        SELECT * FROM Products;
                    END;";
            
            string GetProductsByIdSp =
                @"";

            string AddProductSp =
                @"";

            string UpdateProductSp =
                @"";

            string DeleteProductSp =
                @"";
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
