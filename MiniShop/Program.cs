using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Product prMaseczka = new Product(1, "Maseczka", 2.99);
            Product prRyz = new Product(2, "Ryż", 4.99);
            Product prPapier = new Product(3, "Papier toaletowy", 14.50, "Regina - 3 grube warstwy");

            Order order = new Order();

            order.AddProduct(prMaseczka, 10);
            order.AddProduct(prPapier, 2);
            order.AddProduct(prRyz, 5);
            order.AddProduct(prMaseczka, 15);
            order.AddProduct(prPapier, 3);

            order.RemoveProduct(prMaseczka, 999);
            order.RemoveProduct(prMaseczka, 5);
            order.RemoveProduct(prPapier, 1);
            order.RemoveProduct(prRyz);


            order.Print();

            Console.ReadKey();

        }
    }
}
