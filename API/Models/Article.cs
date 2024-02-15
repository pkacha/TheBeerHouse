namespace API.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public DateOnly AddedDate { get; set; }
        public string AddedBy { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public DateOnly? ExpireDate { get; set; }
        public bool Approved { get; set; }
        public bool Listed { get; set; }
        public bool CommentsEnabled { get; set; }
        public bool OnlyForMembers { get; set; }
        public int ViewCount { get; set; }
        public int Votes { get; set; }
        public int TotalRating { get; set; }
        public Category Category { get; set; }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>The location.</value>
        public string Location
        {
            get
            {
                string city = this.City ?? String.Empty;
                string state = this.State ?? String.Empty;
                string country = this.Country ?? String.Empty;

                string location = city.Split(';')[0];
                if (state.Length > 0)
                {
                    if (location.Length > 0)
                        location += ", ";
                    location += state.Split(';')[0];
                }
                if (country.Length > 0)
                {
                    if (location.Length > 0)
                        location += ", ";
                    location += country.Split(';')[0];
                }
                return location;
            }
        }

        /// <summary>
        /// Gets the average rating.
        /// </summary>
        /// <value>The average rating.</value>
        public double AverageRating
        {
            get
            {
                if (this.Votes >= 1)
                    return ((double)this.TotalRating / (double)this.Votes);
                else
                    return 0D;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Article"/> is published.
        /// </summary>
        /// <value><c>true</c> if published; otherwise, <c>false</c>.</value>
        public bool Published
        {
            get
            {
                var currentDateOnly = DateOnly.FromDateTime(DateTime.Now);
                return (this.Approved && this.ReleaseDate <= currentDateOnly && this.ExpireDate > currentDateOnly);
            }
        }

        /// <summary>
        /// Increments the view count.
        /// </summary>
        public void IncrementViewCount()
        {
            this.ViewCount++;
        }

        /// <summary>
        /// Rates the specified rating.
        /// </summary>
        /// <param name="rating">The rating.</param>
        /// <returns></returns>
        public void Rate(int rating)
        {
            this.Votes++;
            this.TotalRating += rating;
        }
    }
}