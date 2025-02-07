using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MakeaBite_Library.Models
{
    public partial class MakeaBiteContext :DbContext
    {
        public MakeaBiteContext()
        {
        }

        public MakeaBiteContext(DbContextOptions<MakeaBiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=makeabite.czsqqi8iu7yx.us-east-1.rds.amazonaws.com,1433;Initial Catalog=MakeaBite;Integrated Security=False;Persist Security Info=True;User ID=admin;Password=12345678;Encrypt=True;Trust Server Certificate=True");
//            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredient");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IngredientAmount)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.IngredientName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_RecipeId");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorId)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.ImageIrl)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RecipeName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RecipeType)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
