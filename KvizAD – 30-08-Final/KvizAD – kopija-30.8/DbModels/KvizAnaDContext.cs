using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KvizAD.DbModels
{
    public partial class KvizAnaDContext : DbContext
    {
        public KvizAnaDContext()
        {
        }

        public KvizAnaDContext(DbContextOptions<KvizAnaDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Odgovori> Odgovori { get; set; }
        public virtual DbSet<Pitanja> Pitanja { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPitanja> UserPitanja { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=KvizAnaD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Odgovori>(entity =>
            {
                entity.Property(e => e.OdgovoriId).HasColumnName("OdgovoriID");

                entity.Property(e => e.PitanjaId).HasColumnName("PitanjaID");

                entity.Property(e => e.Text).HasColumnName("text");

                entity.HasOne(d => d.Pitanja)
                    .WithMany(p => p.Odgovori)
                    .HasForeignKey(d => d.PitanjaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Odgovori_Pitanja");
            });

            modelBuilder.Entity<Pitanja>(entity =>
            {
                entity.Property(e => e.PitanjaId).HasColumnName("PitanjaID");

                entity.Property(e => e.Text).HasColumnName("text");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserPitanja>(entity =>
            {
                entity.Property(e => e.UserPitanjaId).HasColumnName("UserPitanjaID");

                entity.Property(e => e.PitanjaId).HasColumnName("PitanjaID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Pitanja)
                    .WithMany(p => p.UserPitanja)
                    .HasForeignKey(d => d.PitanjaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPitanja_Pitanja");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPitanja)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPitanja_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
