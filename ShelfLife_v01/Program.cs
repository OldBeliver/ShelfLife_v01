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
            Creator creator = new Creator();
            List<Product> tinnedMeat = new List<Product>();

            for (int i = 0; i < 20; i++)
            {
                tinnedMeat.Add(creator.CreateNewTinnedMeat());
            }

            Console.WriteLine($"список продукции на складе, в ящиках");

            for (int i = 0; i < tinnedMeat.Count; i++)
            {
                Console.Write($"{i+1:d2}. ");
                tinnedMeat[i].ShowInfo();
            }

            Console.WriteLine($"\nНажмите, чтобы получить список просроченной продукции");
            Console.ReadKey();

            var FilteredOverdueDate = tinnedMeat.Where(product => product.ExpiryDay < DateTime.Today);

            foreach (var product in FilteredOverdueDate)
            {
                product.ShowInfo();
            }
        }
    }

    class Creator
    {
        private static Random _random;
        
        private DateTime _firstDay;
        private DateTime _lastDay;

        static Creator()
        {
            _random = new Random();
        }

        public Creator()
        {
            _firstDay = new DateTime(2016, 06, 01);
            _lastDay = new DateTime(2021, 08, 10);
        }

        public Product CreateNewTinnedMeat()
        {
            return new Product(CreateTinnedMeatName(), CreateNewManufacturingDate(_firstDay, _lastDay), CreateNewLifeTimeInYears());
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

        private DateTime CreateNewManufacturingDate(DateTime _firstDay, DateTime _lastDay)
        {
            int period = (_lastDay - _firstDay).Days;

            return _firstDay.AddDays(_random.Next(period));
        }

        private int CreateNewLifeTimeInYears()
        {
            int minLifeTime = 2;
            int maxLifeTime = 6;

            return _random.Next(minLifeTime, maxLifeTime + 1);
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public DateTime ManufacturingDate { get; private set; }
        public int LifeTimeInYears { get; private set; }
        public DateTime ExpiryDay { get; private set; }

        public Product(string name, DateTime manufacturingDate, int lifeTimeInYears)
        {
            Name = name;
            ManufacturingDate = manufacturingDate;
            LifeTimeInYears = lifeTimeInYears;
            ExpiryDay = ManufacturingDate.AddYears(LifeTimeInYears);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} годна до {ExpiryDay.ToString("dd.MM.yyyy")}");
        }
    }
}
