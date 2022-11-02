using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebMVC_API_Gage.Models;
using WebMVC_API_Gage.Services.Interfaces;

namespace WebMVC_API_Gage.Controllers
{
    public class CharacterController : Controller
    {
        private ICharacterService? _service;

        private static readonly HttpClient client = new HttpClient();

        private string requestUri = "https://localhost:7109/api/Characters/";

        public CharacterController(ICharacterService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Gage's API");
        }

        // Example:
        public async Task<IActionResult> Index()
        {
            var response = await _service.FindAll();

            return View(response);
        }

        // GET: VideoGame/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var character = await _service.FindOne(id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: VideoGame/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoGame/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Race,Strength,Health")] Character character)
        {
            character.Id = 0;
            var resultPost = await client.PostAsync<Character>(requestUri, character, new JsonMediaTypeFormatter());

            return RedirectToAction(nameof(Index));
        }

        // GET: VideoGame/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var character = await _service.FindOne(id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: VideoGame/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Race,Strength,Health")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            var resultPut = await client.PutAsync<Character>(requestUri + character.Id.ToString(), character, new JsonMediaTypeFormatter());
            return RedirectToAction(nameof(Index));
        }

        // GET: VideoGame/Delete/5
        public async Task<IActionResult> Delete(int id)

        {
            var character = await _service.FindOne(id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: VideoGame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultDelete = await client.DeleteAsync(requestUri + id.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}

