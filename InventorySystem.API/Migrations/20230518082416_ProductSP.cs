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
                @"CREATE OR ALTER PROCEDURE Inventory_Product_GetById(@Id UNIQUEIDENTIFIER)
                    AS
                    BEGIN
	                    SELECT * FROM Products WHERE Id = @Id;
                    END;";

            string AddProductSp =
                @"CREATE OR ALTER PROCEDURE Inventory_Product_Create(@Name VARCHAR(256),
										                              @Price Float(25),
										                              @Description VARCHAR(256),
										                              @Status INT,
										                              @CreatedAt DATETIME,
										                              @UpdatedAt DATETIME)
                    AS
                    BEGIN
	                    INSERT INTO Products(Id, Name, Price, Description, Status, CreatedAt, UpdatedAt)
	                    VALUES(NEWID(), @Name, @Price, @Description, @Status, @CreatedAt, @UpdatedAt)
                    END;";

            string UpdateProductSp =
                @"CREATE OR ALTER PROCEDURE Inventory_Product_Update(@Id UNIQUEIDENTIFIER,
													                    @Name VARCHAR(256),
													                    @Price Float(25),
													                    @Description VARCHAR(256),
													                    @Status INT,
													                    @CreatedAt DATETIME,
													                    @UpdatedAt DATETIME)
                    AS
                    BEGIN
	                    UPDATE Products
	                    SET Name = @Name, 
		                    Price = @Price, 
		                    Description = @Description, 
		                    Status = @Status, 
		                    CreatedAt = @CreatedAt, 
		                    UpdatedAt = @UpdatedAt
	                    WHERE Id = @Id;
                    END;";

            string DeleteProductSp =
                @"CREATE OR ALTER PROCEDURE Inventory_Product_DeleteById(@Id UNIQUEIDENTIFIER)
                    AS
                    BEGIN
	                    DELETE FROM Products
	                    WHERE Id = @Id;
                    END;";

            migrationBuilder.Sql(GetAllProductsSp);
            migrationBuilder.Sql(GetProductsByIdSp);
            migrationBuilder.Sql(AddProductSp);
            migrationBuilder.Sql(UpdateProductSp);
            migrationBuilder.Sql(DeleteProductSp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string GetAllProductsSp = "DROP PROCEDURE Inventory_Product_GetAll";
            string GetProductsByIdSp = "DROP PROCEDURE Inventory_Product_GetById";
            string AddProductSp = "DROP PROCEDURE Inventory_Product_Create";
            string UpdateProductSp = "DROP PROCEDURE Inventory_Product_Update";
            string DeleteProductSp = "DROP PROCEDURE Inventory_Product_Delete"; 

            migrationBuilder.Sql(GetAllProductsSp);
            migrationBuilder.Sql(GetProductsByIdSp);
            migrationBuilder.Sql(AddProductSp);
            migrationBuilder.Sql(UpdateProductSp);
            migrationBuilder.Sql(DeleteProductSp);
        }
    }
}
