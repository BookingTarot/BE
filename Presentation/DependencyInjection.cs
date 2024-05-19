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
		}
	}

}
