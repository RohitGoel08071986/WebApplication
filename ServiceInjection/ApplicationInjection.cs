using BusinessLayer;
using DataLayer.DataGenerator;
using DataLayer.Interfaces;
using DataLayer.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ServiceInjection
{
    public static class ApplicationInjection
    {

        public static void AddServiceInjection(this IServiceCollection services)
        {
            services.AddSingleton<MoviesGenerator>();
            services.AddScoped<IMoviesRepository, InMemoryMovieRepository>();
            AddBusinessLayerInjection(services);
            //

        }

        private static void AddBusinessLayerInjection(IServiceCollection services)
        {
            
            services.AddScoped<IManageMovies, ManageMovies>();
        }
    }
}
