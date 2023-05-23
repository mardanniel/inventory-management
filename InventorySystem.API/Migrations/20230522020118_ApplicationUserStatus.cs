using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySystem.API.Migrations
{
    public partial class ApplicationUserStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "147c0de8-847c-4466-ad04-1fc7b563e0c4",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp", "Status" },
                values: new object[] { "d6b32e16-a0fb-4d54-a95d-441303bafa0c", new DateTime(2023, 5, 22, 10, 1, 17, 852, DateTimeKind.Local).AddTicks(6508), "AQAAAAEAACcQAAAAEHe4jZOQ0v2YlLd/Skq+JlIqFOe3+XIFi4CW+yaPmOfjl9ev8Kn9zEow+FiFqSVfcA==", "282904e0-00c1-4bfe-909e-4a3c1ca19a05", true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("40e5c79d-5574-42eb-97af-3855bd512827"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 22, 10, 1, 17, 852, DateTimeKind.Local).AddTicks(6258), new DateTime(2023, 5, 22, 10, 1, 17, 852, DateTimeKind.Local).AddTicks(6272) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6aef3efc-435d-4df1-b8b1-b418b67555a9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 22, 10, 1, 17, 852, DateTimeKind.Local).AddTicks(6276), new DateTime(2023, 5, 22, 10, 1, 17, 852, DateTimeKind.Local).AddTicks(6277) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7801d704-39b0-4bc1-8396-155772b5e094"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 22, 10, 1, 17, 852, DateTimeKind.Local).AddTicks(6278), new DateTime(2023, 5, 22, 10, 1, 17, 852, DateTimeKind.Local).AddTicks(6279) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "147c0de8-847c-4466-ad04-1fc7b563e0c4",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a2202e8-f1e9-4a1c-bd52-d85f45c89901", new DateTime(2023, 5, 18, 16, 24, 16, 118, DateTimeKind.Local).AddTicks(5424), "AQAAAAEAACcQAAAAEP63fxxk5qZmqedHZVY9qPBKHH35WyMe7xNClLAW0s89nP/PH17KLbJ76K258r/k/A==", "b9c53204-8a1e-44b2-8800-37b7378b5460" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("40e5c79d-5574-42eb-97af-3855bd512827"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 18, 16, 24, 16, 118, DateTimeKind.Local).AddTicks(4980), new DateTime(2023, 5, 18, 16, 24, 16, 118, DateTimeKind.Local).AddTicks(4995) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6aef3efc-435d-4df1-b8b1-b418b67555a9"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 18, 16, 24, 16, 118, DateTimeKind.Local).AddTicks(4998), new DateTime(2023, 5, 18, 16, 24, 16, 118, DateTimeKind.Local).AddTicks(4999) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7801d704-39b0-4bc1-8396-155772b5e094"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 18, 16, 24, 16, 118, DateTimeKind.Local).AddTicks(5001), new DateTime(2023, 5, 18, 16, 24, 16, 118, DateTimeKind.Local).AddTicks(5002) });
        }
    }
}
