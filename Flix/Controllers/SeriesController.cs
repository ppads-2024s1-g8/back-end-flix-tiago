using Domain.Contracts.UseCases.Series;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flix.Controllers;

[ApiController]
[Route("[controller]")]
public class SeriesController : ControllerBase
{
    private readonly ISerieUseCase _SerieUseCase;

    public SeriesController(ISerieUseCase createBookUseCase)
    {
        _SerieUseCase = createBookUseCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<IActionResult> CreateSerieAsync([FromBody] SerieInputDto input, CancellationToken cancellationToken)
    {
        try
        {
            var serieCreate = await _SerieUseCase.CreateAsync(input, cancellationToken);

            return Ok(
                new
                {
                    serieTitulo = serieCreate
                });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSerieAsync(CancellationToken cancellationToken)
    {
        try
        {
            var serieList = await _SerieUseCase.GetAllAsync(cancellationToken);

            return Ok(serieList);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdSerieasync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var serieId = await _SerieUseCase.GetByIdAsync(id, cancellationToken);
            return Ok(serieId);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteByIdSerieAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var serieDeleted = await _SerieUseCase.DeleteByIdAsync(id, cancellationToken);

            return Ok(serieDeleted);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutByIdSerieAsync([FromBody] SerieInputDto input, int id, CancellationToken cancellationToken)
    {
        try
        {
            var serieUpdated = await _SerieUseCase.PutByIdAsync(input, id, cancellationToken);
            return Ok(serieUpdated);

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
