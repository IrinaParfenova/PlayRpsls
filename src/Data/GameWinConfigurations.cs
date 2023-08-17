using PlayRpsls.Enums;

namespace PlayRpsls.Data
{
	public class GameWinConfigurations
	{
		public static Tuple<Figure, Figure>[] WinConfigurations = new Tuple<Figure, Figure>[]
		{
			new ( Figure.scissors, Figure.paper ),
			new ( Figure.paper, Figure.rock ),
			new ( Figure.rock, Figure.lizard ),
			new ( Figure.lizard, Figure.spock ),
			new ( Figure.spock, Figure.scissors ),
			new ( Figure.scissors, Figure.lizard ),
			new ( Figure.lizard, Figure.paper ),
			new ( Figure.paper, Figure.spock ),
			new ( Figure.spock, Figure.rock ),
			new ( Figure.rock, Figure.scissors ),
		};
	}
}
