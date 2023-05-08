using System.ComponentModel.DataAnnotations;

namespace Razor_Agenda.Modelos
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "El nombre del Contacto es obligatorio")]
        [StringLength(15, ErrorMessage ="{0} el nombre debe de tener entre {2} y {1}", MinimumLength =4)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email del Contacto es obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El telefono del Contacto es obligatorio")]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Creación")]
        public DateTime? FechaCreacion { get; set; }

        //Relacion de 1:M entre Contacto y Categoria. Del lado del Muchos va la relacion
        public int CategoriaId{ get; set; } //id al cual hace referencia que es la pk de categoria
        public Categoria Categoria { get; set; } //Clase Categoria al la cual se relaciona

    }
}
