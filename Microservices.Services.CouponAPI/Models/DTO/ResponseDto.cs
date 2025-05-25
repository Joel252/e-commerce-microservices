namespace Microservices.Services.CouponAPI.Models.DTO
{
    /// <summary>
    /// Data transfer object for responses.
    /// </summary>
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}