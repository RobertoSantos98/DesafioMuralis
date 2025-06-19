namespace DesafioMuralis.Domain.DTOs
{
    public class ClienteDTO
    {
            public int Id { get; set; }
            public string Nome { get; set; }
            public DateOnly DataCadastro { get; set; }
            public EnderecoDTO Endereco { get; set; }
            public List<ContatoDTO> Contatos { get; set; }

    }
}
