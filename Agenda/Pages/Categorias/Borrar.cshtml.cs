using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Agenda.Datos;
using Razor_Agenda.Modelos;

namespace Razor_Agenda.Pages.Categorias
{
    public class BorrarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BorrarModel(ApplicationDbContext context)
        {
          _context = context;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }
        
        //Obtenemos el Id de la categoria para mostrarlo en pantalla de Editar, esto debe ser llmado desde el  Front de Editar
        public async void OnGet(int id)
        {
            Categoria = await _context.Categoria.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
           
                //Obtenemos los datos de la BD por el ID
                var CategoriadesdeBaseDatos = await _context.Categoria.FindAsync(Categoria.Id);
                if (CategoriadesdeBaseDatos == null)
                {
                    return NotFound();
                }

                //Borramos la categoria selecccionada
                _context.Categoria.Remove(CategoriadesdeBaseDatos);

                await _context.SaveChangesAsync();  // permite guardar todos los cambios realizados en la base de datos de manera asíncrona

                return RedirectToPage("Index"); //Retorna al Index de Categoria
    
            
        }
    }
}
