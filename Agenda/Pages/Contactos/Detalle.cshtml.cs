using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Agenda.Datos;
using Razor_Agenda.Modelos;

namespace Razor_Agenda.Pages.Contactos
{
    public class DetalleModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        

        public DetalleModel(ApplicationDbContext contexto)
        {
         _context = contexto;
        }

        [BindProperty]
        public Contacto Contacto { get; set; }

        public async void OnGet(int id)
        {
            //A traves del Id obtenemos que obtibimos en el detallet, vamos y buscamos el registro de la BD
            Contacto = await _context.Contacto
                             .Where(c=> c.Id == id)
                             .Include(c=> c.Categoria)
                             .FirstOrDefaultAsync();
        }

    }
}
