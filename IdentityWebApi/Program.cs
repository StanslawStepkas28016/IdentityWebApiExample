using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Add DbContext
    builder.Services.AddDbContext<AppDbContext>
        (options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb")));

    // Add identity
    builder.Services
        .AddIdentityApiEndpoints<AppUser>()
        .AddEntityFrameworkStores<AppDbContext>();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapIdentityApi<AppUser>();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}