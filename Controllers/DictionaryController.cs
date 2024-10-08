using Microsoft.AspNetCore.Mvc;
using DictionaryAPI.Data;

namespace DictionaryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        private readonly DictionaryContext _context;

        // Inject the DictionaryContext through the constructor
        public DictionaryController(DictionaryContext context)
        {
            _context = context;
        }

        // Define a GET endpoint to translate words
        [HttpGet("translate")]
        public IActionResult Translate(string word)
        {
            // Find the translation in the database
            var translation = _context.Dictionary
                .FirstOrDefault(e => e.EnglishWord.ToLower() == word.ToLower());

            // If not found, return a NotFound response
            if (translation == null)
            {
                return NotFound(new { Message = "Translation not found" });
            }

            // If found, return the translation
            return Ok(new { Translation = translation.HungarianTranslation });
        }
    }
}
