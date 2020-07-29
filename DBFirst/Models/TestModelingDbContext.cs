using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBFirst.Models
{
    public partial class TestModelingDbContext : DbContext
    {
        public TestModelingDbContext()
        {
        }

        public TestModelingDbContext(DbContextOptions<TestModelingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Solutions> Solutions { get; set; }
        public virtual DbSet<TagnQuestions> TagnQuestions { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestModelingDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Content).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_User");

                entity.HasOne(d => d.ForSolution)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ForSolutionId)
                    .HasConstraintName("FK_Comments_Solutions");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.QuestionId).ValueGeneratedNever();

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Solutions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Text).HasMaxLength(50);

                entity.HasOne(d => d.ByUser)
                    .WithMany(p => p.Solutions)
                    .HasForeignKey(d => d.ByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solutions_User");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Solutions)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solutions_Questions");
            });

            modelBuilder.Entity<TagnQuestions>(entity =>
            {
                entity.HasKey(e => new { e.TagId, e.QuestionId });

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TagnQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagnQuestions_Questions1");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagnQuestions)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagnQuestions_Tags");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.Property(e => e.TagId).ValueGeneratedNever();

                entity.Property(e => e.Tag).HasMaxLength(25);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserProfile)
                    .HasForeignKey<UserProfile>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserProfile_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Age).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
