using Microsoft.EntityFrameworkCore;

namespace Tree.Models
{
    public class TreesContext : DbContext
    {
        public TreesContext(DbContextOptions<TreesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Plant>()
            .HasData(
                new Plant { PlantId = 2, Strain = "In The Pines", Type = "Sativa", Farm = "GUD Gardens", Description = "This shit right here tho...PHEW buddy. Get ready!"},
                new Plant { PlantId = 3, Strain = "Special Weapon", Type = "Sativa", Farm = "Deep Creek Gardens", Description = "Special Weapon will destroy you."},
                new Plant { PlantId = 4, Strain = "Grape Fluff", Type = "Indica", Farm = "Fox Hollow Flora", Description = "I know what a GRAPE is. What the fuck is a grape FRUIT?"}
            );
        }

        public DbSet<Plant> Plants { get; set; }
    }
}