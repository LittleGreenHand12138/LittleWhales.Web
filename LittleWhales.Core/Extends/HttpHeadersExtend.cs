/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：HttpHeadersExtend.cs
// 功能描述：获取请求头数据
// 
// 创建标识：Wuyuchi 2019/11/12 11:35:17
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using LittleWhales.Core.Jwt;
using Microsoft.AspNetCore.Http;

namespace LittleWhales.Core.Extends
{
    public class HttpHeadersExtend
    {
        private IHttpContextAccessor accessor;

        // public string token { get; set; }

        public HttpHeadersExtend(IHttpContextAccessor _accessor)
        {
            accessor = _accessor;
        }

        public string GetUserId()
        {
            var dic = accessor.HttpContext.Request.Headers;
            if (dic.ContainsKey("htjw_token"))
            {
                string token = dic["htjw_token"];
                TokenModelJwt tokenModel = JwtHelper.SerializeJwt(token);
                return tokenModel.Uid;
            }
            return string.Empty;
        }

    }
}
