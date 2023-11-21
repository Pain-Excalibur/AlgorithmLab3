using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab3
{
    internal class Task3_Stack
    {
        public static Stack<int> stack = new Stack<int>();
        public static void Start()
        {
            Console.WriteLine("Введите десятичное число:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите желаемую систему счисления:");
            int mode = int.Parse(Console.ReadLine());

            del(number, mode);

            Console.WriteLine("Результат: ");
            while (stack.Any())
            {
                Console.Write(stack.Pop());
            }
        }
        public static bool del(int number, int mode)
        {
            if (number % mode > 0)
            {
                stack.Push(number % mode);
                number = number / mode;
                return (del(number, mode));
            }
            else
            {
                return true;
            }
        }
    }
}
