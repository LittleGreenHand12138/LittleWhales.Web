using LittleWhales.Core.Jwt;
using LittleWhales.Domain.BasicInfoManage.IManagers;
using LittleWhales.Infrastructure;
using LittleWhales.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web.Http.Filters;

namespace LittleWhales.Core.Attributes
{
    /// <summary>
    /// 校验登录
    /// </summary>
    public class CheckLoginAttribute : Attribute, IActionFilter
    {
        //private readonly IBase_UserManager userManager = null;
        //public CheckLoginAttribute()
        //{
        //    userManager = IOCManage.Resolve<IBase_UserManager>();
        //}
        //protected Base_User UserInfo;
        ///// <summary>
        ///// Action执行之前执行
        ///// </summary>
        ///// <param name="filterContext">过滤器上下文</param>
        //public void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var request = filterContext.HttpContext.Request;

        //    try
        //    {

        //        //判断是否需要登录
        //        List<string> attrList = FilterHelper.GetFilterList(filterContext);
        //        bool needLogin = attrList.Contains(typeof(CheckLoginAttribute).FullName) && !attrList.Contains(typeof(IgnoreLoginAttribute).FullName);
        //        //转到登录
        //        if (needLogin)
        //        {
        //            string token = request.Headers["htjw_token"];
        //            if (!JwtHelper.Validate(token))
        //            {
        //                RedirectToLogin();
        //                return;
        //            }
        //            TokenModelJwt tokenModel = JwtHelper.SerializeJwt(token);

        //            Base_User user = userManager.GetEntry(tokenModel.Uid);
        //            if (user == null)
        //            {
        //                RedirectToLogin();
        //                return;
        //            }
        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RedirectToLogin();
        //        return;
        //    }
        //    void RedirectToLogin()
        //    {

        //        filterContext.Result = new ContentResult
        //        {
        //            Content = new MessageModel<string> { success = false, ErrorCode = 401, msg = "未登录" }.ToJson(),
        //            ContentType = "application/json;charset=UTF-8"
        //        };
        //    }

        //}

        ///// <summary>
        ///// Action执行完毕之后执行
        ///// </summary>
        ///// <param name="filterContext"></param>
        //public void OnActionExecuted(ActionExecutedContext filterContext)
        //{

        //}
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
    public class FilterHelper
    {
        public static List<string> GetFilterList(ActionExecutingContext context)
        {
            return context.Filters.Select(x => x.GetType().FullName).ToList();
        }
    }
}