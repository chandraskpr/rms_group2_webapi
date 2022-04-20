using Microsoft.EntityFrameworkCore;
using rms_web_api_group2.repository;
using rms_web_api_group2.repository.Interface;
using rms_web_api_group2.RMSdb;
using Microsoft.EntityFrameworkCore.Proxies;
using rms_web_api_group2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.AddLog4Net(new Log4NetProviderOptions("log4net.config"));

var connectionString = builder.Configuration.GetConnectionString("RMSdbConnection");
builder.Services.AddDbContext<RMSContext>(options =>
    options.UseLazyLoadingProxies()
    .UseSqlServer(connectionString)
 );

builder.Services.AddDbContext<RMSContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IResumeRepository, ResumeRepository>();
builder.Services.AddTransient<IRoleMaster, RoleMasterRepository>();
builder.Services.AddTransient<IDesignationMaster, DesignationMasterRepository>();
builder.Services.AddTransient<IProjectMaster, ProjectMasterRepository>();
builder.Services.AddTransient<ITechStackMaster, TechStackMasterRepository>();

builder.Services.AddTransient<ITechStackValue, TechStackValueRepository>();
builder.Services.AddCors();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseCors(options =>
    options.WithOrigins("http://localhost:3001")
    .AllowAnyHeader()
    .AllowAnyMethod()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<GlobalErrorMiddleware>();
app.MapControllers();

app.Run();
