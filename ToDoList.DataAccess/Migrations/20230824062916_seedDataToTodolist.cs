using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedDataToTodolist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "Id", "CreatedDate", "Description", "Name" },
                values: new object[] { 1, new DateTime(2023, 8, 24, 11, 59, 16, 472, DateTimeKind.Local).AddTicks(4817), "create some payment", "Payment Module" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 24, 11, 59, 16, 472, DateTimeKind.Local).AddTicks(4593));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 24, 11, 45, 17, 66, DateTimeKind.Local).AddTicks(1898));
        }
    }
}
