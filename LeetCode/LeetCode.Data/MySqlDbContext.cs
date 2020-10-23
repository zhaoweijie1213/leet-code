using LeetCode.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Data
{
    public partial class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options):base(options)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<ClubseasonDrawboxreceive> ClubseasonDrawboxreceive { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;port=3306;database=bookstore;uid=root;pwd=123456;charset=utf8;Allow User Variables=True;sslMode=None;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClubseasonDrawboxreceive>(entity =>
            {
                entity.ToTable("clubseason_drawboxreceive");

                entity.HasIndex(e => new { e.Gameid, e.Gameno, e.Uid })
                    .HasName("gameid, gameno, uid");

                entity.HasIndex(e => new { e.Gameno, e.Isreceive, e.Uid })
                    .HasName("gameno,isreceive, uid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Areaid).HasColumnName("areaid");

                entity.Property(e => e.Clubid).HasColumnName("clubid");

                entity.Property(e => e.Copperbox).HasColumnName("copperbox");

                entity.Property(e => e.Gameid).HasColumnName("gameid");

                entity.Property(e => e.Gameno)
                    .IsRequired()
                    .HasColumnName("gameno")
                    .HasMaxLength(50);

                entity.Property(e => e.Goldbox).HasColumnName("goldbox");

                entity.Property(e => e.Isreceive)
                    .HasColumnName("isreceive")
                    .HasComment("是否领取");

                entity.Property(e => e.Receivebox)
                    .IsRequired()
                    .HasColumnName("receivebox")
                    .HasMaxLength(20);

                entity.Property(e => e.Silverbox).HasColumnName("silverbox");

                entity.Property(e => e.Uid).HasColumnName("uid");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
