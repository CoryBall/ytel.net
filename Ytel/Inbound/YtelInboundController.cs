using Microsoft.AspNetCore.Mvc;

namespace Ytel.Inbound;

public class YtelInboundController: ControllerBase
{
    protected YtelInboundResponse YtelResponse (InboundXml response)
    {
        return new YtelInboundResponse(response);
    }

}