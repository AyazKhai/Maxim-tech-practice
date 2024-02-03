using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Practice
{
    public class Task4:Task3
    {
        /*
          Помимо обработки строки и подсчёта количества вхождений каждого символа, 
          необходимо найти в обработанной строке наибольшую подстроку, которая начинается и 
          заканчивается на гласную букву из «aeiouy»
               a => aa
               abcdef => cbafed
               abcde => edcbaabcde
        */
        public static void LongestVowStrVow(string input) 
        {

            int leftIndex = -1;
            int rightIndex = -1;
            for (int i = 0;i< input.Length;i++) 
            {
                if ("aeiouy".Contains(input[i]))
                {
                    if (leftIndex == -1)
                    {
                        leftIndex = i;//индекс первой гласной буквы слева
                    }
                    rightIndex = i;//индекс последней гласной буквы
                }
            }

            if (leftIndex != -1)
                Console.WriteLine("Наибольшая подстроку, которая начинается и заканчивается на гласную: " + input.Substring(leftIndex, rightIndex - leftIndex + 1));//выводится строка от первой гласной буквы, длинной в разность последнего и первого индекса
            else
                return;
        }
        public static string LongestVowStrVowString(string input)
        {

            int leftIndex = -1;
            int rightIndex = -1;
            for (int i = 0; i < input.Length; i++)
            {
                if ("aeiouy".Contains(input[i]))
                {
                    if (leftIndex == -1)
                    {
                        leftIndex = i;//индекс первой гласной буквы слева
                    }
                    rightIndex = i;//индекс последней гласной буквы
                }
            }
            string result;
            if (leftIndex != -1)
                return result = ("Наибольшая подстрока, которая начинается и заканчивается на гласную: " + input.Substring(leftIndex, rightIndex - leftIndex + 1));//выводится строка от первой гласной буквы, длинной в разность последнего и первого индекса
            else
                return null;
        }

    }
}
