
using WebAPI.Interfaces;
using WebAPI.Services;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            const string COSR_POLICY_NAME = "myCORS";
            builder.Services.AddCors(cors =>
            {
                cors.AddPolicy(COSR_POLICY_NAME, policy =>
                    policy.WithOrigins("http://localhost:4112")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            builder.Services.AddScoped<GetDataInterface, GetDataService>();
            builder.Services.AddScoped<FormSubmitInterface, GetDataService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseCors(COSR_POLICY_NAME);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
