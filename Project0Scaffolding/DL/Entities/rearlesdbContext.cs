using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;


namespace DL.Entities
{
    public partial class RearlesDBContext : DbContext
    {
        public RearlesDBContext()
        {
        }

        public RearlesDBContext(DbContextOptions<RearlesDBContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ReviewJoin> ReviewJoins { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");
                entity.Property(e => e.Name) //name of the restaurant
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Zipcode) //zipcodde where its located
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.IRestuarant)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.isAdmin)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
             modelBuilder.Entity<ReviewJoin>(entity =>
            {
                entity.ToTable("ReviewJoin");
                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.ReviewJoins)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK__ReviewJoi__Resta__19DFD96B");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.ReviewJoins)
                    .HasForeignKey(d => d.ReviewId)
                    .HasConstraintName("FK__ReviewJoi__Revie__1AD3FDA4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReviewJoins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ReviewJoi__UserI__1BC821DD");
            });


            // modelBuilder.Entity<Meal>(entity => //do this with the join table. 
            // {
            //     entity.Property(e => e.FoodType)
            //         .IsRequired()
            //         .HasMaxLength(100)
            //         .IsUnicode(false);

            //     entity.Property(e => e.Time).HasColumnType("datetime");

            //     entity.HasOne(d => d.Cat)
            //         .WithMany(p => p.Meals)
            //         .HasForeignKey(d => d.CatId)
            //         .HasConstraintName("FK__Meals__CatId__02FC7413");
            // });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
