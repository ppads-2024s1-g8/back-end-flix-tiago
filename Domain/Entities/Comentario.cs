using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Comentario
    {
        public Comentario(string nome, string texto)
        {
            Nome = nome;
            Texto = texto;
        }

        [Key]
        public int Id { get; init; }
        public string Nome { get; set; }
        public string Texto { get; set; }
    }
}
