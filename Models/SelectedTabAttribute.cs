using System;
using System.Web.Mvc;

namespace GrandLabFixers.Models
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SelectedTabAttribute : ActionFilterAttribute
    {
        private readonly string _selectedTab;

        public SelectedTabAttribute(string selectedTab)
        {
            _selectedTab = selectedTab;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.SelectedTab = _selectedTab;
        }
    }
}