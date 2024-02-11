using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Task3:Task2
    {
        /*Добавить в программу из «Задания 2» дополнительный функционал. Помимо обработанной строки, необходимо 
          также возвращать пользователю информацию о том, сколько раз повторялся каждый символ в обработанной строке.
           Результат программы:
            Если не подходящая строка
            Сообщение об ошибке с информацией
           Если подходящая строка
            Обработанная строка
            Информация о том, сколько раз входил в обработанную строку каждый символ
        */
        public static void GetRecurLettersPrint(string input) 
        {
            if (IsValidEngStringInLower(input)) //проверяет, является ли входная строка допустимой английской строкой в нижнем регистре
            {
                Dictionary<char, int> result = new Dictionary<char, int>();// Создаём словарь из пары ключей для символа и его количества в строке
                foreach (char c in input)
                {
                    if (result.ContainsKey(c))// Если символ уже есть в словаре, увеличиваем его счетчик
                    {
                        result[c]++;
                    }
                    else
                    {
                        result.Add(c, 1);// Если символа нет в словаре, добавляем его со счетчиком 1
                    }
                }

                foreach (var c in result)// Вывод символов и их количества
                {
                    Console.WriteLine($"Буква {c.Key} встречается {c.Value} раз");
                }
            }
        }
        public static string GetRecurLettersString(string input)
        {
            if (input == null)
            {
                // Если входная строка null, возвращаем пустой массив
                return "";
            }
            StringBuilder sb = new StringBuilder();
            if (IsValidEngStringInLower(input)) //проверяет, является ли входная строка допустимой английской строкой в нижнем регистре
            {
                Dictionary<char, int> result = new Dictionary<char, int>();// Создаём словарь из пары ключей для символа и его количества в строке
                foreach (char c in input)
                {
                    if (result.ContainsKey(c))// Если символ уже есть в словаре, увеличиваем его счетчик
                    {
                        result[c]++;
                    }
                    else
                    {
                        result.Add(c, 1);// Если символа нет в словаре, добавляем его со счетчиком 1
                    }
                }

                foreach (var c in result)// Вывод символов и их количества
                {
                    sb.Append($"{c.Key} {c.Value}; ");
                }

            }
            return sb.ToString();
        }
        public static async Task<string[]> GetRecurLettersArrayAsync(string input)
        {
            if (input == null)
            {
                // Если входная строка null, возвращаем пустой массив
                return new string[] { };
            }

            StringBuilder sb = new StringBuilder();

            if (IsValidEngStringInLower(input))
            {
                Dictionary<char, int> result = new Dictionary<char, int>();

                await Task.Run(() =>
                {
                    foreach (char c in input)
                    {
                        if (result.ContainsKey(c))
                        {
                            result[c]++;
                        }
                        else
                        {
                            result.Add(c, 1);
                        }
                    }
                });

                return result.Select(c => $"{c.Key} {c.Value}").ToArray();
            }

            return new string[] { };
        }


    }
}
