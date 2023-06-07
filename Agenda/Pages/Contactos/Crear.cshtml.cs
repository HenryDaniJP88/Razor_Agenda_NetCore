using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Agenda.Datos;
using Razor_Agenda.Modelos.ViewModels;

namespace Razor_Agenda.Pages.Contactos
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CrearModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CrearContactoVM ContactoVm { get; set; }
        public async Task<IActionResult> OnGet()
        {
            //Esto me va a servir para acceder a la Lista de Contacto y a la Categoria
            //Estos datos vienen del ViewModel "CrearContactoVM"
            ContactoVm = new CrearContactoVM()
            {
                ListaCategorias = await _context.Categoria.ToListAsync(),
                Contacto = new Modelos.Contacto()
            };

            return Page();
        }

        //para enviar datos al Server
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _context.Contacto.AddAsync(ContactoVm.Contacto); //enviamos los datos del Contacto de Forma asincorna
                await _context.SaveChangesAsync();//guardamos los cambios
                return RedirectToPage("Index"); //Redireccionamos al index de esta pagina de Contacto

            }
            else
            {
                return Page(); //retornamos esta misma pagina 
            }
        }
    }
}
