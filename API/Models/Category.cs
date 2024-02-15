namespace API.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public DateOnly AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Title { get; set; }
        public int Importance { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}