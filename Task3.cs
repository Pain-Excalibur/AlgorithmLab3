using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Task3
    {
        public static Stack<int> stack = new Stack<int>();
        public static void StackTask()
        {
            Console.WriteLine("Enter path:");
            var strNumber = new StreamReader(Console.ReadLine());
            string str = strNumber.ReadToEnd();
            int number = int.Parse(str);
            int mode = int.Parse(Console.ReadLine());

            del(number, mode);

            while (stack.Any())
            {
                Console.WriteLine(stack.Pop());
            }
        }
        public static bool del(int number, int mode)
        {
            if (number % 16 > 0)
            {
                stack.Push(number % 16);
                number = number / 16;
                return (del(number, mode));
            }
            else
            {
                return true;
            }
        }

        public static void QueueTask()
        {
            int time = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();

            for (int i = time; i >= 0; i--)
            {
                queue.Enqueue(i);
            }

            while (queue.Any())
            {
                Console.WriteLine(queue.Dequeue());
                Thread.Sleep(1000);
            }
        }

        private static int[] TreeSort(int[] array)
        {
            var treeNode = new Tree(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                treeNode.Insert(new Tree(array[i]));
            }

            return treeNode.Transform();
        }

        public static void Start()
        {
            //Task3.StackTask();
            //Task3.QueueTask();


            //вызов сортировки деревом
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());

            var arr = new int[n];
            List<int> list = new List<int>();
            var random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(0, 100);
                list.Add(arr[i]);
            }

            int[] results = Bubble.Sort(list);
            foreach (int result in results)
            {
                Console.WriteLine(result);
            }

            //дерево
            //Console.WriteLine("Random Array: {0}", string.Join(" ", a));

            //Console.WriteLine("Sorted Array: {0}", string.Join(" ", TreeSort(a)));
        }
    }
}
