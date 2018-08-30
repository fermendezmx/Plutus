using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Plutus.Api.Filters
{
    public class SwaggerFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDocument, DocumentFilterContext context)
        {
            swaggerDocument.Security = new List<IDictionary<string, IEnumerable<string>>>
            {
                new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[]{ } },
                    { "Basic", new string[]{ } },
                }
            };
        }
    }
}
