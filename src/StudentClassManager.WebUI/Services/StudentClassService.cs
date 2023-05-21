using StudentClassManager.WebUI.Services.Interfaces;
using StudentClassManager.WebUI.ViewModels;

namespace StudentClassManager.WebUI.Services;

public class StudentClassService : IStudentClassService
{
    private const string BaseUrl = "api/StudentClass";

    private readonly HttpClient _client;

    public StudentClassService(HttpClient client)
    {
        _client = client;
    }

    public async Task AssociateStudentWithClassAsync(int studentId, int classId)
    {
       await _client.PostAsJsonAsync($"{BaseUrl}/associate", new { studentId, classId });
    }

    public async Task<IList<StudentViewModel>> GetClassStudentsAsync(int classId)
    {
        var response = await _client.GetAsync($"{BaseUrl}/{classId}");
        
        var classStudents = await response.Content.ReadFromJsonAsync<IList<StudentViewModel>>();

        return classStudents!;
    }

    public async Task<IList<StudentViewModel>> GetStudentsToAssociate(int classId)
    {
        var response = await _client.GetAsync($"{BaseUrl}/studentsToAssociate/{classId}");
        var studentsToAssociate = await response.Content.ReadFromJsonAsync<IList<StudentViewModel>>();

        return studentsToAssociate!;
    }

    public async Task RemoveStudentFromClassAsync(int studentId, int classId)
    {
        await _client.DeleteAsync($"{BaseUrl}/{classId}/{studentId}");
    }
}
