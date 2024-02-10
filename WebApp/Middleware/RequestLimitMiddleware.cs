using System.Text;

namespace WebApp.Middleware
{
    // Middleware, реализующий ограничение по количеству одновременных запросов
    public class RequestLimitMiddleware
    {
        private readonly RequestDelegate _next; // Ссылка на следующий делегат в конвейере обработки запросов
        private readonly SemaphoreSlim _semaphore; // Семафор для управления одновременными запросами
        private readonly int _maxConcurrentRequests; // Максимальное количество одновременных запросов

        // Конструктор middleware с получением настроек из IConfiguration
        public RequestLimitMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _maxConcurrentRequests = configuration.GetValue<int>("Settings:ParallelLimit");
            _semaphore = new SemaphoreSlim(_maxConcurrentRequests); // Инициализация семафора
        }

        // Метод InvokeAsync, который выполняет обработку запроса
        public async Task InvokeAsync(HttpContext context)
        {
            if (_semaphore.Wait(0)) // Попытка захватить семафор
            {
                try
                {
                    await _next(context); // Вызов следующего делегата в конвейере обработки запросов
                }
                finally
                {
                    _semaphore.Release(); // Освобождение семафора в блоке finally для предотвращения блокировки
                }
            }
            else
            {
                // В случае превышения лимита одновременных запросов отправляется ответ с кодом 503 и сообщением
                context.Response.StatusCode = 503;
                await context.Response.WriteAsync($"HTTP 503 Service Unavailable. Too many requests ({_maxConcurrentRequests}).");
                return;
            }
        }
    }
}

