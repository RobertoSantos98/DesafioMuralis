namespace DesafioMuralis.Domain.Models
{
    public class Endereco
    {
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }

        public Endereco(string cep, string logradouro, string cidade, string numero, string complemento)
        {
            Cep = cep;
            Logradouro = logradouro;
            Cidade = cidade;
            Numero = numero;
            Complemento = complemento;
        }

    }
}
