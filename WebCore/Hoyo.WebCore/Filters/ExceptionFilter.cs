﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Hoyo.WebCore;
/// <summary>
/// 全局异常过滤器
/// </summary>
public class ExceptionFilter : ExceptionFilterAttribute
{
    public override Task OnExceptionAsync(ExceptionContext context)
    {
        context.Result = new ObjectResult(new
        {
            StatusCode = HttpStatusCode.InternalServerError,
            Msg = context.Exception.Message,
            Data = default(object)
        });
        return base.OnExceptionAsync(context);
    }
}