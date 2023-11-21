using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace AlgorithmLab3
{
    internal class Task4
    {

        public static void Start()
        {
            Console.WriteLine("Enter task number(1-12)");
            string inp = Console.ReadLine();

            OurStack<string> stack = new OurStack<string>();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            stack.Push("4");
            stack.Push("5");
            Console.Write("Исходный: ");
            stack.Print();
            Console.WriteLine();
            string x = "";
            string y = "";
            if(inp == "5" || inp == "6" || inp == "7" || inp == "8" || inp == "10" || inp == "12")
            {
                Console.WriteLine("Введите x: ");
                x = Console.ReadLine();
            }
            if (inp == "8" || inp == "12")
            {
                Console.WriteLine("Введите y: ");
                y = Console.ReadLine();
            }
            Console.Write("Результат: ");

            switch (inp)
            {
                case "1":
                    stack.Reverse();
                    stack.Print();
                    break;
                case "2":
                case "2.1":
                    stack.TopToBot();
                    stack.Print();
                    break;
                case "2.2":
                    stack.BotToTop();
                    stack.Print();
                    break;
                case "3":
                    Console.WriteLine(stack.CountDifElems());
                    break;
                case "4":
                    stack.MakeUnique();
                    stack.Print();
                    break;
                case "5":
                    stack.SelfInsert(x);
                    stack.Print();
                    break;
                case "6":
                    stack.OrderedInsert(x);
                    stack.Print();
                    break;
                case "7":
                    stack.OrderedInsert(x);
                    stack.Print();
                    break;
                case "8":
                    stack.IfElemInsert(x, y);
                    stack.Print();
                    break;
                case "9":
                    Append();
                    break;
                case "10":
                    Console.WriteLine();
                    Console.WriteLine(stack.Split(x));
                    stack.Print();
                    break;
                case "11":
                    stack.Double();
                    stack.Print();
                    break;
                case "12":
                    stack.Swap(x, y);
                    stack.Print();
                    break;
                default:
                    break;
            }
        }

        //append
        public static void Append()
        {
            Console.WriteLine("Enter path to first Stack");
            string[] first = Tasks12.ReadSeqFromFile();
            Console.WriteLine("Enter path to second Stack");
            string[] second = Tasks12.ReadSeqFromFile();

            OurStack<string> s1 = new OurStack<string>();
            foreach (string f in first)
            {
                s1.Push(f);
            }

            OurStack<string> s2 = new OurStack<string>();
            foreach (string s in second)
            {
                s2.Push(s);
            }
            s1.Append(s2);
            s1.Print();
        }
    }
}
