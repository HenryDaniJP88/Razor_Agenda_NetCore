using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Agenda.Datos;
using Razor_Agenda.Modelos;

namespace Razor_Agenda.Pages.Categorias
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CrearModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }
        public void OnGet()
        {
        }

        //para enviar datos al Server
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _context.Categoria.AddAsync(Categoria); //enviamos los datos de Categoria de Forma asincorna
                await _context.SaveChangesAsync();//guardamos los cambios
                return RedirectToPage("Index"); //Redireccionamos al index de esta pagina de catagorias

            }
            else
            {
              return Page(); //retornamos esta misma pagina 
            }
        }
    }
}
