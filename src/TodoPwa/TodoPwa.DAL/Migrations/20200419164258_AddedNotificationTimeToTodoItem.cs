using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoPwa.DAL.Migrations
{
    public partial class AddedNotificationTimeToTodoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NotificationTime",
                table: "TodoItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationTime",
                table: "TodoItems");
        }
    }
}
