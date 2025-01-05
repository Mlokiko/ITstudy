using ITstudy.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Identity.Client;

namespace ITstudy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Ranks> Ranks { get; set; }
        public DbSet<Threads> Threads { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Opis categori wymagany i nie większy od 255, Name wymagane
            builder.Entity<Categories>()
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder.Entity<Categories>()
                .Property(c => c.Name)
                .IsRequired();

            // Może zadziałal i ustawi datę prawidłowo, trzeba potem to sprawdzić
            builder.Entity<Posts>()
                .Property(c => c.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            // Można ustawić max długość postu tutaj, nwm czy chcemy czy nie, raczej chcemy, ale na jaką wartość?
            // Sprawdzić czy będzie działać z dłuższymi wartościami, tzn, czy tworzy wewnętrznie varchara, text czy co w bazie danych
            builder.Entity<Posts>()
                .Property(c => c.Content)
                .IsRequired();

            // Sprawdzić czy ustawia prawidłowo to 0, na czuja to dałem
            builder.Entity<Posts>()
                .Property(c => c.Edited)
                .IsRequired()
                .HasDefaultValueSql("0");

            // UserId i ThreadID z Posts nie daje tutaj jako required, sprawdzmy czy bez tego działa

            builder.Entity<Ranks>()
                .Property(c => c.Name)
                .IsRequired();

            builder.Entity<Threads>()
                .Property(c => c.Title)
                .IsRequired();

            builder.Entity<Threads>()
                .Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Entity<Users>()
                .Property(c => c.UserName)
                .IsRequired();

            builder.Entity<Users>()
                .Property(c => c.PasswordHash)
                .IsRequired();

            // Jak wymusić żeby było unique?
            builder.Entity<Users>()
                .Property(c => c.Email)
                .IsRequired();

            builder.Entity<Users>()
                .Property(c => c.JoinDate)
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Entity<Users>()
                .Property(c => c.Ranks)
                .IsRequired();
        }
    }
}
