using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GcpBlog.Domain.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Body", "Slug", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec euismod diam quam, at dictum elit tincidunt in.", "angular-11", "Angular 11" },
                    { 2, "Donec posuere iaculis iaculis. Donec pulvinar varius diam, nec tincidunt mauris cursus ut. Quisque fringilla risus dignissim justo ultricies aliquam.", "core", ".NET Core" },
                    { 3, "Vestibulum egestas dapibus elit non facilisis. Maecenas sit amet elit sem. Donec eget placerat mauris. Sed sodales enim nec lacinia sagittis. Etiam at bibendum quam, condimentum commodo est.", "git", "Git Hub" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
