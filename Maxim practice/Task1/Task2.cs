using Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Task2 : Task1
    {

        /*
         * Добавить в программу из «Задания 1» дополнительный функционал. 
         * Необходимо начать проверять входящую строку, чтобы в ней были только буквы из английского алфавита в нижнем регистре «abcdefghijklmnopqrstuvwxyz». 
         * Результатом работы программы должна стать либо обработанная строка, как в «Задании 1» или сообщение о том, что были введены не подходящие символы, в сообщении об ошибке должны быть перечислены все неподходящие символы, которые были введены
                Результат программы:
                Если не подходящая строка
                Сообщение об ошибке с информацией
                Если подходящая строка
                Обработанная строка
         */
        public static void Print(string str)
        {
            // Если введенная строка не является корректной строкой с буквами на английском языке в нижнем регистре
            if (!IsValidEngStringInLower(str))
            {
                // Выводим ошибку с символами, которые не являются английскими буквами в нижнем регистре
                Console.WriteLine($"Ошибочные символы: {GetNonEnglishLetterInLowerCase(str)}");
            }
            else
            {
                // Выводим обработанную строку
                Console.WriteLine($"Обработанныя строка: {Replacer(str)}");
            }
        }

        private static bool IsValidEngStringInLower(string input)
        {
            // Если в строке есть только буквы и все буквы находятся в нижнем регистре
            if (input.All(char.IsLetter) && input.All(char.IsLower))
            {
                foreach (char c in input)// Проверяем каждую букву строки, если она находится в диапазоне букв 'a' - 'z'
                {
                    if (c <= 'a' || c >= 'z')
                    {
                        return false; // Если хотя бы одна буква не удовлетворяет условию, то возвращаем false
                    }
                }
                // Если все буквы удовлетворяют условию, то возвращаем true
                return true;
            }
            else
            {
                return false;// Если в строке есть что-то кроме букв или есть буквы, которые не находятся в нижнем регистре, то возвращаем false
            }
        }

        public static string GetNonEnglishLetterInLowerCase(string str)
        {
            StringBuilder result = new StringBuilder();
            // Проверяем каждый символ строки
            foreach (char c in str)
            {
                // Если символ не является английской буквой в нижнем регистре (т.е. находится вне диапазона 'a' - 'z')
                if (c < 'a' || c > 'z')
                {
                    // Добавляем его в результат
                    result.Append(c);
                }
            }
            
            return result.ToString();// Возвращаем результат в виде строки
        }
    }
}
