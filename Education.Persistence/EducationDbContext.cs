using Education.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Persistence
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext()
        {

        }
        public EducationDbContext(DbContextOptions<EducationDbContext> option): base(option){}

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(!options.IsConfigured)
            {
                options.UseSqlServer("Server=GASQL;Database=AdventureWorksDW2012;User Id=asp;Password=.net2015.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .Property(x => x.Precio)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion = "Curso de C# Basico",
                    Titulo = "C# desde cero hasta avanzado",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 56
                }                                
            );
            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion = "Curso de Java",
                    Titulo = "Master en Java Spring desde la raices",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 25
                }
            );
            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion = "Curso de Unit Test para Net Core",
                    Titulo = "Master en Unit Test con CQRS",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 1000
                }
            );
        }
    }
}
