using AspNetCoreCodingExamples.Domain.MessageSelector.Interfaces;
using System;

namespace AspNetCoreCodingExamples.Domain.MessageSelector.Services
{
    public class EmailService : IMessageService
    {
        public string SendMessage(string message)
        {
            Console.WriteLine($"Email: {message}");
            return $"Message sent successfully via Email";
        }
    }
}
