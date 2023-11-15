using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace AlgorithmLab3
{
    internal class Task4In
    {
        //append
        public static void Start()
        {
            Console.WriteLine("Enter path to first Stack");
            string[] first = Tasks.ReadSeqFromFile();
            Console.WriteLine("Enter path to second Stack");
            string[] second = Tasks.ReadSeqFromFile();

            OurStack s1 = new OurStack();
            foreach(string f in first)
            {
                s1.Push(f);
            }

            OurStack s2 = new OurStack();
            foreach (string s in second)
            {
                s2.Push(s);
            }

            s1.Append(s2);
        }
    }
}
