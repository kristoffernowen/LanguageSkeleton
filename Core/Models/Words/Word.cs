namespace Domain.Models.Words
{
    public class Word
    {
        public string Id { get; set; } = null!;
        public string? DisplayForm { get; set; }

        public virtual void SetDisplayForm()
        {
        }
    }
}
