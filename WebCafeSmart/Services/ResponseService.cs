namespace WebCafeSmart.Services
{
    public class ResponseService
    {
        public object? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
