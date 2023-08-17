using System.Text.Json.Serialization;
using PlayRpsls.Enums;

namespace PlayRpsls.Model
{
	public class PlayResult
	{
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public GameResult Results { get; set; }

		public Figure Player { get; set; }

		public Figure Bot { get; set; }
	}
}
