
#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Forum.App.Data.Migrations;

using System;

using Microsoft.EntityFrameworkCore.Migrations;

/// <inheritdoc />
public partial class CreateAndSeedDb : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Posts",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Posts", x => x.Id);
            });

        migrationBuilder.InsertData(
            table: "Posts",
            columns: new[] { "Id", "Content", "Title" },
            values: new object[,]
            {
                { new Guid("03741c5a-0190-4b02-9f26-1161b2cf6edc"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean elementum rhoncus nunc sed ullamcorper. Sed sed urna pellentesque, placerat augue.", "My first post" },
                { new Guid("29e0f3dd-d731-43a0-93e0-0b65e95fcfa6"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In faucibus nunc nec augue congue tincidunt. Donec tristique, leo sollicitudin dignissim.", "My third post" },
                { new Guid("b8739324-c93a-4a69-aa1e-9d235a2c0279"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ut enim non nibh euismod pretium. Ut malesuada nulla ut mattis.", "My second post" }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Posts");
    }
}