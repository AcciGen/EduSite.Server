using Education.Application;
using Education.Application.UseCases.EmailService;
using Education.Domain.Entities.Auth;
using Education.Infrastructure;
using Education.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins",
        builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

builder.Services.AddEducationApplication();
builder.Services.AddEducationINfrastructure(builder.Configuration);

builder.Services.AddScoped<ISendEmailService,SendEmailService>();

builder.Services.AddIdentity<UserModel, IdentityRole>()
               .AddEntityFrameworkStores<EducationDbContext>()
               .AddDefaultTokenProviders();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    }); // Configure NewtonsoftJson options

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors("_myAllowSpecificOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "User", "Teacher" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager =
        scope.ServiceProvider.GetRequiredService<UserManager<UserModel>>();

    string email = "admin@gmail.com";
    string password = "Sardor0618!";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new UserModel()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "Insoniyat",
            FullName = "Brat",
            Country = "Uzbekistan",
            Exp = 1300,
            Rank = 1,
            Email = email,
            Role = "Admin",
            EmailConfirmed = true

        };

        var res = await userManager.CreateAsync(user, password);

        var res1 = await userManager.AddToRoleAsync(user, "Admin");

    }
}

app.MapHub<Hubs>("/yourHubPath");

app.Run();