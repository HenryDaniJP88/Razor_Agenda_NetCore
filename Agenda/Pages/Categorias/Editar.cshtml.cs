using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Agenda.Datos;
using Razor_Agenda.Modelos;

namespace Razor_Agenda.Pages.Categorias
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditarModel(ApplicationDbContext context)
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
            if (ModelState.IsValid)
            {
                var CategoriadesdeBaseDatos = await _context.Categoria.FindAsync(Categoria.Id); //Obetenemos los datos de la BD por el ID
                CategoriadesdeBaseDatos.Nombre = Categoria.Nombre; //asignamos el nombre obtenido en la Pantalla Editar
                CategoriadesdeBaseDatos.FechaCreacion = Categoria.FechaCreacion;

                await _context.SaveChangesAsync();

                return RedirectToPage("Index"); //Retorna al Index de Categoria
            }
            else
            {
                return RedirectToPage(); //Nos retorna a esta misma Pagina si no es correcto
            }
            
        }
    }
}
