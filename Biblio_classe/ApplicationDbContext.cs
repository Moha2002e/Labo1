using Microsoft.EntityFrameworkCore;

namespace Biblio_classe
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;Database=TodoDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Task>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Task>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();


            modelBuilder.Entity<User>()
                .Property(u => u.Nom)
                .HasMaxLength(80);


            modelBuilder.Entity<User>()
                .Property(u => u.Prenom)
                .HasMaxLength(80);


            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(100);


            modelBuilder.Entity<User>()
                .Property(u => u.MotDePasse)
                .HasMaxLength(40);


            modelBuilder.Entity<Project>()
                .Property(p => p.Titre)
                .HasMaxLength(100);


            modelBuilder.Entity<Project>()
                .Property(p => p.Description)
                .HasMaxLength(512);


            modelBuilder.Entity<Task>()
                .Property(t => t.Titre)
                .HasMaxLength(100);


            modelBuilder.Entity<Task>()
                .Property(t => t.Description)
                .HasMaxLength(512);


            modelBuilder.Entity<Task>()
                .Property(t => t.Etat)
                .HasMaxLength(50);
        }
    }
}
