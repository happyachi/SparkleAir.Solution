using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkleAir.FrontEnd.Site.Models.MenuItems
{
    public class MenuItem : IMenuItem, IElement
    {
        public string Name { get; set ; }

        public void Accept(IMenuItemVisitor vistor)
        {
            vistor.Visit(this);
        }

        public string ActionName { get; set; }
        public string ControllerName { get; set; }
    }
}