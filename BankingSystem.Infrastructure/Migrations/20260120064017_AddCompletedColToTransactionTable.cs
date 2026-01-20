using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCompletedColToTransactionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "Transactions",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "Transactions");
        }
    }
}
