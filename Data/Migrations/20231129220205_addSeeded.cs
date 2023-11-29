using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nouns",
                columns: new[] { "Id", "NounArticle", "NounDeclension", "PluralForm", "SingularForm" },
                values: new object[,]
                {
                    { "7357f66f-f38e-4f15-b949-3caa228d0b1f", 0, 1, "fiskar", "fisk" },
                    { "a163d3d1-70c1-4dbf-872c-8ebad193d3ef", 0, 0, "flickor", "flicka" },
                    { "b73f8789-958b-4752-9f70-6d1a73794b03", 0, 1, "pojkar", "pojke" },
                    { "cca1e103-c140-4acf-a7bf-32b14adab539", 0, 1, "bilar", "bil" },
                    { "d42ae057-05ce-4f93-9b17-75d2689c06e7", 0, 1, "böcker", "bok" }
                });

            migrationBuilder.InsertData(
                table: "Verbs",
                columns: new[] { "Id", "Imperative", "PresentTense", "VerbConjugation", "verb_type" },
                values: new object[,]
                {
                    { "5d4385e4-39ab-458f-bad9-f217c08bdb86", "prata", "pratar", "ArVerb", "Weak" },
                    { "81fbd7fb-0bff-4905-9ede-98290b3e0485", "bo", "bor", "RVerb", "Short" }
                });

            migrationBuilder.InsertData(
                table: "Verbs",
                columns: new[] { "Id", "Imperative", "Infinitive", "PastTense", "PresentTense", "Supine", "VerbConjugation", "verb_type" },
                values: new object[,]
                {
                    { "99eaf871-c042-4fec-9440-384f00e3f54d", "var", "vara", "var", "är", "varit", "IrregularVerb", "Irregular" },
                    { "cfc483f6-ce2b-49cf-bc8b-d092dcc83027", "ha", "ha", "hade", "har", "haft", "IrregularVerb", "Irregular" }
                });

            migrationBuilder.InsertData(
                table: "Verbs",
                columns: new[] { "Id", "Imperative", "PresentTense", "VerbConjugation", "verb_type" },
                values: new object[] { "f61fa1fa-b3ea-4c02-ad5f-9da466c07d11", "läs", "läser", "ErVerb", "Weak" });

            migrationBuilder.InsertData(
                table: "Verbs",
                columns: new[] { "Id", "Imperative", "Infinitive", "PastTense", "PresentTense", "Supine", "VerbConjugation", "verb_type" },
                values: new object[] { "fe7fc830-0d37-4f0f-a96d-be258253cee0", "ska", "skola", "skulle", "ska", "skolat", "IrregularVerb", "Irregular" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nouns",
                keyColumn: "Id",
                keyValue: "7357f66f-f38e-4f15-b949-3caa228d0b1f");

            migrationBuilder.DeleteData(
                table: "Nouns",
                keyColumn: "Id",
                keyValue: "a163d3d1-70c1-4dbf-872c-8ebad193d3ef");

            migrationBuilder.DeleteData(
                table: "Nouns",
                keyColumn: "Id",
                keyValue: "b73f8789-958b-4752-9f70-6d1a73794b03");

            migrationBuilder.DeleteData(
                table: "Nouns",
                keyColumn: "Id",
                keyValue: "cca1e103-c140-4acf-a7bf-32b14adab539");

            migrationBuilder.DeleteData(
                table: "Nouns",
                keyColumn: "Id",
                keyValue: "d42ae057-05ce-4f93-9b17-75d2689c06e7");

            migrationBuilder.DeleteData(
                table: "Verbs",
                keyColumn: "Id",
                keyValue: "5d4385e4-39ab-458f-bad9-f217c08bdb86");

            migrationBuilder.DeleteData(
                table: "Verbs",
                keyColumn: "Id",
                keyValue: "81fbd7fb-0bff-4905-9ede-98290b3e0485");

            migrationBuilder.DeleteData(
                table: "Verbs",
                keyColumn: "Id",
                keyValue: "99eaf871-c042-4fec-9440-384f00e3f54d");

            migrationBuilder.DeleteData(
                table: "Verbs",
                keyColumn: "Id",
                keyValue: "cfc483f6-ce2b-49cf-bc8b-d092dcc83027");

            migrationBuilder.DeleteData(
                table: "Verbs",
                keyColumn: "Id",
                keyValue: "f61fa1fa-b3ea-4c02-ad5f-9da466c07d11");

            migrationBuilder.DeleteData(
                table: "Verbs",
                keyColumn: "Id",
                keyValue: "fe7fc830-0d37-4f0f-a96d-be258253cee0");
        }
    }
}
