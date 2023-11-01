using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab3
{
    public class OurStack
    {
        //top node
        private static Node topElem;

        //Push element to stack
        public static void Push(object data)
        {
            Node nodeToAdd = new Node()
            {
                data = data,
                prevElem = topElem
            };
            topElem = nodeToAdd;
        }

        //Pop element from stack
        public static object Pop() 
        {
            if (topElem == null) 
            {
                throw new Exception ("Stak is empty!");
            }
            Node elemToPop = topElem;
            topElem = topElem.prevElem;
            return elemToPop.data;
        }

        //Return top element
        public static object Top() 
        {
            if (topElem == null)
            {
                throw new Exception("Stak is empty!");
            }
            return topElem.data;
        }

        //Returns 1 if stack is empty
        public static bool IsEmpty()
        {
            return topElem == null;
        }

        
        public static void Print()
        {
            Node current = topElem;

            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.prevElem;
            }
        }
    }

    //node
    public class Node
    {
        //previous node
        public Node? prevElem;

        //current node data
        public object? data;
    }
}
