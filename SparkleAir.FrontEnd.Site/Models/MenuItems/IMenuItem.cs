using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkleAir.FrontEnd.Site.Models.MenuItems
{
    public interface IMenuItem
    {
        string Name { get; set; }
    }
    public interface IElement
    {
        void Accept(IMenuItemVisitor vistor);
    }
}
