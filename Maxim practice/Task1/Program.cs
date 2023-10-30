using System.Diagnostics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
//Выполнил Хайрутдинов Аяз https://github.com/AyazKhai/Maxim-tech-practice/blob/main/Maxim%20practice/Task1/Program.cs
namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string arg = Console.ReadLine();
            Console.WriteLine(ReplacerSecOpt(arg));

        }

        public static string Replacer(string input)
        {
            if (input.Length % 2 == 0)//Проверка строки на четность элементов
            {
                string firstHalf = input.Substring(0, input.Length / 2);//Первая половина строки
                string SecondHalf = input.Substring(input.Length / 2);//Вторая

                //создаем массивы элементов каждой полвинки и переворачиваем их
                char[] firstHalfCharArray = firstHalf.ToCharArray();
                Array.Reverse(firstHalfCharArray);

                char[] SecondHalfCharArray = SecondHalf.ToCharArray();
                Array.Reverse(SecondHalfCharArray);

                //Объединяем перевернутые строки
                string reversedInput = new string(firstHalfCharArray) + new string(SecondHalfCharArray);
                return reversedInput;
            }
            else
            {
                //Переворачиваем строку
                char[] reversefInput = input.ToCharArray();
                Array.Reverse(reversefInput);

                //Объединяем перевернутую строку с изначальной(input)
                string reversedInput = new string(reversefInput) + input;
                return reversedInput;
            }
        }

        public static string ReplacerSecOpt(string input)
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