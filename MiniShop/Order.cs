using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop
{
    public class Order
    {

        // typ wyliczeniowy
        enum OrderStatus
        {
            NewOrder = 10,
            Complete = 20,
            Confirmed = 30,
            Shipped = 40,
            Returned = 50,
            Cancelled = 60
        }

        private String orderNumber;
        private List<OrderItem> items = new List<OrderItem>(); //utworzona pusta lista
        private byte discount = 0;
        private String customerName;
        private String shipAddress;
        private DateTime orderDate;
        private OrderStatus status = OrderStatus.NewOrder;
        
        public double TotalAmount
        {
            get { return CalcTotalAmount(); }
        }

        private int GetProductIndex(Product product)
        {
            int result = -1;

            for (int i = 0; i < items.Count; i++)
            {
                if ( items[i].ProductName.Equals(product.ToString()) )
                {
                    return i;
                }

            }

            return result;
        }

        //metody
        public bool AddProduct(Product product, int qnty)
        {
            //akcja dodania produktu do listy produktow
            if (status == OrderStatus.NewOrder && qnty > 0 && product != null)
            {
                int productIndex = items.FindIndex(x => x.ProductName.Equals(product.ToString()));
                //int productIndex = GetProductIndex(product);
                if (productIndex == -1)
                {
                    items.Add(new OrderItem(product, qnty));
                }
                else
                {
                    items[productIndex].Qnty += qnty;
                }

                return true;
            } 
            
            else
            {
                return false;
            }
        }

        public bool RemoveProduct (Product product, int qnty=0)
        {
            if (status == OrderStatus.NewOrder && qnty >= 0 && product!= null)
            {
                int productIndex = items.FindIndex(x => x.ProductName.Equals(product.ToString()));

                //int productIndex = GetProductIndex(product);
                if (productIndex == -1) return false;
                if (qnty > items[productIndex].Qnty) return false;
                if (qnty ==0 || qnty==items[productIndex].Qnty)
                {
                    items.RemoveAt(productIndex);
                    return true;
                }

                items[productIndex].Qnty -= qnty;
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Clear()
        {
            if (status == OrderStatus.NewOrder)
            {
                items.Clear();
                return true;
            } else
            {
                return false;
            }
        }

        private double CalcTotalAmount()
        {
            double amount = 0.0;
            items.ForEach(e => amount += e.ProductPrice * e.Qnty);

            //foreach (var item in items)
            //{
            //    amount += item.ProductPrice * item.Qnty;
            //}
            if (discount>0 && discount<=100)
            {
                amount *= (100 - discount) / 100.0;
            }
            return amount;
        }

        public void Print()
        {
            Console.WriteLine("Elementy zamówienia:");
            items.ForEach(e => Console.WriteLine("{0,-30}|{1,10}|{2,10:0.00} zł|{3,12:0.00} zł|",
                    e.ProductName, e.Qnty, e.ProductPrice, e.ProductPrice * e.Qnty));

            //foreach (var item in items)
            //{
            //    Console.WriteLine("{0,-30}|{1,10}|{2,10:0.00} zł|{3,12:0.00} zł|", 
            //        item.ProductName, item.Qnty, item.ProductPrice, item.ProductPrice*item.Qnty);
            //}
            Console.WriteLine("Do zapłaty: {0:0.00}", CalcTotalAmount() );
        }
    }
}
