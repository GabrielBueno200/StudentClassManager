using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentClassManager.WebUI.Services.Interfaces;
using StudentClassManager.WebUI.ViewModels;

namespace StudentClassManager.WebUI.Pages.Class
{
    public class CreateModel : PageModel
    {
        private readonly IClassService _service;
        public CreateModel(IClassService service)
        {
            _service = service;
        }

        [BindProperty]
        public ClassViewModel Class { get; set; }
        

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.CreateClassAsync(Class);

            TempData["SuccessMessage"] = "Turma atualizada com sucesso";

            return RedirectToPage("Index");
        }
    }
}