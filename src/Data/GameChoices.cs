using PlayRpsls.Enums;
using PlayRpsls.Model;

namespace PlayRpsls.Data
{
	public class GameChoices
	{
		public static readonly Choice[] Choices = new Choice[]
		{
			new Choice()
			{
				Id = Figure.rock,
				Name = Figure.rock
			},
			new Choice()
			{
				Id = Figure.paper,
				Name = Figure.paper
			},
			new Choice()
			{
				Id = Figure.scissors,
				Name = Figure.scissors
			},
			new Choice()
			{
				Id = Figure.lizard,
				Name = Figure.lizard
			},
			new Choice()
			{
				Id = Figure.spock,
				Name = Figure.spock
			}
		};
	}
}
