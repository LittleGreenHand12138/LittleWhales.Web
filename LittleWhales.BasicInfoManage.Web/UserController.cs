using LittleWhales.DB;
using LittleWhales.Domain.BasicInfoManage.Enums;
using LittleWhales.Domain.BasicInfoManage.IManagers;
using LittleWhales.Infrastructure;
using LittleWhales.Infrastructure.Enums;
using LittleWhales.Infrastructure.Models;
using LittleWhales.Infrastructure.Redis;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LittleWhales.BasicInfoManage.Web
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserController : HtjwController
    {
        #region 注入
        private ILogger<UserController> _logger = null;
        private AutoMapper.IMapper _mapper = null;
        private ICacheService _cacheService = null;
        public UserController(ILogger<UserController> logger, AutoMapper.IMapper mapper, ICacheService cacheService)
        {
            _logger = logger;
            _mapper = mapper;
            _cacheService = cacheService;
        }
        #endregion
        [HttpPost]
        [EnableCors("AllowAny")]
        public ActionResult<string> Post(string key, string value)
        {
            TimeSpan span = (DateTime.Now.AddMinutes(1) - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            _cacheService.SetCache(key, value, span);
            return "Success";
        }
        [HttpGet("{key}")]
        [EnableCors("AllowAny")]
        public ActionResult<object> Get(string key)
        {
            TimeSpan span = (DateTime.Now.AddMinutes(1) - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            var value = _cacheService.GetCache(key);
            return value;
        }
    }
}
