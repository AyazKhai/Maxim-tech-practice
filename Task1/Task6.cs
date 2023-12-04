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


        public static void DeletLetter(string input) 
        {
            if(input.Length == 0)return;
            int rnd = GetRandomNum(1, input.Length);
            input = input.Remove(rnd-1,1);
            Console.WriteLine($"Строка с удаленным символом по индексу {rnd}: {input}");
        }
        public static int GetRandomNum(int min,int max) 
        {
            int randomNum;
            try
            {
                string url = $"https://www.random.org/integers/?num=1&min={min}&max={max}&col=1&base=10&format=plain&rnd=new";
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    randomNum = int.Parse(response.Content.ReadAsStringAsync().Result);
                    Console.WriteLine("\nСлучайное число успешно получено через API");
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine("\nНе удалось получить случайное число через удалённый API, число будет получено средствами .NET");
                Random rnd = new();
                randomNum = rnd.Next(min, max);
            }
            return randomNum;
        }

        
    }
}
