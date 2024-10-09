using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CakeShop.DAL.DataModel
{
    public partial class CAKESHOP_DbContext : DbContext
    {
        public CAKESHOP_DbContext()
        {
        }

        public CAKESHOP_DbContext(DbContextOptions<CAKESHOP_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cake> Cake { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pictures> Pictures { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-6DPV5BR\\SQLEXPRESS;Database=CakeShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cake>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.Property(e => e.Ingredient)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IngredientQuantity)
                    .IsRequired()
                    .HasColumnName("Ingredient_Quantity")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitOfMeasure)
                    .HasColumnName("Unit_of_Measure")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__Ingredien__Recip__5441852A");
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.Property(e => e.Changes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cake)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.CakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderItem__CakeI__4E88ABD4");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderItem__Order__4D94879B");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BCF59469A49");

                entity.Property(e => e.DeliveryAddress)
                    .HasColumnName("Delivery_Address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDue).HasColumnType("datetime");

                entity.Property(e => e.OrderPlaced).HasColumnType("datetime");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMethod)
                    .HasColumnName("Payment_Method")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PickupMethod)
                    .HasColumnName("Pickup_Method")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice).HasColumnName("Total_Price");

                entity.HasOne(d => d.Cake)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CakeId)
                    .HasConstraintName("FK__Orders__CakeId__45F365D3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__UserId__46E78A0C");
            });

            modelBuilder.Entity<Pictures>(entity =>
            {
                entity.HasOne(d => d.Cake)
                    .WithMany(p => p.Pictures)
                    .HasForeignKey(d => d.CakeId)
                    .HasConstraintName("FK__Pictures__CakeId__3B75D760");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.PreparationTime)
                    .HasColumnName("Preparation_Time")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Recipe1)
                    .IsRequired()
                    .HasColumnName("Recipe")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cake)
                    .WithMany(p => p.Recipe)
                    .HasForeignKey(d => d.CakeId)
                    .HasConstraintName("FK__Recipe__CakeId__5165187F");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__A9D10534BF3F1E8B")
                    .IsUnique();

                entity.HasIndex(e => e.Oib)
                    .HasName("UQ__Users__CB394B3E7AFDD140")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Oib)
                    .IsRequired()
                    .HasColumnName("OIB")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
