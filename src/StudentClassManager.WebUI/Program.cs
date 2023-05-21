using StudentClassManager.WebUI.Services;
using StudentClassManager.WebUI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages().AddSessionStateTempDataProvider();
builder.Services.AddSession();

builder.Services.AddSingleton<HttpClient>(provider =>
{
    var httpClient = new HttpClient();
    httpClient.BaseAddress = new("http://localhost:5220/");
    return httpClient;
});

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IStudentClassService, StudentClassService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
