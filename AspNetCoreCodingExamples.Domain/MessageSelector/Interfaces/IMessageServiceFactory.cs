namespace AspNetCoreCodingExamples.Domain.MessageSelector.Interfaces
{
    public interface IMessageServiceFactory
    {
        IMessageService GetService(string type);
    }
}
