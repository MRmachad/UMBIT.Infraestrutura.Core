using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Linq;

namespace UMBIT.MVC.Core.Conventions
{
    public class ActionConvetions : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            if(!action.Selectors.Where(m => m.AttributeRouteModel != null && m.AttributeRouteModel.Template == action.ActionName).Any())
            {
                action.Selectors.Add(new SelectorModel()
                {
                    AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(action.ActionName))
                });

                action.RouteValues.Add("RV_" + Guid.NewGuid().ToString(), action.Controller.ControllerType.Assembly.GetName().Name);
            }
        }
    }
}
