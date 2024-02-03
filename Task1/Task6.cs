using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Practice
{
    public class Task6
    {
        /*
         Добавить в программу из «Задания 5» дополнительный функционал. Помимо всех предыдущих результатов, 
        программа также должна получать случайно сгенерированное число, которое будет меньше, чем число символов в обработанной строке, 
        и удалять символ в той позиции, номер которой вернёт случайный генератор. 
        Получать число необходимо через удалённый API (например http://www.randomnumberapi.com или любое со схожим функционалом).
        Если удалённое API в момент работы программы возвращает какую-то непредвиденную ошибку,
        то необходимо получать случайное число средствами .NET
         */

        public static void DeletLetterPrint(string input)
        {
            if (input.Length == 0) return;// Если строка пустая, выходим из метода
            int rnd = GetRandomNum(0, input.Length);// Генерируем случайное число в диапазоне от 1 до длины строки
            input = input.Remove(rnd, 1); // Удаляем символ из строки по индексу
            // Выводим результат
            Console.WriteLine($"Строка с удаленным символом по индексу {rnd}: {input}");
        }
        public static string DeletLetterString(string input)
        {
            if (input.Length == 0) return null;// Если строка пустая, выходим из метода
            int rnd = GetRandomNum(0, input.Length);// Генерируем случайное число в диапазоне от 1 до длины строки
            input = input.Remove(rnd, 1); // Удаляем символ из строки по индексу
            // Выводим результат
            return $"Строка с удаленным символом по индексу {rnd}: {input}";
        }
        public static int GetRandomNum(int min, int max)
        {
            int randomNum;
            try
            {
                // Формируем URL для получения случайного числа через удалённый API
                string url = $"https://www.random.org/integers/?num=1&min={min}&max={max-1}&col=1&base=10&format=plain&rnd=new";
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(url).Result; // Отправляем GET-запрос на указанный URL и получаем ответ
                    randomNum = int.Parse(response.Content.ReadAsStringAsync().Result); // Преобразуем ответ в строку и парсим число из строки 
                    Console.WriteLine($"\nСлучайное число {randomNum}, успешно получено через API.");// Выводим сообщение об успешном получении случайного числа через API
                }
            }
            catch (Exception ex)
            {
                // Если возникло исключение при использовании удалённого API, выводим сообщение об ошибке
                Console.WriteLine($"\nНе удалось получить случайное число через удалённый API, число будет получено средствами .NET.");
                Random rnd = new(); // Генерируем случайное число средствами .NET
                randomNum = rnd.Next(min, max);
                Console.WriteLine($"Случайное число {randomNum}");
            }
            // Возвращаем сгенерированное случайное число
            return randomNum;
        }

    }
}
