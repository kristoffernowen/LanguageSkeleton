using Domain.Enums.Noun;
using Domain.Models.ValueObjects;

namespace Domain.Test
{
    public class NounTest
    {

        //should i go all in and do tdd for all noun declensions and their rules?
        [Fact]
        public void Noun_Ending_With_Vowel_Should_Should_Get_N_Added_To_End_For_Singular_Definite()
        {
            var noun = new Noun(
                nounDeclension: NounDeclension.One,
                grammaticalGender: GrammaticalGender.Feminine,
                nounArticle: NounArticle.en,
                singularForm: "flicka",
                pluralForm: "flickor");

            var nounForm = noun.Inflect(
                grammaticalNumber: GrammaticalNumber.Singular,
                definiteness: Definiteness.Definite,
                grammaticalCase: GrammaticalCase.Nominative);

            Assert.Equal("flickan", nounForm.SurfaceForm);
        }

        [Fact]
        public void Non_Neuter_Noun_Ending_With_Consonant_Should_Should_Get_En_Added_To_End_For_Singular_Definite()
        {
            var noun = new Noun(
                nounDeclension: NounDeclension.Two,
                nounArticle: NounArticle.en,
                grammaticalGender: GrammaticalGender.CommonGender,
                singularForm: "hund",
                pluralForm: "hundar");
               
            var nounForm = noun.Inflect(
                grammaticalNumber: GrammaticalNumber.Singular,
                definiteness: Definiteness.Definite,
                grammaticalCase: GrammaticalCase.Nominative);
            Assert.Equal("hunden", nounForm.SurfaceForm);
        }

        [Theory]
        [InlineData("bok", "boken")]
        [InlineData("stad", "staden")]
        public void Noun_Declension_Three_Should_Get_En_Added_To_End_For_Singular_Definite(string singularForm, string expectedForm)
        {
            var noun = new Noun(
                nounDeclension: NounDeclension.Three,
                nounArticle: NounArticle.en,
                grammaticalGender: GrammaticalGender.CommonGender,
                singularForm: singularForm,
                pluralForm: "böcker");
               
            var nounForm = noun.Inflect(
                grammaticalNumber: GrammaticalNumber.Singular,
                definiteness: Definiteness.Definite,
                grammaticalCase: GrammaticalCase.Nominative);
            Assert.Equal(expectedForm, nounForm.SurfaceForm);
        }

        [Theory]
        [InlineData("äpple", "äpplet")]
        [InlineData("hus", "huset")]
        public void Neuter_Noun_Declension_Four_Should_Get_Et_Added_To_End_For_Singular_Definite(string singularForm, string expectedForm)
        {
            var noun = new Noun(
                nounDeclension: NounDeclension.Four,
                grammaticalGender: GrammaticalGender.Neuter,
                nounArticle: NounArticle.ett,
                singularForm: singularForm,
                pluralForm: "äpplen"); //notice this is not used in the test
                
            var nounForm = noun.Inflect(
                grammaticalNumber: GrammaticalNumber.Singular,
                definiteness: Definiteness.Definite,
                grammaticalCase: GrammaticalCase.Nominative);
            Assert.Equal(expectedForm, nounForm.SurfaceForm);
        }

        [Fact]
        public void Noun_Declension_Five_Should_Get_Same_Form_In_Indefinite_Singular_And_Plural()
        {
            var noun = new Noun(
                nounDeclension: NounDeclension.Five,
                grammaticalGender: GrammaticalGender.Neuter,
                nounArticle: NounArticle.ett,
                singularForm: "glas",
                pluralForm: "glas");

            var nounForm = noun.Inflect(
                grammaticalNumber: GrammaticalNumber.Singular,
                definiteness: Definiteness.Indefinite,
                grammaticalCase: GrammaticalCase.Nominative);

            var nounFormTwo = noun.Inflect(
                grammaticalNumber: GrammaticalNumber.Plural,
                definiteness: Definiteness.Indefinite,
                grammaticalCase: GrammaticalCase.Nominative);

            Assert.Equal(nounFormTwo.SurfaceForm, nounForm.SurfaceForm);
        }
    }
}
