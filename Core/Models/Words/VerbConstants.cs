namespace Domain.Models.Words;

/// <summary>
/// Constants for verb forms that are not applicable in Swedish grammar.
/// Example: Modal verbs like "ska" (shall) do not have imperative form.
/// </summary>
public static class VerbConstants
{
    /// <summary>
    /// Sentinel value indicating the verb form does not exist in Swedish.
    /// Using em dash (—) for visual distinction.
    /// </summary>
    public const string NotApplicable = "——EJ TILLÄMPBAR——";


    /// <summary>
    /// Checks if a verb form is marked as not applicable.
    /// </summary>
    public static bool IsNotApplicable(string? form)
    {
        return string.IsNullOrWhiteSpace(form) ||
               form == NotApplicable;
    }
}