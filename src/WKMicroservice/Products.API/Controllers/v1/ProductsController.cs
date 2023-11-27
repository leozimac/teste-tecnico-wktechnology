using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.API.Application.Commands.AddProduct;
using Products.API.Application.Commands.DeleteProduct;
using Products.API.Application.Commands.UpdateProduct;
using Products.API.Application.Queries.GetAll;
using Products.API.Application.Queries.GetById;
using Products.API.Controllers.shared;
using Products.API.Domain.DTOs;

namespace Products.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductsController : ApiControllerBase
    {
        public IMediator Mediator { get; set; }

        public ProductsController(IMediator mediator)
        {
            Mediator = mediator;
        }

        /// <summary>
        /// Get all the products.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns all products registered.</response>
        /// <response code="500">Returns the errors that occured.</response>
        [ProducesResponseType(typeof(GetAllProductsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetAllProductsResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<GetAllProductsResponse> GetAllAsync([FromQuery]GetAllProductsRequest getAllProductsRequest)
        {
            var response = await Mediator.Send(getAllProductsRequest);
            
            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Get a product by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(GetProductByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<GetProductByIdResponse> GetByIdAsync([FromRoute]GetProductByIdRequest getProductByIdRequest)
        {
            var response = await Mediator.Send(getProductByIdRequest);
            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Add a new product.
        /// </summary>
        /// <param name="productRequest"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(AddProductResponse), StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<AddProductResponse> AddAsync([FromBody]AddProductRequest productRequest)
        {
            var response = await Mediator.Send(productRequest);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="updateProductRequest"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<UpdateProductResponse> UpdateAsync([FromBody]UpdateProductRequest updateProductRequest)
        {
            var response = await Mediator.Send(updateProductRequest);
            HttpContext.Response.StatusCode = (int)response.StatusCode;
            return response;
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="deleteProductRequest"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<DeleteProductResponse> DeleteAsync([FromRoute]DeleteProductRequest deleteProductRequest)
        {
            var response = await Mediator.Send(deleteProductRequest);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }
    }
}
