using WebMVC_API_Gage.Helpers;
using WebMVC_API_Gage.Services.Interfaces;
using WebMVC_API_Gage.Models;

namespace WebMVC_API_Gage.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Character/";

        public CharacterService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Character>> FindAll()
        {
            var responseGet = await _client.GetAsync(BasePath);

            var response = await responseGet.ReadContentAsync<List<Character>>();

            return response;
        }

        public async Task<Character> FindOne(int id)
        {
            var request = BasePath + id.ToString();
            var responseGet = await _client.GetAsync(request);

            var response = await responseGet.ReadContentAsync<Character>();

            var character = new Character(response.Id, response.Name, response.Health, response.Race, response.Strength);

            return character;
        }
    }
}