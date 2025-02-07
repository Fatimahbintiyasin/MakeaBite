using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MakeaBite_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MakeaBite_WebApp.Controllers
{
    public class RecipeController : Controller
    {
        HttpClient client = new HttpClient();
        string uri = "https://localhost:7131";
        HttpResponseMessage response;

        public RecipeController()
        {
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Recipe> recipes = new List<Recipe>();
            try
            {
                string json;
                response = await client.GetAsync("api/Recipe/list");
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    recipes = JsonConvert.DeserializeObject<IEnumerable<Recipe>>(json);
                }
                else
                {
                    Console.WriteLine("Internal Server error");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            return View(recipes);
        }


        // GET: RecipeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Recipe recipe = new Recipe() { Ingredients = new List<Ingredient>() };
            try
            {
                string json;
                response = await client.GetAsync("api/Recipe/" + id);
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    recipe = JsonConvert.DeserializeObject<Recipe>(json);
                }
                else
                {
                    Console.WriteLine("Internal Server error");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            return View(recipe);
        }

        // GET: RecipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Recipe recipe)
        {
            try
            {
                string json;
                Recipe recipeNew = new Recipe()
                {
                    Description = recipe.Description,
                    RecipeName = recipe.RecipeName,
                    RecipeType = recipe.RecipeType,
                    ImageIrl = recipe.ImageIrl,
                    AuthorId = recipe.AuthorId
                };
                json = JsonConvert.SerializeObject(recipeNew);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync("api/Recipe", content);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Recipe recipe = null;
            try
            {
                string json;
                response = await client.GetAsync("api/Recipe/" + id);
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    recipe = JsonConvert.DeserializeObject<Recipe>(json);
                }
                else
                {
                    Console.WriteLine("Internal Server error");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            return View(recipe);
        }

        // POST: RecipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Recipe recipe)
        {
            try
            {
                string json;
                Recipe recipeNew = new Recipe()
                {
                    Description = recipe.Description,
                    RecipeName = recipe.RecipeName,
                    RecipeType = recipe.RecipeType,
                    ImageIrl = recipe.ImageIrl,
                    AuthorId = recipe.AuthorId
                };
                json = JsonConvert.SerializeObject(recipeNew);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PutAsync("api/recipe/update/" + id, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Recipe recipe = null;
            try
            {
                string json;
                response = await client.GetAsync("api/Recipe/" + id);
                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    recipe = JsonConvert.DeserializeObject<Recipe>(json);
                }
                else
                {
                    Console.WriteLine("Internal Server error");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            return View(recipe);
        }

        // POST: RecipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                response = await client.DeleteAsync("api/Recipe/delete/" + id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
