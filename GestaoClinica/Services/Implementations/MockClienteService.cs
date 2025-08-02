using GestaoClinica.Services.Interfaces;
using GestaoClinica.ViewModel;
using System.Collections.Concurrent;

namespace GestaoClinica.Services.Implementations
{
    public class MockClienteService : IClienteService
    {
        // Usando ConcurrentDictionary para thread safety
        private readonly ConcurrentDictionary<int, ClienteViewModel> _clientes;
        private int _nextId = 1;

        public MockClienteService()
        {
            _clientes = new ConcurrentDictionary<int, ClienteViewModel>();
            SeedData();
        }

        private void SeedData()
        {
            // Dados de exemplo realistas para testes
            var clientesSeed = new List<ClienteViewModel>
            {
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "João Silva",
                    CPF = "123.456.789-00",
                    DataNascimento = new DateTime(1985, 5, 15),
                    Telefone = "(11) 99999-9999",
                    Email = "joao.silva@email.com",
                    Observacoes = "Paciente com histórico de alergias",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Rua das Flores",
                        Numero = "123",
                        Complemento = "Apto 101",
                        Cidade = "São Paulo",
                        Uf = "SP",
                        Cep = "01001-000"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Maria Santos",
                    CPF = "987.654.321-00",
                    DataNascimento = new DateTime(1990, 8, 20),
                    Telefone = "(21) 88888-8888",
                    Email = "maria.santos@email.com",
                    Observacoes = "Primeira consulta",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Avenida Paulista",
                        Numero = "1000",
                        Complemento = "Sala 501",
                        Cidade = "São Paulo",
                        Uf = "SP",
                        Cep = "01310-100"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Carlos Oliveira",
                    CPF = "456.789.123-00",
                    DataNascimento = new DateTime(1975, 12, 10),
                    Telefone = "(31) 77777-7777",
                    Email = "carlos.oliveira@email.com",
                    Observacoes = "Paciente frequente",
                    Ativo = false,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Rua dos Andradas",
                        Numero = "500",
                        Complemento = "",
                        Cidade = "Belo Horizonte",
                        Uf = "MG",
                        Cep = "30120-050"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Ana Costa",
                    CPF = "321.654.987-00",
                    DataNascimento = new DateTime(1988, 3, 8),
                    Telefone = "(51) 66666-6666",
                    Email = "ana.costa@email.com",
                    Observacoes = "Consulta de rotina",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Rua da Praia",
                        Numero = "250",
                        Complemento = "Casa 2",
                        Cidade = "Porto Alegre",
                        Uf = "RS",
                        Cep = "90010-100"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Pedro Almeida",
                    CPF = "789.123.456-00",
                    DataNascimento = new DateTime(1995, 11, 30),
                    Telefone = "(81) 55555-5555",
                    Email = "pedro.almeida@email.com",
                    Observacoes = "Retorno pós-cirúrgico",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Av. Brasil",
                        Numero = "1500",
                        Complemento = "Bloco B",
                        Cidade = "Recife",
                        Uf = "PE",
                        Cep = "50050-100"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Fernanda Rodrigues",
                    CPF = "159.753.486-00",
                    DataNascimento = new DateTime(1982, 7, 22),
                    Telefone = "(41) 44444-4444",
                    Email = "fernanda.rodrigues@email.com",
                    Observacoes = "Gestante - acompanhamento pré-natal",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Rua XV de Novembro",
                        Numero = "800",
                        Complemento = "Apto 302",
                        Cidade = "Curitiba",
                        Uf = "PR",
                        Cep = "80010-010"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Roberto Ferreira",
                    CPF = "357.951.246-00",
                    DataNascimento = new DateTime(1970, 2, 14),
                    Telefone = "(61) 33333-3333",
                    Email = "roberto.ferreira@email.com",
                    Observacoes = "Diabético - controle mensal",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "SBN Quadra 2",
                        Numero = "100",
                        Complemento = "Edifício Central",
                        Cidade = "Brasília",
                        Uf = "DF",
                        Cep = "70020-020"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Juliana Mendes",
                    CPF = "258.369.147-00",
                    DataNascimento = new DateTime(1993, 9, 5),
                    Telefone = "(85) 22222-2222",
                    Email = "juliana.mendes@email.com",
                    Observacoes = "Consulta dermatológica",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Av. Beira Mar",
                        Numero = "2000",
                        Complemento = "Loja 15",
                        Cidade = "Fortaleza",
                        Uf = "CE",
                        Cep = "60020-010"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Marcos Andrade",
                    CPF = "147.258.369-00",
                    DataNascimento = new DateTime(1965, 11, 18),
                    Telefone = "(92) 11111-1111",
                    Email = "marcos.andrade@email.com",
                    Observacoes = "Hipertenso - acompanhamento trimestral",
                    Ativo = false,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Rua 7 de Setembro",
                        Numero = "300",
                        Complemento = "",
                        Cidade = "Manaus",
                        Uf = "AM",
                        Cep = "69010-100"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Patrícia Lima",
                    CPF = "369.258.147-00",
                    DataNascimento = new DateTime(1987, 4, 30),
                    Telefone = "(62) 98765-4321",
                    Email = "patricia.lima@email.com",
                    Observacoes = "Consulta ginecológica",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Av. Goiás",
                        Numero = "500",
                        Complemento = "Sala 1001",
                        Cidade = "Goiânia",
                        Uf = "GO",
                        Cep = "74010-010"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Ricardo Souza",
                    CPF = "852.741.963-00",
                    DataNascimento = new DateTime(1991, 1, 25),
                    Telefone = "(83) 91234-5678",
                    Email = "ricardo.souza@email.com",
                    Observacoes = "Atleta - avaliação física",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Rua da Paz",
                        Numero = "150",
                        Complemento = "Casa",
                        Cidade = "João Pessoa",
                        Uf = "PB",
                        Cep = "58010-100"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Camila Ribeiro",
                    CPF = "741.852.963-00",
                    DataNascimento = new DateTime(1984, 6, 12),
                    Telefone = "(86) 98765-1234",
                    Email = "camila.ribeiro@email.com",
                    Observacoes = "Consulta pediátrica - acompanhante",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Av. Frei Serafim",
                        Numero = "800",
                        Complemento = "Apto 505",
                        Cidade = "Teresina",
                        Uf = "PI",
                        Cep = "64001-010"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Alexandre Cardoso",
                    CPF = "963.852.741-00",
                    DataNascimento = new DateTime(1978, 3, 8),
                    Telefone = "(91) 91234-9876",
                    Email = "alexandre.cardoso@email.com",
                    Observacoes = "Fumante - programa de cessação",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Av. Nazaré",
                        Numero = "1200",
                        Complemento = "Bloco C",
                        Cidade = "Belém",
                        Uf = "PA",
                        Cep = "66010-100"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Beatriz Martins",
                    CPF = "159.357.486-00",
                    DataNascimento = new DateTime(1996, 10, 15),
                    Telefone = "(67) 99876-5432",
                    Email = "beatriz.martins@email.com",
                    Observacoes = "Estudante - vacinação",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Rua Treze de Maio",
                        Numero = "400",
                        Complemento = "",
                        Cidade = "Campo Grande",
                        Uf = "MS",
                        Cep = "79010-100"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Gustavo Pereira",
                    CPF = "357.159.246-00",
                    DataNascimento = new DateTime(1973, 12, 3),
                    Telefone = "(69) 91234-4321",
                    Email = "gustavo.pereira@email.com",
                    Observacoes = "Aposentado - check-up anual",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Av. Sete de Setembro",
                        Numero = "600",
                        Complemento = "Sala 201",
                        Cidade = "Porto Velho",
                        Uf = "RO",
                        Cep = "76801-010"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Larissa Alves",
                    CPF = "258.147.369-00",
                    DataNascimento = new DateTime(1989, 8, 27),
                    Telefone = "(96) 98765-6789",
                    Email = "larissa.alves@email.com",
                    Observacoes = "Consulta oftalmológica",
                    Ativo = false,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Av. Getúlio Vargas",
                        Numero = "250",
                        Complemento = "Loja B",
                        Cidade = "Boa Vista",
                        Uf = "RR",
                        Cep = "69301-100"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Thiago Nunes",
                    CPF = "147.369.258-00",
                    DataNascimento = new DateTime(1980, 5, 9),
                    Telefone = "(95) 91234-5432",
                    Email = "thiago.nunes@email.com",
                    Observacoes = "Motorista - exame admissional",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Rua São Sebastião",
                        Numero = "180",
                        Complemento = "Casa 3",
                        Cidade = "Rio Branco",
                        Uf = "AC",
                        Cep = "69901-100"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Vanessa Correia",
                    CPF = "369.147.258-00",
                    DataNascimento = new DateTime(1994, 11, 19),
                    Telefone = "(63) 99876-1234",
                    Email = "vanessa.correia@email.com",
                    Observacoes = "Consulta nutricional",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Av. Teotônio Segurado",
                        Numero = "1000",
                        Complemento = "Apto 701",
                        Cidade = "Palmas",
                        Uf = "TO",
                        Cep = "77010-100"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Diego Barbosa",
                    CPF = "852.963.741-00",
                    DataNascimento = new DateTime(1976, 2, 14),
                    Telefone = "(89) 91234-8765",
                    Email = "diego.barbosa@email.com",
                    Observacoes = "Trabalhador rural - exame periódico",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Rua Floriano Peixoto",
                        Numero = "320",
                        Complemento = "",
                        Cidade = "Teresina",
                        Uf = "PI",
                        Cep = "64001-020"
                    }
                },
                new ClienteViewModel
                {
                    IdCliente = _nextId++,
                    Nome = "Isabela Freitas",
                    CPF = "741.963.852-00",
                    DataNascimento = new DateTime(1992, 7, 22),
                    Telefone = "(98) 98765-9876",
                    Email = "isabela.freitas@email.com",
                    Observacoes = "Consulta psicológica",
                    Ativo = true,
                    Endereco = new EnderecoViewModel
                    {
                        Logradouro = "Av. Daniel de La Touche",
                        Numero = "500",
                        Complemento = "Sala 305",
                        Cidade = "São Luís",
                        Uf = "MA",
                        Cep = "65010-100"
                    }
                }
            };

