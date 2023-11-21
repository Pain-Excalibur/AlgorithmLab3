using AlgorithmLab3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Task3
    {
        public static void Choice()
        {
            Console.WriteLine("Выберите задачу: Stack, Queue, List, Tree");
        Point:
            string task = Console.ReadLine();
            switch (task)
            {
                case ("1" or "Stack" or "stack"):
                    Task3_Stack.Start();
                    break;

                case ("2" or "Queue" or "queue"):
                    Task3_Queue.Start();
                    break;

                case ("3" or "List" or "list"):
                    Task3_List.Start();
                    break;

                case ("4" or "Tree" or "tree"):
                    Task3_Tree.Start();
                    break;

                default:
                    Console.WriteLine("Неверное значение. Введите название или номер задачи");
                    goto Point;
            }
        }
    }
}
