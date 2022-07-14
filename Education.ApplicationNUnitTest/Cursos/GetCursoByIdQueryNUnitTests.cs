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
    public class GetCursoByIdQueryNUnitTests
    {
        private GetCursoByIdQuery.GetCursoByIdQueryHandler _handlerByIdCurso;
        private Guid cursoIdTest;

        [SetUp]
        public void SetUp()
        {
            cursoIdTest = new Guid("2ce24c4d-df93-4620-ba47-c8865633775f");
            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();

            cursoRecords.Add(fixture.Build<Curso>()
                .With(tr => tr.CursoId, cursoIdTest)
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

            _handlerByIdCurso = new GetCursoByIdQuery.GetCursoByIdQueryHandler(educationDBContextFake, mapper);
        }

        [Test]
        public async Task GetCursoByIdQueryHandler_InputCursoId_ReturnsTrue()
        {
            //1. Emular al Context que representa la instacion de EF
            //2. Emular al Mapping Profile
            //3. Instanciar un objeto de la clase GetCursoQuery.GetCursoQUeryHandler y pasarle
            //como parametros lo objetos context y mapping
            //GetCursoQueryHandler 

            GetCursoByIdQuery.GetCursoByIdQueryRequest request = new()
            {
                Id = cursoIdTest
            };

            var resltado = await _handlerByIdCurso.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(resltado);

        }
    }
}
