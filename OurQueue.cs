using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab3
{
    public class OurQueue
    {
        private static StringBuilder queue = new StringBuilder();

        public static void Push(string data)
        {
            queue.Append(data);
        }

        //Pop element from stack
        public static string Pop()
        {
            string returnElement = Convert.ToString(queue[0]);
            queue.Remove(0,1);
            return returnElement;
            
        }

        //Return top element
        public static string Peek()
        {
            return Convert.ToString(queue[0]);
        }

        //Returns 1 if stack is empty
        public static bool IsEmpty()
        {
            return queue.Length == 0;
        }


        public static void Print()
        {
            for (int i = 0; i < queue.Length; i++)
            {
                Console.Write(queue[i] + " ");
            }
        }

        public static void Clear()
        {
            queue.Clear();
        }

        public static int Length() 
        {
            return queue.Length;
        }
    }


}
