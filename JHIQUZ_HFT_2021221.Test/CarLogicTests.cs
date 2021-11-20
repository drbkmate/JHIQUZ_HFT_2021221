using JHIQUZ_HFT_2021221.Logic;
using JHIQUZ_HFT_2021221.Models;
using JHIQUZ_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Test
{
    [TestFixture]
    public class CarLogicTests
    {
        ICarLogic logic;
        [SetUp]
        public void Setup()
        {
            Mock<ICarRepository> mockRepo = new Mock<ICarRepository>();
            Brand b1 = new Brand() { Name = "BMW" };
            Brand b2 = new Brand() { Name = "Audi" };

            mockRepo
                .Setup(x => x.ReadAll())
                .Returns(new List<Car>
                {
                    new Car() {
                        BasePrice = 5000,
                        Brand = b1
                    },
                    new Car() {
                        BasePrice = 6000,
                        Brand = b1
                    },
                    new Car() {
                        BasePrice = 4500,
                        Brand = b2
                    },
                    new Car() {
                        BasePrice = 7700,
                        Brand = b2
                    },
                    new Car() {
                        BasePrice = 7500,
                        Brand = b2
                    },
                    new Car() {
                        BasePrice = 3200,
                        Brand = b2
                    },
                }
                .AsQueryable());

            logic = new CarLogic(mockRepo.Object);
        }

        [Test]
        public void CheckAveragePrice()
        {
            double avg = logic.AveragePrice();
            Assert.That(avg, Is.EqualTo(5650));
        }
        [Test]
        public void CheckAveragePricesByBrands()
        {
            var apbb = logic.AveragePricesByBrands();

            Assert.That(apbb.Where(x => x.Key == "BMW"), Is.EqualTo(apbb.Where(x => x.Value == 5500)));
            Assert.That(apbb.Where(x => x.Key == "Audi"), Is.EqualTo(apbb.Where(x => x.Value == 5725)));


        }
    }
}
