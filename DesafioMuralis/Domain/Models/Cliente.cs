using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioMuralis.Domain.Models
{
    public class Cliente
    {

        [Key]
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DateOnly DataCadastro { get; private set; } = new DateOnly();
        public List<Contato> Contatos { get; private set; } = new List<Contato>();
        public Endereco Endereco { get; private set; }

        private Cliente() { }

        public Cliente(string nome, List<Contato> contatos, Endereco endereco)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            DataCadastro = DateOnly.FromDateTime(DateTime.Today);
            Contatos = contatos ?? throw new ArgumentNullException(nameof(contatos));
            Endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
        }

        public void AlterarNome(string novoNome)
        {
            Nome = novoNome;
        }

        public void AtualizarContatos(List<Contato> novosContatos)
        {
            Contatos.Clear();
            foreach (var contato in novosContatos)
            {
                Contatos.Add(contato);
            }
        }

        public void AtualizarEndereco(Endereco novoEndereco)
        {
            Endereco = novoEndereco;
        }

    }
}
