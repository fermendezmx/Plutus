using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Plutus.Business.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content)
        {
            string json = await content.ReadAsStringAsync();
            T result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
    }
}
