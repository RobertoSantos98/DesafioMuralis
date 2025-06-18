using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioMuralis.Domain.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public List<Contato> Contatos { get; private set; } = new List<Contato>();
        public Endereco Endereco { get; private set; }

    }
}
