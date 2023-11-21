using AlgorithmLab3;
using ConsoleApp1;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;

class Program
{
    public static void Main()
    {
        //Tasks.Start();
        //Task3.Start();
        OurStack<string> stack = new OurStack<string>();
        stack.Push("1");
        stack.Push("2");
        stack.Push("3");
        stack.Push("4");
        stack.Push("5");
        stack.Push("5");
        stack.Print();
        Console.WriteLine("| " + stack.CountDifElems());
        stack.Print();
    }
}