using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages.AdminSection
{
    public class OrderAdminPageModel : PageModel
    {
        private OrderCatalog _orderCatalog;
        
        
        public Dictionary<int, Order> Orders { get; set; }

        public OrderAdminPageModel(OrderCatalog repoOrderCatalog)
        {
            _orderCatalog = repoOrderCatalog;

        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("SessionType") != "adminSession")
            {
                return Redirect("/Unauthorized");
            }
            Orders = _orderCatalog.GetAllOrders();
            return Page();
        }
    }
}
