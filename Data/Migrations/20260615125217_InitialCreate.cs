using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nouns",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 36, nullable: false),
                    NounDeclension = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    NounArticle = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    GrammaticalGender = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    SingularForm = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PluralForm = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nouns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Verbs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 36, nullable: false),
                    Infinitive = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Imperative = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PresentTense = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PastTense = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Supine = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    VerbConjugation = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nouns_GrammaticalGender",
                table: "Nouns",
                column: "GrammaticalGender");

            migrationBuilder.CreateIndex(
                name: "IX_Nouns_NounDeclension",
                table: "Nouns",
                column: "NounDeclension");

            migrationBuilder.CreateIndex(
                name: "IX_Nouns_SingularForm",
                table: "Nouns",
                column: "SingularForm");

            migrationBuilder.CreateIndex(
                name: "IX_Nouns_SingularForm_PluralForm",
                table: "Nouns",
                columns: new[] { "SingularForm", "PluralForm" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verbs_Infinitive",
                table: "Verbs",
                column: "Infinitive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nouns");

            migrationBuilder.DropTable(
                name: "Verbs");
        }
    }
}
