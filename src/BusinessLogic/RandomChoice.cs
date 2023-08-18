using PlayRpsls.Enums;
using PlayRpsls.ExternalServices;

namespace PlayRpsls.BusinessLogic
{
	public class RandomChoice
	{
		private readonly IRandomService _randomService;

		public RandomChoice(IRandomService randomService)
		{
			_randomService = randomService;
		}

		public async Task<int> ExecuteAsync()
		{
			var randomInt = await _randomService.GetRandomNumberAsync();

			var figuresCount = Enum.GetValues<Figure>().Length;

			return randomInt.Random % figuresCount;
		}
	}
}
