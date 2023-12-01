using Domain.Enums;

namespace Domain.Models.Words;

public class Noun : Word
{
    private readonly INounDisplayFormSetter? _nounDisplayFormSetter;

    public NounDeclension NounDeclension { get; set; }
    public NounArticle NounArticle { get; set; }
    public string SingularForm { get; set; } = null!;
    public string PluralForm { get; set; } = null!;
    public GrammaticalNumber? GrammaticalNumber { get; set; }
    public Definiteness? Definiteness { get; set; }

    public Noun(INounDisplayFormSetter nounDisplayFormSetter)
    {
        _nounDisplayFormSetter = nounDisplayFormSetter;
    }

    public Noun()
    {
        
    }

    public override void SetDisplayForm()
    {
        if (GrammaticalNumber == Enums.GrammaticalNumber.Singular && Definiteness == Enums.Definiteness.Definite)
        {
            DisplayForm =
                _nounDisplayFormSetter.SetForm(SingularForm, NounDeclension, Definiteness, GrammaticalNumber, NounArticle);
        }
        else
        {
            throw new NotImplementedException("investigating behavior for noun display form on domain model");
        }
    }
}