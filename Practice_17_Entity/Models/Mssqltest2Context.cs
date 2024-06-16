using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practice_17_Entity;

public partial class Mssqltest2Context : DbContext
{
    public Mssqltest2Context()
    {
    }

    public Mssqltest2Context(DbContextOptions<Mssqltest2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Purchase> Purchases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MSSQLTest2;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3214EC0760EF2F04");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ItemId).HasMaxLength(50);
            entity.Property(e => e.ItemName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
