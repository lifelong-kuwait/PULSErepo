// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-22-2017
// ***********************************************************************
// <copyright file="RequiredIfValidator.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Web.Mvc;

namespace TMS.Library
{
    /// <summary>
    /// Class RequiredIfValidator.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.DataAnnotationsModelValidator{TMS.Library.RequiredIfAttribute}" />
    public class RequiredIfValidator : DataAnnotationsModelValidator<RequiredIfAttribute>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredIfValidator"/> class.
        /// </summary>
        /// <param name="metadata">The metadata for the model.</param>
        /// <param name="context">The controller context for the model.</param>
        /// <param name="attribute">The validation attribute for the model.</param>
        public RequiredIfValidator(ModelMetadata metadata, ControllerContext context, RequiredIfAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        /// <summary>
        /// Retrieves a collection of client validation rules.
        /// </summary>
        /// <returns>A collection of client validation rules.</returns>
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            // no client validation - I might well blog about this soon!
            return base.GetClientValidationRules();
        }

        /// <summary>
        /// Returns a list of validation error messages for the model.
        /// </summary>
        /// <param name="container">The container for the model.</param>
        /// <returns>A list of validation error messages for the model, or an empty list if no errors have occurred.</returns>
        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            // get a reference to the property this validation depends upon
            var field = Metadata.ContainerType.GetProperty(Attribute.DependentProperty);

            if (field != null)
            {
                // get the value of the dependent property
                var value = field.GetValue(container, null);

                // compare the value against the target value
                if ((value == null && Attribute.TargetValue == null) ||
                    (value.Equals(Attribute.TargetValue)))
                {
                    // match => means we should try validating this field
                    if (!Attribute.IsValid(Metadata.Model))
                        // validation failed - return an error
                        yield return new ModelValidationResult { Message = ErrorMessage };
                }
            }
        }
    }
}