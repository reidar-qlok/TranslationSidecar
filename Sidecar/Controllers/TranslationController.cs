using Microsoft.AspNetCore.Mvc;

namespace Sidecar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationController : Controller
    {
        [HttpPost]
        public IActionResult Translate([FromBody] TranslationRequest request)
        {
            string translatedText = TranslateToSpanish(request.Text);
            return Ok(new TranslationResponse { TranslatedText = translatedText });
        }

        private string TranslateToSpanish(string text)
        {
            // Simulerad översättning
            return text switch
            {
                "Hello" => "Hola",
                "Goodbye" => "Adiós",
                _ => text
            };
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
