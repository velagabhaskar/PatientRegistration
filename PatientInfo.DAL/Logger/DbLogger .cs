
using Microsoft.Extensions.Logging;
using PatientInfo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInfo.DAL.Logger
{
    public class DbLogger:ILogger
    { 
        private readonly PatientDataContext _dbContext;
    private readonly string _categoryName;

    public DbLogger(PatientDataContext dbContext, string categoryName)
    {
        _dbContext = dbContext;
        _categoryName = categoryName;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        // You can adjust the log level based on your requirements
        return logLevel == LogLevel.Error || logLevel == LogLevel.Critical;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel))
            return;

        var logEntry = new LogEntry
        {
            Timestamp = DateTimeOffset.Now,
            LogLevel = logLevel.ToString(),
            Message = formatter(state, exception),
            Exception = exception?.ToString()
        };

        _dbContext.LogEntries.Add(logEntry);
        _dbContext.SaveChanges();
    }
    }
}
