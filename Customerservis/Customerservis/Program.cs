var builder = WebApplication.CreateBuilder(args);

// Ini WAJIB untuk MapControllers bisa jalan
builder.Services.AddControllers();

// Tambahan jika pakai Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Ini boleh tetap
app.UseAuthorization();

// Ini penting untuk menjalankan controller
app.MapControllers();

app.Run();
