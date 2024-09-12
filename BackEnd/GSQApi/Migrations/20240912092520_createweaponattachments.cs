using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSQApi.Migrations
{
    /// <inheritdoc />
    public partial class createweaponattachments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GunParts_GunBuilds_GunBuildId",
                table: "GunParts");

            migrationBuilder.DropIndex(
                name: "IX_GunParts_GunBuildId",
                table: "GunParts");

            migrationBuilder.DropColumn(
                name: "EulerAngles",
                table: "GunParts");

            migrationBuilder.DropColumn(
                name: "GunBuildId",
                table: "GunParts");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "GunParts");

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EulerAngles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GunBuildId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_GunBuilds_GunBuildId",
                        column: x => x.GunBuildId,
                        principalTable: "GunBuilds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_GunBuildId",
                table: "Attachments",
                column: "GunBuildId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.AddColumn<string>(
                name: "EulerAngles",
                table: "GunParts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GunBuildId",
                table: "GunParts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "GunParts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_GunParts_GunBuildId",
                table: "GunParts",
                column: "GunBuildId");

            migrationBuilder.AddForeignKey(
                name: "FK_GunParts_GunBuilds_GunBuildId",
                table: "GunParts",
                column: "GunBuildId",
                principalTable: "GunBuilds",
                principalColumn: "Id");
        }
    }
}
