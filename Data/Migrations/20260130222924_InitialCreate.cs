using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    Id = table.Column<string>(type: "nchar(36)", fixedLength: true, maxLength: 36, nullable: false),
                    NounDeclension = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NounArticle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GrammaticalGender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SingularForm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PluralForm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nouns", x => x.Id);
                    table.CheckConstraint("CK_Nouns_PluralForm_NotEmpty", "LEN([PluralForm]) > 0");
                    table.CheckConstraint("CK_Nouns_SingularForm_NotEmpty", "LEN([SingularForm]) > 0");
                });

            migrationBuilder.CreateTable(
                name: "Verbs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nchar(36)", fixedLength: true, maxLength: 36, nullable: false),
                    Infinitive = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Imperative = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PresentTense = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PastTense = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Supine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VerbConjugation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbs", x => x.Id);
                    table.CheckConstraint("CK_Verbs_Imperative_NotEmpty", "LEN([Infinitive]) > 0");
                    table.CheckConstraint("CK_Verbs_Infinitive_NotEmpty", "LEN([Infinitive]) > 0");
                    table.CheckConstraint("CK_Verbs_PastTense_NotEmpty", "LEN([Infinitive]) > 0");
                    table.CheckConstraint("CK_Verbs_PresentTense_NotEmpty", "LEN([PresentTense]) > 0");
                    table.CheckConstraint("CK_Verbs_Supine_NotEmpty", "LEN([Infinitive]) > 0");
                });

            migrationBuilder.InsertData(
                table: "Nouns",
                columns: new[] { "Id", "GrammaticalGender", "NounArticle", "NounDeclension", "PluralForm", "SingularForm" },
                values: new object[,]
                {
                    { "7357f66f-f38e-4f15-b949-3caa228d0b1f", "CommonGender", "en", "Two", "fiskar", "fisk" },
                    { "8a9bb56c-2604-4ae6-8462-f044fa5239dc", "Neuter", "ett", "Five", "brev", "brev" },
                    { "9e1c3f4a-8f4e-4d2a-9f3e-2b6c5d7e8f9a", "CommonGender", "en", "Three", "städer", "stad" },
                    { "a163d3d1-70c1-4dbf-872c-8ebad193d3ef", "Feminine", "en", "One", "flickor", "flicka" },
                    { "b73f8789-958b-4752-9f70-6d1a73794b03", "Masculine", "en", "Two", "pojkar", "pojke" },
                    { "cca1e103-c140-4acf-a7bf-32b14adab539", "CommonGender", "en", "Two", "bilar", "bil" },
                    { "d42ae057-05ce-4f93-9b17-75d2689c06e7", "CommonGender", "en", "Two", "böcker", "bok" },
                    { "f38485c6-be45-4d52-a043-a561ff09467d", "Neuter", "ett", "Four", "hus", "hus" }
                });

            migrationBuilder.InsertData(
                table: "Verbs",
                columns: new[] { "Id", "Imperative", "Infinitive", "PastTense", "PresentTense", "Supine", "VerbConjugation" },
                values: new object[,]
                {
                    { "0fedcba9-8765-4321-0fed-cba987654321", "få", "få", "fick", "får", "fått", "Irregular" },
                    { "12345678-90ab-cdef-1234-567890abcdef", "skriv", "skriva", "skrev", "skriver", "skrivit", "StrongFour" },
                    { "23456789-0abc-def1-2345-67890abcdef1", "flyg", "flyga", "flög", "flyger", "flugit", "StrongFour" },
                    { "34567890-1bcd-ef23-4567-890abcdef123", "bär", "bära", "bar", "bär", "burit", "StrongFour" },
                    { "346bcffa-9f2c-498c-8c5a-0394293b4e4e", "ge", "ge", "gav", "ger", "gett", "StrongFour" },
                    { "3c9d5f4e-2b6a-4f8e-9c3d-1e2f3a4b5c6d", "——EJ TILLÄMPBAR——", "skola", "skulle", "ska", "skolat", "Irregular" },
                    { "45678901-2cde-f345-6789-0abcdef12345", "gråt", "gråta", "grät", "gråter", "gråtit", "StrongFour" },
                    { "56789012-3def-4567-890a-bcdef1234567", "drick", "dricka", "drack", "dricker", "druckit", "StrongFour" },
                    { "5713f1ff-9e9e-40c7-901c-ba992a91608e", "håll", "hålla", "höll", "håller", "hållit", "StrongFour" },
                    { "67890123-4ef5-6789-0abc-def123456789", "kom", "komma", "kom", "kommer", "kommit", "StrongFour" },
                    { "78901234-5f67-890a-bcde-f1234567890a", "var", "vara", "var", "är", "varit", "Irregular" },
                    { "8217bd0f-d1df-4660-b07b-063c33d7f559", "ta", "ta", "tog", "tar", "tagit", "StrongFour" },
                    { "8b0e7e1a-13fb-45b3-9667-ebfbb938e6c6", "prata", "prata", "pratade", "pratar", "pratat", "WeakOne" },
                    { "8e87ea09-a6bf-431c-9559-b5221b14e81b", "ha", "ha", "hade", "har", "haft", "Irregular" },
                    { "9abcdef0-1234-5678-9abc-def012345678", "ljug", "ljuga", "ljög", "ljuger", "ljugit", "StrongFour" },
                    { "a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d", "bo", "bo", "bodde", "bor", "bott", "WeakThree" },
                    { "abcdef12-3456-7890-abcd-ef1234567890", "läs", "läsa", "läste", "läser", "läst", "WeakTwo" },
                    { "d3f5c4e2-2c4b-4f3a-9f3e-2e5f6c7d8e9f", "ät", "äta", "åt", "äter", "ätit", "StrongFour" },
                    { "f4e5d6c7-b8a9-0b1c-2d3e-4f5a6b7c8d9e", "spring", "springa", "sprang", "springer", "sprungit", "StrongFour" },
                    { "fedcba98-7654-3210-fedc-ba9876543210", "sov", "sova", "sov", "sover", "sovit", "StrongFour" }
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
