using AlgorithmLab3;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;

class Program
{
    public static void Main ()
    {

        SequencesHandler(ReadFromInputTxt());

    }

    public static string[] ReadFromInputTxt()
    {
        Console.WriteLine("Введите расположение файла input.txt");

        string path = Console.ReadLine();

        path = "C:\\Users\\ACGuardian\\Desktop\\input.txt";

        string[] sequences = File.ReadAllLines(path);

        return sequences;
    }
    public static void SequencesHandler(string[] sequences)
    {
        foreach (string sequence in sequences)
        {
            string[] partedSequence = sequence.Split(' ');
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
        }
    }

    public static void TimeMeasuringSequencesHandler(string[] sequences)
    {
        foreach (string sequence in sequences)
        {
            string[] partedSequence = sequence.Split(' ');


            Stopwatch timeOfSequence = new Stopwatch();
            timeOfSequence.Start();
            
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

            timeOfSequence.Stop();
            //TODO timeOfSequence.ElapsedTicks / 10000000.0d;
        }
    }
}