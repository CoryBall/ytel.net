using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ytel.Inbound;

public class YtelInboundResponse : IActionResult
{
    private string? Data { get;  set; }
    
    public YtelInboundResponse ()
    {
    }

    public YtelInboundResponse (string inboundXml)
    {
        Data = inboundXml;
    }

    public YtelInboundResponse (InboundXml? response)
    {
        if (response != null) {
            Data = response.ToString();
        }
    }
    
    public async Task ExecuteResultAsync(ActionContext context)
    {
        var response = context.HttpContext.Response;
        response.ContentType = "application/xml";
        Data ??= "<Response></Response>";
        await response.WriteAsync(Data);
    }
}