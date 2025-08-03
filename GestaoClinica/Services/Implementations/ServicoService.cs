using GestaoClinica.Entities;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Services.Interfaces;
using GestaoClinica.Entities.GestaoClinica.Entities;

namespace GestaoClinica.Services.Implementations
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoService(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task AdicionarAsync(Servico servico)
        {
            if (string.IsNullOrEmpty(servico.NomeServico))
            {
                throw new ArgumentException("O nome é obrigatório!");
            }

            servico.DataCriacao = DateTime.Now;
            servico.UltimaAtualizacao = DateTime.Now;
            servico.Ativo = true;

            await _servicoRepository.AdicionarAsync(servico);
        }

        public async Task AtualizarAsync(Servico servico)
        {
            await _servicoRepository.AtualizarAsync(servico);
            servico.UltimaAtualizacao = DateTime.Now;
        }

        public async Task ExcluirAsync(int id)
        {
            await _servicoRepository.ExcluirAsync(id);
        }

        public async Task<IEnumerable<Servico>> ListarServicoAsync()
        {
            return await _servicoRepository.ListarServicoAsync();
        }

        public Task<Servico> ObterServicoPorIdAsync(int id)
        {
            var servico = _servicoRepository.ObterServicoPorIdAsync(id);
            if (servico == null)
            {
                throw new KeyNotFoundException($"Servico com {id} não encontrado.");
            }
            return servico;
        }
    }
}
