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
        // Mapeamento para os DTOs de resumo
        CreateMap<Cliente, ClienteResumoDTO>();
        CreateMap<Servico, ServicoResumoDTO>();
        CreateMap<Funcionario, FuncionarioResumoDTO>();

        // Mapeamento principal para AgendamentoDTO
        CreateMap<Agendamento, AgendamentoDTO>()
            .ForMember(dest => dest.StatusAgenda, 
                opt => opt.MapFrom(src => src.StatusAgenda.ToString()))
            .ForMember(dest => dest.Cliente, 
                opt => opt.MapFrom(src => src.Cliente))
            .ForMember(dest => dest.Servico, 
                opt => opt.MapFrom(src => src.Servico))
            .ForMember(dest => dest.Funcionario, 
                opt => opt.MapFrom(src => src.Funcionario));
        
        CreateMap<AgendamentoDTO, Agendamento>()
            .ForMember(dest => dest.StatusAgenda, 
                opt => opt.MapFrom(src => Enum.Parse<StatusAgendaEnum>(src.StatusAgenda)));

        // Mapeamento para criação
        CreateMap<AgendamentoCreateDTO, Agendamento>()
            .ForMember(dest => dest.StatusAgenda, 
                opt => opt.MapFrom(src => Enum.Parse<StatusAgendaEnum>(src.StatusAgenda)));

        // Mapeamentos base
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