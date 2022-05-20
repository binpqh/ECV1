using EC.V1.Defined;
using Microsoft.AspNetCore.Mvc;

namespace EC.V1.Types;

public interface IStumpResponse
{
    string GetSignature(string key);
}

public static class Responses
{
    public static StatusResponse Error(EnumResponses code, string desc)
    {
        return new StatusResponse
        {
            Code = code,
            Desc = desc
        };
    }

    public static StatusResponse Success(string desc)
    {
        return new StatusResponse
        {
            Code = EnumResponses.Success,
            Desc = desc
        };
    }
}

public class StatusResponse
{
    public EnumResponses Code { get; set; }
    public string? Desc { get; set; }
}

public class BadRequestResponse : StatusResponse
{
    public Dictionary<string, string[]> Errors { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public BadRequestResponse(ActionContext context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        this.Code = EnumResponses.BadRequest;
        this.Desc = "Sai dữ liệu đầu vào";
        this.getErrors(context);
    }

    private void getErrors(ActionContext context)
    {
        this.Errors = new Dictionary<string, string[]>();

        foreach (var keyModelStatePair in context.ModelState)
        {
            string prop = keyModelStatePair.Key;
            var errors = keyModelStatePair.Value.Errors;
            if (errors != null && errors.Count > 0)
            {
                if (errors.Count == 1)
                {
                    var errorMessage = errors[0].ErrorMessage;
                    Errors.Add(prop, new[] { errorMessage });
                }
                else
                {
                    var errorMessages = new string[errors.Count];
                    for (var i = 0; i < errors.Count; i++)
                    {
                        errorMessages[i] = errors[i].ErrorMessage;
                    }

                    Errors.Add(prop, errorMessages);
                }
            }
        }
    }
}