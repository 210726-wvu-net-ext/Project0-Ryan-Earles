using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL.Entities
{
    public partial class petdbContext : DbContext
    {
        public petdbContext()
        {
        }

        public petdbContext(DbContextOptions<petdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cat>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.Property(e => e.FoodType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK__Meals__CatId__02FC7413");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
