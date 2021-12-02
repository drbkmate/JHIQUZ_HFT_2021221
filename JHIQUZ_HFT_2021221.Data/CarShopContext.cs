using JHIQUZ_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JHIQUZ_HFT_2021221.Data
{
    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarShopDatabase.mdf;Integrated Security=True
    public class CarShopContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Engine> Engines { get; set; }

        public CarShopContext()
        {
            Database.EnsureCreated();
        }
        public CarShopContext(DbContextOptions<CarShopContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarShopDatabase.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasOne(car => car.Brand)
                    .WithMany(brand => brand.Cars)
                    .HasForeignKey(car => car.BrandId)
                    .HasForeignKey(car => car.EngineId)
                    .OnDelete(DeleteBehavior.ClientSetNull);// később lehet módosítani kell hogy a.SaveChanges() ne dobjon exception - t
            });

            modelBuilder.Entity<Engine>(entity =>
            {
            entity.HasMany(e => e.Cars)
                .WithOne(c => c.Engine)
                .OnDelete(DeleteBehavior.ClientSetNull);//később lehet módosítani kell hogy a .SaveChanges() ne dobjon exception-t
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasMany(b => b.Cars)
                    .WithOne(c => c.Brand)
                    .OnDelete(DeleteBehavior.ClientSetNull);//később lehet módosítani kell hogy a .SaveChanges() ne dobjon exception-t
            });

            Engine gas1 = new Engine() { Id = 1, Ccm = 2000, Fuel = FuelType.Gasoline };
            Engine gas2 = new Engine() { Id = 2, Ccm = 1800,Fuel = FuelType.Gasoline };
            Engine diesel1 = new Engine() { Id = 3, Ccm = 2200, Fuel = FuelType.Diesel };

            Brand bmw = new Brand() { Id = 1, Name = "BMW" };
            Brand citroen = new Brand() { Id = 2, Name = "Citroen" };
            Brand audi = new Brand() { Id = 3, Name = "Audi" };
            Brand ford = new Brand() { Id = 4, Name = "Ford" };


            Car bmw1 = new Car() { Id = 1, BrandId = bmw.Id, BasePrice = 20000, Model = "1 series", EngineId=gas2.Id };
            Car bmw2 = new Car() { Id = 2, BrandId = bmw.Id, BasePrice = 30000, Model = "5 series" , EngineId = diesel1.Id };
            Car citroen1 = new Car() { Id = 3, BrandId = citroen.Id, BasePrice = 10000, Model = "C1" , EngineId = gas2.Id };
            Car citroen2 = new Car() { Id = 4, BrandId = citroen.Id, BasePrice = 15000, Model = "C3" , EngineId = gas2.Id };
            Car audi1 = new Car() { Id = 5, BrandId = audi.Id, BasePrice = 20000, Model = "A3", EngineId = gas1.Id };
            Car audi2 = new Car() { Id = 6, BrandId = audi.Id, BasePrice = 25000, Model = " A4", EngineId = diesel1.Id };
            Car ford1 = new Car() { Id = 7, BrandId = ford.Id, BasePrice=9000, Model = "Mondeo", EngineId = gas1.Id };

            modelBuilder.Entity<Engine>().HasData(gas1, gas2, diesel1);
            modelBuilder.Entity<Brand>().HasData(bmw, citroen, audi,ford);
            modelBuilder.Entity<Car>().HasData(bmw1, bmw2, citroen1, citroen2, audi1, audi2,ford1);

        }
    }
}
