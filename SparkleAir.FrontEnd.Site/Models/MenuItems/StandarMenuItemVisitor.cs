using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SparkleAir.FrontEnd.Site.Models.MenuItems
{
    public class StandarMenuItemVisitor : IMenuItemVisitor
    {
        StringBuilder sb = new StringBuilder();

        public string GetHtml()
        {
            return sb.ToString();
        }

        public void Visit(MenuItem menuItem)
        {
            var url = $"/{menuItem.ControllerName}/{menuItem.ActionName}/";

            sb.AppendLine($@"
                <li class=""nav-item"">
                  <a class=""nav-link"" href=""{url}"">
                    <span class=""sidebar-text"">{menuItem.Name}</span>
                  </a>
                </li>");
        }

        public void Visit(TopLevelMenuComponent topLevelMenuComponent)
        {
            string template = @"<li class=""nav-item"">
            <span
              class=""nav-link collapsed d-flex justify-content-between align-items-center""
              data-bs-toggle=""collapse""
              data-bs-target=""#{0}""
            >
              <span><div style=""width:40px; display:inline-block"">
                <span class=""sidebar-icon"">
                  {1}
                </span></div>
                <span class=""sidebar-text"">{0}</span>
              </span>
              <span class=""link-arrow"">
                <svg
                  class=""icon icon-sm""
                  fill=""currentColor""
                  viewBox=""0 0 20 20""
                  xmlns=""http://www.w3.org/2000/svg""
                >
                  <path
                    fill-rule=""evenodd""
                    d=""M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z""
                    clip-rule=""evenodd""
                  ></path>
                </svg>
              </span>
            </span>
            <div
              class=""multi-level collapse""
              role=""list""
              id=""{0}""
              aria-expanded=""false""
            >
              <ul class=""flex-column nav"">
                ";

            sb.AppendFormat(template, topLevelMenuComponent.Name, topLevelMenuComponent.Icon);

            if(topLevelMenuComponent.MenuItems != null)
            {
                foreach (var menuItem in topLevelMenuComponent.MenuItems)
                {
                    ((IElement)menuItem).Accept(this);
                }
            }

            sb.AppendLine("</ul>\r\n            </div>\r\n          </li>");
        }
    }
}