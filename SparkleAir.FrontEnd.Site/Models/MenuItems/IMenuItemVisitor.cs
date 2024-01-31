using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.FrontEnd.Site.Models.MenuItems
{
    public interface IMenuItemVisitor
    {
        void Visit(MenuItem menuItem);

        void Visit(TopLevelMenuComponent topLevelMenuComponent);


        string GetHtml();
    }
}
