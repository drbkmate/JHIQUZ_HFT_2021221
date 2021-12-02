using HFT_FF_L08.Client;
using JHIQUZ_HFT_2021221.Models;
using System;
using System.Linq;

namespace JHIQUZ_HFT_2021221.Client
{
    class Program
    {
        static RestService rest = new RestService("http://localhost:51322");
        static void Main(string[] args)
        {
            /*
            CarShopContext ctx = new CarShopContext();

            var res1 = ctx.Cars.ToList();

            ;*/

            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:51322");

            var cars = rest.Get<Car>("car");
            var brands = rest.Get<Car>("brand");
            var engines = rest.Get<Car>("engine");
            /*
            Console.WriteLine("Adja meg hogy melyik táblán és milyen műveletet szeretne végezni egy két számjegyű számmal");
            Console.WriteLine("Tizes helyiértéken levő számjegy megadja hogy melyik táblán szeretné végezni:");
            Console.WriteLine("1x - Car tábla");
            Console.WriteLine("2x - Brand tábla");
            Console.WriteLine("3x - Engine tábla");
            Console.WriteLine("4x - Stat tábla");
            Console.WriteLine("Az egyes helyiértéken levő számjegy megadja hogy milyen műveletet szeretne végezni");
            Console.WriteLine("CRRUD műveletek esetén");
            Console.WriteLine("x1 - ReadOne");
            Console.WriteLine("x2 - ReadAll");
            Console.WriteLine("x3 - Create");
            Console.WriteLine("x4 - Delete");
            Console.WriteLine("x5 - Update");
            Console.WriteLine("Stat műveletek estén");
            Console.WriteLine("41 - Átlag árak");
            Console.WriteLine("42 - Átlag árak brandenként");
            Console.WriteLine("43 - BMW áttlag árak");
            Console.WriteLine("44 - Brandenkénti legdrágább autók");
            Console.WriteLine("45 - Modellenkénti legnagyobb köbcentis motorok");
            Console.WriteLine("46 - Átlag köbcenti diesel meghajtású Audiknál");
            Console.WriteLine("Adjon meg egy kétjegyű számot: ");
            */
            Console.WriteLine("Adja meg hogy melyik táblán és milyen műveletet szeretne végezni");
            Console.WriteLine("Táblák: car/brand/engine/stat");
            string table = Console.ReadLine().ToLower();
            int task = 0;
            if (table == "stat")
            {
                Console.WriteLine("Lehetséges műveletek: ");
                Console.WriteLine("11 - Átlag árak");
                Console.WriteLine("12 - Átlag árak brandenként");
                Console.WriteLine("13 - BMW áttlag árak");
                Console.WriteLine("14 - Brandenkénti legdrágább autók");
                Console.WriteLine("15 - Modellenkénti legnagyobb köbcentis motorok");
                Console.WriteLine("16 - Átlag köbcenti diesel meghajtású Audiknál");
                Console.WriteLine("Adja meg a művelet sorszámát");
                task= int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Lehetséges műveletek: ");
                Console.WriteLine("1 - ReadOne");
                Console.WriteLine("2 - ReadAll");
                Console.WriteLine("3 - Create");
                Console.WriteLine("4 - Delete");
                Console.WriteLine("5 - Update");
                Console.WriteLine("Adja meg a művelet sorszámát");
                task = int.Parse(Console.ReadLine());
            }


            switch (task)
            {
                case 1:
                    Console.WriteLine("Adjon meg egy indexet: ");
                    int ind = int.Parse(Console.ReadLine());
                    switch (table)
                    {
                        case "car":
                            Console.WriteLine(rest.GetSingle<Car>(table + "/" + ind).Model);
                            break;
                        case "engine":
                            Console.WriteLine(rest.GetSingle<Engine>(table + "/" + ind).Ccm);
                            break;
                        case "brand":
                            Console.WriteLine(rest.GetSingle<Brand>(table + "/" + ind).Name);
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    switch (table)
                    {
                        case "car":
                            foreach (var item in rest.Get<Car>(table))
                            {
                                Console.WriteLine(item.Model);
                            }
                            break;
                        case "engine":
                            foreach (var item in rest.Get<Engine>(table))
                            {
                                Console.WriteLine(item.Ccm);
                            }
                            break;
                        case "brand":
                            foreach (var item in rest.Get<Brand>(table))
                            {
                                Console.WriteLine(item.Name);
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch (table)
                    {
                        case "car":
                            Console.WriteLine("Az autó modellje: ");
                            string model = Console.ReadLine();
                            Console.WriteLine("Az autó ára: ");
                            int price = int.Parse(Console.ReadLine());

                            rest.Post<Car>(new Car { 
                                Model = model, BasePrice = price
                            }, table);
                            break;
                        case "engine":
                            Console.WriteLine("A motor mérete: ");
                            int ccm = int.Parse(Console.ReadLine());

                            rest.Post<Engine>(new Engine
                            {
                                Ccm = ccm
                            }, table);
                            break;
                        case "brand":
                            Console.WriteLine("Márka: ");
                            string brand = Console.ReadLine();

                            rest.Post<Brand>(new Brand
                            {
                                Name = brand
                            }, table);
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    Console.WriteLine("Adjon meg egy indexet: ");
                    int idx = int.Parse(Console.ReadLine());
                    rest.Delete(idx, table);
                    break;
                case 5:

                    break;
                case 11:

                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                    
                default:
                    break;
            }

            ;

        }
        static void RO(int index, string table)
        {
            switch (table)
            {
                case "car":
                    rest.GetSingle<Car>(table + "/" + index);
                    break;
                case "engine":
                    rest.GetSingle<Engine>(table + "/" + index);
                    break;
                case "brand":
                    rest.GetSingle<Brand>(table + "/" + index);
                    break;
                default:
                    break;
            }

        }
    }
}
