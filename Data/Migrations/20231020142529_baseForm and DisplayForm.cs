using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class baseFormandDisplayForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Infinitive",
                table: "Verbs",
                newName: "BaseForm");

            migrationBuilder.AddColumn<string>(
                name: "DisplayForm",
                table: "Verbs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayForm",
                table: "Nouns",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayForm",
                table: "Verbs");

            migrationBuilder.DropColumn(
                name: "DisplayForm",
                table: "Nouns");

            migrationBuilder.RenameColumn(
                name: "BaseForm",
                table: "Verbs",
                newName: "Infinitive");
        }
    }
}
