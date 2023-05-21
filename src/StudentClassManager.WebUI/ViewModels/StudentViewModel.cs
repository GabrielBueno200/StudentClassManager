using System.ComponentModel.DataAnnotations;
using StudentClassManager.WebUI.Attributes;

namespace StudentClassManager.WebUI.ViewModels;

public class StudentViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório ")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo Usuário é obrigatório ")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "O campo Senha é obrigatório ")]
    [PasswordValidationAttribute(ErrorMessage = "A senha deve ter pelo menos oito caracteres, uma letra maiúscula, um número e um caractere especial.")]
    
    public string Password { get; set; }
}