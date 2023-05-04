using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LibraryApp.DataService.ModelsSql
{
    public partial class LibreriaTravelContext : DbContext
    {
        public LibreriaTravelContext()
        {
        }

        public LibreriaTravelContext(DbContextOptions<LibreriaTravelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<AutoresLibro> AutoresLibros { get; set; }
        public virtual DbSet<Editoriale> Editoriales { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK__Autores__9AE8206A12F429BE");

                entity.Property(e => e.IdAutor).HasColumnName("idAutor");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<AutoresLibro>(entity =>
            {
                entity.HasKey(e => e.IdAutorLibro)
                    .HasName("PK__AutoresL__34C16D2B422769AC");

                entity.Property(e => e.IdAutorLibro).HasColumnName("idAutorLibro");

                entity.Property(e => e.IdAutor).HasColumnName("idAutor");

                entity.Property(e => e.LibroIsbn).HasColumnName("libroISBN");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.AutoresLibros)
                    .HasForeignKey(d => d.IdAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AutoresLi__idAut__34C8D9D1");

                entity.HasOne(d => d.LibroIsbnNavigation)
                    .WithMany(p => p.AutoresLibros)
                    .HasForeignKey(d => d.LibroIsbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AutoresLi__libro__35BCFE0A");
            });

            modelBuilder.Entity<Editoriale>(entity =>
            {
                entity.HasKey(e => e.IdEditorial)
                    .HasName("PK__Editoria__9DF182DBC8B4A275");

                entity.Property(e => e.IdEditorial).HasColumnName("idEditorial");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Sede)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("sede");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PK__Libros__447D36EB7A1E44F4");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.Property(e => e.IdEditorial).HasColumnName("idEditorial");

                entity.Property(e => e.NPaginas)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nPaginas");

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("sinopsis");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdEditorialNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdEditorial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Libros__idEditor__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
