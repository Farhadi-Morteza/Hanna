using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ActivityProductRelationNN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Activities_ActivityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ActivityId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "CompanyCategories",
                keyColumn: "Id",
                keyValue: new Guid("06685e00-1219-4972-9921-62f198dadff9"));

            migrationBuilder.DeleteData(
                table: "CompanyCategories",
                keyColumn: "Id",
                keyValue: new Guid("1abf45d6-044f-48c6-ae48-16bc2d222b1e"));

            migrationBuilder.DeleteData(
                table: "CompanyCategories",
                keyColumn: "Id",
                keyValue: new Guid("cb51d684-41f0-4365-a769-da810db2b9ef"));

            migrationBuilder.DeleteData(
                table: "CompanyCategories",
                keyColumn: "Id",
                keyValue: new Guid("d221ddf9-42f8-4070-8287-1ea01178b5da"));

            migrationBuilder.DeleteData(
                table: "CompanyCategories",
                keyColumn: "Id",
                keyValue: new Guid("eb4ce414-065d-4b06-bbb5-702a63dc5112"));

            migrationBuilder.DeleteData(
                table: "CompanyTypes",
                keyColumn: "Id",
                keyValue: new Guid("2827342a-0dec-44ca-b7d4-1ae16db9d0b1"));

            migrationBuilder.DeleteData(
                table: "CompanyTypes",
                keyColumn: "Id",
                keyValue: new Guid("3b5f187f-47ab-4c2c-9fd8-8b855554b918"));

            migrationBuilder.DeleteData(
                table: "CompanyTypes",
                keyColumn: "Id",
                keyValue: new Guid("4e4755e4-1c3e-4dfe-b0ac-5d69c3044d1a"));

            migrationBuilder.DeleteData(
                table: "CompanyTypes",
                keyColumn: "Id",
                keyValue: new Guid("669e0470-ce23-49e0-95a8-24e2c69f95b2"));

            migrationBuilder.DeleteData(
                table: "CompanyTypes",
                keyColumn: "Id",
                keyValue: new Guid("87aa7b7f-0f3d-4647-9f19-6136407bebe1"));

            migrationBuilder.DeleteData(
                table: "CompanyTypes",
                keyColumn: "Id",
                keyValue: new Guid("a9c5bc0d-d35b-43f9-bc97-651d02733b99"));

            migrationBuilder.DeleteData(
                table: "CompanyTypes",
                keyColumn: "Id",
                keyValue: new Guid("f1d3bdfd-bb13-4e78-b8bf-08913fc48846"));

            migrationBuilder.DeleteData(
                table: "Culture",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Culture",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("d6e0781e-f92d-4ada-bf86-4943fbf3f42c"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("fce3ea9f-ef52-47c9-a06e-2946f2a955cb"));

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: new Guid("252aec3b-f421-416f-b596-fb8f93014886"));

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: new Guid("c1c3c921-abdf-4257-9e72-693cae9c51e7"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("b91327b3-79b6-40c5-9c52-3e6f6dbacb17"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("f786edaa-921f-413c-9953-7129f2bbe4ea"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("7a4f16a2-1352-41fb-8b2c-09d9ec07c916"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("d8a4c858-7c01-497e-9658-1aa2d832c728"));

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ActivityProduct",
                columns: table => new
                {
                    ActivitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityProduct", x => new { x.ActivitiesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ActivityProduct_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityProduct_ProductsId",
                table: "ActivityProduct",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "ActivityId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "CompanyCategories",
                columns: new[] { "Id", "DeleteDate", "DeleteUserId", "InsertDate", "InsertUserId", "IsDeleted", "Name", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { new Guid("06685e00-1219-4972-9921-62f198dadff9"), null, null, null, null, false, "هلدینگ", null, null },
                    { new Guid("1abf45d6-044f-48c6-ae48-16bc2d222b1e"), null, null, null, null, false, "کشت و صنعت", null, null },
                    { new Guid("cb51d684-41f0-4365-a769-da810db2b9ef"), null, null, null, null, false, "واحد", null, null },
                    { new Guid("d221ddf9-42f8-4070-8287-1ea01178b5da"), null, null, null, null, false, "شرکت", null, null },
                    { new Guid("eb4ce414-065d-4b06-bbb5-702a63dc5112"), null, null, null, null, false, "واحد فرعی", null, null }
                });

            migrationBuilder.InsertData(
                table: "CompanyTypes",
                columns: new[] { "Id", "DeleteDate", "DeleteUserId", "InsertDate", "InsertUserId", "IsDeleted", "Name", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { new Guid("2827342a-0dec-44ca-b7d4-1ae16db9d0b1"), null, null, null, null, false, "سهامی عام", null, null },
                    { new Guid("3b5f187f-47ab-4c2c-9fd8-8b855554b918"), null, null, null, null, false, "سهامی خاص", null, null },
                    { new Guid("4e4755e4-1c3e-4dfe-b0ac-5d69c3044d1a"), null, null, null, null, false, "مختلط سهامی", null, null },
                    { new Guid("669e0470-ce23-49e0-95a8-24e2c69f95b2"), null, null, null, null, false, "مسئولیت محدود", null, null },
                    { new Guid("87aa7b7f-0f3d-4647-9f19-6136407bebe1"), null, null, null, null, false, "مختلط غیرسهامی", null, null },
                    { new Guid("a9c5bc0d-d35b-43f9-bc97-651d02733b99"), null, null, null, null, false, "شرکت نسبی", null, null },
                    { new Guid("f1d3bdfd-bb13-4e78-b8bf-08913fc48846"), null, null, null, null, false, "تضامنی", null, null }
                });

            migrationBuilder.InsertData(
                table: "Culture",
                columns: new[] { "Id", "Language", "LanguageTag", "Location" },
                values: new object[,]
                {
                    { 1, "Persian", "fa-IR", "Iran" },
                    { 2, "English", "en-US", "United State" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DeleteDate", "DeleteUserId", "InsertDate", "InsertUserId", "IsActive", "IsDeleted", "ManagerId", "Name", "Title", "UpdateDate", "UpdateUserId" },
                values: new object[] { new Guid("d8a4c858-7c01-497e-9658-1aa2d832c728"), null, null, null, null, false, false, null, "Charles Montgomery Burns", "Owner", null, null });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "CultrueId", "Name" },
                values: new object[,]
                {
                    { new Guid("252aec3b-f421-416f-b596-fb8f93014886"), null, "فرعی" },
                    { new Guid("c1c3c921-abdf-4257-9e72-693cae9c51e7"), null, "اصلی" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DeleteDate", "DeleteUserId", "InsertDate", "InsertUserId", "IsActive", "IsDeleted", "ManagerId", "Name", "Title", "UpdateDate", "UpdateUserId" },
                values: new object[] { new Guid("7a4f16a2-1352-41fb-8b2c-09d9ec07c916"), null, null, null, null, false, false, new Guid("d8a4c858-7c01-497e-9658-1aa2d832c728"), "Waylon Smithers, Jr.", "Assistant", null, null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DeleteDate", "DeleteUserId", "InsertDate", "InsertUserId", "IsActive", "IsDeleted", "ManagerId", "Name", "Title", "UpdateDate", "UpdateUserId" },
                values: new object[] { new Guid("f786edaa-921f-413c-9953-7129f2bbe4ea"), null, null, null, null, false, false, new Guid("7a4f16a2-1352-41fb-8b2c-09d9ec07c916"), "Carl Carlson", "Safety Operations Supervisor", null, null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DeleteDate", "DeleteUserId", "InsertDate", "InsertUserId", "IsActive", "IsDeleted", "ManagerId", "Name", "Title", "UpdateDate", "UpdateUserId" },
                values: new object[] { new Guid("fce3ea9f-ef52-47c9-a06e-2946f2a955cb"), null, null, null, null, false, false, new Guid("7a4f16a2-1352-41fb-8b2c-09d9ec07c916"), "Lenny Leonard", "Technical Supervisor", null, null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DeleteDate", "DeleteUserId", "InsertDate", "InsertUserId", "IsActive", "IsDeleted", "ManagerId", "Name", "Title", "UpdateDate", "UpdateUserId" },
                values: new object[] { new Guid("b91327b3-79b6-40c5-9c52-3e6f6dbacb17"), null, null, null, null, false, false, new Guid("f786edaa-921f-413c-9953-7129f2bbe4ea"), "Inanimate Carbon Rod", "Rod", null, null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DeleteDate", "DeleteUserId", "InsertDate", "InsertUserId", "IsActive", "IsDeleted", "ManagerId", "Name", "Title", "UpdateDate", "UpdateUserId" },
                values: new object[] { new Guid("d6e0781e-f92d-4ada-bf86-4943fbf3f42c"), null, null, null, null, false, false, new Guid("b91327b3-79b6-40c5-9c52-3e6f6dbacb17"), "Homer Simpson", "Safety Inspector", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ActivityId",
                table: "Products",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Activities_ActivityId",
                table: "Products",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
