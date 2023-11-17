using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class changeBaseVerbsToVerbs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseVerbs",
                table: "BaseVerbs");

            migrationBuilder.RenameTable(
                name: "BaseVerbs",
                newName: "Verbs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verbs",
                table: "Verbs",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Verbs",
                table: "Verbs");

            migrationBuilder.RenameTable(
                name: "Verbs",
                newName: "BaseVerbs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseVerbs",
                table: "BaseVerbs",
                column: "Id");
        }
    }
}
