using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
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

        public IActionResult OnPostCreateCase(string name, string desc, string status, string tag, string tagcolor) //**************************** Only 1 tag, fix ***********************
        {
            TagsList tgs = new TagsList(new Tag(tag, tagcolor));
            c = new Case(name, desc, status,tgs);
            CasesList.Cases.Add(c);
            return RedirectToPage("MyCases");
        }
    }
}
