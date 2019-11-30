using LittleWhales.Core.Attributes;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Core.WebApi.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiHttpHeaderFilter : IDocumentFilter, IOperationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Parameters = operation.Parameters ?? new List<IParameter>();
            var actionAttributes = context.ApiDescription.ActionAttributes();
            var controllerAttributes = context.ApiDescription.ControllerAttributes();
            var allowAnonymous = !actionAttributes.Any(a => a.GetType() == typeof(CheckLoginAttribute))
                && !controllerAttributes.Any(a => a.GetType() == typeof(CheckLoginAttribute));
            if (!allowAnonymous)
            {
                operation.Parameters.Add(new BodyParameter
                {
                    Name = "htjw_token",
                    @In = "header",
                    Description = "access token",
                    Required = true
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
