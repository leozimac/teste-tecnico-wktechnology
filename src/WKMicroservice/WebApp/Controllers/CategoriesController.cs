using Microsoft.AspNetCore.Mvc;
using WebApp.DTOs.Category;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        HttpClient httpClient;
        GetCategoriesResponse getCategoriesResponse = new GetCategoriesResponse();

        public CategoriesController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await FetchCategoriesListAsync();
            ViewBag.ResponseDetails = new
            {
                Messages = getCategoriesResponse.Messages.FirstOrDefault(),
                StatusCode = (int)getCategoriesResponse.StatusCode
            };

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            var response = await CreateCategoryAsync(model);

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
            var response = await FetchCategoryAsync(id);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ViewBag.ResponseDetails = new
                {
                    Messages = response.Messages.FirstOrDefault(),
                    StatusCode = (int)response.StatusCode
                };
            }

            var model = response.Category;

            return View(model);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            var response = await UpdateCategoryAsync(model);

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
            var response = await FetchCategoryAsync(id);

            return View(response.Category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(CategoryViewModel model)
        {
            var response = await DeleteCategoryAsync(model.Id);

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

        #region API Calls
        private async Task<List<CategoryViewModel>> FetchCategoriesListAsync()
        {
            var categoriesResponse = await httpClient.GetFromJsonAsync<GetCategoriesResponse>("/api/categories");
            getCategoriesResponse = categoriesResponse;

            return categoriesResponse.Categories;
        }

        private async Task<GetCategoryByIdResponse> FetchCategoryAsync(int id)
        {
            var category = await httpClient.GetFromJsonAsync<GetCategoryByIdResponse>($"/api/categories/{id}");

            return category;
        }

        private async Task<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryViewModel model)
        {
            var response = await httpClient.PostAsJsonAsync<CreateCategoryViewModel>("/api/categories", model);

            return await response.Content.ReadFromJsonAsync<CreateCategoryResponse>();
        }

        private async Task<UpdateCategoryResponse> UpdateCategoryAsync(CategoryViewModel model)
        {
            var response = await httpClient.PutAsJsonAsync<CategoryViewModel>($"/api/categories/{model.Id}", model);

            return await response.Content.ReadFromJsonAsync<UpdateCategoryResponse>();
        }

        private async Task<DeleteCategoryResponse> DeleteCategoryAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"api/categories/{id}");
            return await response.Content.ReadFromJsonAsync<DeleteCategoryResponse>();
        }
        #endregion
    }
}
