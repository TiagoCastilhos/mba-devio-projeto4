using Coldmart.Alunos.Data.Contexts;
using Coldmart.Core.Contracts;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Coldmart.Alunos.API.Consumers;

public class PagamentoRealizadoConsumer : IConsumer<PagamentoRealizado>
{
    private readonly AlunosDbContext _dbContext;

    public PagamentoRealizadoConsumer(AlunosDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<PagamentoRealizado> context)
    {
        var matricula = await _dbContext.Matriculas
            .FirstAsync(m => m.Id == context.Message.MatriculaId);
        matricula.Iniciar();
        await _dbContext.SaveChangesAsync();
    }
}
