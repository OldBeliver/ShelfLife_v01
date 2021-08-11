using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelfLife_v01
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            DateTime startDay = new DateTime(2018,06,01);
            DateTime endDay = new DateTime(2021,08,10);
            DateTime randomDay;
            int easyday;
            Random random = new Random();

            while (true)
            {
                easyday = (endDay - startDay).Days;

                randomDay = startDay.AddDays(random.Next(easyday));

                Console.WriteLine($"{randomDay.ToLongDateString()}");

                Console.ReadKey();
            }
            */
        }
    }

    class Creator
    {
        private static Random _random;
        private Product _product;

        static Creator()
        {
            _random = new Random();
        }

        public Creator()
        {
           
        }

        public Product CreateNewTinnedMeat()
        {
            return new Product();
        }

        private string CreateTinnedMeatName()
        {
            string name;
            string[] names = new string[]
            {
                "Свинятина тушеная",
                "Телятина тушеная",
                "Курятина тушеная",
                "Крольчатина тушеная",
                "Кенгурятина тушеная",
                "Оленятина тушеная",
                "Лосятина тушеная"
            };

            name = names[_random.Next(names.Length)];

            return name;
        }

        private DateTime CreateManufacturingDate()
        {
            DateTime firstDay = new DateTime(2018, 06, 01);
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public DateTime ManufacturingDate { get; private set; }
        public int LifeTimeInYears { get; private set; }
        public DateTime LastDay { get; private set; }

        public Product(string name, DateTime manufacturingDate, int lifeTimeInYears)
        {
            Name = name;
            ManufacturingDate = manufacturingDate;
            LifeTimeInYears = lifeTimeInYears;
            LastDay = ManufacturingDate.AddYears(LifeTimeInYears);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} годна до {LastDay.ToString("dd.MM.yyyy")}");
        }
    }
}
