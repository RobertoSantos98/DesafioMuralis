using DesafioMuralis.Domain.DTOs;

namespace DesafioMuralis.Applications.ViewModel
{
    public class ClienteViewModel
    {
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public List<ContatoDTO> Contatos { get; set; }
    }
}
