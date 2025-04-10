using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;
using AspNetCoreCodingExamples.Domain.DataStructures.Services;
using AspNetCoreCodingExamples.Domain.ParkingLot;
using AspNetCoreCodingExamples.Domain.ParkingLot.Interfaces;
using AspNetCoreCodingExamples.Domain.MessageSelector.Interfaces;
using AspNetCoreCodingExamples.Domain.MessageSelector.Services;

namespace AspNetCoreCodingExamples.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddLogging();

            //
            // AddTransient - Create a new instance every time it is requested
            // AddScoped    - One instance per HTTP request
            // AddSingleton - One instance for the entire app
            //
            builder.Services.AddTransient<IParkingLotSimulation, ParkingLotSimulation>();
            builder.Services.AddScoped<IArrayAlgorithms, ArrayAlgorithms>();
            builder.Services.AddScoped<IDictionaryAlgorithms, DictionaryAlgorithms>();
            builder.Services.AddScoped<ICharStringAlgorithms, CharStringAlgorithms>();
            builder.Services.AddScoped<IStackQueueExamples, StackQueueExamples>();
            builder.Services.AddScoped<IHashSetExamples, HashSetExamples>();

            builder.Services.AddTransient<IMessageServiceFactory, MessageServiceFactory>();
            builder.Services.AddTransient<EmailService>();
            builder.Services.AddTransient<SmsService>();


            builder.Services.AddControllers();
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
            app.MapControllers();


            app.Run();
        }
    }
}
