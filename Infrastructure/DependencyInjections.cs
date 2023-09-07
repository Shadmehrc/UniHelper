using Application.RepositoryInterfaces;
using Infrastructure.Repositories;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUsersDataAccess, UsersDataAccess>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ILessonTypeRepository, LessonTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}