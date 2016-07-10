using AutoMapper;
using Golfe.Web.Database;

namespace Golfe.Data.Models.Mappings
{
    public class FactoryGolfMapper
    {
       
       public static IMapper Map(MappingEnum golf)
       {

           MapperConfiguration config = null;

           switch (golf)
           {
               case MappingEnum.Tarefas:
                   config = new MapperConfiguration(cfg =>
                   {
                    cfg.CreateMap<tarefasgerais, Tarefas>()
                    .ForMember(dst => dst.AreaJogo, src => src.MapFrom(item => item.areajogo))
                    .ForMember(dst => dst.Data, src => src.MapFrom(item => item.data))
                    .ForMember(dst => dst.Concluida, src => src.MapFrom(item => item.concluida))
                    .ForMember(dst => dst.Funcionario, src => src.MapFrom(item => item.funcionario))
                    .ForMember(dst => dst.Maquina, src => src.MapFrom(item => item.maquina))
                    .ForMember(dst => dst.Operacao, src => src.MapFrom(item => item.operacao))
                    .ForMember(dst => dst.Id, src => src.MapFrom(item => item.id));
                    cfg.CreateMap<Tarefas, tarefasgerais>()
                           .ForMember(dst => dst.areajogo, src => src.MapFrom(item => item.AreaJogo))
                           .ForMember(dst => dst.data, src => src.MapFrom(item => item.Data))
                           .ForMember(dst => dst.concluida, src => src.MapFrom(item => item.Concluida))
                           .ForMember(dst => dst.funcionario, src => src.MapFrom(item => item.Funcionario))
                           .ForMember(dst => dst.maquina, src => src.MapFrom(item => item.Maquina))
                           .ForMember(dst => dst.operacao, src => src.MapFrom(item => item.Operacao))
                           .ForMember(dst => dst.id, src => src.MapFrom(item => item.Id));
                   });
                   break;
               case MappingEnum.AreaJogo:
                   config = new MapperConfiguration(cfg =>
                   {

                       cfg.CreateMap<areajogo, AreaJogo>()
                           .ForMember(dst => dst.Id, src => src.MapFrom(item => item.id))
                           .ForMember(dst => dst.Area, src => src.MapFrom(item => item.area));

                       cfg.CreateMap<AreaJogo, areajogo>()
                           .ForMember(dst => dst.id, src => src.MapFrom(item => item.Id))
                           .ForMember(dst => dst.area, src => src.MapFrom(item => item.Area));

                   });
                   break;
                case MappingEnum.Funcionarios:
                   config = new MapperConfiguration(cfg =>
                   {

                       cfg.CreateMap<funcionarios, Funcionarios>()
                           .ForMember(dst => dst.Id, src => src.MapFrom(item => item.id))
                           .ForMember(dst => dst.Nome, src => src.MapFrom(item => item.nome))
                           .ForMember(dst => dst.Email, src => src.MapFrom(item => item.email))
                           .ReverseMap();

                   });
                   break;
                case MappingEnum.Maquinas:
                   config = new MapperConfiguration(cfg =>
                   {

                       cfg.CreateMap<maquina, Maquinas>()
                           .ForMember(dst => dst.Id, src => src.MapFrom(item => item.id))
                           .ForMember(dst => dst.Nome, src => src.MapFrom(item => item.nome))
                           .ReverseMap();

                   });
                   break;
                 case MappingEnum.Operacao:
                   config = new MapperConfiguration(cfg =>
                   {

                       cfg.CreateMap<operacao, Operacao>()
                           .ForMember(dst => dst.Id, src => src.MapFrom(item => item.id))
                           .ForMember(dst => dst.Nome, src => src.MapFrom(item => item.nome))
                           .ReverseMap();

                   });
                   break;

           }


           if (config == null) return null;
           config.AssertConfigurationIsValid();
           var mapper = config.CreateMapper();
           return mapper;
       }
    }
}
