using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Agenda.Datos;
using Razor_Agenda.Modelos.ViewModels;

namespace Razor_Agenda.Pages.Contactos
{
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BorrarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CrearContactoVm ContactoVm { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            //Esto me va a servir para acceder a la Lista de Contacto y a la Categoria
            //Estos datos vienen del ViewModel "CrearContactoVM"
            ContactoVm = new CrearContactoVm()
            {
                ListaCategorias = await _context.Categoria.ToListAsync(),
                Contacto = await _context.Contacto.FindAsync(id)
            };

            return Page();
        }

        //hacemos el OnPost para eliminar
        public async Task<IActionResult> OnPost()
        {
            var contacto = await _context.Contacto.FindAsync(ContactoVm.Contacto.Id);

            if (contacto == null)
            {
                return NotFound();
            }

            _context.Contacto.Remove(contacto); //Borramos el contacto en base al id encotrado arriba
            await _context.SaveChangesAsync();
            return RedirectToPage("Index"); //Retorna al Index de Categoria
        }
    }
}
