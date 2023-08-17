using PlayRpsls.BusinessLogic;

namespace PlayRpsls.Configuration
{
	public static class DependencyConfig
	{
		public static void Configure(this IServiceCollection services)
		{
			services.AddScoped<RandomChoice>();
			services.AddScoped<PlayGameWithBot>();
		}
	}
}
