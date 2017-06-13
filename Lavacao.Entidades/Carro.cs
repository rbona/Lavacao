using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lavacao.Entidades
{
    [Table(name: "Carros")]
    public class Carro
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarroID { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
    }
}
