

using System.ComponentModel.DataAnnotations;

namespace DesafioMuralis.Domain.Models
{
    public class Contato
    {
        public Contato(string tipo, string texto)
        {
            Tipo = tipo ?? throw new ArgumentNullException(nameof(tipo));
            Texto = texto ?? throw new ArgumentNullException(nameof(texto));
        }

        [Key]
        public int Id { get; private set; }
        public string Tipo { get; private set; }
        public string Texto { get; private set; }

    }


}
