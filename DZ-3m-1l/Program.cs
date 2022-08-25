namespace DZ_3m_1l
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        // Счётчик третьего метода
        private static int counterV = 0;
        private static int counterM = 0;
        private static int counterE = 0;
        private static int counter3 = 0;

        // Имена планет. к третьей программе пришёл к переменным. Устал писать каждое название.
        public static string E = "Земля";
        public static string V = "Венера";
        public static string l = "Лимония";
        public static string m = "Марс";


        private static void Main(string[] args)
        {
            AnonPlanet();
            EasyClassPlanet();
            AnotherMethod();
        }

        private static void AnonPlanet()
        {
            // Создание четырёх анонимных объектов/планет
            var venus = new
            {
                Name = "Венера",
                SolarNumber = 2,
                EquatorLen = 12_104,
                PreviousPlanet = (string)null,
            };

            var earth = new
            {
                Name = "Земля",
                SolarNumber = 3,
                EquatorLen = 40_075,
                PreviousPlanet = venus,
            };

            var mars = new
            {
                Name = "Марс",
                SolarNumber = 4,
                EquatorLen = 21_344,
                PreviousPlanet = earth,
            };

            var venus2 = new
            {
                Name = "Венера",
                SolarNumber = 2,
                EquatorLen = 12_104,
                PreviousPlanet = mars,
            };

            // Вывод на консоль информации
            // Console.WriteLine($"Название {venus.Name} " +
            //    $"\n Порядковый номер от Солнца {venus.SolarNumber} " +
            //    $"\n Длина экватора  {venus.EquatorLen} " +
            //    $"\n Предыдущая планета {venus.PreviousPlanet}");
            // Console.WriteLine("Венера = Венера - " + (venus.Equals(venus)));

            // Console.WriteLine($"Название {earth.Name} " +
            //    $"\n Порядковый номер от Солнца {earth.SolarNumber} " +
            //    $"\n Длина экватора  {earth.EquatorLen} " +
            //    $"\n Предыдущая планета {earth.PreviousPlanet.Name}");
            // Console.WriteLine("Земля = Венера - " + (earth.Equals(venus)));

            // Console.WriteLine($"Название {mars.Name} " +
            //    $"\n Порядковый номер от Солнца {mars.SolarNumber} " +
            //    $"\n Длина экватора  {mars.EquatorLen} " +
            //    $"\n Предыдущая планета {mars.PreviousPlanet.Name}");
            // Console.WriteLine("Марс = Венера - " + (mars.Equals(venus)));

            // Console.WriteLine($"Название {venus2.Name} " +
            //    $"\n Порядковый номер от Солнца {venus2.SolarNumber} " +
            //    $"\n Длина экватора  {venus2.EquatorLen} " +
            //    $"\n Предыдущая планета {venus2.PreviousPlanet.Name}");
            // Console.WriteLine("Венера2 = Венера - " + (venus2.Equals(venus)));

            dynamic s = venus2;
            var nextStep = true;
            do
            {
                if (s.PreviousPlanet != null)
                {
                    Console.WriteLine($"Название {s.Name} " +
                $"\n Порядковый номер от Солнца {s.SolarNumber} " +
                $"\n Длина экватора  {s.EquatorLen} " +
                $"\n Предыдущая планета {s.PreviousPlanet.Name}");
                    Console.WriteLine($"{s.Name} = Венера - " + s.Equals(venus));
                    s = s.PreviousPlanet;
                }
                else
                {
                    Console.WriteLine($"Название {s.Name} " +
                $"\n Порядковый номер от Солнца {s.SolarNumber} " +
                $"\n Длина экватора  {s.EquatorLen} " +
                $"\n Предыдущая планета {s.PreviousPlanet}");
                    Console.WriteLine($"{s.Name} = Венера - " + s.Equals(venus));
                    nextStep = false;
                }

            } while (nextStep);
        }

        // Метод вызова второй программы
        private static void EasyClassPlanet()
        {
            var catalogP = new CatalogPlanet();

            Console.WriteLine(catalogP.GetPlanet(E));
            Console.WriteLine(catalogP.GetPlanet(V));
            Console.WriteLine(catalogP.GetPlanet(l));
        }

        // Метод вызова третьей программы
        private static void AnotherMethod()
        {
            var catalogP = new CatalogPlanetA();

            Console.WriteLine(catalogP.GetPlanet(E, catalogP.Validator));
            Console.WriteLine(catalogP.GetPlanet(V, catalogP.Validator));
            Console.WriteLine(catalogP.GetPlanet(l, catalogP.Validator));
            Console.WriteLine(catalogP.GetPlanet(m, catalogP.Validator));
            Console.WriteLine(catalogP.GetPlanet(E, catalogP.Validator));
            Console.WriteLine(catalogP.GetPlanet(V, catalogP.Validator));
            Console.WriteLine(catalogP.GetPlanet(l, catalogP.Validator));
            Console.WriteLine(catalogP.GetPlanet(m, catalogP.Validator));
            Console.WriteLine(catalogP.GetPlanet(E, catalogP.Validator));
            Console.WriteLine(catalogP.GetPlanet(V, catalogP.Validator));
            Console.WriteLine(catalogP.GetPlanet(l, catalogP.Validator));
            Console.WriteLine(catalogP.GetPlanet(m, catalogP.Validator));
            Console.WriteLine(catalogP.GetPlanet("Другая планета", catalogP.Validator));
            Console.WriteLine(catalogP.GetPlanet(E, message => counter3 == 3 ? " - Вы спрашиваете слишком часто" : null));
            Console.WriteLine(catalogP.GetPlanet(E, message => counter3 == 3 ? " - Вы спрашиваете слишком часто" : null));
            Console.WriteLine(catalogP.GetPlanet(l, message => l == l ? " - Это запретная планета" : null));
            Console.WriteLine(catalogP.GetPlanet(E, message => E == l ? " - Это запретная планета" : null));
            Console.WriteLine(catalogP.GetPlanet(V, message => V == l ? " - Это запретная планета" : null));
        }

        // Класс планета и класс список
        private class Planet
        {
            public string Name { get; set; }

            public int SolarNumber { get; set; }

            public int EquatorLen { get; set; }

            public Planet PreviousPlanet { get; set; }
        }

        private class CatalogPlanet
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

            // Мотод получения номера планеты и длины экватора
            // Счётчик метода GetPlanet
            private int counter = 0;

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


        // Список с новым методом

        private class CatalogPlanetA
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

            // Новый метод получения номера планеты и длины экватора


            public string Validator(string namePl)
            {
                var r = "";
                switch (namePl)
                {
                    case "Венера":
                        counterV++;
                        r = $"  Вы спрашиваете про {namePl} - {counterV} - раз";
                        break;
                    case "Земля":
                        counterE++;
                        r = $"  Вы спрашиваете про {namePl} - {counterE} - раз";
                        break;
                    case "Марс":
                        counterM++;
                        r = $"  Вы спрашиваете про {namePl} - {counterM} - раз";
                        break;
                }
                counter3++;
                if (counter3 == 3)
                {
                    counter3 = 0;
                    r = r + "  Вы спрашиваете слишком часто!  ";
                }

                return r;
            }


            public (int s, int e, string E) GetPlanet(string planetName, PlanetValidator planetValidator)
            {

                Planet p = new Planet();
                string message;
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
                message += planetValidator(planetName);

                return (p.SolarNumber, p.EquatorLen, message);
            }

            public delegate string PlanetValidator(string a);

        }
    }
}
