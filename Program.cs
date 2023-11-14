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
        OurStack s = new OurStack();
        
        s.Push("1");
        s.Push("2");
        s.Push("3");
        s.Push("4");
        s.Push("5");
        s.Push("6");
        s.Push("7");
        s.Push("8");
        s.Push("9");
        s.Push("10");
        s.Swap("7","2");
        s.Print();
    }

}