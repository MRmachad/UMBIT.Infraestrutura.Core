using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Linq;

namespace UMBIT.MVC.Core.Conventions
{
    public class ControllerConventions : IControllerModelConvention
    {
        private string Area;
        private string BaseNameSpace;
        public ControllerConventions(string area, string baseNameSpace)
        {
            this.Area = area;
            this.BaseNameSpace = baseNameSpace;
        }
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.Assembly.GetName().Name == this.BaseNameSpace)
            {
                var rota = this.Area + "/[controller]";

                if (!(controller.Selectors.Where(m => m.AttributeRouteModel != null && m.AttributeRouteModel.Template == rota).Any()))
                    controller.Selectors.Add(new SelectorModel()
                    {
                        AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(rota))
                    });
            }

        }
    }

}
