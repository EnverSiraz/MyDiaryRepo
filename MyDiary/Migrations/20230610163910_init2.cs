using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDiary.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createTime",
                table: "diaries");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "diaries",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "body",
                table: "diaries",
                newName: "Body");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "diaries",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "diaries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "diaries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "diaries",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "diaries",
                newName: "body");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "diaries",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "diaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "body",
                table: "diaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createTime",
                table: "diaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
