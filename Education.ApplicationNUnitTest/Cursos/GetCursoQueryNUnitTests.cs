using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
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
    public class GetCursoQueryNUnitTests
    {
        private GetCursoQuery.GetCursoQueryHandler _handlerAllCursos;

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

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            }
            );

            var mapper = mapConfig.CreateMapper();

            _handlerAllCursos = new GetCursoQuery.GetCursoQueryHandler(educationDBContextFake, mapper);
        }

        [Test]
        public async Task GetCursoQueryHandler_ConsultaCrusos_ReturnsTrue()
        {
            //1. Emular al Context que representa la instacion de EF
            //2. Emular al Mapping Profile
            //3. Instanciar un objeto de la clase GetCursoQuery.GetCursoQUeryHandler y pasarle
            //como parametros lo objetos context y mapping
            //GetCursoQueryHandler 

            GetCursoQuery.GetCursoQueryRequest request = new();

            var resltados = await _handlerAllCursos.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(resltados);

        }
    }
}
