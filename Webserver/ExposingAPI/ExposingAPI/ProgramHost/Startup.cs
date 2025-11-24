using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace ExposingAPI.ProgramHost
{
	public class Startup
	{
		public IConfiguration oConfiguration { get; }
	
		public Startup(IConfiguration oConfig)
		{
			oConfiguration = oConfig;
		}

		public void ConfigureServices(IServiceCollection oServices)
		{
			oServices.AddGraphQLServer().AddTypes();

			oServices.AddOpenApi();
			oServices.AddEndpointsApiExplorer();
			
			ConfigureRateLimiting(ref oServices);
		}

		public void Configure(IApplicationBuilder oApp, IWebHostEnvironment oEnv)
		{
			if (oEnv.IsDevelopment()) {
				oApp.UseDeveloperExceptionPage();
			}

			oApp.UseExceptionHandler("/error");
			oApp.UseHttpsRedirection();
			oApp.UseRouting();

			oApp.MapGraphQL("", "");

			oApp.UseStaticFiles();
			oApp.UseRateLimiter();
		}

		private void ConfigureRateLimiting(ref IServiceCollection oServices)
		{
			oServices.AddRateLimiter(options =>
				{
					options.AddSlidingWindowLimiter("SlidingWindowPolicy", opt =>
					{
						opt.Window = TimeSpan.FromMinutes(1);
						opt.PermitLimit = 100;
						opt.QueueLimit = 25;
						opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
						opt.SegmentsPerWindow = 6;
					}).RejectionStatusCode = 429; //429 is too many requests
				});
		}
	}
}
