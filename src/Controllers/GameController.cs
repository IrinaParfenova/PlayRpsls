using Microsoft.AspNetCore.Mvc;
using PlayRpsls.BusinessLogic;
using PlayRpsls.Data;
using PlayRpsls.Model;
using System.ComponentModel.DataAnnotations;

namespace PlayRpsls.Controllers
{
	[ApiController]
	[Route("game")]
	public class GameController : ControllerBase
	{
		private readonly RandomChoice _randomChoice;
		private readonly PlayGameWithBot _playGameWithBot;
		public GameController(RandomChoice randomChoice, PlayGameWithBot playGameWithBot)
		{
			_randomChoice = randomChoice;
			_playGameWithBot = playGameWithBot;
		}

		[HttpGet]
		[Route("choices")]
		public IActionResult GetChoices()
		{
			var choices = Enum.GetValues<Figure>()
				.Select(t => new Choice
				{
					Id = t,
					Name = t
				});

			return Ok(choices);
		}

		[HttpGet]
		[Route("choice")]
		public async Task<IActionResult> GetRandomChoice()
		{
			var result = await _randomChoice.ExecuteAsync();
   
			var choice = new Choice
			{
				Id = (Figure)result,
				Name = (Figure)result
			};
			
			return Ok(choice);
		}

		[HttpPost]
		[Route("play")]
		public async Task<IActionResult> Play([Range(0, 4, ErrorMessage = "Specify a number in the range 0-4")] int player)
		{
			var request = new PlayRequest 
			{ 
				Player = player,
				Bot = await _randomChoice.ExecuteAsync()
			};

			var result = _playGameWithBot.Execute(request);

			return Ok(result);
		}

	}
}
