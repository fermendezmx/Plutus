namespace Plutus.Infrastructure.Shared
{
    public class XHRResponse<T> where T : new()
    {
        public XHRResponse()
        {
            Data = new T();
            Message = string.Empty;
        }

        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
