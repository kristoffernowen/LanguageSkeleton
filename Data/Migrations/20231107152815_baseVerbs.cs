using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class baseVerbs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Verbs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Imperative = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PresentTense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerbConjugation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    verb_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Infinitive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PastTense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VowelChangeGroup = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseVerbs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verbs");
        }
    }
}
