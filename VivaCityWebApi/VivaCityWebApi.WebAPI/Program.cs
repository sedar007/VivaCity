using VivaCityWebApi.Business.Implementations;
using VivaCityWebApi.Business.Implementations;
using VivaCityWebApi.Business.Interfaces;
using VivaCityWebApi.Common;
using VivaCityWebApi.DataAccess;
using VivaCityWebApi.DataAccess.Implementations;
using VivaCityWebApi.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using VivaCityWebApi.Common.Interfaces;

namespace VivaCityWebApi.WebAPI;

public class Program {
	private const string CORS_POLICY = "CORS_POLICY";
	
	


	public static void Main(string[] args) {
		

		var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
		logger.Info("Starting Application ...");

		try {
			var builder = WebApplication.CreateBuilder(args);
			builder.Configuration.AddUserSecrets<Program>();
			var rawConfig = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddEnvironmentVariables()
				.AddJsonFile("appsettings.json")
				.AddUserSecrets<Program>()
				.Build();

			var appSettingsSection = rawConfig.GetSection("AppSettings");
			builder.Services.Configure<AppSettings>(appSettingsSection);
			builder.Services.Configure<AppSettings>(builder.Configuration);


			// Context
			builder.Services.AddTransient<GameContext>();

			// Add services to the container.
			builder.Services.AddTransient<IUserDataAccess, UsersDataAccess>();
			builder.Services.AddTransient<IUserService, UserService>();
			builder.Services.AddTransient<IRessourceItemsDataAccess, RessourceItemsDataAccess>();
			builder.Services.AddTransient<IRessourceItemService, RessourceItemService>();
			builder.Services.AddTransient<IRessourceDataAccess, RessourceDataAccess>();
			builder.Services.AddTransient<IRessourceService, RessourceService>();
			builder.Services.AddTransient<ICoutDataAccess, CoutDataAccess>();
			builder.Services.AddTransient<ICoutService, CoutService>();
			builder.Services.AddTransient<IBatimentDataAccess, BatimentDataAccess>();
			builder.Services.AddTransient<IBatimentService, BatimentService>();
			builder.Services.AddTransient<IVillageDataAccess, VillageDataAccess>();
			builder.Services.AddTransient<IVillageService, VillageService>();
			builder.Services.AddTransient<IRankingDataAccess, RankingDataAccess>();
			builder.Services.AddTransient<IRankingService, RankingService>();

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			
			builder.Services.AddCors(options => {
				options.AddPolicy(name: CORS_POLICY,
					policy => {
						policy.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader();
					});
			});

			// NLog: Setup NLog for Dependency injection
			builder.Logging.ClearProviders();
			builder.Host.UseNLog();
			
			

			var app = builder.Build();

			using (var scope = app.Services.CreateScope()) {
				var dbContext = scope.ServiceProvider.GetRequiredService<GameContext>();

				// Here is the migration executed
				dbContext.Database.Migrate();
			}

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment()) {
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseCors(CORS_POLICY);

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		} catch (Exception e) {
			logger.Error(e);
			throw;
		} finally {
			// Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
			NLog.LogManager.Shutdown();
		}
	}
}
