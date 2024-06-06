using Microsoft.AspNetCore.Mvc;

namespace Sidecar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationController : Controller
    {
        private static readonly Dictionary<string, string> Translations = new Dictionary<string, string>
        {
            { "Hello", "Hola" },
            { "Goodbye", "Adiós" },
            { "Please", "Por favor" },
            { "Thank you", "Gracias" },
            { "Yes", "Sí" },
            { "No", "No" },
            { "How are you?", "¿Cómo estás?" },
            { "Good morning", "Buenos días" },
            { "Good night", "Buenas noches" },
            { "What's your name?", "¿Cómo te llamas?" },
            { "My name is", "Me llamo" },
            { "I don't understand", "No entiendo" },
            { "Do you speak English?", "¿Hablas inglés?" }
        };

        private readonly ILogger<TranslationController> _logger;

        public TranslationController(ILogger<TranslationController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Translate([FromBody] TranslationRequest request)
        {
            _logger.LogInformation("Received text to translate: {Text}", request.Text);
            var translatedText = TranslateToSpanish(request.Text);
            _logger.LogInformation("Translated text: {TranslatedText}", translatedText);
            return Ok(new TranslationResponse { TranslatedText = translatedText });
        }

        private string TranslateToSpanish(string text)
        {
            return Translations.TryGetValue(text, out var translatedText) ? translatedText : text;
        }
    }

    public class TranslationRequest
    {
        public string Text { get; set; }
    }

    public class TranslationResponse
    {
        public string TranslatedText { get; set; }
    }
}
