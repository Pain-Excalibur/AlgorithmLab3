using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab3
{
    public class Task3_Queue
    {
        public static void Start()
        {
            OrderProcessor orderProcessor = new OrderProcessor();

            Order order1 = new Order { Dish = "Пицца", Quantity = 2 };
            orderProcessor.AddOrder(order1);

            Order order2 = new Order { Dish = "Салат", Quantity = 1 };
            orderProcessor.AddOrder(order2);

            Order order3 = new Order { Dish = "Паста", Quantity = 3 };
            orderProcessor.AddOrder(order3);

            orderProcessor.ProcessOrders();

            Console.ReadLine();
        }
    }
    
    
    public class Order
    {
        public string Dish { get; set; }
        public int Quantity { get; set; }
    }
    
   
    public class OrderProcessor
    {
        private Queue<Order> orderQueue;

        public OrderProcessor()
        {
            orderQueue = new Queue<Order>();
        }

        public void AddOrder(Order order)
        {
            orderQueue.Enqueue(order);
            Console.WriteLine("Заказ добавлен в очередь.");
        }

        public void ProcessOrders()
        {
            while (orderQueue.Count > 0)
            {
                Order order = orderQueue.Dequeue();
                Console.WriteLine($"Обработка заказа: {order.Dish} ({order.Quantity} шт.)");
                // Здесь можно добавить обработку заказа, например, отправить его на кухню
            }
            Console.WriteLine("Все заказы обработаны.");
        }
    }    
}
