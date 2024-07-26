using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskCheckStorage.Migrations
{
    /// <inheritdoc />
    public partial class CreateDateAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "TaskCheck",
                table: "UserTask",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "TaskCheck",
                table: "UserTask");
        }
    }
}
