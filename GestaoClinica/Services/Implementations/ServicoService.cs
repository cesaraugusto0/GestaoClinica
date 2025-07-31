using GestaoClinica.Entities;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Services.Interfaces;

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
                throw new ArgumentNullException("O nome do serviço é obrigatório");
            }
                await _servicoRepository.AdicionarAsync(servico);
        }

        public Task AtualizarAsync(Servico servico)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAsync(Servico servico)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Servico>> ListarServicoAsync()
        {
            return await _servicoRepository.ListarServicoAsync();
        }
    }
}