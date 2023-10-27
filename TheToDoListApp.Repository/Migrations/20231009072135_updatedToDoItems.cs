using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheTodoRepository.Migrations
{
    /// <inheritdoc />
#pragma warning disable IDE1006 // Naming Styles
    public partial class updatedToDoItems : Migration
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedTime",
                table: "ToDoItems",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishedTime",
                table: "ToDoItems");
        }
    }
}
