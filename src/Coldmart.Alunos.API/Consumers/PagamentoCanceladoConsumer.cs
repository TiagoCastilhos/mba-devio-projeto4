using Coldmart.Alunos.Data.Contexts;
using Coldmart.Core.Contracts;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Coldmart.Alunos.API.Consumers;

public class PagamentoCanceladoConsumer : IConsumer<PagamentoCancelado>
{
    private readonly IAlunosDbContext _dbContext;

    public PagamentoCanceladoConsumer(IAlunosDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<PagamentoCancelado> context)
    {
        Console.WriteLine("--> Consuming Pagamento Cancelado");

        var matricula = await _dbContext.Matriculas
            .FirstAsync(m => m.Id == context.Message.MatriculaId);

        matricula.Cancelar();
        await _dbContext.SaveChangesAsync();
    }
}
