namespace muchik.market.infrasctructure.crosscutting.Models
{
    public class ExceptionResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = null!;
        public string StackTrace { get; set; } = null!;
    }
}
