using System;

namespace WebApp
{
    public class GetRandom
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private static readonly Random _random = new Random();

        public GetRandom(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
        }
        /// <summary>
        /// удаляет один случайный символ из строки
        /// </summary>
        /// <param name="inputString">входная строка</param>
        /// <returns>измененную строку и индекс удаленного символа</returns>
        public async Task<string> GetSymblessStrAsync(string inputString)
        {
            string apiUrl = _configuration["AppUrl"];
            int randomNumber = await GetRandomNumAsync(0, inputString.Length); // Проверка на получение рандомного числа
            inputString = inputString.Remove(randomNumber, 1);
            return $"{inputString},{randomNumber}";
        }

        /// <summary>
        /// Получает случайное число через удалённый API или средствами .NET.
        /// </summary>
        /// <param name="inputString">Входная строка</param>
        /// <param name="min">Минимальное значение для генерации случайного числа</param>
        /// <param name="max">Максимальное значение для генерации случайного числа</param>
        /// <returns>Случайное число</returns>
        public async Task<int> GetRandomNumAsync( int min, int max)
        {
            try
            {
                string apiUrl = _configuration["AppUrl"];
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (int.TryParse(result, out int randomNum))
                    {
                        Console.WriteLine($"\nСлучайное число {randomNum}, успешно получено через API.");
                        return randomNum;
                    }
                }

                Console.WriteLine($"\nНе удалось получить случайное число через удалённый API, число будет получено средствами .NET.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла ошибка при получении случайного числа через удалённый API: {ex.Message}");
            }

            return _random.Next(min, max);
        }

        
    }
}
