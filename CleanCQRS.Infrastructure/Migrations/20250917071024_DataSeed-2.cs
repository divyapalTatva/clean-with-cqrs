using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanCQRS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("7f8b2a4d-3c91-4e67-b8f5-2d1a9e6c4b73"), "tatva@tatvasoft.com", "Tatva", "User", "+91 1234567890" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("2e8b4f93-7a1d-4c56-9b38-f4e2a8d6c179"), "Premium business laptop with 15.6\" display, Intel Core i5 processor, 8GB RAM, 256GB SSD. Features enterprise-grade security, long battery life, and durable construction perfect for mobile professionals and remote work scenarios", "HP EliteBook 850 G8 Laptop", 30000m, 10 },
                    { new Guid("a3f7d821-94c6-4b2e-8f15-6d9a3e7c2b84"), "High-performance business desktop computer featuring Intel Core i7 processor, 16GB RAM, 512GB SSD storage. Designed for demanding business applications with enhanced security features and reliable performance for professional workloads", "Dell OptiPlex 7090 Desktop", 10000m, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("7f8b2a4d-3c91-4e67-b8f5-2d1a9e6c4b73"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2e8b4f93-7a1d-4c56-9b38-f4e2a8d6c179"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a3f7d821-94c6-4b2e-8f15-6d9a3e7c2b84"));
        }
    }
}
