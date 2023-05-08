using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Agenda.Datos;
using Razor_Agenda.Modelos;

namespace Razor_Agenda.Pages.Contactos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        

        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        //Aca vamos a almacenar la lista de contactos
        public IEnumerable<Contacto> Contactos{ get; set; }

        /*el m�todo "OnGet" se utiliza para inicializar los datos que se mostrar�n en la p�gina Razor y
         * para manejar la l�gica necesaria para mostrar la p�gina*/
        public async Task OnGet()
        {
            Contactos = await _contexto.Contacto.Include(c => c.Categoria).ToListAsync();
        }
    }
}
