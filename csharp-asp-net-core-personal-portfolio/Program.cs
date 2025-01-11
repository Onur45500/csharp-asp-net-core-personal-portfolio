using csharp_asp_net_core_personal_portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<ExperienceService>();
builder.Services.AddScoped<EntrepreneurshipService>();
builder.Services.AddScoped<EducationService>();
builder.Services.AddScoped<SkillsService>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<GitHubService>();

builder.WebHost.UseUrls("http://0.0.0.0:5293");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
