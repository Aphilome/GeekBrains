using FullSearchSamples.Entity;
using Microsoft.EntityFrameworkCore;

namespace FullSearchSamples
{
    public class DocumentDbContext : DbContext
    {
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<WordDocument> WordDocuments { get; set; }
        public DocumentDbContext(DbContextOptions options) : base(options) { }

    }
}
