


using learn_worker.Models;

namespace learn_worker
{
    public class JokeService
    {
        ILogger<JokeService> _logger;
        private readonly JokeServiceSettingsModel _jokeServiceSettings;

        public JokeService(ILogger<JokeService> logger, JokeServiceSettingsModel jokeServiceSettings)
        {
            _logger=logger;
            _jokeServiceSettings=jokeServiceSettings;
        }

        public async Task<JokeResponseModel> GetJokeAsync()
        {
            //var uri = "https://v2.jokeapi.dev/joke/Any?&type=twopart";
            var returnedJoke = new JokeResponseModel();
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(_jokeServiceSettings.JokeEndpoint!)
            };
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
    }
}
