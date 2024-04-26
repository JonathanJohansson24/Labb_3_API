using Labb_3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_3_API.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PersonInterest>()                   // Deklarera primary keyn i personinterest blir en unik kombination av person och interest
                .HasKey(pi => pi.PersonInterestId);

            modelBuilder.Entity<PersonInterest>()               // En person kan ha många personinterest
                .HasOne(pi => pi.Person)
                .WithMany(p => p.PersonInterests)
                .HasForeignKey(pi => pi.PerId);

            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Interest)
                .WithMany(i => i.PersonInterests)
                .HasForeignKey(pi => pi.InterestId);

            modelBuilder.Entity<Link>()
                .HasKey(l => l.LiId);

            modelBuilder.Entity<Link>()
                .HasOne(l => l.PersonInterest)
                .WithMany(pi => pi.Links)
                .HasForeignKey(l => l.PersonInterestId);
            // Seed data
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Anna Andersson", PhoneNumber = "0731234567" },
                new Person { Id = 2, Name = "Berit Bengtsson", PhoneNumber = "0741234568" }
                );
            modelBuilder.Entity<Interest>().HasData(
                new Interest { IntId = 1, Title = "Fotografering", Description = "Konsten att fånga ögonblicket" },
                new Interest { IntId = 2, Title = "Programmering", Description = "Utveckling av programvara och applikationer" }
                );
            modelBuilder.Entity<PersonInterest>().HasData(
                new PersonInterest { PersonInterestId = 1, PerId = 1, InterestId = 1 },
                new PersonInterest { PersonInterestId = 2, PerId = 1, InterestId = 2 },
                new PersonInterest { PersonInterestId = 3, PerId = 2, InterestId = 2 }
                );

            modelBuilder.Entity<Link>().HasData(
                new Link { LiId = 1, URL = "https://pixabay.com/sv/", PersonInterestId = 1 },
                new Link { LiId = 2, URL = "https://www.freecodecamp.org/", PersonInterestId = 2 },
                new Link { LiId = 3, URL = "https://www.iamtimcorey.com/", PersonInterestId = 3 }
            );

        }
    }
}
