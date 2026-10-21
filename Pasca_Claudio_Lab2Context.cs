using Microsoft.EntityFrameworkCore;
using Pasca_Claudio_Lab2.Models;

namespace Pasca_Claudio_Lab2.Data
{
    public class Pasca_Claudio_Lab2Context : DbContext
    {
        public DbSet<Pasca_Claudio_Lab2.Models.Category> Category { get; set; } = default!;
        public Pasca_Claudio_Lab2Context(DbContextOptions<Pasca_Claudio_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Pasca_Claudio_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Pasca_Claudio_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Pasca_Claudio_Lab2.Models.Author> Author { get; set; } = default!;
    }
}