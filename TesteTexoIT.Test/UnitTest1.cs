using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TesteTexoIT.Domain.Context;
using TesteTexoIT.Domain.Entities;
using TestoTexoIT.Application.Services;

namespace TesteTexoIT.Test
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SearchMinMaxTest()
        {
            TexoContext context = new TexoContext();
            AwardService awardService = new AwardService(context);
            SearchMinMaxService searchMinMaxService = new SearchMinMaxService(awardService);

            List<Award> awards = new List<Award>();

            awards.Add(new Award()
            {
                Id = 1,
                Year = 2000,
                Producers = "Produtor 1",
                Studios = "Estudio 1",
                Title = "Titulo 1",
                Winner = true
            });
            awards.Add(new Award()
            {
                Id = 2,
                Year = 2001,
                Producers = "Produtor 1",
                Studios = "Estudio 1",
                Title = "Titulo 2",
                Winner = true
            });
            awards.Add(new Award()
            {
                Id = 3,
                Year = 2002,
                Producers = "Produtor 2",
                Studios = "Estudio 1",
                Title = "Titulo 1",
                Winner = true
            });
            awards.Add(new Award()
            {
                Id = 4,
                Year = 2005,
                Producers = "Produtor 2",
                Studios = "Estudio 1",
                Title = "Titulo 2",
                Winner = true
            });


            var minMax = searchMinMaxService.SearchMinMax(awards);

            Assert.AreEqual(minMax.Min[0].Interval, 1);
            Assert.AreEqual(minMax.Max[0].Interval, 3);
        }
    }
}