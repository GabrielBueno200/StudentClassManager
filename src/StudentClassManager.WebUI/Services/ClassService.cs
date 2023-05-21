using StudentClassManager.WebUI.Services.Interfaces;
using StudentClassManager.WebUI.ViewModels;
using System.Text.Json;

namespace StudentClassManager.WebUI.Services;

public class ClassService : IClassService
{
    private const string BaseUrl = "api/Class";

    private readonly HttpClient _client;

    public ClassService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<ClassViewModel>> FindAllClassesAsync()
    {
        var response = await _client.GetAsync(BaseUrl);

        var existingClasses = await response.Content.ReadFromJsonAsync<IEnumerable<ClassViewModel>>();

        return existingClasses!;
    }

    public async Task<ClassViewModel> GetClassByIdAsync(int id)
    {
        var response = await _client.GetAsync($"{BaseUrl}/{id}");
        var existingClass = await response.Content.ReadFromJsonAsync<ClassViewModel>();

        return existingClass!;
    }

    public async Task<ClassViewModel> CreateClassAsync(ClassViewModel classToCreate)
    {
        var response = await _client.PostAsJsonAsync(BaseUrl, classToCreate);
        var createdClass = await response.Content.ReadFromJsonAsync<ClassViewModel>();

        return createdClass!;
    }

    public async Task UpdateClassAsync(ClassViewModel classToUpdate)
    {
        await _client.PutAsJsonAsync(BaseUrl, classToUpdate);
    }

    public async Task DeleteClassAsync(int classId)
    {
        await _client.DeleteAsync($"{BaseUrl}/{classId}");
    }
}