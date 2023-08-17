using PlayRpsls.Model;

namespace PlayRpsls.ExternalServices
{
	public interface IRandomService
	{
		Task<RandomResult> GetRandomNumber();
	}
}
