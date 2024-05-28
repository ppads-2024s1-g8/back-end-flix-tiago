using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts.UseCases.Comentario;
using Domain.Contracts.UseCases.Film;
using Domain.Entities;
using Flix.Application.InterfaceAdapters;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Comentarios
{
    public class ComentarioUseCase
    {
        private readonly IApplicationDbContext _dbContext;
        public ComentarioUseCase(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comentario> PostComentario(ComentarioDTO input, CancellationToken cancellationToken)
        {

            var newComentario = new Comentario(input.Nome, input.Texto);

            await _dbContext.Comentario.AddAsync(newComentario, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return newComentario;
        }
    }
}
