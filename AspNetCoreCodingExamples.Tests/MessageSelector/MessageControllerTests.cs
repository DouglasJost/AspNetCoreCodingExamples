using AspNetCoreCodingExamples.API.Controllers;
using AspNetCoreCodingExamples.Domain.MessageSelector.DTOs;
using AspNetCoreCodingExamples.Domain.MessageSelector.Interfaces;
using AspNetCoreCodingExamples.Domain.MessageSelector.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AspNetCoreCodingExamples.Tests.MessageSelector
{
    public class MessageControllerTests
    {
        private readonly Mock<IMessageServiceFactory> _factoryMock;
        private readonly MessageController _controller;

        public MessageControllerTests()
        {
            _factoryMock = new Mock<IMessageServiceFactory>();
            _controller = new MessageController(_factoryMock.Object);
        }

        [Fact]
        public void SendMessage_Email_Should_Return_Success_Response()
        {
            var request = new MessageRequestDto { Type = "Email", Message = "Hello Email" };
            var emailService = new EmailService();

            _factoryMock.Setup(f => f.GetService("Email")).Returns(emailService);

            var result = _controller.SendMessage(request);

            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult!.Value.Should().Be("Message sent successfully via Email");
        }

        [Fact]
        public void SendMessage_Sms_Should_Return_Success_Response()
        {
            var request = new MessageRequestDto { Type = "Sms", Message = "Hello Sms" };
            var smsService = new SmsService();

            _factoryMock.Setup(f => f.GetService("Sms")).Returns(smsService);

            var result = _controller.SendMessage(request);

            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult!.Value.Should().Be("Message sent successfully via Sms");
        }

        [Fact]
        public void SendMessage_InvalidType_Should_Throw_Exception()
        {
            var request = new MessageRequestDto { Type = "Invalid", Message = "Hello Unknown" };
            _factoryMock.Setup(f => f.GetService("Invalid")).Throws(new ArgumentException("Unknown message type"));

            Action act = () => _controller.SendMessage(request);

            act.Should().Throw<ArgumentException>().WithMessage("Unknown message type");
        }
    }
}
