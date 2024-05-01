using Domain.Contracts.UseCases.Book;
using Microsoft.AspNetCore.Mvc;

namespace Flix.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{

    private readonly IBookUseCase _BookUseCase;

    public BookController(IBookUseCase createBookUseCase)
    {
        _BookUseCase = createBookUseCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<IActionResult> CreateBookAsync([FromBody] BookInputDto input, CancellationToken cancellationToken)
    {
        try
        {
            var bookCreate = await _BookUseCase.CreateAsync(input, cancellationToken);

            return Ok(
                new
                {
                    BookTitulo = bookCreate
                });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBookAsync(CancellationToken cancellationToken)
    {
        try
        {
            var bookList = await _BookUseCase.GetAllAsync(cancellationToken);

            return Ok(bookList);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdBookAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var bookId = await _BookUseCase.GetByIdAsync(id, cancellationToken);
            return Ok(bookId);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteByIdBookAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var bookDeleted = await _BookUseCase.DeleteByIdAsync(id, cancellationToken);

            return Ok(bookDeleted);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutByIdBookAsync([FromBody] BookInputDto input, int id, CancellationToken cancellationToken)
    {
        try
        {
            var bookUpdated = await _BookUseCase.PutByIdAsync(input, id, cancellationToken);
            return Ok(bookUpdated);

        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

}
