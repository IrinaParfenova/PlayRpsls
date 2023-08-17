using PlayRpsls.BusinessLogic;
using PlayRpsls.Enums;
using PlayRpsls.Model;

namespace PlayRpsls.Tests
{
	public class PlayGameWithBotTests
	{
		protected PlayGameWithBot _playGameWithBot = null!;

		[OneTimeSetUp]
		public void Setup()
		{
			_playGameWithBot = new PlayGameWithBot();
		}

		[TestCase(Figure.rock, Figure.rock)]
		[TestCase(Figure.paper, Figure.paper)]
		[TestCase(Figure.scissors, Figure.scissors)]
		[TestCase(Figure.lizard, Figure.lizard)]
		[TestCase(Figure.spock, Figure.spock)]
		public void TieGame(Figure player, Figure bot)
		{
			var playRequest = new PlayRequest
			{
				Player = (int)player,
				Bot = (int)bot
			};

			var result = _playGameWithBot.Execute(playRequest);
			
			Assert.IsNotNull(result);
			Assert.AreEqual(playRequest.Player, (int)result.Player, "Player is incorrect");
			Assert.AreEqual(playRequest.Bot, (int)result.Bot, "Bot is incorrect");

			Assert.AreEqual(GameResult.Tie, result.Results, "Game result is incorrect");
		}

		[TestCase(Figure.scissors, Figure.paper)]
		[TestCase(Figure.paper, Figure.rock)]
		[TestCase(Figure.rock, Figure.lizard)]
		[TestCase(Figure.lizard, Figure.spock)]
		[TestCase(Figure.spock, Figure.scissors)]
		[TestCase(Figure.scissors, Figure.lizard)]
		[TestCase(Figure.lizard, Figure.paper)]
		[TestCase(Figure.paper, Figure.spock)]
		[TestCase(Figure.spock, Figure.rock)]
		[TestCase(Figure.rock, Figure.scissors)]
		public void WinGame(Figure player, Figure bot)
		{
			var playRequest = new PlayRequest
			{
				Player = (int)player,
				Bot = (int)bot
			};

			var result = _playGameWithBot.Execute(playRequest);

			Assert.IsNotNull(result);
			Assert.AreEqual(playRequest.Player, (int)result.Player, "Player is incorrect");
			Assert.AreEqual(playRequest.Bot, (int)result.Bot, "Bot is incorrect");

			Assert.AreEqual(GameResult.Win, result.Results, "Game result is incorrect");
		}

		[TestCase(Figure.paper, Figure.scissors)]
		[TestCase(Figure.rock, Figure.paper)]
		[TestCase(Figure.lizard, Figure.rock)]
		[TestCase(Figure.spock, Figure.lizard)]
		[TestCase(Figure.scissors, Figure.spock)]
		[TestCase(Figure.lizard, Figure.scissors)]
		[TestCase(Figure.paper, Figure.lizard)]
		[TestCase(Figure.spock, Figure.paper)]
		[TestCase(Figure.rock, Figure.spock)]
		[TestCase(Figure.scissors, Figure.rock)]
		public void LoseGame(Figure player, Figure bot)
		{
			var playRequest = new PlayRequest
			{
				Player = (int)player,
				Bot = (int)bot
			};

			var result = _playGameWithBot.Execute(playRequest);

			Assert.IsNotNull(result);
			Assert.AreEqual(playRequest.Player, (int)result.Player, "Player is incorrect");
			Assert.AreEqual(playRequest.Bot, (int)result.Bot, "Bot is incorrect");

			Assert.AreEqual(GameResult.Lose, result.Results, "Game result is incorrect");
		}
	}
}