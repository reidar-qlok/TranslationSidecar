namespace MainApp.Services
{
    public class TranslationService
    {
        private readonly HttpClient _httpClient;

        public TranslationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> TranslateAsync(string text)
        {
            var request = new { Text = text };
            var response = await _httpClient.PostAsJsonAsync("https://localhost:5002/Translation", request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<TranslationResponse>();
            return result.TranslatedText;
        }

        private class TranslationResponse
        {
            public string TranslatedText { get; set; }
        }
    }
}
