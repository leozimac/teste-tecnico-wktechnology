using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebApp.DTOs.Category;
using WebApp.DTOs.Product;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        HttpClient httpClient;

        GetProductsResponse getProductsResponse = new GetProductsResponse();

        public ProductsController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var products = await FetchProductsListAsync();
            ViewBag.ResponseDetails = new
            {
                Messages = getProductsResponse.Messages.FirstOrDefault(),
                StatusCode = (int)getProductsResponse.StatusCode
            };

            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await FetchCategoriesForDropdownAsync();

            var selectListCategory = new List<SelectListItem>();

            foreach (var item in categories)
            {
                selectListCategory.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            var model = new CreateProductViewModel
            {
                Categories = selectListCategory
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            var response = new AddProductResponse();
            if (ModelState.IsValid)
            {
                var request = new AddProductRequest
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    IdCategory = model.IdCategory
                };

                response = await PostProductAsync(request);
            }

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ViewBag.ResponseDetails = new
                {
                    Messages = response.Messages.FirstOrDefault(),
                    StatusCode = (int)response.StatusCode
                };

                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await FetchProductAsync(id);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ViewBag.ResponseDetails = new
                {
                    Messages = response.Messages.FirstOrDefault(),
                    StatusCode = (int)response.StatusCode
                };
            }

            var categories = await FetchCategoriesForDropdownAsync();

            var selectListCategory = new List<SelectListItem>();

            foreach (var item in categories)
            {
                selectListCategory.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            var model = new EditProductViewModel
            {
                Id = response.Product.Id,
                Name = response.Product.Name,
                Description = response.Product.Description,
                Price = response.Product.Price,
                IdCategory = response.Product.IdCategory,
                Categories = selectListCategory
            };

            return View(model);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            var response = await UpdateProductAsync(new ProductDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                IdCategory = model.IdCategory
            });

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ViewBag.ResponseDetails = new
                {
                    Messages = response.Messages.FirstOrDefault(),
                    StatusCode = (int)response.StatusCode
                };
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await FetchProductAsync(id);

            return View(new ProductViewModel
            {
                Id = response.Product.Id,
                Name = response.Product.Name,
                Description = response.Product.Description,
                Price = response.Product.Price,
                Category = response.Product.IdCategory.ToString()
            });
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(ProductDto model)
        {
            var response = await DeleteProductAsync(model.Id);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ViewBag.ResponseDetails = new
                {
                    Messages = response.Messages.FirstOrDefault(),
                    StatusCode = (int)response.StatusCode
                };
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region API Calls
        private async Task<List<ProductViewModel>> FetchProductsListAsync()
        {
            var productsResponse = await httpClient.GetFromJsonAsync<GetProductsResponse>("/api/products");
            getProductsResponse = productsResponse;

            return productsResponse.Products;
        }

        private async Task<GetProductByIdResponse> FetchProductAsync(int id)
        {
            var product = await httpClient.GetFromJsonAsync<GetProductByIdResponse>($"/api/products/{id}");

            return product;
        }

        private async Task<List<CategoriesMenuDto>> FetchCategoriesForDropdownAsync()
        {
            var categoriesMenuResponse = await httpClient.GetFromJsonAsync<GetCategoriesMenuResponse>("/api/categories/menu");

            return categoriesMenuResponse.Categories;
        }

        private async Task<AddProductResponse> PostProductAsync(AddProductRequest request)
        {
            var response = await httpClient.PostAsJsonAsync("api/products", request);
            return await response.Content.ReadFromJsonAsync<AddProductResponse>();
        }

        private async Task<UpdateProductResponse> UpdateProductAsync(ProductDto request)
        {
            var response = await httpClient.PutAsJsonAsync<ProductDto>($"/api/products", request);

            return await response.Content.ReadFromJsonAsync<UpdateProductResponse>();
        }

        private async Task<DeleteProductResponse> DeleteProductAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"api/products/{id}");
            return await response.Content.ReadFromJsonAsync<DeleteProductResponse>();
        }
        #endregion
    }
}
