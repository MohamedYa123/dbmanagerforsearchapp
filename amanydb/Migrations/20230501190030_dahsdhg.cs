using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amanydb.Migrations
{
    /// <inheritdoc />
    public partial class dahsdhg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_positions_users_recordid",
                table: "positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_positions",
                table: "positions");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "searchrecord");

            migrationBuilder.RenameTable(
                name: "positions",
                newName: "file");

            migrationBuilder.RenameIndex(
                name: "IX_positions_recordid",
                table: "file",
                newName: "IX_file_recordid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_searchrecord",
                table: "searchrecord",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_file",
                table: "file",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_file_searchrecord_recordid",
                table: "file",
                column: "recordid",
                principalTable: "searchrecord",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_file_searchrecord_recordid",
                table: "file");

            migrationBuilder.DropPrimaryKey(
                name: "PK_searchrecord",
                table: "searchrecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_file",
                table: "file");

            migrationBuilder.RenameTable(
                name: "searchrecord",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "file",
                newName: "positions");

            migrationBuilder.RenameIndex(
                name: "IX_file_recordid",
                table: "positions",
                newName: "IX_positions_recordid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_positions",
                table: "positions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_positions_users_recordid",
                table: "positions",
                column: "recordid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
