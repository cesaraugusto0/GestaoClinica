using AutoMapper;
using GestaoClinica.DTO;
using GestaoClinica.Entities;
using GestaoClinica.Entities.Enums;
using GestaoClinica.Entities.GestaoClinica.Entities;

namespace GestaoClinica.Configuration;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Mapeamento existente para AgendamentoDTO
        CreateMap<Agendamento, AgendamentoDTO>()
            .ForMember(dest => dest.StatusAgenda, 
                opt => opt.MapFrom(src => src.StatusAgenda.ToString()));
        
        CreateMap<AgendamentoDTO, Agendamento>()
            .ForMember(dest => dest.StatusAgenda, 
                opt => opt.MapFrom(src => Enum.Parse<StatusAgendaEnum>(src.StatusAgenda)));

        // Adicione este novo mapeamento para AgendamentoCreateDTO
        CreateMap<AgendamentoCreateDTO, Agendamento>()
            .ForMember(dest => dest.StatusAgenda, 
                opt => opt.MapFrom(src => Enum.Parse<StatusAgendaEnum>(src.StatusAgenda))); // Se StatusAgenda for uma string no DTO

        // Mapeamentos existentes...
        CreateMap<Servico, ServicoDTO>().ReverseMap();
        CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
        CreateMap<Pessoa, PessoaDTO>().ReverseMap();
        
        CreateMap<Cliente, ClienteDTO>()
            .IncludeBase<Pessoa, PessoaDTO>()
            .ReverseMap()
            .IncludeBase<PessoaDTO, Pessoa>();

        CreateMap<Endereco, EnderecoDTO>().ReverseMap();
    }
}