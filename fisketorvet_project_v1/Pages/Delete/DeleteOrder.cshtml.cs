using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages.Delete
{
    public class DeleteOrderModel : PageModel
    {
        private OrderCatalog _orderCatalog;

        public DeleteOrderModel(OrderCatalog repoOrderCatalog)
        {
            _orderCatalog = repoOrderCatalog;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("SessionType") != "adminSession")
            {
                return Redirect("/Unauthorized");
            }

            return Page();
        }
        public IActionResult OnPost(int id)
        {
            _orderCatalog.RemoveOrder(id);
            return Redirect("/AdminSection/OrderAdminPage");
        }
    }
}
