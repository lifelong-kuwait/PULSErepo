// ***********************************************************************
// Assembly         : TMS.Library
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-22-2017
// ***********************************************************************
// <copyright file="RequiredIfAttribute.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;

namespace TMS.Library
{
    /// <summary>
    /// Class RequiredIfAttribute.
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    public class RequiredIfAttribute : ValidationAttribute
    { // Note: we don't inherit from RequiredAttribute as some elements of the MVC
        // framework specifically look for it and choose not to add a RequiredValidator
        // for non-nullable fields if one is found. This would be invalid if we inherited
        // from it as obviously our RequiredIf only applies if a condition is satisfied.
        // Therefore we're using a private instance of one just so we can reuse the IsValid
        // logic, and don't need to rewrite it.
        private RequiredAttribute innerAttribute = new RequiredAttribute();

        /// <summary>
        /// Gets or sets the dependent property.
        /// </summary>
        /// <value>The dependent property.</value>
        public string DependentProperty { get; set; }

        /// <summary>
        /// Gets or sets the target value.
        /// </summary>
        /// <value>The target value.</value>
        public object TargetValue { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredIfAttribute"/> class.
        /// </summary>
        /// <param name="dependentProperty">The dependent property.</param>
        /// <param name="targetValue">The target value.</param>
        public RequiredIfAttribute(string dependentProperty, object targetValue)
        {
            this.DependentProperty = dependentProperty;
            this.TargetValue = targetValue;
        }

        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            return innerAttribute.IsValid(value);
        }
    }
}