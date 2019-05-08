using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionAppCSharp
{
    public class Function2
    {
        private readonly DiSampleClass _diSampleClass;

        private readonly string _instanceId;

        public Function2(DiSampleClass diSampleClass)
        {
            _diSampleClass = diSampleClass;
            _instanceId = Guid.NewGuid().ToString();
        }

        [FunctionName("Function2")]
        public void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, 
            ILogger log)
        {
            log.LogInformation($"Instance Id: {_instanceId}");
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            log.LogInformation(_diSampleClass.HelloDi);
        }
    }
}
