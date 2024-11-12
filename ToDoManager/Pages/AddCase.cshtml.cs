using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoManager.Classes;

namespace ToDoManager.Pages
{
    public class AddCaseModel : PageModel
    {
        public void OnGet()
        {
        }
        private readonly ILogger<PrivacyModel> _logger;
        public Case c = new Case();
        public AddCaseModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPostCreateCase(string name, string desc, string status)
        {
            c = new Case(name, desc, status);
            CasesList.Cases.Add(c);
            return RedirectToPage("MyCases");
        }
    }
}
