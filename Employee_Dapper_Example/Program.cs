using Employee_Dapper_Example.Data;
using Employee_Dapper_Example.Interface;
using Employee_Dapper_Example.Repository;
using Employee_Dapper_Example.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddScoped<IEmpConnectionFactory,EmpConnectionFactory>();
builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository >();
builder.Services.AddScoped<IDepartmentServices,DepartmentServices >();
builder.Services.AddScoped<IOrdersServices,OrdersServices>();
builder.Services.AddScoped<IOrdersRepository,OrdersRepository>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
