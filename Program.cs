using AlgorithmLab3;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;

class Program
{
    public static void Main ()
    {
        Task2();
        Task3();
        //сделать в 4 таске чтобы префиксную в постфиксную
        //SolveExpression(string expression)//СЮДА постфиксную форму передавать и он возвращает СЛОЖНОСТЬ СМОТРЕТЬ ЗАДАНИЕ

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
        PostFix(ReadSeqFromFile());
    }
    

    //Methods

    public static string[] ReadSeqFromFile()
    {
        Console.WriteLine("Введите расположение файла input.txt");

        string path = Console.ReadLine();

        path = "C:\\Users\\ACGuardian\\Desktop\\input.txt";//ПЕРЕПИСАТЬ ВСЕМ ДЛЯ СЕБЯ 

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
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
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
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
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
        foreach (string i in partedExpression) 
        {
            if (Double.TryParse(i, out double number))
            {
                OurStack.Push(number);
            }
            else
            {
                difficulty++;
                switch (i)//(+, -, *, :, ^, ln, cos, sin, sqrt, «)». 
                {
                    case "+":
                        OurStack.topElem.prevElem.data = Convert.ToDouble(OurStack.topElem.prevElem.data) + Convert.ToDouble(OurStack.topElem.data);
                        OurStack.Pop();
                        break;
                    case "-":
                        OurStack.topElem.prevElem.data = Convert.ToDouble(OurStack.topElem.prevElem.data) - Convert.ToDouble(OurStack.topElem.data);
                        OurStack.Pop();
                        break;
                    case "*":
                        OurStack.topElem.prevElem.data = Convert.ToDouble(OurStack.topElem.prevElem.data) * Convert.ToDouble(OurStack.topElem.data);
                        OurStack.Pop();
                        break;
                    case "/":
                    case ":":
                        OurStack.topElem.prevElem.data = Convert.ToDouble(OurStack.topElem.prevElem.data) / Convert.ToDouble(OurStack.topElem.data);
                        OurStack.Pop();
                        break;
                    case "^":
                        OurStack.topElem.prevElem.data = Math.Pow(Convert.ToDouble(OurStack.topElem.prevElem.data), Convert.ToDouble(OurStack.topElem.data));
                        OurStack.Pop();
                        break;
                    case "ln":
                        OurStack.topElem.data = Math.Log(Convert.ToDouble(OurStack.topElem.data));
                        break;
                    case "cos":
                        OurStack.topElem.data = Math.Cos(Convert.ToDouble(OurStack.topElem.data));
                        break;
                    case "sin":
                        OurStack.topElem.data = Math.Sin(Convert.ToDouble(OurStack.topElem.data));
                        break;
                    case "sqrt":
                        OurStack.topElem.data = Math.Sqrt(Convert.ToDouble(OurStack.topElem.data));
                        break;
                }
            }
        }
        Console.WriteLine(OurStack.Pop());
        return difficulty;
    }



    /// Я насрал
    /// Я насрал
    /// Я насрал
    /// Я насрал 
    /// Я насрал
    
    public static void PostFix(string[] sequences)
    {
        var stack = new Stack<string>();

        var queue = new Queue<string>();


        foreach (string sequence in sequences)
        {
            bool success = int.TryParse(sequence, out int number);
            if (success)
            {
                queue.Enqueue(sequence);
            }
            else
            {
                if (sequence == "(")
                    stack.Push(sequence);
                if (sequence == ")")
                    stack.Pop();
                if ((sequence == "+") || (sequence == "-"))
                {
                    string top = stack.Peek();
                    if ((!stack.Any()) || (top == "("))
                        stack.Push(sequence);
                    else if ((top == "*") || (top == "/"))
                    {
                        stack.Pop();
                        stack.Push(sequence);
                    }
                    else
                        stack.Push(sequence);
                }
                if ((sequence == "*") || (sequence == "/"))
                {
                    string top = stack.Peek();
                    if ((top == "*") || (top == "/"))
                    {
                        stack.Pop();
                        stack.Push(sequence);
                    }
                }
            }
        }
        string[] array = stack.ToArray();

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == "(")
                array[i] = " ";
            queue.Enqueue(array[i]);
        }
    }
}