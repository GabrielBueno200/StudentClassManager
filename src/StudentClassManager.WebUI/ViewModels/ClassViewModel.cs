using System.ComponentModel.DataAnnotations;
using StudentClassManager.WebUI.Attributes;

namespace StudentClassManager.WebUI.ViewModels;

public class ClassViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo Turma é obrigatório")]
    public string ClassName { get; set; }
    
    [Required(ErrorMessage = "O campo Ano é obrigatório")]
    [YearValidationAttribute]
    public int? Year { get; set; }
}