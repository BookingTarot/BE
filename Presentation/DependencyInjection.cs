using Repositories;
using Services;

namespace Presentation
{
	/// <summary>
	/// Functions for create dependency injections
	/// </summary>
	public static class DependencyInjection
	{
		/// <summary>
		/// This function to add dependency injection for NuGet Package
		/// </summary>
		/// <param name="services"></param>
		public static void AddPackage(this IServiceCollection services)
		{
			//Add nunet package
			//services.AddCors(options =>
			//{
			//	options.AddPolicy("AllowReactApp",
			//		builder =>
			//		{
			//			builder.WithOrigins("http://localhost:3000") // Update with your React app URL
			//				   .AllowAnyHeader()
			//				   .AllowAnyMethod()
			//				   .AllowAnyOrigin()
			//				   .AllowCredentials();
			//		});
			//});
			services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000", "https://www.tellory.id.vn") // Update with your React app URL
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowCredentials();
                    });
            });



            services.AddSwaggerGen();
        }

		/// <summary>
		/// Create dependencies for service (interface) & service (class) or repository (interface) & repository (class)
		/// </summary>
		/// <param name="services"></param>
		public static void AddMasterServices(this IServiceCollection services)
		{
			//Add injecting about class and interface
			//EX:
			//services.AddScoped<IAccountRepository, AccountRepository>();
			//services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<ITarotReaderRepository, TarotReaderRepository>();
			services.AddScoped<ITarotReaderService, TarotReaderService>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IBookingRepository, BookingRepository>();
			services.AddScoped<IBookingService, BookingService>();
			services.AddScoped<IScheduleRepository, ScheduleRepository>();
			services.AddScoped<IFeedbackRepository, FeedbackRepository>();
			services.AddScoped<IFeedbackService, FeedbackService>();
			services.AddScoped<IScheduleService, ScheduleService>();
			services.AddScoped<ISessionTypeRepository, SessionTypeRepository>();
			services.AddScoped<ISessionTypeService, SessionTypeService>();
		}
	}

}
