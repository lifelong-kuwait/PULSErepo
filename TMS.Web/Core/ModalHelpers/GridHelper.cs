using Kendo.Mvc;
using Kendo.Mvc.UI;
using System.ComponentModel;
using System.Linq;

namespace TMS.Web
{
    public static class GridHelper
    {
        public static string GetSortExpression(DataSourceRequest Request, string DefaultID)
        {
            if (Request.Sorts.Any())
            {
                foreach (SortDescriptor sortDescriptor in Request.Sorts)
                {
                    var member = sortDescriptor.Member;
                    return sortDescriptor.SortDirection == ListSortDirection.Ascending ? member : member + " DESC";
                }
            }
            return DefaultID + " DESC";
        }
    }
}