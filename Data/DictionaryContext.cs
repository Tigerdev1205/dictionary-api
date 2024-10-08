using Microsoft.EntityFrameworkCore;

namespace DictionaryAPI.Data
{
    public class DictionaryContext : DbContext
    {
        public DbSet<DictionaryEntry> Dictionary { get; set; }

        public DictionaryContext(DbContextOptions<DictionaryContext> options) : base(options) { }
    }

    public class DictionaryEntry
    { 
        public int Id { get; set; }
        public required string EnglishWord { get; set; }
        public required string HungarianTranslation { get; set; }
    }
}
