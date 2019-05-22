// ***********************************************************************
// Assembly : TMS.Library
// Author : Almas Shabbir
// Created : 12-17-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="GreaterDate.cs" company="LifeLong www.lifelongkuwait.com">
// Copyright © 2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TMS.Library.Core.Validation.Kendo
{
    /// <summary>
    /// Class GreaterDateAttribute.
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    /// <seealso cref="System.Web.Mvc.IClientValidatable" />
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class GreaterDateAttribute : ValidationAttribute, IClientValidatable
    {
        /// <summary>
        /// Gets or sets the earlier date field.
        /// </summary>
        /// <value>The earlier date field.</value>
        public string EarlierDateField { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime? date = value != null ? (DateTime?)value : null;
            var earlierDateValue = validationContext.ObjectType.GetProperty(EarlierDateField)
            .GetValue(validationContext.ObjectInstance, null);
            DateTime? earlierDate = earlierDateValue != null ? (DateTime?)earlierDateValue : null;

            if (date.HasValue && earlierDate.HasValue && date <= earlierDate)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }

        /// <summary>
        /// When implemented in a class, returns client validation rules for that class.
        /// </summary>
        /// <param name="metadata">The model metadata.</param>
        /// <param name="context">The controller context.</param>
        /// <returns>The client validation rules for this validator.</returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = ErrorMessage ?? ErrorMessageString,
                ValidationType = "greaterdate"
            };

            rule.ValidationParameters["earlierdate"] = EarlierDateField;

            yield return rule;
        }
    }
}