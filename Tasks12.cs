using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab3
{
    internal class Tasks12
    {
        public static bool isStack = false;
        public static bool isTime = false;
        public static bool isPostfixTask = false;
        public static bool isCs = false;

        public static void Start()
        {
            Survey();

            if (isPostfixTask)
            {
                if (isTime)
                {
                    List<double> timeArray = new List<double>();

                    foreach (string expression in ReadSeqFromFile())
                    {
                        Stopwatch timeOfSequence = new Stopwatch();
                        timeOfSequence.Start();
                        Console.WriteLine("Difficulty: " + SolveExpression(expression));

                        timeOfSequence.Stop();
                        timeArray.Add(timeOfSequence.ElapsedTicks / 10000000.0d);
                    }

                    StreamWriter sw = File.CreateText("output.txt");
                    foreach (double i in timeArray)
                    {
                        sw.WriteLine(i);
                    }
                    sw.Close();
                    Process.Start("notepad.exe", "output.txt");

                }
                else
                {
                    foreach (string expression in ReadSeqFromFile())
                        Console.WriteLine("Difficulty: " + SolveExpression(expression));
                }
            }
            else
            {
                if (isTime)
                {
                    double[] timeArray = SequencesHandler(ReadSeqFromFile());

                    StreamWriter sw = File.CreateText("output.txt");
                    foreach (double i in timeArray)
                    {
                        sw.WriteLine(i);
                    }
                    sw.Close();
                    Process.Start("notepad.exe", "output.txt");

                }
                else
                {
                    SequencesHandler(ReadSeqFromFile());
                }
            }
        }

        public static void Survey()
        {
        Tasks:
            Console.WriteLine("Tasks 1-2(1) or Task 3(3) or Task 4(4)");
            string tasks = Console.ReadLine();
            switch(tasks)
            {
                case "3":
                    Task3.Choice();
                    Environment.Exit(0);
                    break;
                case "4":
                    Task4.Start();
                    Environment.Exit(0);
                    break;
                case "1":
                case "2":
                    break;
                default:
                    Console.WriteLine("Sorry, but we have no such option! Try again, please.");
                    goto Tasks;


            }


        SoQ:
            Console.WriteLine("Stack(s) or Queue(q)?");
            string SoQ = Console.ReadLine();
            switch (SoQ)
            {
                case "s":
                    isStack = true;
                    break;
                case "q":
                    break;
                default:
                    Console.WriteLine("Sorry, but we have no such option! Try again, please.");
                    goto SoQ;
            }

        csormy:
            string chosenCollection;
            if (isStack)
                chosenCollection = "Stack";
            else
                chosenCollection = "Queue";
            Console.WriteLine("C# " + chosenCollection + "(c) or  Our " + chosenCollection + "(o)?");
            string csormy = Console.ReadLine();
            switch (csormy)
            {
                case "c":
                    isCs = true;
                    break;
                case "o":
                    break;
                default:
                    Console.WriteLine("Sorry, but we have no such option! Try again, please.");
                    goto csormy;
            }

        mT:
            Console.WriteLine("Measure time(y/n)?");
            string mT = Console.ReadLine();
            switch (mT)
            {
                case "y":
                    isTime = true;
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Sorry, but we have no such option! Try again, please.");
                    goto mT;
            }
            if (isStack && !isCs)
            {
            iE:
                Console.WriteLine("Collections functionality(f) or Solve Equation(e)?");
                string iE = Console.ReadLine();
                switch (iE)
                {
                    case "e":
                        isPostfixTask = true;
                        break;
                    case "f":
                        break;
                    default:
                        Console.WriteLine("Sorry, but we have no such option! Try again, please.");
                        goto iE;
                }
            }
        }

        public static string[] ReadSeqFromFile()
        {

            Console.WriteLine("Please, enter path to input.txt");
        Path:
            string path = Console.ReadLine();

            try
            {
                string[] sequences = File.ReadAllLines(path);
                return sequences;
            }
            catch
            {
                Console.WriteLine("Sorry, but you wrote the path incorrectly! Try again, please.");
                goto Path;
            }

        }

        public static double[] SequencesHandler(string[] sequences)
        {
            double[] timeArray = new double[sequences.Length];
            for (int i = 0; i < sequences.Length; i++)
            {
                Stopwatch timeOfSequence = new Stopwatch();
                timeOfSequence.Start();

                string[] partedSequence = sequences[i].Split(' ');

                Stack<string> csStack = new Stack<string>();
                Queue<string> csQueue = new Queue<string>();
                OurStack<string> ourStack = new OurStack<string>();
                OurQueue<string> ourQueue = new OurQueue<string>();

                foreach (string sequenceInstance in partedSequence)
                {
                    switch (sequenceInstance[0])
                    {
                        case '1':
                            if (isCs)
                            {
                                if (isStack)
                                {
                                    //csstack
                                    csStack.Push(sequenceInstance.Substring(2));
                                }
                                else
                                {
                                    //csqueue
                                    csQueue.Enqueue(sequenceInstance.Substring(2));
                                }
                            }
                            else
                            {
                                if (isStack)
                                {
                                    //ourStack
                                    ourStack.Push(sequenceInstance.Substring(2));
                                }
                                else
                                {
                                    //ourQueue
                                    ourQueue.Enqueue(sequenceInstance.Substring(2));
                                }

                            }

                            break;
                        case '2':
                            if (isCs)
                            {
                                if (isStack)
                                {
                                    //csstack
                                    Console.Write(csStack.Pop() + ", ");
                                }
                                else
                                {
                                    //csqueue
                                    Console.Write(csQueue.Dequeue() + ", ");
                                }
                            }
                            else
                            {
                                if (isStack)
                                {
                                    //ourStack
                                    Console.Write(ourStack.Pop() + ", ");
                                }
                                else
                                {
                                    //ourQueue
                                    Console.Write(ourQueue.Dequeue() + ", ");
                                }

                            }

                            break;
                        case '3':
                            if (isCs)
                            {
                                if (isStack)
                                {
                                    //csstack
                                    try
                                    {
                                        Console.Write(csStack.Peek() + ", ");
                                    }
                                    catch
                                    {
                                        Console.Write("");
                                    }
                                }
                                else
                                {
                                    //csqueue
                                    try
                                    {
                                        Console.Write(csQueue.Peek() + ", ");
                                    }
                                    catch
                                    {
                                        Console.Write("");
                                    }
                                }
                            }
                            else
                            {
                                if (isStack)
                                {
                                    //ourStack
                                    Console.Write(ourStack.Top() + ", ");
                                }
                                else
                                {
                                    //ourQueue
                                    Console.Write(ourQueue.Peek() + ", ");
                                }

                            }

                            break;
                        case '4':
                            if (isCs)
                            {
                                if (isStack)
                                {
                                    //csstack
                                    Console.Write(Convert.ToString(!csStack.Any()) + ", ");
                                }
                                else
                                {
                                    //csqueue
                                    Console.Write(Convert.ToString(!csQueue.Any()) + ", ");
                                }
                            }
                            else
                            {
                                if (isStack)
                                {
                                    //ourStack
                                    Console.Write(Convert.ToString(ourStack.IsEmpty()) + ", ");
                                }
                                else
                                {
                                    //ourQueue
                                    Console.Write(Convert.ToString(ourQueue.IsEmpty()) + ", ");
                                }

                            }

                            break;
                        case '5':
                            if (isCs)
                            {
                                if (isStack)
                                {
                                    //csstack
                                    Console.WriteLine(csStack.ToString());
                                }
                                else
                                {
                                    //csqueue
                                    Console.WriteLine(csQueue.ToString());
                                }
                            }
                            else
                            {
                                if (isStack)
                                {
                                    //ourStack
                                    ourStack.Print();
                                }
                                else
                                {
                                    //ourQueue
                                    ourQueue.Print();
                                }

                            }
                            Console.Write(", ");
                            break;
                        default:
                            Console.WriteLine("Unknown Command!");
                            break;
                    }

                }
                timeOfSequence.Stop();
                timeArray[i] = timeOfSequence.ElapsedTicks / 10000000.0d;
            }
            return timeArray;
        }

        public static double SolveExpression(string expression)
        {
            OurStack<string> ourStack = new OurStack<string>();

            string[] partedExpression = expression.Split(" ");
            int difficulty = 0;

            string[] formattedExpression = InFixToPostFix(partedExpression);

            foreach (string i in formattedExpression)
            {
                if (double.TryParse(i, out double number))
                {
                    ourStack.Push(i);
                }
                else
                {
                    difficulty++;
                    switch (i)
                    {
                        case "+":
                            ourStack.Push(Convert.ToString(Convert.ToDouble(ourStack.Pop()) + Convert.ToDouble(ourStack.Pop())));
                            ourStack.Pop();
                            break;
                        case "-":
                            string substractor = ourStack.Pop();
                            ourStack.Push(Convert.ToString(Convert.ToDouble(ourStack.Pop()) - Convert.ToDouble(substractor)));
                            ourStack.Pop();
                            break;
                        case "*":
                            ourStack.Push(Convert.ToString(Convert.ToDouble(ourStack.Pop()) * Convert.ToDouble(ourStack.Pop())));
                            ourStack.Pop();
                            break;
                        case "/":
                        case ":":
                            string divider = ourStack.Pop();
                            ourStack.Push(Convert.ToString(Convert.ToDouble(ourStack.Pop()) / Convert.ToDouble(divider)));
                            break;
                        case "^":
                            string power = ourStack.Pop();
                            ourStack.Push(Convert.ToString(Math.Pow(Convert.ToDouble(ourStack.Pop()), Convert.ToDouble(power))));
                            break;
                        case "ln":
                            ourStack.Push(Convert.ToString(Math.Log(Convert.ToDouble(ourStack.Pop()))));
                            break;
                        case "cos":
                            ourStack.Push(Convert.ToString(Math.Cos(Convert.ToDouble(ourStack.Pop()))));
                            break;
                        case "sin":
                            ourStack.Push(Convert.ToString(Math.Sin(Convert.ToDouble(ourStack.Pop()))));
                            break;
                        case "sqrt":
                            ourStack.Push(Convert.ToString(Math.Sqrt(Convert.ToDouble(ourStack.Pop()))));
                            break;
                    }
                }
            }
            Console.WriteLine("Result: " + ourStack.Pop());
            return difficulty;
        }

        public static string[] InFixToPostFix(string[] partedSequence)
        {
            StringBuilder expression = new StringBuilder();
            OurStack<string> ourStack = new OurStack<string>();


            foreach (string sequenceInstance in partedSequence)
            {
                if (sequenceInstance.Contains('.'))
                {
                    expression.Append(sequenceInstance.Replace('.', ',') + " ");
                }

                if (double.TryParse(sequenceInstance, out double number))
                {
                    expression.Append(sequenceInstance + " ");
                }
                else if (sequenceInstance == "sin" || sequenceInstance == "cos" || sequenceInstance == "sqrt" || sequenceInstance == "ln" || sequenceInstance == "(")
                {
                    ourStack.Push(sequenceInstance);
                }
                else if (sequenceInstance == ")")
                {



                    while (ourStack.Top() != "(")
                    {
                        expression.Append(ourStack.Pop() + " ");
                    }
                    ourStack.Pop();
                }
                else if (sequenceInstance == "+" || sequenceInstance == "-" || sequenceInstance == "*" || sequenceInstance == "/" || sequenceInstance == ":" || sequenceInstance == "^")
                {
                    while (!ourStack.IsEmpty() && ((ourStack.Top() == "^") || ((ourStack.Top() == "*" || ourStack.Top() == "/" || ourStack.Top() == ":" || ourStack.Top() == "^") && (sequenceInstance != "^")) || ((ourStack.Top() == "+" || ourStack.Top() == "-") && (sequenceInstance == "+" || sequenceInstance == "-"))))
                    {
                        expression.Append(ourStack.Pop() + " ");
                    }
                    ourStack.Push(sequenceInstance);
                }
            }
            while (!ourStack.IsEmpty())
            {
                if (ourStack.Top() != "(")
                    expression.Append(ourStack.Pop() + " ");
                else
                    ourStack.Pop();
            }
            expression.Length--;

            return expression.ToString().Split(" ");

        }

    }
}
