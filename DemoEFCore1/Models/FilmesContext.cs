﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DemoEFCore1.Models
{
    public partial class FilmesContext : DbContext
    {
        public FilmesContext()
        {
        }

        public FilmesContext(DbContextOptions<FilmesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Filme> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=ITA12_filmes;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Filme>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Ano)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("ano");

                entity.Property(e => e.AtoresPrincipais)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("atoresPrincipais");

                entity.Property(e => e.Diretor)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("diretor");

                entity.Property(e => e.Duracao)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("duracao");

                entity.Property(e => e.Genero)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("genero");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.Property(e => e.ValorIngresso)
                    .HasColumnType("numeric(5, 2)")
                    .HasColumnName("valorIngresso");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
