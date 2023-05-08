using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Agenda.Datos;
using Razor_Agenda.Modelos;

namespace Razor_Agenda.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContext _context; //esto permiten conectarnos a la BD

        public IndexModel(ApplicationDbContext context)
        {
          _context = context;
        }

        //Variable para obtener la Lista de Categorias
        public IEnumerable<Categoria> Categorias { get; set; }
        
        //Al cargar metodo OnGet(). 1  Me tiene que traer la lista de categorias
        //OnGet => Metodo Principal para obtener en esta vista Index.html los datos
        public async Task OnGet()
        {
            Categorias = await _context.Categoria.ToListAsync();
        }
    }
}
