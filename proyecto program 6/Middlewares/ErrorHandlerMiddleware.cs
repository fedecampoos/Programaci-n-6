﻿using Microsoft.AspNetCore.Http;
using Progracion6_DesarrolloDeContenidos.Extensions;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Progracion6_DesarrolloDeContenidos.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };

                switch (error)
                {
                    case ApiException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;


                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);

            }
        }
    }
}
