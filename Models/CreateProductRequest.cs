namespace Fullstack.SwaggerIntergration.Models
{
    public class CreateProductRequest
    {
       
        /// <summary>
        /// Product name.
        /// </summary>
        /// <example>iPhone 17 Pro</example>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Product category.
        /// </summary>
        /// <example>Smartphones</example>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Product selling price.
        /// </summary>
        /// <example>129999.99</example>
        public decimal Price { get; set; }

        /// <summary>
        /// Number of units available in inventory.
        /// </summary>
        /// <example>25</example>
        public int Stock { get; set; }
    }

}
