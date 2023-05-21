using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentClassManager.WebUI.Services.Interfaces;
using StudentClassManager.WebUI.ViewModels;

namespace StudentClassManager.WebUI.Pages.Class
{
    public class GetModel : PageModel
    {
        private readonly IClassService _service;
        public GetModel(IClassService service)
        {
            _service = service;
        }

        [BindProperty]
        public IList<ClassViewModel> Classes { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Classes = await _service.FindAllClassesAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _service.DeleteClassAsync(id);
            return RedirectToPage("/Class/Index");
        }
    }
}