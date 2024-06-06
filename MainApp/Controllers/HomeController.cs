using MainApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MainApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TranslationService _translationService;

        public HomeController(TranslationService translationService)
        {
            _translationService = translationService;
        }

        public async Task<IActionResult> Index()
        {
            var translatedText = await _translationService.TranslateAsync("Hello");
            ViewData["TranslatedText"] = translatedText;
            return View();
        }
    }
}
