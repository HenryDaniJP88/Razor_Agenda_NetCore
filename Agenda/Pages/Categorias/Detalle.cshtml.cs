using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Agenda.Datos;
using Razor_Agenda.Modelos;

namespace Razor_Agenda.Pages.Categorias
{
    public class DetalleModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetalleModel(ApplicationDbContext context)
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
       
    }
}
