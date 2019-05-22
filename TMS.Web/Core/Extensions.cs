using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TMS
{
    public static class Extensions
    {
        private static readonly SelectListItem[] SingleEmptyItem = new[] { new SelectListItem { Text = string.Empty, Value = string.Empty } };

        //#region Properties
        //public int Value {
        //    get { return _value; }
        //    set { _value=Value; }
        //}
        //public string Name { get; set; }
        //public string displayName { get; set; }
        //#endregion

        /// <summary>
        /// Default constructore, used to populate the field members from start
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        //public Extensions(int value,string name,string displayName)
        //{
        //    _value = value;
        //    _name = name;
        //    _displayName = displayName;
        //}

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
        {
            return htmlHelper.EnumDropDownListFor(expression, null);
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var enumType = GetNonNullableModelType(metadata);
            var values = Enum.GetValues(enumType).Cast<TEnum>();

            var items =
                values.Select(value => new SelectListItem
                {
                    Text = GetName(value),
                    Value = value.ToString()
                    //Selected = value.Equals(metadata.Model)
                }).Where(x => x.Value != "Not_Specified");

            if (metadata.IsNullableValueType)
            {
                items = SingleEmptyItem.Concat(items);
            }

            return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
        }

        private static string GetName<TEnum>(TEnum value)
        {
            var displayAttribute = GetDisplayAttribute(value);

            return displayAttribute == null ? value.ToString() : displayAttribute.GetName();
        }

        private static DisplayAttribute GetDisplayAttribute<TEnum>(TEnum value)
        {
            return value.GetType()
                        .GetField(value.ToString())
                        .GetCustomAttributes(typeof(DisplayAttribute), false)
                        .Cast<DisplayAttribute>()
                        .FirstOrDefault();
        }

        private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
        {
            var realModelType = modelMetadata.ModelType;
            var underlyingType = Nullable.GetUnderlyingType(realModelType);

            return underlyingType ?? realModelType;
        }

        public static List<DDlList> EnumToSelectList<TEnum>(Type enumType)
        {
            
            var values = Enum.GetValues(enumType).Cast<TEnum>();
            var items =
                values.Select(value => new DDlList
                {
                    Text = GetName(value),
                    Value = Convert.ToInt32(value),

                }).Where(c => c.Value != 0);
            return items.ToList();
        }
        public static string GetDisplayName(this Enum value)
        {
            var type = value.GetType();
            if (!type.IsEnum) throw new ArgumentException(String.Format("Type '{0}' is not Enum", type));

            var members = type.GetMember(value.ToString());
            if (members.Length == 0) throw new ArgumentException(String.Format("Member '{0}' not found in type '{1}'", value, type.Name));

            var member = members[0];
            var attributes = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes.Length == 0) throw new ArgumentException(String.Format("'{0}.{1}' doesn't have DisplayAttribute", type.Name, value));

            var attribute = (DisplayAttribute)attributes[0];
            return attribute.GetName();
        }
         
        public class EnumValueCollection : List<EnumValue>
        {

        }

        public static EnumValueCollection GetEnumCollection(Type EnumType)
        {
            FieldInfo[] fieldinfo = EnumType.GetFields();
            EnumValueCollection enumValueCollection = new EnumValueCollection();
            string description = null;

            foreach(FieldInfo field in fieldinfo)
            {
                if (field.IsSpecialName)
                {
                    continue;
                }
                DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                description = (attributes.Length > 0) ? attributes[0].Description : field.GetValue(null).ToString();
                enumValueCollection.Add(new EnumValue(Convert.ToInt32(field.GetValue(null)), field.GetValue(null).ToString(), description));

            }
            return enumValueCollection;
        }

    }

    public class EnumValue
    {
        private int _value;
        private string _name;
        private string _displayName;

        public EnumValue(int value,string name,string displayName)
        {
            _value = value;
            _name = name;
            _displayName = displayName;
        }

        #region properties

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = Name; }
        }
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = DisplayName; }
        }
        #endregion
    }
}