using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Order_Program
{
    public class Program
    {
        public class Pizza
        {
            public int Price { get; set; }
            public string Name { get; set; }
            public int MenuNumber { get; set; }
        }

        public static void Main(string[] args)
        {
            List<Pizza> pizzas = new List<Pizza>
            {
                new Pizza { MenuNumber = 1, Name = "Margherita", Price = 54 },
                new Pizza { MenuNumber = 2, Name = "Roma", Price = 60 },
                new Pizza { MenuNumber = 3, Name = "Husets Pizza", Price = 70 }
            };

            int i = 0;
            do
            {
                Console.WriteLine("Velkommen til Hvad vil du Bestille");

                foreach (Pizza p in pizzas)
                {
                    Console.WriteLine($"{p.MenuNumber}. ----- {p.Name} - {p.Price}Kr.");
                }

                string svar = Console.ReadLine();
                string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(svar.ToLower());

                List<Pizza> yourOrders = new List<Pizza> { };

                try
                {
                    int order = Convert.ToInt32(svar);
                    foreach (Pizza p in pizzas)
                    {
                        if (p.MenuNumber == order)
                        {
                            yourOrders.Add(pizzas[order -1]);
                            Console.WriteLine(pizzas[order -1].Name);
                        } 
                    } 
                }
                catch (Exception) { }
                finally
                {
                    foreach (Pizza p in pizzas)
                    {
                        if (p.Name.ToLower() == svar.ToLower())
                        {
                            Console.WriteLine($"Ok har valgt {titleCase}");
                        }
                    }
                }
            }
            while (i == 0);


            Console.WriteLine("Press Enter to Exit Program");
            Console.ReadLine();
        }
    }
}