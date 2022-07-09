using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogApiProject.Migrations
{
    public partial class subtracks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TrackId",
                table: "Tracks",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_TrackId",
                table: "Tracks",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Tracks_TrackId",
                table: "Tracks",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Tracks_TrackId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_TrackId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "Tracks");
        }
    }
}
