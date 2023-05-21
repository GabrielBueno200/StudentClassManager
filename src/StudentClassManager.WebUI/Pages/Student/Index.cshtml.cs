using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentClassManager.WebUI.Services.Interfaces;
using StudentClassManager.WebUI.ViewModels;

namespace StudentClassManager.WebUI.Pages.Student
{
    public class GetModel : PageModel
    {
        private readonly IStudentService _service;
        public GetModel(IStudentService service)
        {
            _service = service;
        }

        [BindProperty]
        public IEnumerable<StudentViewModel> Students { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Students = await _service.FindAllStudentsAsync();
            return Page();
        }

        public async Task<IActionResult> OnDelete(int id)
        {
            await _service.DeleteStudentAsync(id);
            return Page();
        }
    }
}