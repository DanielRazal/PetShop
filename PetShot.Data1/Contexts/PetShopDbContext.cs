using Microsoft.EntityFrameworkCore;
using PetShop.Data.Models;

namespace PetShop.Data.Contexts
{
    public partial class PetShopDbContext : DbContext
    {
        public PetShopDbContext() { } 

        public PetShopDbContext(DbContextOptions<PetShopDbContext> options): base(options) { }

        public virtual DbSet<Animal> Animals { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Initializes the database with existing data
        {

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK__Comments__Animal__2EDAF651");
            });

            modelBuilder.Entity<Category>(entity =>
            entity.HasData(
             new { CategoryId = 1, Name = "Dogs" },
             new { CategoryId = 2, Name = "Cats" },
             new { CategoryId = 3, Name = "Birds" },
             new { CategoryId = 4, Name = "Rabbits" },
             new { CategoryId = 5, Name = "Hamsters" }
            )
            );

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasData(
                new { AnimalId = 1, Name = "Shoko", BirthDate = DateTime.Now.AddYears(-3).AddMonths(-5).AddDays(1), Description = "Friendly and loyal", CategoryId = 1, PhotoUrl = "ShokoDog.jpg" },
                new { AnimalId = 2, Name = "Bamba", BirthDate = DateTime.Now.AddYears(-2).AddMonths(-2).AddDays(-3), Description = "Furry and neutered", CategoryId = 2, PhotoUrl = "BambaCat.jpg" },
                new { AnimalId = 3, Name = "Regev", BirthDate = DateTime.Now.AddYears(-1).AddMonths(-3).AddDays(-3), Description = "Speak", CategoryId = 3, PhotoUrl = "RegevBird.jpg" },
                new { AnimalId = 4, Name = "Humi",  BirthDate = DateTime.Now.AddYears(-3).AddMonths(-4).AddDays(-7), Description = "Cute and furry", CategoryId = 4, PhotoUrl = "HumiRabbit.jpg" },
                new { AnimalId = 5, Name = "Tommy", BirthDate = DateTime.Now.AddYears(-1).AddMonths(-7).AddDays(-9), Description = "Love to play in the facilities", CategoryId = 5, PhotoUrl = "TommyHamster.jpg" });
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
