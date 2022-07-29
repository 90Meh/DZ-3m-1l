using System;
using System.Collections.Generic;

namespace DZ_3m_1l
{
    internal class Program
    {
        static void Main(string[] args)
        {

            AnonPlanet();
            EasyClassPlanet();
            AnotherMethod();
        }

        static void AnonPlanet()
        {
            //Создание четырёх анонимных объектов/планет
            var venus = new
            {
                Name = "Венера",
                SolarNumber = 2,
                EquatorLen = 12_104,
                PreviousPlanet = "none"
            };

            var earth = new
            {
                Name = "Земля",
                SolarNumber = 3,
                EquatorLen = 40_075,
                PreviousPlanet = venus
            };

            var mars = new
            {
                Name = "Марс",
                SolarNumber = 4,
                EquatorLen = 21_344,
                PreviousPlanet = earth
            };

            var venus2 = new
            {
                Name = "Венера",
                SolarNumber = 2,
                EquatorLen = 12_104,
                PreviousPlanet = mars
            };

            //Вывод на консоль информации
            Console.WriteLine($"Название {venus.Name} " +
                $"\n Порядковый номер от Солнца {venus.SolarNumber} " +
                $"\n Длина экватора  {venus.EquatorLen} " +
                $"\n Предыдущая планета {venus.PreviousPlanet}");
            Console.WriteLine("Венера = Венера - " + (venus.Equals(venus)));

            Console.WriteLine($"Название {earth.Name} " +
                $"\n Порядковый номер от Солнца {earth.SolarNumber} " +
                $"\n Длина экватора  {earth.EquatorLen} " +
                $"\n Предыдущая планета {earth.PreviousPlanet.Name}");
            Console.WriteLine("Земля = Венера - " + (earth.Equals(venus)));

            Console.WriteLine($"Название {mars.Name} " +
                $"\n Порядковый номер от Солнца {mars.SolarNumber} " +
                $"\n Длина экватора  {mars.EquatorLen} " +
                $"\n Предыдущая планета {mars.PreviousPlanet.Name}");
            Console.WriteLine("Марс = Венера - " + (mars.Equals(venus)));

            Console.WriteLine($"Название {venus2.Name} " +
                $"\n Порядковый номер от Солнца {venus2.SolarNumber} " +
                $"\n Длина экватора  {venus2.EquatorLen} " +
                $"\n Предыдущая планета {venus2.PreviousPlanet.Name}");
            Console.WriteLine("Венера2 = Венера - " + (venus2.Equals(venus)));
        }

        //Метод вызова второй программы
        static void EasyClassPlanet()
        {
            var catalogP = new CatalogPlanet();
            
            Console.WriteLine(catalogP.GetPlanet("Земля"));
            Console.WriteLine(catalogP.GetPlanet("Венера"));
            Console.WriteLine(catalogP.GetPlanet("Лимония"));
        }

        //Метод вызова третьей программы
        static void AnotherMethod()
        {
            var Pl = new CatalogPlanetA();
            Console.WriteLine(Pl.GetPlanet("Венера"));
        }
        //Класс планета и его список
        class Planet
        {
            public string Name { get; set; }
            public int SolarNumber { get; set; }
            public int EquatorLen { get; set; }
            public Planet PreviousPlanet { get; set; }

        }
        class CatalogPlanet
        {
            private List<Planet> listPlanet = new List<Planet>();

            public CatalogPlanet()
            {
                var venus = new Planet();
                venus.Name = "Венера";
                venus.SolarNumber = 2;
                venus.EquatorLen = 12_104;
                venus.PreviousPlanet = null;
                listPlanet.Add(venus);

                var earth = new Planet();
                earth.Name = "Земля";
                earth.SolarNumber = 3;
                earth.EquatorLen = 40_07;
                earth.PreviousPlanet = venus;
                listPlanet.Add(earth);

                var mars = new Planet();
                mars.Name = "Марс";
                mars.SolarNumber = 4;
                mars.EquatorLen = 21_344;
                mars.PreviousPlanet = earth;
                listPlanet.Add(mars);
            }

            //Мотод получения номера планеты и длины экватора
            //Счётчик метода GetPlanet
            int counter = 0;
            public (int s, int e, string E) GetPlanet(string planetName)
            {
                Planet p = new Planet();
                string message = "0";
                counter++;
                switch (planetName)
                {
                    case "Венера":
                        p = listPlanet[0];
                        message = planetName;
                        break;
                    case "Земля":
                        p = listPlanet[1];
                        message = planetName;
                        break;
                    case "Марс":
                        p = listPlanet[2];
                        message = planetName;
                        break;
                    default:
                        message = "Не удалось найти планету";
                        break;
                }
                if (counter == 3)
                {
                    counter = 0;
                    message += " - Вы спрашиваете слишком часто";
                }

                return (p.SolarNumber, p.EquatorLen, message);
            }
        }
        

        //Список с новым методом
        
        class CatalogPlanetA
        {
            private List<Planet> listPlanet = new List<Planet>();

            public CatalogPlanetA()
            {
                var venus = new Planet();
                venus.Name = "Венера";
                venus.SolarNumber = 2;
                venus.EquatorLen = 12_104;
                venus.PreviousPlanet = null;
                listPlanet.Add(venus);

                var earth = new Planet();
                earth.Name = "Земля";
                earth.SolarNumber = 3;
                earth.EquatorLen = 40_07;
                earth.PreviousPlanet = venus;
                listPlanet.Add(earth);

                var mars = new Planet();
                mars.Name = "Марс";
                mars.SolarNumber = 4;
                mars.EquatorLen = 21_344;
                mars.PreviousPlanet = earth;
                listPlanet.Add(mars);
            }

            //Мотод получения номера планеты и длины экватора

            public delegate string PlanetValidator(string pl);
            public (int s, int e, string E) GetPlanet(string planetName, PlanetValidator val)
            {
                Planet p = new Planet();
                string message;
                val(planetName);
                switch (planetName)
                {
                    case "Венера":
                        p = listPlanet[0];
                        message = planetName;
                        break;
                    case "Земля":
                        p = listPlanet[1];
                        message = planetName;
                        break;
                    case "Марс":
                        p = listPlanet[2];
                        message = planetName;
                        break;
                    default:
                        message = "Не удалось найти планету";
                        break;
                }
                
                return (p.SolarNumber, p.EquatorLen, message);
            }
        }
    }
}
