using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication15
{
    public class Node
    {
        public int inf;
        public Node next;
        public Node(int inf, Node next)
        {
            this.inf = inf;
            this.next = next;
        }
    }
    public class MyStack
    {
        Node top;
        public void Push(int data)//положить в стек
        {
            top = new Node(data, top);
        }
        public object Pop()// взять из стека
        {
            if (top == null) throw new InvalidOperationException();
            int result = top.inf;
            top = top.next;
            return result;
        }
        public bool isEmpty()// проверка на пустоту
        {
            return top == null;
        }
    }



    public class MyList     // Класс списка
    {
        public Node head;
        public int count;
        public MyList()
        {
            head = null;
            count = 0;
        }

        public void Add(int inf)  //Добавление элемента в список
        {
            if (head == null)
            {
                head = new Node(inf, null);
            }
            else
            {
                Node p = head;
                while (p.next != null) p = p.next;
                p.next = new Node(inf, null);
            }
            count++;
        }
        public void Delete(int index)  // Удалить по индексу
        {
            if (index != 0)
            {
                Node p = head;
                for (int i = 0; i < index - 1; i++)
                    p = p.next;
                if (p.next != null)
                    p.next = p.next.next;
            }
            else
                head = head.next;
            count--;
        }
        public void Insert(int index, int val)  // Вставить по индексу
        {
            if (index != 0)
            {
                Node p = head;
                for (int i = 0; i < index; i++)
                    p = p.next;
                Node q = new Node(val, p.next);
                p.next = q;
            }
            else
            {
                Node q = new Node(val, head);
                head = q;
            }
            count++;
        }
        public Node GetNode(int index)//нахождение узла
        {
           if (index<count)
           {
               Node p=head;
               for (int i=0;i<index;i++)
               p=p.next;
        return p;
           }
           else 
           {
               IndexOutOfRangeException ex = new IndexOutOfRangeException();
               throw (ex);
           }
           }
        public object GetVal(int index)//возрващение значения узла
        {
            Node p = GetNode(index);
            return p.inf;
        }
        public void Print() // Вывод списка
        {
            Node p = head;
            while (p != null)
            {
                Console.WriteLine("{0} ", p.inf);
                p = p.next;
            }
        }
    }
}

