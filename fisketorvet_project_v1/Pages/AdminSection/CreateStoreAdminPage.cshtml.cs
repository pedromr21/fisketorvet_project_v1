using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fisketorvet_project_v1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fisketorvet_project_v1.Pages.AdminSection
{
    public class CreateStoreAdminPageModel : PageModel
    {
        [BindProperty]
        public Store Store { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(Store.Id ==)
            return Redirect("StoreAdminPage");
        }
    }
}
