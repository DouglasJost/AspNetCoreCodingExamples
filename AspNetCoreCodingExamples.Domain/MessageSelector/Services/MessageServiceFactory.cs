using AspNetCoreCodingExamples.Domain.MessageSelector.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNetCoreCodingExamples.Domain.MessageSelector.Services
{
    public class MessageServiceFactory : IMessageServiceFactory
    {
        private readonly IServiceProvider _provider;

        public MessageServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IMessageService GetService(string type)
        {
            IMessageService selectedMessageService;

            switch(type.ToLower())
            {
                case "email": 
                {
                    selectedMessageService = _provider.GetRequiredService<EmailService>();
                    break;
                }
                case "sms":
                {
                    selectedMessageService = _provider.GetRequiredService<SmsService>();
                    break;
                }
                default: 
                {
                    throw new ArgumentException("Unknown message type");
                }
            }
            return selectedMessageService;
        }
    }
}
