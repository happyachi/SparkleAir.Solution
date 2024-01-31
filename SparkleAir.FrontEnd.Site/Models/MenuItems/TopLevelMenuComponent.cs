using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkleAir.FrontEnd.Site.Models.MenuItems
{
    public class TopLevelMenuComponent : IMenuItem, IElement
    {
        public string Icon { get; set; }
        public string Name { get ; set ; }

        public void Accept(IMenuItemVisitor visitor)
        {
            visitor.Visit(this);
        }

        public List<IMenuItem> MenuItems { get; set; }
    }
}