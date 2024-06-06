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
            var translations = new[]
            {
                await _translationService.TranslateAsync("Hello"),
                await _translationService.TranslateAsync("Goodbye"),
                await _translationService.TranslateAsync("Please"),
                await _translationService.TranslateAsync("Thank you"),
                await _translationService.TranslateAsync("Yes"),
                await _translationService.TranslateAsync("No")
            };

            ViewData["Translations"] = translations;
            return View();
        }
    }
}
