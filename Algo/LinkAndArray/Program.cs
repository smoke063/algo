using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkAndArray
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkList linkedList = new LinkList();
            // добавление элементов
            linkedList.AddNode(1);
            linkedList.AddNode(2);
            linkedList.AddNode(4);
            var n = linkedList.FindNode(2);
            linkedList.AddNodeAfter(n, 3);
            var n1 = linkedList.FindNode(4);
            linkedList.AddNodeAfter(n1, 5);
            linkedList.AddNode(6);
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            var n2 = linkedList.FindNode(2);
            // удаление
            linkedList.RemoveNode(n2);
            Console.WriteLine("-----------");
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }


        public class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
        }

        public class LinkList: ILinkedList, IEnumerable
        {
            private Node head;
            private Node tail;
            private int count;

            IEnumerator IEnumerable.GetEnumerator()
            {
                Node current = head;
                while (current != null)
                {
                    yield return current.Value;
                    current = current.NextNode;
                }
            }

            public int GetCount()
            {
                return count;
            }

            public void AddNode(int value)
            {
                var node = new Node() {Value = value};
                if (head == null)
                {
                    head = node;
                }
                else
                {
                    tail.NextNode = node;
                    node.PrevNode = tail;
                }
                tail = node;
                count++;
            }

            public void AddNodeAfter(Node node, int value)
            {
                var newNode = new Node() {Value = value};
                var nextNode = node.NextNode;
                node.NextNode = newNode;
                newNode.NextNode = nextNode;
                newNode.PrevNode = node;
                if (nextNode == null)
                {
                    tail = newNode;
                }
                else
                {
                    nextNode.PrevNode = newNode;
                }
                count++;
            }

            public void RemoveNode(int index)
            {
                throw new NotImplementedException();
            }

            public void RemoveNode(Node node)
            {
                Node current = head;

                // поиск удаляемого узла
                while (current != null)
                {
                    if (current.Value == node.Value)
                    {
                        break;
                    }
                    current = current.NextNode;
                }
                if (current != null)
                {
                    // если узел не последний
                    if (current.NextNode != null)
                    {
                        current.NextNode.PrevNode = current.PrevNode;
                    }
                    else
                    {
                        // если последний, переустанавливаем tail
                        tail = current.PrevNode;
                    }

                    // если узел не первый
                    if (current.PrevNode != null)
                    {
                        current.PrevNode.NextNode = current.NextNode;
                    }
                    else
                    {
                        // если первый, переустанавливаем head
                        head = current.NextNode;
                    }
                    count--;
                }
            }

            public Node FindNode(int searchValue)
            {
                Node current = head;
                while (current != null)
                {
                    if (current.Value == searchValue)
                    {
                        return current;
                    }
                    current = current.NextNode;
                }

                return null;
            }
        }

        //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value);  // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению
        }

        // O(log n)
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}
