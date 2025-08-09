using GestaoClinica.Data.Context;
using GestaoClinica.DTO;
using GestaoClinica.Entities;
using GestaoClinica.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoClinica.Repository.Implementation
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly SQLServerDbContext _context;

        public AgendamentoRepository(SQLServerDbContext context)
        {
            _context = context;
        }

        private IQueryable<Agendamento> GetAgendamentosComIncludes()
        {
            return _context.Agendamentos
                .Include(a => a.Cliente)
                .Include(a => a.Servico)
                .Include(a => a.Funcionario);
        }
        public async Task<IEnumerable<Agendamento>> ListarAgendamentosAsync()
        {
            return await GetAgendamentosComIncludes().ToListAsync();
        }

        public async Task<Agendamento?> ObterAgendamentoPorIdAsync(int id)
        {
            return await GetAgendamentosComIncludes().FirstOrDefaultAsync(a => a.IdAgendamento == id);
        }
        public async Task<IEnumerable<Agendamento>> ListarAgendamentosPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            // A query agora calcula a DataHoraFim dinamicamente.
            return await GetAgendamentosComIncludes()
                .Where(a => a.DataHoraInicio >= dataInicio &&
                            a.DataHoraInicio.AddMinutes(a.DuracaoAtendimento) <= dataFim)
                .ToListAsync();
        }

        public async Task<IEnumerable<Agendamento>> ListarAgendamentosPorClienteAsync(int idCliente)
        {
            return await GetAgendamentosComIncludes()
                .Where(a => a.ClienteId == idCliente)
                .ToListAsync();
        }

        public async Task<IEnumerable<Agendamento>> ListarAgendamentosPorFuncionarioAsync(int idFuncionario)
        {
            return await GetAgendamentosComIncludes()
                .Where(a => a.FuncionarioId == idFuncionario)
                .ToListAsync();
        }

        public async Task<IEnumerable<Agendamento>> ListarAgendamentosPorServicoAsync(int idServico)
        {
            return await GetAgendamentosComIncludes()
                .Where(a => a.ServicoId == idServico)
                .ToListAsync();
        }

        public async Task AdicionarAsync(Agendamento agendamento)
        {
            await _context.Agendamentos.AddAsync(agendamento);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Agendamento agendamento)
        {
            _context.Agendamentos.Update(agendamento);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAsync(int id)
        {
            var agendamentoExistente = await _context.Agendamentos.FindAsync(id);
            if (agendamentoExistente != null)
            {
                _context.Agendamentos.Remove(agendamentoExistente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FuncionarioAgendamentoReportDTO>> GetTop5FuncionariosComMaisAgendamentosAsync()
        {
            return await _context.Agendamentos
                .GroupBy(a => new { a.FuncionarioId, a.Funcionario.Nome })
                .Select(g => new FuncionarioAgendamentoReportDTO
                {
                    FuncionarioId = g.Key.FuncionarioId,
                    NomeFuncionario = g.Key.Nome,
                    TotalAgendamentos = g.Count()
                })
                .OrderByDescending(f => f.TotalAgendamentos)
                .Take(5)
                .ToListAsync();
        }
    }
}