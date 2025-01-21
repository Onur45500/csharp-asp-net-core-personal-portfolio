using csharp_asp_net_core_personal_portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<ExperienceService>();
builder.Services.AddScoped<EntrepreneurshipService>();
builder.Services.AddScoped<EducationService>();
builder.Services.AddScoped<SkillsService>();
builder.Services.AddScoped<ProjectService>();
//builder.Services.AddScoped<GitHubService>();

// Ensure the application listens to appropriate URLs and ports
// Note: Don't force HTTPS here if Apache is handling SSL termination
builder.WebHost.UseUrls("http://0.0.0.0:5293");

var app = builder.Build();

// Serve static files (CSS, JS, images, etc.)
app.UseStaticFiles();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    // Use exception handling middleware for production
    app.UseExceptionHandler("/Error");

    // Optional: Enable HSTS only if SSL termination happens at app level
    // app.UseHsts();
}

// Conditionally enable HTTPS redirection only if SSL is handled by the app
// Since SSL is handled at the Apache level (with certs in Apache), HTTPS redirection is disabled in production.
// Uncomment the following line if you want ASP.NET Core to handle SSL termination directly.
if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection(); // Enable only in non-production environments or if the app handles SSL termination
}

// Ensure the app routes correctly
app.UseRouting();

// Optional: Add any authentication/authorization middleware (if applicable)
app.UseAuthorization();

// Ensure Razor Pages and static assets are correctly mapped and served
app.MapRazorPages();

// Start the application
app.Run();
