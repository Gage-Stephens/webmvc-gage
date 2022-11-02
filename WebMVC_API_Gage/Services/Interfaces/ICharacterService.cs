using WebMVC_API_Gage.Models;

namespace WebMVC_API_Gage.Services.Interfaces
{
    public interface ICharacterService
    {
        Task<IEnumerable<Character>> FindAll();

        Task<Character> FindOne(int id);
    }
}
