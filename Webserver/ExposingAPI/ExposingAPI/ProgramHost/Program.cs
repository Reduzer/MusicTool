
namespace ExposingAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHost(args).Build().Run();
		}

		private static IHostBuilder CreateHost(string[] args)
		{
			return Host.CreateDefaultBuilder(args).
				ConfigureWebHostDefaults(oWebBuilder => 
				{
					oWebBuilder.UseStartup<ExposingAPI.ProgramHost.Startup>();
					oWebBuilder.UseUrls("");
					oWebBuilder.UseKestrel();
				});
		}
	}
}
