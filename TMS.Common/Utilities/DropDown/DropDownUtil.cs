// ***********************************************************************
// Assembly         : TMS.Common
// Author           : Almas Shabbir
// Created          : 12-22-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-23-2017
// ***********************************************************************
// <copyright file="DropDownUtil.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace TMS
{
    /// <summary>
    /// Class DropDownUtil.
    /// </summary>
    public static class DropDownUtil
    {

        public static void FillDropDown(DropDownList _ObjDdl, object _ObjDataSource, string _ObjDataTextField, string _ObjDataValueField, string _ObjDefaultText)
        {
            try
            {
                _ObjDdl.Items.Clear();
                _ObjDdl.DataSource = _ObjDataSource;
                _ObjDdl.DataTextField = _ObjDataTextField;
                _ObjDdl.DataValueField = _ObjDataValueField;
                _ObjDdl.DataBind();
                if (_ObjDefaultText != "")
                    _ObjDdl.Items.Insert(0, new ListItem(" Select " + _ObjDefaultText, ""));
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Fills the session time drop down.
        /// </summary>
        /// <returns>List&lt;SelectListItem&gt;.</returns>
        public static List<SelectListItem> FillSessionTimeDropDown()
        {
            List<SelectListItem> SelectListItem = new List<SelectListItem>();
            SelectListItem.Add(new SelectListItem() { Text = "07:30 AM", Value = "07:30 AM" });
            SelectListItem.Add(new SelectListItem() { Text = "08:00 AM", Value = "08:00 AM" });
            SelectListItem.Add(new SelectListItem() { Text = "08:30 AM", Value = "08:30 AM" });
            SelectListItem.Add(new SelectListItem() { Text = "09:00 AM", Value = "09:00 AM" });
            SelectListItem.Add(new SelectListItem() { Text = "09:30 AM", Value = "09:30 AM" });
            SelectListItem.Add(new SelectListItem() { Text = "10:00 AM", Value = "10:00 AM" });
            SelectListItem.Add(new SelectListItem() { Text = "10:30 AM", Value = "10:30 AM" });
            SelectListItem.Add(new SelectListItem() { Text = "11:00 AM", Value = "11:00 AM" });
            SelectListItem.Add(new SelectListItem() { Text = "11:30 AM", Value = "11:30 AM" });
            SelectListItem.Add(new SelectListItem() { Text = "12:00 PM", Value = "12:00 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "12:30 PM", Value = "12:30 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "01:00 PM", Value = "01:00 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "01:30 PM", Value = "01:30 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "02:00 PM", Value = "02:00 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "02:30 PM", Value = "02:30 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "03:00 PM", Value = "03:00 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "03:30 PM", Value = "03:30 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "04:00 PM", Value = "04:00 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "04:30 PM", Value = "04:30 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "05:00 PM", Value = "05:00 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "05:30 PM", Value = "05:30 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "06:00 PM", Value = "06:00 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "06:30 PM", Value = "06:30 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "07:00 PM", Value = "07:00 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "07:30 PM", Value = "07:30 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "08:00 PM", Value = "08:00 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "08:30 PM", Value = "08:30 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "09:00 PM", Value = "09:00 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "09:30 PM", Value = "09:30 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "10:00 PM", Value = "10:00 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "10:30 PM", Value = "10:30 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "11:00 PM", Value = "11:00 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "11:30 PM", Value = "11:30 PM" });
            SelectListItem.Add(new SelectListItem() { Text = "11:59 PM", Value = "11:59 PM" });
            return SelectListItem;
        }
    }
}