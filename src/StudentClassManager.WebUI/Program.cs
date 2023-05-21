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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
