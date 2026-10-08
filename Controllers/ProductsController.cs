using Fullstack.SwaggerIntergration.Examples;
using Fullstack.SwaggerIntergration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Fullstack.SwaggerIntergration.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products =
        [
            new Product
        {
            Id = 1,
            Name = "iPhone 17 Pro",
            Category = "Smartphones",
            Price = 129999.99m,
            Stock = 25,
            IsActive = true
        },
        new Product
        {
            Id = 2,
            Name = "MacBook Pro",
            Category = "Laptops",
            Price = 189999.99m,
            Stock = 12,
            IsActive = true
        }
        ];

        /// <summary>
        /// Gets all active products.
        /// </summary>
        /// <returns>A list of active products.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(Products.Where(x => x.IsActive));
        }

        /// <summary>
        /// Gets a produdct by ites unique idnetifiesrs
        /// </summary>
        /// <param name="id">The unique identifies</param>
        /// <returns>The Request Products</returns>
        /// <returns code="200">Products found sucessfully</returns>
         /// <returns code="404">Product was not found</returns>

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var product = Products.FirstOrDefault(x => x.Id == id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }



        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="request">Product creation details.</param>
        /// <returns>The newly created product.</returns>
        /// <response code="201">Product created successfully.</response>
        /// <response code="400">Invalid product data.</response>
        [HttpPost]
        [SwaggerRequestExample(typeof(CreateProductRequest), typeof(CreateProductRequestExample))]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(CreateProductRequest request)
        {
            if (request.Price <= 0)
            {
                return BadRequest(new
                {
                    message = "Price must be greater than zero."
                });
            }

            var product = new Product
            {
                Id = Products.Max(x => x.Id) + 1,
                Name = request.Name,
                Category = request.Category,
                Price = request.Price,
                Stock = request.Stock,
                IsActive = true
            };

            Products.Add(product);

            return CreatedAtAction(
                nameof(GetById),
                new { id = product.Id },
                product);
        }

    }

}
