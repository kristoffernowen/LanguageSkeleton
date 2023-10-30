using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class verbAndNounEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Infinitive",
                table: "Verbs",
                newName: "BaseForm");

            migrationBuilder.AddColumn<string>(
                name: "PluralForm",
                table: "Nouns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PluralForm",
                table: "Nouns");

            migrationBuilder.RenameColumn(
                name: "BaseForm",
                table: "Verbs",
                newName: "Infinitive");
        }
    }
}
