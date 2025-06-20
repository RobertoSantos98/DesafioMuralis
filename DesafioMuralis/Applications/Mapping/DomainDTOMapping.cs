using AutoMapper;
using DesafioMuralis.Domain.DTOs;
using DesafioMuralis.Domain.Models;

namespace DesafioMuralis.Applications.Mapping
{
    public class DomainDTOMapping : Profile
    {
        public DomainDTOMapping()
        {
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<Cliente, ClienteDTO>();

            CreateMap<EnderecoDTO, Endereco>();
            CreateMap<Endereco, EnderecoDTO>();

            CreateMap<ContatoDTO, Contato>();
            CreateMap<Contato, ContatoDTO>();
        }
    }
}
