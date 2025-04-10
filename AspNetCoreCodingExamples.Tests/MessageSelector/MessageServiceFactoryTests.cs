using AspNetCoreCodingExamples.Domain.MessageSelector.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreCodingExamples.Tests.MessageSelector
{
    public class MessageServiceFactoryTests
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly MessageServiceFactory _factory;

        public MessageServiceFactoryTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<EmailService>();
            services.AddTransient<SmsService>();
            _serviceProvider = services.BuildServiceProvider();

            _factory = new MessageServiceFactory(_serviceProvider);
        }

        [Theory]
        [InlineData("email", typeof(EmailService))]
        [InlineData("EMAIL", typeof(EmailService))]
        [InlineData("sms", typeof(SmsService))]
        [InlineData("SMS", typeof(SmsService))]
        public void GetService_Should_Return_CorrectServiceInstance(string type, Type expectedType)
        {
            var service = _factory.GetService(type);

            service.Should().BeOfType(expectedType);
        }

        [Fact]
        public void GetService_Should_Throw_WhenTypeIsUnknown()
        {
            Action act = () => _factory.GetService("carrierpigeon");

            act.Should().Throw<ArgumentException>()
                .WithMessage("*Unknown message type*");
        }
    }
}
