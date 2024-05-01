using Domain.Contracts.UseCases.Film;
using Microsoft.AspNetCore.Mvc;

namespace Flix.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase
{
    private readonly IFilmUseCase _FilmUseCase;

    public FilmController(IFilmUseCase createFilmUseCase)
    {
        _FilmUseCase = createFilmUseCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<IActionResult> CreateFilmAsync([FromBody] FilmInputDto input, CancellationToken cancellationToken)
    {
        try
        {
            var filmCreate = await _FilmUseCase.CreateAsync(input, cancellationToken);

            return Ok(
                new
                {
                    FilmTitulo = filmCreate
                });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFilmAsync(CancellationToken cancellationToken)
    {
        try
        {
            var filmList = await _FilmUseCase.GetAllAsync(cancellationToken);

            return Ok(filmList);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdFilmAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var filmId = await _FilmUseCase.GetByIdAsync(id, cancellationToken);
            return Ok(filmId);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteByIdFilmAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var filmDeleted = await _FilmUseCase.DeleteByIdAsync(id, cancellationToken);

            return Ok(filmDeleted);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutByIdFilmAsync([FromBody] FilmInputDto input, int id, CancellationToken cancellationToken)
    {
        try
        {
            var filmUpdated = await _FilmUseCase.PutByIdAsync(input, id, cancellationToken);
            return Ok(filmUpdated);

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
