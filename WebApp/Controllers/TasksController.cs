﻿using Microsoft.AspNetCore.Mvc;
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
        // HTTP GET по "api/Tasks/word_alteration"
        [HttpGet("word_alteration")]
        public IActionResult ProcessString([FromQuery][Required] string input)
        {
            if (!Task2.IsValidEngStringInLower(input) ) // Проверка, что входная строка является допустимой английской строкой в нижнем регистре.
            {
                return BadRequest("HTTP ошибка 400 Bad Request. Invalid input string.");
            }
            
            string coveredStr = Task1.Replacer(ref input);// Обработанная строка
            string duoSymbols = Task3.GetRecurLettersString(coveredStr);// получение строки с повторяющимися символами.
            string LongestVowels = Task4.LongestVowStrVowString(coveredStr);// Вызов метода Task4.LongestVowStrVowString для получения самой длинной подстроки, состоящей из гласных.
            string sortedstr = Task5.QuickSortString(coveredStr); // Быстрая соритровка 
            string withoutSymStr = Task6.DeletLetterString(coveredStr);// Вызов для удаления букв из строки.

            var result = new// Создание анонимного объекта с результатами обработки строки и возврат ответа в формате JSON.
            {
                coveredStr,
                duoSymbols,
                LongestVowels,
                sortedstr,
                withoutSymStr
            };
            return Ok(result);
        }
    }
}