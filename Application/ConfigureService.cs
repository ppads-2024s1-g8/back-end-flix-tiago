using Application.UseCases;
using Application.UseCases.Book;
using Application.UseCases.Film;
using Application.UseCases.Series;
using Application.UseCases.User;
using Domain.Contracts.UseCases.Book;
using Domain.Contracts.UseCases.Film;
using Domain.Contracts.UseCases.Series;
using Domain.Contracts.UseCases.User;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureService
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFilmUseCase, FilmUseCase>();
        services.AddScoped<IBookUseCase, BookUseCase>();
        services.AddScoped<ISerieUseCase, SeriesUseCase>();
        services.AddScoped<IUsuarioUseCase, UsuarioUseCases>();
        services.AddScoped<TokenUserCase>();
        return services;
    }
}
