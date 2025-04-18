using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public partial class KitapDbbContext : DbContext
{
    public KitapDbbContext()
    {
    }

    public KitapDbbContext(DbContextOptions<KitapDbbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategori> Kategoriler { get; set; }

    public virtual DbSet<Kitap> Kitaplar { get; set; }

    public virtual DbSet<YayinEvi> YayinEvis { get; set; }

    public virtual DbSet<Yazar> Yazarlar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data source=.;initial catalog=KitapDBB;integrated security=true;trust server certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.ToTable("Kategoriler");

            entity.Property(e => e.Ad).HasMaxLength(50);
        });

        modelBuilder.Entity<Kitap>(entity =>
        {
            entity.ToTable("Kitaplar");

            entity.HasIndex(e => e.KategoriId, "IX_Kitaplar_KategoriId");

            entity.HasIndex(e => e.YayinEviId, "IX_Kitaplar_YayinEviId");

            entity.HasIndex(e => e.YazarId, "IX_Kitaplar_YazarId");

            entity.Property(e => e.Fiyat).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Kategori).WithMany(p => p.Kitaplar).HasForeignKey(d => d.KategoriId);

            entity.HasOne(d => d.YayinEvi).WithMany(p => p.Kitaplar).HasForeignKey(d => d.YayinEviId);

            entity.HasOne(d => d.Yazar).WithMany(p => p.Kitaplar).HasForeignKey(d => d.YazarId);
        });

        modelBuilder.Entity<Yazar>(entity =>
        {
            entity.ToTable("Yazarlar");

            entity.Property(e => e.Ad).HasMaxLength(50);
            entity.Property(e => e.Biyografi).HasMaxLength(1000);
            entity.Property(e => e.Soyad).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
