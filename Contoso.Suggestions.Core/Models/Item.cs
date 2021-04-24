namespace Contoso.Suggestions.Core.Models
{
    public class Item : BaseModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}