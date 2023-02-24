using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class chatMessageAddField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "chatMessages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteUserId",
                table: "chatMessages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "chatMessages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InsertUserId",
                table: "chatMessages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "chatMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "chatMessages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateUserId",
                table: "chatMessages",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "chatMessages");

            migrationBuilder.DropColumn(
                name: "DeleteUserId",
                table: "chatMessages");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "chatMessages");

            migrationBuilder.DropColumn(
                name: "InsertUserId",
                table: "chatMessages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "chatMessages");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "chatMessages");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "chatMessages");
        }
    }
}
