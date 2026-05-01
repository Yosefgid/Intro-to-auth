using ConferenceManager.Repositories;
using ConferenceManager.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ConferenceManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddScoped<IEventRepo, EventRepo>();
            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<IAttendeeRepo, AttendeeRepo>();
            builder.Services.AddScoped<IAttendeeServices, AttendeeService>();
            builder.Services.AddScoped<ISpeakerRepo, SpeakerRepo>();
            builder.Services.AddScoped<ISpeakerService, SpeakerService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var key = Encoding.UTF8.GetBytes("your-very-secure-secret-which-must-be-quite-long-see-below");

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "Name",
                    ValidateAudience = true,
                    ValidAudience = "AppName",
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    //RoleClaimType = "roles",
                
                };
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}


//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IlRlc3QgVXNlciIsImlhdCI6MTc2NzE5ODA2NywiZXhwIjoxODA0MDY3MjAwLCJpc3MiOiJOYW1lIiwiYXVkIjoiQXBwTmFtZSIsInJvbGVzIjpbXX0.gIXw0ThBCDJWPs8y2DmCpvGiArrqT7C8UYrs4sl8Pjo
