using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSQApi.Migrations
{
    /// <inheritdoc />
    public partial class madepublicattachments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GunBuildId",
                table: "GunParts",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GunParts_GunBuilds_GunBuildId",
                table: "GunParts");

            migrationBuilder.DropIndex(
                name: "IX_GunParts_GunBuildId",
                table: "GunParts");

            migrationBuilder.DropColumn(
                name: "GunBuildId",
                table: "GunParts");
        }
    }
}
