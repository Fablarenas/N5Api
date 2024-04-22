namespace N5.Api.Middlewares
{
    public class KafkaLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly KafkaProducer _producer;

        public KafkaLoggingMiddleware(RequestDelegate next, KafkaProducer producer)
        {
            _next = next;
            _producer = producer;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestId = Guid.NewGuid();
            string operationName = context.Request.Method switch
            {
                "POST" => "request",
                "PUT" => "modify",
                "GET" => "get",
                _ => "other"
            };

            var message = $"Id: {requestId} - Name operation: {operationName}";

            await _producer.SendMessageAsync(message);

            await _next(context);
        }
    }

}
