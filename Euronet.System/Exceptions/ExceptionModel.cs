using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

namespace Euronet.Exceptions
{
[DataContract(Name = "exception-model")]
public class ExceptionModel
{
    [DataMember(Name = "code")]
    public int Code { get; set; }

    [DataMember(Name = "message")]
    public string Message { get; set; }

    [DataMember(Name = "severity")]
    public Severity Severity { get; set; }

    [DataMember(Name = "source")]
    public string Source { get; set; }

    [DataMember(Name = "exceptions")]
    public IEnumerable<ExceptionModel> InnerExceptionModels { get; set; }

    public ExceptionModel()
    {
    }

    public ExceptionModel(string message)
        : this(400, message, Severity.Error)
    {
    }

    public ExceptionModel(string message, Severity severity)
        : this(400, message, severity)
    {
    }

    public ExceptionModel(int code, Severity severity)
        : this(code, string.Empty, severity)
    {
    }

    public ExceptionModel(int code, string message)
        : this(code, message, Severity.Error)
    {
    }

    public ExceptionModel(int code, string message, Severity severity)
    {
        Code = code;
        Message = message;
        Severity = severity;
    }

    public static ExceptionModel Create(ModelStateDictionary modelStates)
    {
        if (modelStates == null)
        {
            return null;
        }

        List<ExceptionModel> list = new List<ExceptionModel>();
        foreach (string key in modelStates.Keys)
        {
            list.AddRange(Create(modelStates[key].Errors, key));
        }

        if (list == null || list.Count == 0)
        {
            return null;
        }

        if (list.Count == 1)
        {
            return list.FirstOrDefault();
        }

        ExceptionModel exceptionModel = new ExceptionModel();
        exceptionModel.Code = 400;
        exceptionModel.Severity = Severity.Error;
        exceptionModel.Message = "There are multiple errors. See inner exceptions for additional details.";
        exceptionModel.InnerExceptionModels = list;
        return exceptionModel;
    }

    private static List<ExceptionModel> Create(ModelErrorCollection errors, string key)
    {
        List<ExceptionModel> list = new List<ExceptionModel>();
        foreach (ModelError error in errors)
        {
            list.Add(Create(error, key));
        }

        return list;
    }

    private static ExceptionModel Create(ModelError modelError, string source)
    {
        if (modelError == null)
        {
            return null;
        }

        string text = modelError.ErrorMessage ?? ((modelError.Exception != null) ? modelError.Exception.Message : null);
        if (text.IsNullOrEmpty())
        {
            return null;
        }

        try
        {
            return JsonConvert.DeserializeObject<ExceptionModel>(text);
        }
        catch
        {
        }

        return new ExceptionModel
        {
            Code = 400,
            Message = text,
            Severity = Severity.Error,
            Source = source
        };
    }
}
}
