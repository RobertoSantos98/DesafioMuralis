using System.Text.Json.Serialization;

namespace DesafioMuralis.Domain.DTOs
{
    public class EnderecoDTO
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }

        [JsonPropertyName("localidade")]
        public string Cidade { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }
}
