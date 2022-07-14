using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Cursos
{
    [TestFixture]
    public class CreateCursoCommandNUnitTests
    {
        private CreateCursoCommand.CreateCursoCommandHandler _handlerCursoCreate;

        [SetUp]
        public void SetUp()
        {
            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();

            cursoRecords.Add(fixture.Build<Curso>()
                .With(tr => tr.CursoId, Guid.Empty)
                .Create()
                );

            var options = new DbContextOptionsBuilder<EducationDbContext>()
                .UseInMemoryDatabase(databaseName: $"EducationDBContext-{Guid.NewGuid()}")
                .Options;

            var educationDBContextFake = new EducationDbContext(options);
            educationDBContextFake.Cursos.AddRange(cursoRecords);
            educationDBContextFake.SaveChanges();


            _handlerCursoCreate = new CreateCursoCommand.CreateCursoCommandHandler(educationDBContextFake);
        }

        [Test]
        public async Task CreateCursoCommandHandler_InputCruso_ReturnsInt()
        {
            //1. Emular al Context que representa la instacion de EF
            //2. Emular al Mapping Profile
            //3. Instanciar un objeto de la clase GetCursoQuery.GetCursoQUeryHandler y pasarle
            //como parametros lo objetos context y mapping
            //GetCursoQueryHandler 

            CreateCursoCommand.CreateCursoCommandRequest request = new();

            request.FechaPublicacion = DateTime.UtcNow.AddDays(52);
            request.Titulo = "Libro de Pruebas Automaticas en net";
            request.Descripcion = "Aprender a crear unit test desde cero";
            request.Precio = 99;

            var resltados = await _handlerCursoCreate.Handle(request, new System.Threading.CancellationToken());

            Assert.That(resltados, Is.EqualTo(Unit.Value));

        }
    }
}
