﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DemoEFCore3.Models
{
    public partial class BaseDadosContext : DbContext
    {
        public BaseDadosContext()
        {
        }

        public BaseDadosContext(DbContextOptions<BaseDadosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=ITA12_produtos;Integrated Security=True");
                optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("descricao");

                entity.Property(e => e.EstaDisponivel).HasColumnName("estadisponivel");

                entity.Property(e => e.PrecoUnitario).HasColumnName("precounitario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
