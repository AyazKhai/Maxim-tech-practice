﻿using System.Diagnostics;
using System.Text;
//Выполнил Хайрутдинов Аяз https://github.com/AyazKhai/Maxim-tech-practice/blob/main/Task1/Program.cs
namespace Practice
{
    public class Task1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string arg = Console.ReadLine();
            if(String.IsNullOrEmpty(arg)) 
            {
                Console.WriteLine("Введена пустая строка");
                Environment.Exit(0);
            }
            
            Task2.Print(ref arg);
            Task3.GetRecurLettersPrint(arg);
            Task4.LongestVowStrVowPrint(arg);
            Task5.ChooseSort(arg);
            Console.WriteLine();
            Task6.DeletLetterPrint(arg);
        }

        public static string Replacer(ref string input)
        {
            // Проверяем на null
            if (input == null)
            {
                // Возвращаем null без изменений
                return null;
            }

            StringBuilder result = new StringBuilder();
            if (input.Length % 2 == 0 )
            {
                //Переворачиваем первую половину
                for (int i = input.Length / 2 - 1; i >= 0; i--)
                {
                    result.Append(input[i]);
                }
                //Переворачиваем вторую половину
                for (int i = input.Length - 1; i >= input.Length / 2; i--)
                {
                    result.Append(input[i]);
                }
            }
            else
            {
                // Переворачиваем всю строку и добавляем к результату
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    result.Append(input[i]);
                }
                result.Append(input);// Добавляем исходную строку 
            }
            input = result.ToString();
            return input;
        }
        

    }
}