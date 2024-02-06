using SparkleAir.FrontEnd.Site.Controllers.AirFlight;
using SparkleAir.FrontEnd.Site.Controllers.Airtype_Owns;
using SparkleAir.FrontEnd.Site.Models.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkleAir.FrontEnd.Site.Controllers
{
    public class BaseController : Controller
    {

        public BaseController()
        {
            var menuItems = GetMenuItems();
            IMenuItemVisitor visitor = new StandarMenuItemVisitor();

            foreach (IElement menuItem in menuItems)
            {
                menuItem.Accept(visitor);
            }

            ViewBag.MenuItems = visitor.GetHtml();
        }


        public List<IMenuItem> GetMenuItems()
        {
            var menuItems = new List<IMenuItem>();
            menuItems.Add(new TopLevelMenuComponent
            {
                Name = "飛機",
                Icon = "<i class=\"fa-solid fa-plane\"></i>",
                MenuItems = new List<IMenuItem>
                {
                    new MenuItem
                    {
                        Name = "機場管理",
                        ActionName = "Index",
                        ControllerName = "Airports",
                    },
                    new MenuItem
                    {
                        Name = "飛機設置",
                        ActionName = "Index",
                        ControllerName = "Planes",
                    },
                    new MenuItem
                    {
                        Name = "航班管理",
                        ActionName = "Index",
                        ControllerName = "AirFlightsManagement",
                    },
                    new MenuItem
                    {
                        Name = "班次管理",
                        ActionName = "Index",
                        ControllerName = "AirFlights",
                    },
                     new MenuItem
                    {
                        Name = "機隊管理",
                        ActionName = "Index",
                        ControllerName = "Owns",
                    }
                }
            });
            //menuItems.Add(new TopLevelMenuComponent
            //{
            //    Name = "票務",
            //    Icon = "<i class=\"fa-solid fa-ticket\"></i>",
            //    MenuItems = new List<IMenuItem>
            //    {
            //        new MenuItem
            //        {
            //            Name = "無",
            //            ActionName = "",
            //            ControllerName = "",
            //        }
            //    }
            //});
            menuItems.Add(new TopLevelMenuComponent
            {
                Name = "加值服務",
                Icon = "<i class=\"fa-solid fa-book\"></i>",
                MenuItems = new List<IMenuItem>
                {
                    new MenuItem
                    {
                        Name = "託運管理",
                        ActionName = "Index",
                        ControllerName = "Luggage",
                    },
                    new MenuItem
                    {
                        Name = "託運明細清單",
                        ActionName = "Index",
                        ControllerName = "LuggageOrders",
                    },
                    new MenuItem
                    {
                        Name = "里程管理",
                        ActionName = "Index",
                        ControllerName = "MileageDetail",
                    },
                     new MenuItem
                    {
                        Name = "飛機餐",
                        ActionName = "Index",
                        ControllerName = "AirMeals",
                    }
                }
            });
            menuItems.Add(new TopLevelMenuComponent
            {
                Name = "免稅品管理",
                Icon = "<i class=\"fa-solid fa-gift\"></i>",
                MenuItems = new List<IMenuItem>
                {
                    new MenuItem
                    {
                        Name = "品項設定",
                        ActionName = "Index",
                        ControllerName = "TFItem",
                    },
                    
                    //new MenuItem
                    //{
                    //    Name = "免稅品預訂單檢視",
                    //    ActionName = "Index",
                    //    ControllerName = "TFReserve",
                    //},
                    //new MenuItem
                    //{
                    //    Name = "免稅品預訂管理",
                    //    ActionName = "Index",
                    //    ControllerName = "TFReservelist",
                    //},
                    new MenuItem
                    {
                        Name = "備貨量檢視",
                        ActionName = "Index",
                        ControllerName = "TFOrderlist",
                    },
                    new MenuItem
                    {
                        Name = "願望清單檢視",
                        ActionName = "Index",
                        ControllerName = "TFWishlist",
                    }
                }
            });

            menuItems.Add(new TopLevelMenuComponent
            {
                Name = "行銷",
                Icon = "<i class=\"fa-solid fa-tags\"></i>",
                MenuItems = new List<IMenuItem>
                {
                    new MenuItem
                    {
                        Name = "優惠券",
                        ActionName = "Index",
                        ControllerName = "CampaignsCoupon",

                    },
                    new MenuItem
                    {
                        Name = "折扣促銷",
                        ActionName = "Index",
                        ControllerName = "CampaignsDiscount",
                    }
                }
            });



            //menuItems.Add(new TopLevelMenuComponent
            //{
            //    Name = "金流",
            //    Icon = "<i class=\"fa-solid fa-money-bill-wave\"></i>",
            //    MenuItems = new List<IMenuItem>
            //    {
            //        new MenuItem
            //        {
            //            Name = "無",
            //            ActionName = "",
            //            ControllerName = "",
            //        }
            //    }
            //});
            //menuItems.Add(new TopLevelMenuComponent
            //{
            //    Name = "客服",
            //    Icon = "<i class=\"fa-solid fa-comment\"></i>",
            //    MenuItems = new List<IMenuItem>
            //    {
            //        new MenuItem
            //        {
            //            Name = "無",
            //            ActionName = "",
            //            ControllerName = "",
            //        }
            //    }
            //});
            menuItems.Add(new TopLevelMenuComponent
            {
                Name = "會員管理",
                Icon = "<i class=\"fa-solid fa-user\"></i>",
                MenuItems = new List<IMenuItem>
                {
                    new MenuItem
                    {
                        Name = "國籍設定",
                        ActionName = "Index",
                        ControllerName = "Countries",
                    },
                    new MenuItem
                    {
                        Name = "會員等級設定",
                        ActionName = "Index",
                        ControllerName = "MemberClasses",
                    },
                    new MenuItem
                    {
                        Name = "會員設定",
                        ActionName = "Index",
                        ControllerName = "Members",
                    },
                    //new MenuItem
                    //{
                    //    Name = "會員登入紀錄",
                    //    ActionName = "Index",
                    //    ControllerName = "MemberLoginLogs",
                    //}
                }
            });
            menuItems.Add(new TopLevelMenuComponent
            {
                Name = "員工管理",
                Icon = "<i class=\"fa-solid fa-chalkboard-user\"></i>",
                MenuItems = new List<IMenuItem>
                {
                    new MenuItem
                    {
                        Name = "部門設定",
                        ActionName = "Index",
                        ControllerName = "CompanyDepartments",
                    },
                    new MenuItem
                    {
                        Name = "職位設定",
                        ActionName = "Index",
                        ControllerName = "CompanyJobs",
                    },
                    new MenuItem
                    {
                        Name = "職員設定",
                        ActionName = "Index",
                        ControllerName = "CompanyStaffs",
                    },
                    //new MenuItem
                    //{
                    //    Name = "職員登入紀錄",
                    //    ActionName = "Index",
                    //    ControllerName = "CompanyStaffLoginLogs",
                    //},
                    //new MenuItem
                    //{
                    //    Name = "職員更換密碼紀錄",
                    //    ActionName = "Index",
                    //    ControllerName = "CompanyStaffsChangePasswordLogs",
                    //},
                }
            });
            menuItems.Add(new TopLevelMenuComponent
            {
                Name = "權限管理",
                Icon = "<i class=\"fa-solid fa-user\"></i>",
                MenuItems = new List<IMenuItem>
                {
                    new MenuItem
                    {
                        Name = "頁面設定",
                        ActionName = "Index",
                        ControllerName = "PermissionPageInfos",
                    },
                    new MenuItem
                    {
                        Name = "群組設定",
                        ActionName = "Index",
                        ControllerName = "PermissionGroups",
                    },
                    new MenuItem
                    {
                        Name = "頁面權限設定",
                        ActionName = "Index",
                        ControllerName = "PermissionSettings",
                    },
                    new MenuItem
                    {
                        Name = "群組權限設定",
                        ActionName = "Index",
                        ControllerName = "PermissionGroupsAddStaffs",
                    },
                }
            });

            return menuItems;

        }
    }
}