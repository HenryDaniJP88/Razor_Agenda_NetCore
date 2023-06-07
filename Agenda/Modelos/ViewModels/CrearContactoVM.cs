namespace Razor_Agenda.Modelos.ViewModels
{
    public class CrearContactoVM
    {
      //Este View Models va a tener la lista de categorias y el Moldelo del Contacto
        public List<Categoria> ListaCategorias { get; set; }

        public Contacto Contacto { get; set; }

    }
}