            foreach (var cliente in clientesSeed)
            {
                _clientes.TryAdd(cliente.IdCliente, cliente);
            }
        }

        public async Task AdicionarAsync(ClienteViewModel clienteViewModel)
        {
            await Task.Delay(100); // Simula latência de rede

            // Validação
            if (string.IsNullOrEmpty(clienteViewModel.Nome))
            {
                throw new ArgumentException("O nome é obrigatório!");
            }

            // Define o ID e datas
            clienteViewModel.IdCliente = _nextId++;
            clienteViewModel.Ativo = true;

            // Adiciona ao dicionário
            _clientes.TryAdd(clienteViewModel.IdCliente, clienteViewModel);
        }

        public async Task AtualizarAsync(ClienteViewModel clienteViewModel)
        {
            await Task.Delay(100); // Simula latência de rede

            if (_clientes.TryGetValue(clienteViewModel.IdCliente, out var existingCliente))
            {
                // Atualiza as propriedades mantendo o ID e as datas
                clienteViewModel.IdCliente = existingCliente.IdCliente;

                // Atualiza no dicionário
                _clientes[clienteViewModel.IdCliente] = clienteViewModel;
            }
            else
            {
                throw new KeyNotFoundException($"Cliente com ID {clienteViewModel.IdCliente} não encontrado.");
            }
        }

        public async Task ExcluirAsync(int id)
        {
            await Task.Delay(50); // Simula latência de rede
            _clientes.TryRemove(id, out _);
        }

        public async Task<IEnumerable<ClienteViewModel>> ListarClienteAsync()
        {
            await Task.Delay(150); // Simula latência de rede
            return _clientes.Values.ToList();
        }

        public async Task<ClienteViewModel?> ObterClientePorIdAsync(int id)
        {
            await Task.Delay(50); // Simula latência de rede

            if (_clientes.TryGetValue(id, out var cliente))
            {
                return cliente;
            }

            return null;
        }

        public async Task<IEnumerable<ClienteViewModel>> ProcurarClientesAsync(string pesquisa)
        {
            await Task.Delay(100); // Simula latência de rede

            if (string.IsNullOrWhiteSpace(pesquisa))
                return await ListarClienteAsync();

            pesquisa = pesquisa.ToLower();
            var clientes = _clientes.Values.Where(c =>
                c.Nome.ToLower().Contains(pesquisa) ||
                c.CPF.Contains(pesquisa) ||
                (c.Email?.ToLower().Contains(pesquisa) ?? false) ||
                (c.Telefone?.Contains(pesquisa) ?? false)
            );

            return clientes.ToList();
        }
    }
}