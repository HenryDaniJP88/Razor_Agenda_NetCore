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

        /*el método "OnGet" se utiliza para inicializar los datos que se mostrarán en la página Razor y
         * para manejar la lógica necesaria para mostrar la página*/
        public async Task OnGet()
        {
            Contactos = await _contexto.Contacto.Include(c => c.Categoria).ToListAsync();
        }
    }
}
