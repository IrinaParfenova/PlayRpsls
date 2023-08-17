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
			return Ok(GameChoices.Choices);
		}

		[HttpGet]
		[Route("choice")]
		public async Task<IActionResult> GetRandomChoice()
		{
			var result = await _randomChoice.ExecuteAsync();
			return Ok(GameChoices.Choices[result]);
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
