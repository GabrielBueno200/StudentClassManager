using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentClassManager.WebUI.Services.Interfaces;
using StudentClassManager.WebUI.ViewModels;

namespace StudentClassManager.WebUI.Pages.Student
{
    public class UpdateModel : PageModel
    {
        private readonly IStudentService _service;
        public UpdateModel(IStudentService service)
        {
            _service = service;
        }

        [BindProperty]
        public StudentViewModel Student { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Student = await _service.GetStudentByIdAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPost(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.UpdateStudentAsync(student);

            return Page();
        }
    }
}