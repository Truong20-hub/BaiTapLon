using BLL.InterFace;
using BLL_;
using DAL;
using DAL_;
using DAL_.helper;
using shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<IBangDiem, BangDiemDAL>();
builder.Services.AddTransient<IBangDiemBLL, BangDiemBLL>();
builder.Services.AddTransient<IDangKyHocPhanDAL, DangLyHocPhanDAL>();
builder.Services.AddTransient<IDangKyHocPhanBLL, DangKyHocPhanBLL>();
builder.Services.AddTransient<IDauDiemDAL, DauDiemDAL>();
builder.Services.AddTransient<IDauDiemBLL, DauDiemBLL>();
builder.Services.AddTransient<IDiemDanhDAL, DiemDanhDAL>();
builder.Services.AddTransient<IDiemDanhBLL, DiemDanhBLL>();
builder.Services.AddTransient<ILichHocDAL, LichHocDAL>();
builder.Services.AddTransient<ILichHocBLL, LichHocBLL>();
builder.Services.AddTransient<ILichThiDAL, LichThiDAL>();
builder.Services.AddTransient<ILichThiBLL, LichThiBLL>();
builder.Services.AddTransient<IMonHocDAL, MonHocDAL>();
builder.Services.AddTransient<IMonHocBLL, MonHocBLL>();
builder.Services.AddTransient<IPhongHocDAL, PhongHocDAL>();
builder.Services.AddTransient<IPhongHocBLL, PhongHocBLL>();
builder.Services.AddTransient<IChiTietBangDiemDAL, ChiTietBangDiemDAL>();
builder.Services.AddTransient<IChiTietBangDiemBLL, ChiTietBangDiemBLLL>(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<RestricAcessMiddleware>();
app.MapControllers();

app.Run();
