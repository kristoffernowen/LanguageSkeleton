namespace Domain.Models.Words
{
    public abstract class Word
    {
        public string Id { get; set; } = null!;
        public string? DisplayForm { get; set; }

        public virtual void ArrangeDisplayForm(){}
    }
}
