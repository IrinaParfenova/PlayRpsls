using PlayRpsls.Model;

namespace PlayRpsls.ExternalServices
{
	public class RandomService : IRandomService
	{
		private readonly HttpClient _httpClient;
		private readonly ILogger<RandomService> _logger;

		public RandomService(HttpClient httpClient, ILogger<RandomService> logger)
		{
			_httpClient = httpClient;
			_logger = logger;
		}

		public async Task<RandomResult> GetRandomNumberAsync()
		{
			try
			{
				_logger.LogDebug("Calling external random service...");

				var result = await _httpClient.GetFromJsonAsync<RandomResult>("/random");

				if (result == null)
				{
					throw new RandomizerException("Service randomizer did not return a correct value");
				}

				_logger.LogDebug("Got the result from external random service");

				return result;
			}
			catch
			{
				throw new RandomizerException("Service randomizer is unavailable. Try later.");
			}
		}
	}
}
