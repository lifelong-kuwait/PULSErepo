using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lr = Resources.Resources;
namespace TMS.Web.Custom
{
    public class CustomModelBinder<T> : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value != null && !String.IsNullOrEmpty(value.AttemptedValue))
            {
                T temp = default(T);
                try
                {
                    temp = (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(value.AttemptedValue);
                }
                catch
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName,lr.FieldMustBeNumeric);
                    bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);
                }

                return temp;
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
}