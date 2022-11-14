using System;
using System.Collections.Generic;

namespace _3_1_订单和账本
{
    class OrderForm
    {
        public string name;
        public int num;
        public float price;

        public OrderForm(string name,int num, float price)
        {
            this.name = name;
            this.num = num;
            this.price = price;
        }

        public float GetPrice()
        {
            return num * price;
        }

      
    }

    class AccountBook
    {
        List<OrderForm> orders = new List<OrderForm>();

        public OrderForm AddOrder(OrderForm order)
        {
            orders.Add(order);
            return order;
        }

        public float TotalPrice()
        {
            float sum = 0;
            for (int i = 0; i < orders.Count; i++)
            {
                sum += orders[i].GetPrice();
            }
            return sum;
        }
        public bool RemoveByIndex(int i)
        {
            if (i < 0 || i >= orders.Count)
            { return false; }
            orders.RemoveAt(i);
            return true;
        }

        public bool RemoveByObject(OrderForm order)
        {
            //return orders.Remove(order);

            for (int i = 0; i < orders.Count; i++)
            {
                if(orders[i] == order)  // 判断引用相等，即是同一个对象
                { orders.RemoveAt(i); return true; }
            }
            return false;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderForm order1 = new OrderForm("苹果", 10, 0.5f);
            OrderForm order2 = new OrderForm("香蕉", 20, 1f);
            OrderForm order3 = new OrderForm("冰激凌", 3, 5f);

            AccountBook book = new AccountBook();

            book.AddOrder(order1);
            book.AddOrder(order2);
            book.AddOrder(order3);

            float total = book.TotalPrice();

            Console.WriteLine("订单总价格：" + total);

            Console.ReadKey();

        }
    }
}
