using Moq;
using PlayRpsls.BusinessLogic;
using PlayRpsls.ExternalServices;
using PlayRpsls.Model;

namespace PlayRpsls.Tests
{
	public class RandomChoiceTests
	{
		protected RandomChoice _randomChoice = null!;

		protected Mock<IRandomService> _randomService = null!;

		[OneTimeSetUp]
		public void Setup()
		{
			_randomService = new Mock<IRandomService>();
			_randomChoice = new RandomChoice(_randomService.Object);
		}

		[Test]
		public async Task TieGame()
		{
			for (int i = 0; i <= 255; i ++)
			{
				_randomService.Setup(r => r.GetRandomNumber())
				.ReturnsAsync(new RandomResult { Random = i });

				var result = await _randomChoice.ExecuteAsync();

				Assert.LessOrEqual(result, 4, "Return value must be in range [0-4]");
				Assert.GreaterOrEqual(result, 0, "Return value must be in range [0-4]");
			}
		}
	}
}
