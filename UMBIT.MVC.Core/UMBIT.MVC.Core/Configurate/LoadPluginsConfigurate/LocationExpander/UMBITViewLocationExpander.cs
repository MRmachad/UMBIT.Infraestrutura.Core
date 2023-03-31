using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;

namespace UMBIT.MVC.Core.Configurate.LocationExpander
{
    public class UMBITViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            var routeValue = context.ActionContext.RouteData.Values
                                    .Where(m => m.Key.Contains("RV_"));

            string text = routeValue.Any() ?
                          routeValue.Single().Value.ToString() :
                          null;

            if (!string.IsNullOrWhiteSpace(text))
            {
                string[] first = new string[2]
                {
                    "/" + text + "/Views/{1}/{0}.cshtml",
                    "/" + text + "/Views/Shared/{0}.cshtml"
                };
                viewLocations = first.Concat(viewLocations);
            }

            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            var routeValue = context.ActionContext.RouteData.Values
                        .Where(m => m.Key.Contains("RV_"));

            string text = routeValue.Any() ?
                          routeValue.Single().Value.ToString() :
                          null;

            if (!string.IsNullOrEmpty(text))
            {
                context.Values.Add(routeValue.Single().Key, text);
            }
        }
    }
}