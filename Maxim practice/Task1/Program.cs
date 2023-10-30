using System.Diagnostics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
//Выполнил Хайрутдинов Аяз https://github.com/AyazKhai/Maxim-tech-practice/blob/main/Maxim%20practice/Task1/Program.cs
namespace Practice
{
    public class Task1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string arg = Console.ReadLine();
            Task2.Print(arg);

        }

        public static string Replacer(string input)
        {
            StringBuilder result = new StringBuilder();
            if (input.Length % 2 == 0)
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
            return result.ToString();
        }

    }
}