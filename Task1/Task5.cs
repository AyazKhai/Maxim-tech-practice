using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Task5: Task2
    {
        /*
         Добавить в программу из «Задания 4» дополнительный функционал. 
        Помимо всех предыдущих результатов необходимо также возвращать отсортированную обработанную строку.
        Должно быть реализовано два алгоритма сортировки – Быстрая сортировка (Quicksort) и Сортировка деревом (Tree sort). 
        Текущий алгоритм сортировки должен выбираться пользователем.
        */
       
        public static void ChooseSort(string input) 
        {
            Console.WriteLine("\nВыберите действие(1,2,3)\n1.Быстрая сортровка(QuickSort)\n2.Сортировка деревом(Tree sort)\n3.Выход");
            

            // Read the input from the user
            string r = Console.ReadLine();

            switch (r)
            {
                case "1":
                    QuickSort(input);
                    break;
                case "2":
                    TreeSort(input);
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    ChooseSort(input);
                    break;
            }
        }
        public static string QuickSortString(string str)
        {
            char[] input = str.ToCharArray();
            QuickSort(input, 0, input.Length - 1);
            str = String.Concat(input);
            return str;
        }
        public static void TreeSort(string str) 
        {
            Console.Write($"Результат: ");
            BinaryTreeSort.SortString(str);
        }
        public static void QuickSort(string str)
        {
            char[] input = str.ToCharArray();
            QuickSort(input, 0, input.Length-1);
            str = String.Concat(input);
            Console.Write($"Результат: {str}");
        }
        private static void QuickSort(char[] input, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int rightStart = PartQuickSort(input, start, end);
            QuickSort(input, start, rightStart - 1);
            QuickSort(input, rightStart, end);

            int PartQuickSort(char[] input, int left, int right)//локальный метод 
            {
                char pivot = input[left + (right - left) / 2];
                int i = left;//from left
                int j = right;//from right
                while (i <= j)
                {
                    while (input[i] < pivot) i++;
                    while (input[j] > pivot) j--;

                    if (i <= j)
                    {
                        char ghost = input[i];
                        input[i] = input[j];
                        input[j] = ghost;
                        i++;
                        j--;
                    }
                }
                return i;
            }
        }


    }
    // Создаем класс для узлов бинарного дерева
    class Node
    {
        public char data;  // данные узла
        public Node left, right;  // ссылки на левого и правого потомка
        public int count;
        // Конструктор узла
        public Node(char data)
        {
            this.data = data;
            left = null;
            right = null;
            count = 1;
        }
        
    }

    // Класс для сортировки строк с использованием бинарного дерева
    public class BinaryTreeSort 
    {
        private Node root;  // корень дерева
        // Статический метод для сортировки строки
        public static void SortString(string input)
        {
            BinaryTreeSort tree = new BinaryTreeSort();  // создаем экземпляр класса BinaryTreeSort

            // Вставляем каждый символ строки в бинарное дерево
            foreach (char c in input)
            {
                tree.root = tree.InsertNode(tree.root, c);
            }

            tree.DisplaySortedString(tree.root);  // выводим отсортированную строку
        }

        // Метод для вставки узла в бинарное дерево
        private Node InsertNode(Node root, char data)
        {
            if (root == null)
            {
                return new Node(data);  // если узла нет, создаем новый узел
            }
            
            if (data == root.data)
            {
                root.count++;// если данные совпадают, увеличиваем значение на 1
            }
            else if (data < root.data)
            {
                root.left = InsertNode(root.left, data);  // если данные меньше, идем в левое поддерево
            }
            else if (data > root.data)
            {
                root.right = InsertNode(root.right, data);  // если данные больше, идем в правое поддерево
            }

            return root;
        }

        // Метод для отображения отсортированной строки
        private void DisplaySortedString(Node root)
        {
            if (root != null)
            {
                DisplaySortedString(root.left);  // сначала отображаем левое поддерево
                for (int i = 1; i <= root.count; i++) 
                {
                    Console.Write(root.data);
                }
                DisplaySortedString(root.right);  // затем отображаем правое поддерево
            }
        }
    } 



}
