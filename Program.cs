using AlgorithmLab3;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;

class Program
{
    public static void Main()
    {
        //Task2();
        //Task3();
        //сделать в 4 таске чтобы префиксную в постфиксную
        //SolveExpression(string expression)//СЮДА постфиксную форму передавать и он возвращает СЛОЖНОСТЬ СМОТРЕТЬ ЗАДАНИЕ
        Task4();

    }

    //Tasks organizer

    public static void Task2()
    {
        SequencesHandler(ReadSeqFromFile());
    }

    public static void Task3()
    {
        double[] timeArray = TimeMeasuringSequencesHandler(ReadSeqFromFile());

        StreamWriter sw = File.CreateText("C:\\Users\\ACGuardian\\Desktop\\output.txt");
        foreach (double i in timeArray)
        {
            sw.WriteLine(i);
        }
        sw.Close();
        Process.Start("notepad.exe", "C:\\Users\\ACGuardian\\Desktop\\output.txt");
    }

    public static void Task4()
    {
        foreach (string expression in ReadSeqFromFile())
            Console.WriteLine("Difficulty: " + SolveExpression(expression));
    }


    //Methods

    public static string[] ReadSeqFromFile()
    {
        Console.WriteLine("Введите расположение файла input.txt");

        //string path = Console.ReadLine();

        string path;

        path = "C:\\Users\\ACGuardian\\Desktop\\input2.txt";//ПЕРЕПИСАТЬ ВСЕМ ДЛЯ СЕБЯ 

        string[] sequences = File.ReadAllLines(path);

        return sequences;
    }

    public static void SequencesHandler(string[] sequences)
    {
        for (int i = 0; i < sequences.Length; i++)
        {
            string[] partedSequence = sequences[i].Split(' ');

            foreach (string sequenceInstance in partedSequence)
            {
                switch (sequenceInstance[0])
                {
                    case '1':
                        OurStack.Push(sequenceInstance.Substring(2));
                        break;
                    case '2':
                        Console.Write(OurStack.Pop() + ", ");
                        break;
                    case '3':
                        Console.Write(OurStack.Top() + ", ");
                        break;
                    case '4':
                        Console.Write(Convert.ToString(OurStack.IsEmpty()) + ", ");
                        break;
                    case '5':
                        OurStack.Print();
                        Console.Write(", ");
                        break;
                    default:
                        Console.WriteLine("Unknown Command!");
                        break;
                }

            }
            OurStack.Clear();
        }
    }

    public static double[] TimeMeasuringSequencesHandler(string[] sequences)
    {
        double[] timeArray = new double[sequences.Length];
        for (int i = 0; i < sequences.Length; i++)
        {
            Stopwatch timeOfSequence = new Stopwatch();
            timeOfSequence.Start();

            string[] partedSequence = sequences[i].Split(' ');

            foreach (string sequenceInstance in partedSequence)
            {
                switch (sequenceInstance[0])
                {
                    case '1':
                        OurStack.Push(sequenceInstance.Substring(2));
                        break;
                    case '2':
                        Console.Write(OurStack.Pop() + ", ");
                        break;
                    case '3':
                        Console.Write(OurStack.Top() + ", ");
                        break;
                    case '4':
                        Console.Write(Convert.ToString(OurStack.IsEmpty()) + ", ");
                        break;
                    case '5':
                        OurStack.Print();
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



    /// Я насрал
    /// Я насрал
    /// Я насрал
    /// Я насрал 
    /// Я насрал

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

        //var stack = new Stack<string>();

        //var queue = new Queue<string>();


        //foreach (string sequenceInstance in partedSequence)
        //{
        //    if (int.TryParse(sequenceInstance, out int number))
        //    {
        //        queue.Enqueue(sequenceInstance);
        //    }
        //    else
        //    {
        //        if (sequenceInstance == "(")
        //            stack.Push(sequenceInstance);
        //        if (sequenceInstance == ")")
        //            while(stack.Any())
        //                queue.Enqueue(stack.Pop());
        //        if ((sequenceInstance == "+") || (sequenceInstance == "-"))
        //        {
        //            if (stack.Any() && (stack.Peek() == "("))
        //            {
        //                if (stack.Peek() == "(")
        //                    stack.Pop();
        //                stack.Push(sequenceInstance);
        //            }
        //            else if (stack.Any() && ((stack.Peek() == "*") || (stack.Peek() == "/")))
        //            {
        //                stack.Pop();
        //                stack.Push(sequenceInstance);
        //            }
        //            else
        //                stack.Push(sequenceInstance);
        //        }
        //        if ((sequenceInstance == "*") || (sequenceInstance == "/"))
        //        {
        //            if ((stack.Peek() == "*") || (stack.Peek() == "/"))
        //            {
        //                while (stack.Any() && (stack.Peek() == "(" || stack.Peek() == "-" || stack.Peek() == "+"))
        //                {
        //                    if (stack.Peek() == "(")
        //                        stack.Pop();
        //                    queue.Enqueue(stack.Pop());
        //                }

        //            }
        //            stack.Push(sequenceInstance);
        //        }
        //    }
        //}
        //string[] array = queue.ToArray();

        //for (int i = 0; i < array.Length; i++)
        //{
        //    if (array[i] == "(")
        //        array[i] = " ";
        //}
        //return array;



    }
}