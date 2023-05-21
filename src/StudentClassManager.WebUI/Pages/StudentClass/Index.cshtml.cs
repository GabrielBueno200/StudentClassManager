using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentClassManager.WebUI.Services.Interfaces;
using StudentClassManager.WebUI.ViewModels;

namespace StudentClassManager.WebUI.Pages.StudentClass
{
    public class GetModel : PageModel
    {
        private readonly IClassService _classService;
        private readonly IStudentClassService _studentClassService;

        public GetModel(IClassService classService, IStudentClassService studentClassService)
        {
            _classService = classService;
            _studentClassService = studentClassService;
        }

        public IList<ClassViewModel> Classes { get; set; } = new List<ClassViewModel>();

        public IList<StudentViewModel> Students { get; set; } = new List<StudentViewModel>();

        public IList<StudentViewModel> StudentsToAssociate { get; set; } = new List<StudentViewModel>();
        
        public int? SelectedClassId { get; set; }
        public int? SelectedStudentId { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Classes = await _classService.FindAllClassesAsync();
            if (SelectedClassId is not null)
            {
                Students = await _studentClassService.GetClassStudentsAsync((int)SelectedClassId);
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int selectedClassId)
        {
            SelectedClassId = selectedClassId;
            Classes = await _classService.FindAllClassesAsync();
            Students = await _studentClassService.GetClassStudentsAsync(selectedClassId);

            StudentsToAssociate = await _studentClassService.GetStudentsToAssociate(selectedClassId);  

            return Page();
        }

        public async Task<IActionResult> OnPostDelete(int studentId, int classId)
        {
            await _studentClassService.RemoveStudentFromClassAsync(studentId, classId);

            TempData["SuccessMessage"] = "Associação inativada com sucesso";

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAssociate(StudentClassViewModel studentClass)
        {
            await _studentClassService.AssociateStudentWithClassAsync(studentClass.StudentId, studentClass.ClassId);
            
            TempData["SuccessMessage"] = "Aluno associado com sucesso";

            return RedirectToPage();
        }
    }
}
