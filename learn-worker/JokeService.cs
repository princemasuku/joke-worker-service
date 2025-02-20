


using learn_worker.Models;
using System.Net.Http;

namespace learn_worker
{
    public class JokeService
    {
        ILogger<JokeService> _logger;
        private readonly JokeServiceSettingsModel _jokeServiceSettings;
        private readonly IHttpClientFactory _httpClient;

        public JokeService(ILogger<JokeService> logger, JokeServiceSettingsModel jokeServiceSettings, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _jokeServiceSettings = jokeServiceSettings;
            _httpClient = httpClient;
        }

        public async Task<JokeResponseModel> GetJokeAsync()
        {
            _logger.LogInformation("{method} called",nameof(GetJokeAsync));
            var returnedJoke = new JokeResponseModel();
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_jokeServiceSettings.JokeEndpoint!);
            var joke = await client.GetAsync(SelectRandomCategory(_jokeServiceSettings.Categories!)+"?&type=twopart");

            if(joke.IsSuccessStatusCode)
            {
                returnedJoke = Serialization.Serialization<JokeResponseModel>.FromJson(await joke.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine("Nevermind");
            }
                return returnedJoke;
        }

        public string SelectRandomCategory(List<string> categories)
        {
            var random = new Random();
            return categories[random.Next(categories.Count)];
        }

        //public string 
    }
}
