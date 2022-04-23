using System.Collections.Generic;
using System.Web.Http;

namespace n01495499.Controllers
{
    public class item
    {
        public string name { get; set; }
        public int number { get; set; }
        public int calories { get; set; }
    }
    public class j1
    {
        public j1()
        {
            burger = new List<item>();
            drink = new List<item>();
            side = new List<item>();
            dessert = new List<item>();
        }
        public List<item> burger { get; set; }
        public List<item> drink { get; set; }
        public List<item> side { get; set; }
        public List<item> dessert { get; set; }
    }

    [RoutePrefix("api")]
    public class questionController : ApiController
    {
        j1 data;
        public questionController()
        {
            // fill data
            data = new j1();
            data.burger.AddRange(new List<item>() {
                new item() { name = "Cheeseburger", number = 1, calories = 461 },
                new item() { name = "Fish Burger", number = 2, calories = 431 },
                new item() { name = "Veggie Burger", number = 3, calories = 420 },
                new item() { name = "no burger", number = 4, calories = 0 },
                });

            data.side.AddRange(new List<item>() {
                new item() { name = "Fries", number = 1, calories = 100 },
                new item() { name = "Baked Potato", number = 2, calories = 57 },
                new item() { name = "Chef Salad ", number = 3, calories = 70 },
                new item() { name = "no side order", number = 4, calories = 0 },
                });

            data.drink.AddRange(new List<item>() {
                new item() { name = "Soft Drink", number = 1, calories = 130 },
                new item() { name = "Orange Juice", number = 2, calories = 160 },
                new item() { name = "Milk", number = 3, calories = 118 },
                new item() { name = "no drink", number = 4, calories = 0 },
                });

            data.dessert.AddRange(new List<item>() {
                new item() { name = "Apple Pie", number = 1, calories = 167 },
                new item() { name = "Sundae", number = 2, calories = 266 },
                new item() { name = "Fruit Cup", number = 3, calories = 75 },
                new item() { name = "dessert", number = 4, calories = 0 },
                });
        }

        /// <summary>
        /// This method is to calculate calories depends on number from 1 to 4
        /// </summary>

        [HttpGet]
        [Route("J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public string menu(int burger, int drink, int side, int dessert)
        {
            if (burger < 5 && drink < 5 && side < 5 && dessert < 5)
            {
                int totalcalories = 0;
                totalcalories += data.burger.Find(x => x.number == burger).calories;
                totalcalories += data.drink.Find(x => x.number == drink).calories;
                totalcalories += data.side.Find(x => x.number == side).calories;
                totalcalories += data.dessert.Find(x => x.number == dessert).calories;
                return "Your total Calorie count is " + totalcalories.ToString();
            }
            return "";
        }

        /// <summary>
        /// this method is to find number of occurances that gives m+n =10
        /// </summary>
  
        [HttpGet]
        [Route("J2/DiceGame/{m}/{n}")]
        public string DiceGame(int m, int n)
        {
            int ways = 0;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i + j == 10)
                    {
                        ways += 1;
                    }
                }
            }
            if (ways == 1)
                return "There is " + ways + " way to get the sum 10.";
            else
                return "There are " + ways + " way to get the sum 10.";
        }

    }
}
