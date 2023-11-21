using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgorithmLab3
{
    public class OurStack<T> : OurLinkedList<T>
    {
        //Push element to stack
        public void Push(T data)
        {
            this.AddToTop(data);
        }

        //Pop element from stack
        public T Pop() 
        {
            return this.RemoveFromTop().Data;
        }

        //Return top element
        public T Top() 
        {
            return this.GetTop().Data;
        }

        //public bool IsElem(string data)
        //{
        //    StackNode current = topElem;

        //    while (current != null)
        //    {
        //        if(data == current.data)
        //            return true;
        //        current = current.prevElem;
        //    }
        //    return false;
        //}

        //public void Clear()
        //{
        //    topElem = null;
        //}
      
        //public void Reverse()//1
        //{
        //    if (this.IsEmpty())
        //        return;
        //    StackNode previousNode = null;

        //    StackNode currentNode = topElem;
        //    StackNode nextNode = topElem.prevElem;


        //    while (nextNode != null)
        //    {
        //        currentNode.prevElem = previousNode;
        //        previousNode = currentNode;
        //        currentNode = nextNode;
        //        nextNode = currentNode.prevElem;
        //    }
        //    currentNode.prevElem = previousNode;
        //    topElem = currentNode;
        //}

        //public void BotToTop()//2.1
        //{
        //    StackNode current = topElem;
        //    while (current.prevElem.prevElem != null)
        //    {
        //        current = current.prevElem;
        //    }
        //    this.Push(current.prevElem.data);
        //    current.prevElem = null;
        //}

        //public void TopToBot()//2.2
        //{
        //    StackNode current = topElem;
        //    while (current.prevElem != null)
        //    {
        //        current = current.prevElem;
        //    }
        //    current.prevElem = new StackNode() { data = Top() };
        //    this.Pop();
        //}

        //public int DifElems()//3
        //{
        //    HashSet<int> uniqueElems = new HashSet<int>();
        //    StackNode current = topElem;

        //    while (current != null)
        //    {
        //        uniqueElems.Add(Convert.ToInt32(current.data));
        //        current = current.prevElem;
        //    }
        //    return uniqueElems.Count;
        //}
        //public void MakeUnique()//4
        //{
        //    OurStack unique = new OurStack();

        //    StackNode current = topElem;
        //    while (current != null)
        //    {
        //        if(!unique.IsElem(current.data))
        //        unique.Push(current.data);
        //        current = current.prevElem;
        //    }
        //    this.Clear();
        //    while (unique.Top() != null)
        //    {
        //        this.Push(unique.Pop());
        //    }
        //    this.Reverse();
        //}
        //public void SelfInsert(string data)//5
        //{
        //    OurStack self = new OurStack();

        //    StackNode current = topElem;
        //    while (current != null)
        //    {
        //        self.Push(current.data);
        //        current = current.prevElem;
        //    }


        //    OurStack top = new OurStack();

        //    while (this.topElem != null && this.Top() != data)
        //    {
        //        top.Push(this.Pop());
        //    }
        //    while (self.topElem != null)
        //    {
        //        this.Push(self.Pop());
        //    }
        //    while (top.topElem != null)
        //    {
        //        this.Push(top.Pop());
        //    }
        //}

        //public void OrderedInsert(string data)//6
        //{

        //    OurStack top = new OurStack();

        //    while (this.topElem != null && Convert.ToInt32(this.Top()) > Convert.ToInt32(data))
        //    {
        //        top.Push(this.Pop());
        //    }
        //    this.Push(data);
        //    while (top.topElem != null)
        //    {
        //        this.Push(top.Pop());
        //    }
        //}

        //public void Delete(string data)//7
        //{
            

        //    OurStack top = new OurStack();
        //    while ((this.topElem != null) && (this.topElem.data != data))
        //    {
        //        top.Push(this.Pop());
        //    }
        //    this.Pop();
        //    while (top.topElem != null)
        //    {
        //        this.Push(top.Pop());
        //    }

        //    this.Delete(data);
        //}

        //public void Insert(string data, string elem)//8
        //{
        //    if (!this.IsElem(data))
        //        return;

        //    OurStack top = new OurStack();

        //    while (this.topElem != null && this.Top() != data)
        //    {
        //        top.Push(this.Pop());
        //    }
        //    this.Push(elem);
        //    while (top.topElem != null)
        //    {
        //        this.Push(top.Pop());
        //    }
        //}

        //public void Append(OurStack newStack)//9 оформить ввод считывание из файла
        //{
        //    newStack.Reverse();
        //    StackNode current = newStack.topElem;

        //    while (current != null)
        //    {
        //        this.Push(current.data);
        //        current = current.prevElem;
        //    }
        //}

        //public OurStack Split(string divider)//10
        //{
        //    if (!this.IsElem(divider))
        //        return null;

        //    OurStack top = new OurStack();

        //    while (this.topElem != null && this.Top() != divider)
        //    {
        //        top.Push(this.Pop());
        //    }
        //    top.Reverse();
        //    return top;
        //}

        //public void Double()//11
        //{
        //    StackNode current = topElem;
        //    OurStack copy = new OurStack();
        //    while (current != null)
        //    {
        //        copy.Push(current.data);
        //        current = current.prevElem;
        //    }
        //    current = copy.topElem;
        //    while (current != null)
        //    {
        //        this.Push(current.data);
        //        current = current.prevElem;
        //    }
        //}

        //public void Swap(string first, string second)//12
        //{
        //    OurStack _new = new OurStack();
        //    while (this.topElem != null && this.Top() != first && this.Top() != second)
        //    {
        //        _new.Push(this.Pop());
        //    }
        //    if(this.Top() == first)
        //    {
        //        _new.Push(second);
        //        this.Pop();

        //        while (this.topElem != null && this.Top() != second)
        //        {
        //            _new.Push(this.Pop());
        //        }
        //        _new.Push(first);
        //        this.Pop();
        //        while (this.topElem != null)
        //        {
        //            _new.Push(this.Pop());
        //        }
        //    }
        //    else if (this.Top() == second)
        //    {
        //        _new.Push(first);
        //        this.Pop();

        //        while (this.topElem != null && this.Top() != first)
        //        {
        //            _new.Push(this.Pop());
        //        }
        //        _new.Push(second);
        //        this.Pop();
        //        while (this.topElem != null)
        //        {
        //            _new.Push(this.Pop());
        //        }
        //    }
        //    //-----------
        //    _new.Reverse();
        //    while (_new.topElem != null)
        //    {
        //        this.Push(_new.Pop());
        //    }

        //}
    }
}
