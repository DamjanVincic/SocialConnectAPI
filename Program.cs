using Microsoft.EntityFrameworkCore;
using SocialConnectAPI.DataAccess;
using SocialConnectAPI.DataAccess.Comments;
using SocialConnectAPI.DataAccess.Posts;
using SocialConnectAPI.DataAccess.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo {
            Title = "SocialConnectAPI",
            Version = "v1"
        }
     );

     var filePath = Path.Combine(System.AppContext.BaseDirectory, "SocialConnectAPI.xml");
     c.IncludeXmlComments(filePath);
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();


builder.Services.AddDbContext<DatabaseContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            .LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
