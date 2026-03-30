using Coldmart.Alunos.Data.Contexts;
using Coldmart.Alunos.Domain;
using Coldmart.Core.Eventos;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Coldmart.Alunos.API.Consumers;

public class AulaRealizadaConsumer : IConsumer<AulaRealizadaEvento>
{
    private readonly IAlunosDbContext _alunosDbContext;

    public AulaRealizadaConsumer(IAlunosDbContext alunosDbContext)
    {
        _alunosDbContext = alunosDbContext;
    }

    public async Task Consume(ConsumeContext<AulaRealizadaEvento> context)
    {
        var aulasCurso = await _alunosDbContext.Aulas
                        .Where(a => a.CursoId == context.Message.CursoId)
                        .ToListAsync();

        var aulasRealizadas = await _alunosDbContext.HistoricosAlunos
            .Where(h => h.AlunoId == context.Message.AlunoId && h.CursoId == context.Message.CursoId)
            .ToListAsync();

        if (aulasCurso.Count != aulasRealizadas.Count)
            return;

        var curso = await _alunosDbContext.Cursos.FirstAsync(c => c.Id == context.Message.CursoId);
        var aluno = await _alunosDbContext.Alunos.FirstAsync(a => a.Id == context.Message.AlunoId);

        var certificado = new Certificado(curso, aluno);
        await _alunosDbContext.Certificados.AddAsync(certificado);

        var matricula = await _alunosDbContext.Matriculas
            .FirstAsync(m => m.AlunoId == aluno.Id && m.CursoId == curso.Id);
        matricula.Concluir();

        await _alunosDbContext.SaveChangesAsync();
    }
}
