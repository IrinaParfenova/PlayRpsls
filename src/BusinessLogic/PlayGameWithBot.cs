using PlayRpsls.Data;
using PlayRpsls.Enums;
using PlayRpsls.Model;

namespace PlayRpsls.BusinessLogic
{
	public class PlayGameWithBot
	{
		public PlayResult Execute(PlayRequest playRequest)
		{
			var playerFigure = (Figure)playRequest.Player;
			var botFigure = (Figure)playRequest.Bot;

			if (playerFigure == botFigure)
			{
				return new PlayResult
				{
					Results = GameResult.Tie,
					Player = playerFigure,
					Bot = botFigure
				};
			}

			if (GameWinConfigurations.WinConfigurations.Contains(new (playerFigure, botFigure)))
			{
				return new PlayResult
				{
					Results = GameResult.Win,
					Player = playerFigure,
					Bot = botFigure
				};
			}
			else
			{
				return new PlayResult
				{
					Results = GameResult.Lose,
					Player = playerFigure,
					Bot = botFigure
				};
			}
		}
	}
}
