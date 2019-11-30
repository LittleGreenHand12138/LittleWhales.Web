using LittleWhales.Core;
using LittleWhales.Core.Attributes;
using LittleWhales.Core.Extends;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LittleWhales.BasicInfoManage.Web
{
    /// <summary>
    /// BaseController
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = false)]
    [Area("BasicInfoManage")]
    [Route("api/[area]/[controller]")]
    [EnableCors("AllowAny")]
    //[CheckLogin()]
    [ApiController]
    public class HtjwController : ControllerBase
    {
        public string userId { set; get; } = IOCManage.Resolve<HttpHeadersExtend>().GetUserId();
    }
}
