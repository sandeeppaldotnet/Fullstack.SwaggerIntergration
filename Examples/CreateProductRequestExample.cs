using Fullstack.SwaggerIntergration.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Fullstack.SwaggerIntergration.Examples
{
    public class CreateProductRequestExample
    : IExamplesProvider<CreateProductRequest>
    {
        public CreateProductRequest GetExamples()
        {
            return new CreateProductRequest
            {
                Name = "Samsung Galaxy S26",
                Category = "Smartphones",
                Price = 89999.99m,
                Stock = 30
            };
        }
    }

}
