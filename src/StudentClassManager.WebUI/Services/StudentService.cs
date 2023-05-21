using StudentClassManager.WebUI.Services.Interfaces;
using StudentClassManager.WebUI.ViewModels;

namespace StudentClassManager.WebUI.Services;

public class StudentService : IStudentService
{
    private const string BaseUrl =  "api/Student";

    private readonly HttpClient _client;

    public StudentService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<StudentViewModel>> FindAllStudentsAsync()
    {
        var response = await _client.GetAsync(BaseUrl);

        var students = await response.Content.ReadFromJsonAsync<IEnumerable<StudentViewModel>>();

        return students!;
    }

    public async Task<StudentViewModel> GetStudentByIdAsync(int id)
    {
        var response = await _client.GetAsync($"{BaseUrl}/{id}");
        var student = await response.Content.ReadFromJsonAsync<StudentViewModel>();

        return student!;
    }

    public async Task<StudentViewModel> CreateStudentAsync(StudentViewModel student)
    {
        var response = await _client.PostAsJsonAsync(BaseUrl, student);
        var createdStudent = await response.Content.ReadFromJsonAsync<StudentViewModel>();

        return createdStudent!;
    }

    public async Task UpdateStudentAsync(StudentViewModel student)
    {
        await _client.PutAsJsonAsync(BaseUrl, student);
    }

    public async Task DeleteStudentAsync(int studentId)
    {
        await _client.DeleteAsync($"{BaseUrl}/{studentId}");
    }
}
