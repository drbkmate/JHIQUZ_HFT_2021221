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
            Engine e1 = new Engine() { Ccm = 2000 , Fuel = FuelType.Gasoline};
            Engine e2 = new Engine() { Ccm = 2200 , Fuel = FuelType.Diesel};
            Engine e3 = new Engine() { Ccm = 1800 , Fuel = FuelType.Gasoline};
            Engine e4 = new Engine() { Ccm = 1900 , Fuel = FuelType.Diesel};


            mockRepo
                .Setup(x => x.ReadAll())
                .Returns(new List<Car>
                {
                    new Car() {
                        Id=1,
                        BasePrice = 5000,
                        Brand = b1,
                        Engine = e1,
                        Model = "5 series"
                    },
                    new Car() {
                        Id=2,
                        BasePrice = 6000,
                        Brand = b1,
                        Engine = e2,
                        Model = "5 series"
                    },
                    new Car() {
                        Id=3,
                        BasePrice = 4500,
                        Brand = b2,
                        Engine = e3,
                        Model = "A4"
                    },
                    new Car() {
                        Id=4,
                        BasePrice = 7700,
                        Brand = b2,
                        Engine = e4,
                        Model = "A4"

                    },
                    new Car() {
                        Id=5,
                        BasePrice = 7500,
                        Brand = b2,
                        Engine = e1,
                        Model = "A4"

                    },
                    new Car() {
                        Id=6,
                        BasePrice = 3200,
                        Brand = b2,
                        Engine = e2,
                        Model = "A4"

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
        [Test]
        public void CheckAverageBmwPrices()
        {
            var abp = logic.AverageBmwPrices();
            Assert.That(abp.Where(x => x.Key == "BMW"), Is.EqualTo(abp.Where(x => x.Value == 5500)));
        }
        [Test]
        public void CheckMostExpensiveByBrands()
        { 
            var mebb = logic.MostExpensiveByBrands();
            Assert.That(mebb.Where(x => x.Key == "BMW"), Is.EqualTo(mebb.Where(x => x.Value == 6000)));
            Assert.That(mebb.Where(x => x.Key == "Audi"), Is.EqualTo(mebb.Where(x => x.Value == 7700)));
        }
        /*
        [Test]
        public void CheckBiggestEnginesByModels()
        {
            var bebm = logic.BiggestEnginesByModels();
            Assert.That(bebm.Where(x => x.Key == "5 series"), Is.EqualTo(bebm.Where(x => x.Value == 2200)));
            Assert.That(bebm.Where(x => x.Key == "A4"), Is.EqualTo(bebm.Where(x => x.Value == 2200)));

        }*/
        
        [Test]
        public void CheckDieselEngineAudies()
        {
            var dea = logic.DieselEngineAudies();
            Assert.That(dea.Where(x => x.Key == "Audi"), Is.EqualTo(dea.Where(x => x.Value == 2200)));
            Assert.That(dea.Where(x => x.Key == "Audi"), Is.EqualTo(dea.Where(x => x.Value == 1900)));
        }

        [Test]
        public void CheckReadOneException()
        {
            Assert.That(() => logic.ReadOne(0), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void CheckReadAll() 
        {
            var r = logic.ReadAll().Count();
            Assert.That(r, Is.EqualTo(6));
        }
        [Test]
        public void CheckUpdate()
        {
            Car s = new Car
            {
                Id = 2,
                BasePrice = 5000,
                Brand = new Brand() { Name = "BMW" },
                Engine = new Engine() { Ccm = 2200, Fuel = FuelType.Diesel },
                Model = "5 series"
            };
            logic.Update(s);
            Assert.That(logic.ReadOne(s.Id), Is.EqualTo(logic.ReadOne(2)));
        }

        
        [Test]
        public void CheckCreateException()
        {
            Assert.That(() => logic.Create(
                new Car { 
                    BasePrice = 10000,
                    BrandId = 1,
                    EngineId = 1
                }), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void CheckDelete()
        {
            logic.Delete(1);
            Assert.That(logic.ReadOne(1), Is.Null);
            
        }
    }
}
