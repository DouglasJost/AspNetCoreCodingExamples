using Microsoft.Extensions.Logging;
using System;

namespace AspNetCoreCodingExamples.Domain.Services
{
    public abstract class DomainServiceBase<T>
    {
        protected readonly ILogger<T> Logger;

        protected DomainServiceBase(ILogger<T> logger)
        {
            Logger = logger 
                ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
