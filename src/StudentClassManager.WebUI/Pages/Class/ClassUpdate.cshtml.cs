using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentClassManager.WebUI.Services.Interfaces;
using StudentClassManager.WebUI.ViewModels;

namespace StudentClassManager.WebUI.Pages.Class
{
    public class UpdateModel : PageModel
    {
        private readonly IClassService _service;
        public UpdateModel(IClassService service)
        {
            _service = service;
        }

        [BindProperty]
        public ClassViewModel Class { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Class = await _service.GetClassByIdAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.UpdateClassAsync(Class);

            TempData["SuccessMessage"] = "Turma cadastrada com sucesso";

            return RedirectToPage("Index");
        }
    }
}