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
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.HasKey(e => new { e.BookUid, e.VolumeNo, e.VolumeIndex });

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.BookU)
                    .WithMany(p => p.Chapter)
                    .HasForeignKey(d => d.BookUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Chapter_BookUid_fkey");

                entity.HasOne(d => d.ContextU)
                    .WithMany(p => p.Chapter)
                    .HasForeignKey(d => d.ContextUid)
                    .HasConstraintName("Chapter_ContextUid_fkey");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.Txt).IsRequired();

                entity.HasOne(d => d.ContentTypeNavigation)
                    .WithMany(p => p.Content)
                    .HasForeignKey(d => d.ContentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Content_ContentType_fkey");
            });

            modelBuilder.Entity<DbEnum>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.TextCn).IsRequired();

                entity.Property(e => e.TextEn).IsRequired();
            });

            modelBuilder.Entity<Host>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.HasIndex(e => e.Name)
                    .HasName("Host_Name_key")
                    .IsUnique();

                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<NovelCrawl>(entity =>
            {
                entity.HasKey(e => new { e.BookUid, e.Url });

                entity.HasOne(d => d.BookU)
                    .WithMany(p => p.NovelCrawl)
                    .HasForeignKey(d => d.BookUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NovelCrawl_BookUid_fkey");

                entity.HasOne(d => d.CrawlUrlTypeNavigation)
                    .WithMany(p => p.NovelCrawl)
                    .HasForeignKey(d => d.CrawlUrlType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NovelCrawl_CrawlUrlType_fkey");
            });

            modelBuilder.Entity<PageParse>(entity =>
            {
                entity.HasKey(e => new { e.Url, e.PageType });

                entity.Property(e => e.SscriptCode)
                    .IsRequired()
                    .HasColumnName("SScriptCode");

                entity.HasOne(d => d.PageTypeNavigation)
                    .WithMany(p => p.PageParse)
                    .HasForeignKey(d => d.PageType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PageParse_PageType_fkey");
            });

            modelBuilder.Entity<Url>(entity =>
            {
                entity.HasKey(e => e.UrlPath);

                entity.Property(e => e.UrlPath).ValueGeneratedNever();

                entity.Property(e => e.Utype).HasColumnName("UType");

                entity.HasOne(d => d.UtypeNavigation)
                    .WithMany(p => p.Url)
                    .HasForeignKey(d => d.Utype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Url_UType_fkey");
            });

            modelBuilder.Entity<Volume>(entity =>
            {
                entity.HasKey(e => new { e.BookUid, e.No });

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.BookU)
                    .WithMany(p => p.Volume)
                    .HasForeignKey(d => d.BookUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Volume_BookUid_fkey");
            });
        }
    }
}
