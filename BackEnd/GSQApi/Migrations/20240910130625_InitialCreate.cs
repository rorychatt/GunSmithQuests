using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSQApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GunBuilds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EulerAngles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GunBuilds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GunParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EulerAngles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GunParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GunPartContents",
                columns: table => new
                {
                    GunPartId = table.Column<int>(type: "int", nullable: false),
                    ByteArr = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GunPartContents", x => x.GunPartId);
                    table.ForeignKey(
                        name: "FK_GunPartContents_GunParts_GunPartId",
                        column: x => x.GunPartId,
                        principalTable: "GunParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GunBuilds");

            migrationBuilder.DropTable(
                name: "GunPartContents");

            migrationBuilder.DropTable(
                name: "GunParts");
        }
    }
}
