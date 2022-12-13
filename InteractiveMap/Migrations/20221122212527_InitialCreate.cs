using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteractiveMap.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SvgCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aud = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    imgWay = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    imgSvg = table.Column<string>(type: "nvarchar(50)", nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audience", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audience");
        }
    }
}


