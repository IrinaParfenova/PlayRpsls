using PlayRpsls.Enums;
using System.Text.Json.Serialization;

namespace PlayRpsls.Model
{
	public class Choice
	{
		public Figure Id { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public Figure Name { get; set; }
	}
}
