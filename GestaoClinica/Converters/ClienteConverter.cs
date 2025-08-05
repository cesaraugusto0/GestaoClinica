using GestaoClinica.Entities;
using GestaoClinica.ViewModel;

namespace GestaoClinica.Converters;

public class ClienteConverter
{
    public static Cliente ToEntity(ClienteViewModel clienteViewModel)
    {
        var cliente = new Cliente
        {
            IdCliente = clienteViewModel.IdCliente,
            Nome = clienteViewModel.Nome,
            CPF = clienteViewModel.CPF,
            DataNascimento = clienteViewModel.DataNascimento,
            Telefone = clienteViewModel.Telefone,
            Email = clienteViewModel.Email,
            Observacoes = clienteViewModel.Observacoes,
            Ativo = clienteViewModel.Ativo,
            EnderecoId = clienteViewModel.EnderecoId
        };

        // Se houver endereço no ViewModel, cria o objeto Endereco
        if (clienteViewModel.Endereco != null)
        {
            cliente.Endereco = new Endereco
            {
                Logradouro = clienteViewModel.Endereco.Logradouro,
                Numero = clienteViewModel.Endereco.Numero,
                Complemento = clienteViewModel.Endereco.Complemento,
                Cidade = clienteViewModel.Endereco.Cidade,
                Uf = clienteViewModel.Endereco.Uf,
                Cep = clienteViewModel.Endereco.Cep
            };
        }

        return cliente;
    }
    
    public static ClienteViewModel ToViewModel(Cliente cliente)
    {
        return new ClienteViewModel
        {
            IdCliente = cliente.IdCliente,
            Nome = cliente.Nome,
            CPF = cliente.CPF,
            DataNascimento = cliente.DataNascimento,
            Telefone = cliente.Telefone,
            Email = cliente.Email,
            Observacoes = cliente.Observacoes,
            Ativo = cliente.Ativo,
            EnderecoId = cliente.EnderecoId,
            Endereco = cliente.Endereco != null ? new EnderecoViewModel
            {
                Logradouro = cliente.Endereco.Logradouro,
                Numero = cliente.Endereco.Numero,
                Complemento = cliente.Endereco.Complemento,
                Cidade = cliente.Endereco.Cidade,
                Uf = cliente.Endereco.Uf,
                Cep = cliente.Endereco.Cep
            } : null
        };
    }
}