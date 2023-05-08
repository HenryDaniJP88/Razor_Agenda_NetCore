using System.ComponentModel.DataAnnotations;

namespace Razor_Agenda.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El Nombre de la Categoria es obligatorio")]
        [StringLength(15, ErrorMessage ="{0} el nombre debe tener entre {2} y {1}", MinimumLength = 4)]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Creación")]
        public DateTime? FechaCreacion { get; set; }

    }
}
