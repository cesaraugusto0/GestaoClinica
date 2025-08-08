using AutoMapper;
using GestaoClinica.DTO;
using GestaoClinica.Entities;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Services.Interfaces;

namespace GestaoClinica.Services.Implementations
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IMapper _mapper;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository, IMapper mapper)
        {
            _agendamentoRepository = agendamentoRepository;
            _mapper = mapper;
        }

        public async Task AdicionarAsync(AgendamentoCreateDTO agendamentoDTO)
        {
            var agendamento = _mapper.Map<Agendamento>(agendamentoDTO);
            await _agendamentoRepository.AdicionarAsync(agendamento);
        }

        public async Task AtualizarAsync(Agendamento agendamento)
        {
            await _agendamentoRepository.AtualizarAsync(agendamento);
            agendamento.UltimaAtualizacao = DateTime.Now;

        }

        public async Task ExcluirAsync(int id)
        {
            var agendamentoExistente = await _agendamentoRepository.ObterAgendamentoPorIdAsync(id);
            if (agendamentoExistente == null)
            {
                throw new KeyNotFoundException($"Agendamento com ID {id} não encontrado.");
            }
            await _agendamentoRepository.ExcluirAsync(id);
        }

        public async Task<IEnumerable<AgendamentoDTO>> ListarAgendamentosAsync()
        {
            var agendamentos = await _agendamentoRepository.ListarAgendamentosAsync();
            return _mapper.Map<IEnumerable<AgendamentoDTO>>(agendamentos);
        }

        public async Task<Agendamento> ObterAgendamentoPorIdAsync(int id)
        {
            var agendamento = await _agendamentoRepository.ObterAgendamentoPorIdAsync(id);
            if (agendamento == null)
            {
                throw new KeyNotFoundException($"Agendamento com ID {id} não encontrado.");
            }
            return agendamento;
        }

        // Novos métodos de filtragem para o serviço
        public async Task<IEnumerable<Agendamento>> ListarAgendamentosPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            if (dataInicio > dataFim)
            {
                throw new ArgumentException("A data de início deve ser anterior à data de fim.");
            }
            return await _agendamentoRepository.ListarAgendamentosPorPeriodoAsync(dataInicio, dataFim);
        }

        public async Task<IEnumerable<Agendamento>> ListarAgendamentosPorClienteAsync(int idCliente)
        {
            return await _agendamentoRepository.ListarAgendamentosPorClienteAsync(idCliente);
        }

        public async Task<IEnumerable<Agendamento>> ListarAgendamentosPorFuncionarioAsync(int idFuncionario)
        {
            return await _agendamentoRepository.ListarAgendamentosPorFuncionarioAsync(idFuncionario);
        }

        public async Task<IEnumerable<Agendamento>> ListarAgendamentosPorServicoAsync(int idServico)
        {
            return await _agendamentoRepository.ListarAgendamentosPorServicoAsync(idServico);
        }
    }
}
