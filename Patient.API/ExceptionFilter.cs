using System.Web.Http.Filters;

namespace PatientInfo.API
{
    public class ExceptionFilter : IExceptionFilter
    {
        public bool AllowMultiple => throw new NotImplementedException();
        private readonly ILogger<ExceptionFilter> _logger;
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }
        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
