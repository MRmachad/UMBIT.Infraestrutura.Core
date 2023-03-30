using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Linq;

namespace UMBIT.MVC.Core.Conventions
{
    public class ControllerConventions : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var rota = controller.ControllerType.Assembly.GetName().Name.Replace('.', '-').ToString() + "/[controller]";

            if (!(controller.Selectors.Where(m => m.AttributeRouteModel != null && m.AttributeRouteModel.Template == rota).Any() ))
                controller.Selectors.Add(new SelectorModel() {
                    AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(rota))
                });
        }
    }

}
