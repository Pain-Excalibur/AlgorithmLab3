using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab3
{
    internal class Tasks
    {
        public static bool isStack = false;
        public static bool isTime = false;//done
        public static bool isPostfixTask = false;//hard
        public static bool isCs = false;

        public static void Start()
        {
            Survey();

            //DOALG
            if (isPostfixTask)
            {
                //postfixtask
                foreach (string expression in ReadSeqFromFile())
                    Console.WriteLine("Difficulty: " + SolveExpression(expression));
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
                                    //ourstack
                                    OurStack.Push(sequenceInstance.Substring(2));
                                }
                                else
                                {
                                    //ourqueue
                                    OurQueue.Enqueue(sequenceInstance.Substring(2));
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
                                    //ourstack
                                    Console.Write(OurStack.Pop() + ", ");
                                }
                                else
                                {
                                    //ourqueue
                                    Console.Write(OurQueue.Dequeue() + ", ");
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
                                    //ourstack
                                    Console.Write(OurStack.Top() + ", ");
                                }
                                else
                                {
                                    //ourqueue
                                    Console.Write(OurQueue.Peek() + ", ");
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
                                    //ourstack
                                    Console.Write(Convert.ToString(OurStack.IsEmpty()) + ", ");
                                }
                                else
                                {
                                    //ourqueue
                                    Console.Write(Convert.ToString(OurQueue.IsEmpty()) + ", ");
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
                                    //ourstack
                                    OurStack.Print();
                                }
                                else
                                {
                                    //ourqueue
                                    OurQueue.Print();
                                }

                            }
                            Console.Write(", ");
                            break;
                        default:
                            Console.WriteLine("Unknown Command!");
                            break;
                    }

                }
                OurStack.Clear();
                timeOfSequence.Stop();
                timeArray[i] = timeOfSequence.ElapsedTicks / 10000000.0d;
            }
            return timeArray;
        }

        public static double SolveExpression(string expression)//СЮДА постфиксную форму передавать
        {

            string[] partedExpression = expression.Split(" ");
            int difficulty = 0;

            string[] formattedExpression = InFixToPostFix(partedExpression);

            foreach (string i in formattedExpression)
            {
                if (Double.TryParse(i, out double number))
                {
                    OurStack.Push(i);
                }
                else
                {
                    difficulty++;
                    switch (i)//(+, -, *, :, ^, ln, cos, sin, sqrt, «)». 
                    {
                        case "+":
                            OurStack.topElem.prevElem.data = Convert.ToString(Convert.ToDouble(OurStack.topElem.prevElem.data) + Convert.ToDouble(OurStack.topElem.data));
                            OurStack.Pop();
                            break;
                        case "-":
                            OurStack.topElem.prevElem.data = Convert.ToString(Convert.ToDouble(OurStack.topElem.prevElem.data) - Convert.ToDouble(OurStack.topElem.data));
                            OurStack.Pop();
                            break;
                        case "*":
                            OurStack.topElem.prevElem.data = Convert.ToString(Convert.ToDouble(OurStack.topElem.prevElem.data) * Convert.ToDouble(OurStack.topElem.data));
                            OurStack.Pop();
                            break;
                        case "/":
                        case ":":
                            OurStack.topElem.prevElem.data = Convert.ToString(Convert.ToDouble(OurStack.topElem.prevElem.data) / Convert.ToDouble(OurStack.topElem.data));
                            OurStack.Pop();
                            break;
                        case "^":
                            OurStack.topElem.prevElem.data = Convert.ToString(Math.Pow(Convert.ToDouble(OurStack.topElem.prevElem.data), Convert.ToDouble(OurStack.topElem.data)));
                            OurStack.Pop();
                            break;
                        case "ln":
                            OurStack.topElem.data = Convert.ToString(Math.Log(Convert.ToDouble(OurStack.topElem.data)));
                            break;
                        case "cos":
                            OurStack.topElem.data = Convert.ToString(Math.Cos(Convert.ToDouble(OurStack.topElem.data)));
                            break;
                        case "sin":
                            OurStack.topElem.data = Convert.ToString(Math.Sin(Convert.ToDouble(OurStack.topElem.data)));
                            break;
                        case "sqrt":
                            OurStack.topElem.data = Convert.ToString(Math.Sqrt(Convert.ToDouble(OurStack.topElem.data)));
                            break;
                    }
                }
            }
            Console.WriteLine("Result: " + OurStack.Pop());
            return difficulty;
        }

        public static string[] InFixToPostFix(string[] partedSequence)
        {
            StringBuilder expression = new StringBuilder();



            foreach (string sequenceInstance in partedSequence)
            {
                if (int.TryParse(sequenceInstance, out int number))
                {
                    expression.Append(sequenceInstance + " ");
                }
                else if (sequenceInstance == "sin" || sequenceInstance == "cos" || sequenceInstance == "sqrt" || sequenceInstance == "ln" || sequenceInstance == "(")
                {
                    OurStack.Push(sequenceInstance);
                }
                else if (sequenceInstance == ")")
                {



                    while (OurStack.Top() != "(")
                    {
                        expression.Append(OurStack.Pop() + " ");
                    }
                    OurStack.Pop();
                }
                else if (sequenceInstance == "+" || sequenceInstance == "-" || sequenceInstance == "*" || sequenceInstance == "/" || sequenceInstance == ":" || sequenceInstance == "^")
                {
                    while (!OurStack.IsEmpty() && ((OurStack.Top() == "^") || ((OurStack.Top() == "*" || OurStack.Top() == "/" || OurStack.Top() == ":" || OurStack.Top() == "^") && (sequenceInstance != "^")) || ((OurStack.Top() == "+" || OurStack.Top() == "-") && (sequenceInstance == "+" || sequenceInstance == "-"))))
                    {
                        expression.Append(OurStack.Pop() + " ");
                    }
                    OurStack.Push(sequenceInstance);
                }
            }



            while (!OurStack.IsEmpty())
            {
                if (OurStack.Top() != "(")
                    expression.Append(OurStack.Pop() + " ");
                else
                    OurStack.Pop();
            }
            expression.Length--;

            return expression.ToString().Split(" ");

        }

    }
}
