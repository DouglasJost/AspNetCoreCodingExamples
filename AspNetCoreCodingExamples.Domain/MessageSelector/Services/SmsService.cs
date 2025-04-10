using AspNetCoreCodingExamples.Domain.MessageSelector.Interfaces;
using System;

namespace AspNetCoreCodingExamples.Domain.MessageSelector.Services
{
    public class SmsService : IMessageService
    {
        public string SendMessage(string message)
        {
            Console.WriteLine($"Sms: {message}");
            return $"Message sent successfully via Sms";
        }
    }
}
