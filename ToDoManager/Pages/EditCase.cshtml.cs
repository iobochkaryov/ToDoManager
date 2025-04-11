using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoManager.Classes;

namespace ToDoManager.Pages
{
    public class EditCaseModel : PageModel
    {
        public Case currCase = CasesList.Cases[CasesList.currentCase];


       
        public void OnGet()
        {
        }
        public IActionResult OnPostDeleteCase(string confirmDelete)
        {
            if (confirmDelete == "yes")
            {
                CasesList.Cases.Remove(currCase);

                // ����� ��������, �������������� ������������ �� �������� � ������� (��������)
                return RedirectToPage("/MyCases");
            }

            // ���� ������������ ����� "���", ��������� ��������� ���� � �������� �� ������� ��������
            return Page();
        }
        public IActionResult OnPostEditCase(string name, string desc, string status, string tag, string tagColor)
        {
            Tag tag1 = new Tag(tag, tagColor);
            CasesList.Cases[CasesList.currentCase] = new Case(name, desc, status, new TagsList(tag1));
            return RedirectToPage("MyCases");
        }
    }
}

