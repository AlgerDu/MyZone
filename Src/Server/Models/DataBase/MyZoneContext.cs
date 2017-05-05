using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace MyZone.Server.Models.DataBase
{
    public partial class MyZoneContext : DbContext
    {
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Chapter> Chapter { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<DbEnum> DbEnum { get; set; }
        public virtual DbSet<Host> Host { get; set; }
        public virtual DbSet<NovelCrawl> NovelCrawl { get; set; }
        public virtual DbSet<PageParse> PageParse { get; set; }
        public virtual DbSet<Url> Url { get; set; }
        public virtual DbSet<Volume> Volume { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseNpgsql(config.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_Book");

                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.Author).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_Chapter");

                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.BookU)
                    .WithMany(p => p.Chapter)
                    .HasForeignKey(d => d.BookUid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Chapter_BookUid_fkey");

                entity.HasOne(d => d.ContextU)
                    .WithMany(p => p.Chapter)
                    .HasForeignKey(d => d.ContextUid)
                    .HasConstraintName("Chapter_ContextUid_fkey");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_Content");

                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.Ctype).HasColumnName("CType");

                entity.Property(e => e.Txt).IsRequired();

                entity.HasOne(d => d.CtypeNavigation)
                    .WithMany(p => p.Content)
                    .HasForeignKey(d => d.Ctype)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Content_CType_fkey");
            });

            modelBuilder.Entity<DbEnum>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.TextCn)
                    .IsRequired()
                    .HasColumnName("TextCN");

                entity.Property(e => e.TextEn)
                    .IsRequired()
                    .HasColumnName("TextEN");
            });

            modelBuilder.Entity<Host>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK_Host");

                entity.HasIndex(e => e.Name)
                    .HasName("Host_Name_key")
                    .IsUnique();

                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<NovelCrawl>(entity =>
            {
                entity.HasKey(e => new { e.BookUid, e.Url })
                    .HasName("PK_NovelCrawl");

                entity.Property(e => e.Nctype).HasColumnName("NCType");

                entity.HasOne(d => d.BookU)
                    .WithMany(p => p.NovelCrawl)
                    .HasForeignKey(d => d.BookUid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("NovelCrawl_BookUid_fkey");

                entity.HasOne(d => d.NctypeNavigation)
                    .WithMany(p => p.NovelCrawl)
                    .HasForeignKey(d => d.Nctype)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("NovelCrawl_NCType_fkey");
            });

            modelBuilder.Entity<PageParse>(entity =>
            {
                entity.HasKey(e => new { e.Url, e.Utype })
                    .HasName("PK_PageParse");

                entity.Property(e => e.Utype).HasColumnName("UType");

                entity.Property(e => e.SscriptCode)
                    .IsRequired()
                    .HasColumnName("SScriptCode");

                entity.HasOne(d => d.UtypeNavigation)
                    .WithMany(p => p.PageParse)
                    .HasForeignKey(d => d.Utype)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("PageParse_UType_fkey");
            });

            modelBuilder.Entity<Url>(entity =>
            {
                entity.HasKey(e => new { e.HostUid, e.RelativPath })
                    .HasName("PK_Url");

                entity.Property(e => e.Utype).HasColumnName("UType");

                entity.HasOne(d => d.HostU)
                    .WithMany(p => p.Url)
                    .HasForeignKey(d => d.HostUid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Url_HostUid_fkey");

                entity.HasOne(d => d.UtypeNavigation)
                    .WithMany(p => p.Url)
                    .HasForeignKey(d => d.Utype)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Url_UType_fkey");
            });

            modelBuilder.Entity<Volume>(entity =>
            {
                entity.HasKey(e => new { e.BookUid, e.No })
                    .HasName("PK_Volume");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.BookU)
                    .WithMany(p => p.Volume)
                    .HasForeignKey(d => d.BookUid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Volume_BookUid_fkey");
            });
        }
    }
}