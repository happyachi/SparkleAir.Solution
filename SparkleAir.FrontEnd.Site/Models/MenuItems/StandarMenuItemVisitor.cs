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

<li><a href=""{url}""><i class=""material-icons-outlined"">arrow_right</i>{menuItem.Name}</a>
              </li>
                ");

            //< ul class=""mm-collapse mm-show"" style="""">
            //  <li class=""mm-active""><a class=""has-arrow"" href=""javascript:;"" aria-expanded=""true""><i class=""material-icons-outlined"">arrow_right</i> Level
            //      One</a>
            //    <ul class=""mm-collapse mm-show"" style="""">
            //      <li class=""mm-active""><a class=""has-arrow"" href=""javascript:;"" aria-expanded=""true""><i class=""material-icons-outlined"">arrow_right</i> Level
            //          Two</a>
            //        <ul class=""mm-collapse mm-show"" style="""">
            //          <li><a href = ""javascript:;""><i class=""material-icons-outlined"">arrow_right</i> Level Three</a>
            //          </li>
            //        </ul>
            //      </li>
            //    </ul>
            //  </li>
            //</ul>
        }

        public void Visit(TopLevelMenuComponent topLevelMenuComponent)
        {
            string template = @"
<ul>
<li class=""mm-active"">
            <a class=""has-arrow"" href=""javascript:;"" aria-expanded=""true"">
              <div class=""parent-icon""><i class=""material-icons-outlined"">{0}</i>
              </div>
              <div class=""menu-title"">{1}</div>
            </a>

                   



                ";

            sb.AppendFormat(template, topLevelMenuComponent.Name, topLevelMenuComponent.Icon);

            if(topLevelMenuComponent.MenuItems != null)
            {
                foreach (var menuItem in topLevelMenuComponent.MenuItems)
                {
                    ((IElement)menuItem).Accept(this);
                }
            }

            sb.AppendLine("</li></ul>");
        }
    }
}