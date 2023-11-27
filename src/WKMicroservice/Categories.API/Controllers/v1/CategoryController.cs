using Asp.Versioning;
using Categories.API.Application.Queries.GetAll;
using Categories.API.Controllers.shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Categories.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoryController : ApiControllerBase
    {
        public IMediator Mediator { get; set; }

        public CategoryController(IMediator mediator )
        {
            Mediator = mediator;
        }

        /// <summary>
        /// Get all the categories.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Returns all categories registered</response>
        /// <response code="500">Returns the errors that ocurred</response>
        [ProducesResponseType(typeof(GetAllCategoriesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetAllCategoriesResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<GetAllCategoriesResponse> GetAllAsync([FromQuery] GetAllCategoriesRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Get a category by id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Returns a category</response>
        /// <response code="404">Returns if the category is not found</response>
        /// <response code="500">Returns the errors that ocurred</response>
        [ProducesResponseType(typeof(GetCategoryByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetCategoryByIdResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetCategoryByIdResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<GetCategoryByIdResponse> GetByIdAsync([FromRoute] GetCategoryByIdRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Get a list of categories for menus.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Returns a list of categories for a menu</response>
        /// <response code="500">Returns the errors that ocurred</response>
        [ProducesResponseType(typeof(GetCategoryMenuResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("menu")]
        public async Task<GetCategoryMenuResponse> GetMenuAsync()
        {
            var request = new GetCategoryMenuRequest();
            
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;
            return response;
        }

        /// <summary>
        /// Create a new category.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <response code="200">Category created successfully</response>
        /// <response code="500">Returns the errors that ocurred</response>
        [ProducesResponseType(typeof(AddCategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<AddCategoryResponse> AddAsync([FromBody] AddCategoryRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Updates a category.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Category updated successfully</response>
        /// <response code="400">Returns if one or more validation fails</response>
        /// <response code="500">Returns the erros that ocurred</response>
        [ProducesResponseType(typeof(UpdateCategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<UpdateCategoryResponse> UpdateAsync([FromBody] UpdateCategoryRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }

        /// <summary>
        /// Deletes a category.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Category deleted successfully</response>
        /// <response code="400">Returns if one or more validation fails</response>
        /// <response code="500">Returns the errors thar ocurred</response>
        [ProducesResponseType(typeof(DeleteCategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<DeleteCategoryResponse> DeleteAsync([FromRoute] DeleteCategoryRequest request)
        {
            var response = await Mediator.Send(request);

            HttpContext.Response.StatusCode = (int)response.StatusCode;

            return response;
        }
    }
}
