namespace DesafioMuralis.Domain.Models
{
    public class Endereco
    {
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
    }
}
