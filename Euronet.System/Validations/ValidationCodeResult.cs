using Euronet.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euronet.System.Validations
{
    public class ValidationCodeResult
    {
    }
}
public class ValidationCodeResult : ValidationResult
{
    public int Code { get; set; }

    public Severity Severity { get; set; }

    public ValidationCodeResult(string message)
        : base(GetErrorMessage(message, 400, Severity.Error, null))
    {
        Code = 400;
        Severity = Severity.Error;
    }

    public ValidationCodeResult(string message, int code)
        : base(GetErrorMessage(message, code, Severity.Error, null))
    {
        Code = code;
        Severity = Severity.Error;
    }

    public ValidationCodeResult(string message, Severity severity)
        : base(GetErrorMessage(message, 400, severity, null))
    {
        Code = 400;
        Severity = severity;
        
    }

    public ValidationCodeResult(string message, int code, Severity severity)
        : base(GetErrorMessage(message, code, severity, null))
    {
        Code = code;
        Severity = severity;
    }

    public ValidationCodeResult(string message, int code, Severity severity, string source)
        : base(GetErrorMessage(message, code, severity, source))
    {
        Code = code;
        Severity = severity;
    }

    private static string GetErrorMessage(string message, int code, Severity severity, string source)
    {
        ExceptionModel value = new ExceptionModel
        {
            Message = message,
            Code = code,
            Severity = severity,
            Source = source
        };
        return JsonConvert.SerializeObject(value);
    }
}
