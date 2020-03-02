using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebBoard.Models
{
    public partial class WebBoardContext : DbContext
    {
        public WebBoardContext()
        {
        }

        public WebBoardContext(DbContextOptions<WebBoardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BoardTitle> BoardTitle { get; set; }
        public virtual DbSet<Test> Test { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=PC-06;Initial Catalog=WebBoard;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoardTitle>(entity =>
            {
                entity.Property(e => e.Id).HasComment("次序");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("內容");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("姓名");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("主題");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
