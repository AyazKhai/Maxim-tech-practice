using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Practice;

namespace WebApp.Controllers
{
    // Указывает, что данный контроллер обрабатывает запросы API и использует атрибуты для маршрутизации.
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TasksController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // HTTP GET по "api/Tasks/word_alteration"
        [HttpGet("word_alteration")]
        public async Task<IActionResult> ProcessString([FromQuery][Required] string input)
        {
            string[] blacklist = _configuration.GetSection("iisSettings:BlackList").Get<string[]>(); // Перенос черного списка из конфигуратора в массив
            
            if (!Task2.IsValidEngStringInLower(input) ) // Проверка, что входная строка является допустимой английской строкой в нижнем регистре.
            {
                return BadRequest("HTTP ошибка 400 Bad Request. Invalid input string.");
            }
            if (blacklist.Contains(input)) // Проверка на наличие слов в черном списке
            {
                return BadRequest("HTTP ошибка 400 Bad Request. Слово находится в чёрном списке.");
            }

            string coveredStr = Task1.Replacer(ref input);// Обработанная строка

            var duoSymbols = await Task3.GetRecurLettersArrayAsync(coveredStr);// получение массива с повторяющимися символами.

            string LongestVowels = Task4.LongestVowStrVowString(coveredStr);// Вызов метода Task4.LongestVowStrVowString для получения самой длинной подстроки, состоящей из гласных.
            string sortedstr = Task5.QuickSortString(coveredStr); // Быстрая соритровка 

            var random = new GetRandom(_configuration);
            string withoutSymStr = await random.GetSymblessStr(coveredStr);// Вызов для удаления букв из строки.
            var result = new// Создание анонимного объекта с результатами обработки строки и возврат ответа в формате JSON.
            {
                coveredStr,
                duoSymbols,
                LongestVowels,
                sortedstr,
                withoutSymStr,
            };
            return Ok(result);
        }
    }
}