using PlayRpsls.Configuration;
using PlayRpsls.ExternalServices;
using PlayRpsls.Filters;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => 
{
	options.Filters.Add<ExceptionActionFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure();
builder.Services.AddHttpClient<IRandomService, RandomService>(client =>
{
	client.BaseAddress = new Uri(builder.Configuration["RandomUrl"]);
})
	.AddPolicyHandler((services, request) => HttpPolicyExtensions
						.HandleTransientHttpError()
						.Or<TimeoutRejectedException>()
						.OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
						.WaitAndRetryAsync(Convert.ToInt32(builder.Configuration["RandomServiceRetryCount"]),
							retryAttempt => TimeSpan.FromMilliseconds(100),
							onRetry: (outcome, timespan, retryAttempt, context) => 
								services.GetRequiredService<ILogger<IRandomService>>()
								.LogWarning("Delaying for {delay}ms, then making retry {retry}.", timespan.TotalMilliseconds, retryAttempt)))
	.AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(2));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
