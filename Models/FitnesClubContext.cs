using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FitnesClubEF.Models
{
    public partial class FitnesClubContext : DbContext
    {
        public FitnesClubContext()
        {
        }

        public FitnesClubContext(DbContextOptions<FitnesClubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Name> Names { get; set; }
        public virtual DbSet<Npuxog> Npuxogs { get; set; }
        public virtual DbSet<Pacxog> Pacxogs { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<SectionVisitor> SectionVisitors { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FitnesClub;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Instructors)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Instructo__Secti__37A5467C");
            });

            modelBuilder.Entity<Name>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Npuxog>(entity =>
            {
                entity.ToTable("npuxog");

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((1000.0))");

                entity.Property(e => e.When)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.Npuxogs)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__npuxog__VisitorI__38996AB5");
            });

            modelBuilder.Entity<Pacxog>(entity =>
            {
                entity.ToTable("Pacxog");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.When)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.Pacxogs)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pacxog__VisitorI__398D8EEE");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.SectionTitle)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SectionVisitor>(entity =>
            {
                entity.HasKey(e => new { e.SectionId, e.VisitorId })
                    .HasName("PK__SectionV__1BFD128A290C4ABC");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.SectionVisitors)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SectionVi__Secti__3B75D760");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.SectionVisitors)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SectionVi__Visit__3A81B327");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.Property(e => e.When)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visits__SectionI__3D5E1FD2");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.Visits)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visits__VisitorI__3C69FB99");
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.BirthDay).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastTimeVisited)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(datefromparts((2018)+floor(rand(checksum(newid()))*(4)),(1)+floor(rand(checksum(newid()))*(11)),(1)+floor(rand(checksum(newid()))*(28))))");

                entity.Property(e => e.Phone).HasMaxLength(14);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
