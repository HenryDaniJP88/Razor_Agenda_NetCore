using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Agenda.Datos;
using Razor_Agenda.Modelos.ViewModels;

namespace Razor_Agenda.Pages.Contactos
{
    public class EditarModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public EditarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CrearContactoVM ContactoVm { get; set; }
        
        //el registro que quiero editar lo obtengo por el ID
        public async Task<IActionResult> OnGet(int id)
        {
            //Esto me va a servir para acceder a la Lista de Contacto y a la Categoria
            //Estos datos vienen del ViewModel "CrearContactoVM"
            ContactoVm = new CrearContactoVM()
            {
                ListaCategorias = await _context.Categoria.ToListAsync(),
                Contacto = await _context.Contacto.FindAsync(id)
            };

            return Page();
        }


        //Metodo para editar los datos del contacto y guardar en la base de datos
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var contactoDesdeBaseDatos = await _context.Contacto.FindAsync(ContactoVm.Contacto.Id);
                contactoDesdeBaseDatos.Nombre = ContactoVm.Contacto.Nombre;
                contactoDesdeBaseDatos.Email = ContactoVm.Contacto.Email;
                contactoDesdeBaseDatos.CategoriaId = ContactoVm.Contacto.CategoriaId;
                contactoDesdeBaseDatos.Telefono = ContactoVm.Contacto.Telefono;
                contactoDesdeBaseDatos.FechaCreacion = ContactoVm.Contacto.FechaCreacion;

                //guardamos los cambios en la BD
                await _context.SaveChangesAsync();

                return RedirectToPage("Index"); //Retorna al Index de Contacto
            }
            else
            {
                return RedirectToPage(); //Nos retorna a esta misma Pagina si no es correcto
            }

        }
    }
}
