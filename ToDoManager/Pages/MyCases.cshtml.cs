using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoManager.Classes;

namespace ToDoManager.Pages
{
    public class MyCasesModel : PageModel
    {
        private readonly ILogger<MyCasesModel> _logger;
        public MyCasesModel(ILogger<MyCasesModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            OnPostAddDiv();
        }
        /////////////////////////////////////////////////////////
        public List<string> CaseDivs { get; set; } = new List<string>();

        //������������� ������ � html ���

        public void OnPostAddDiv()
        {
            int id = 0;
            var CasesContainer = new TagBuilder("div");
            CasesContainer.AddCssClass("CasesContainer");

            // �������� ������� input ��� caseId, ������� ����� ����������
            var hiddenInput = new TagBuilder("input");
            hiddenInput.Attributes["type"] = "hidden";
            hiddenInput.Attributes["name"] = "caseId";
            hiddenInput.Attributes["id"] = "selectedCaseId"; // ID, ����� ���������������� ���

            // ��������� ����� � ������� input � �����
            CasesContainer.InnerHtml.AppendHtml(hiddenInput);

            foreach (Case @case in CasesList.Cases)
            {
                var caseDiv = new TagBuilder("div");
                // ������������ div ��� ������� case
                caseDiv.AddCssClass("clickable-div");
                caseDiv.Attributes["onclick"] = $"document.getElementById('selectedCaseId').value='{id}'; this.closest('form').submit();"; // ������������� caseId � ���������� �����

                // ��������� � ��������
                var title = new TagBuilder("h1");
                title.AddCssClass("case_title");
                title.InnerHtml.Append(@case.getName());

                var desc = new TagBuilder("h4");
                desc.AddCssClass("case_desc");
                desc.InnerHtml.Append(@case.getDesc());
                //*****************************Test Tags**********************************
                var tags = new TagBuilder("h4");
                tags.AddCssClass("case_desc");
                tags.Attributes["style"] = "color:" + @case.getTags().Color;
                tags.InnerHtml.Append(@case.getTags().Name);

                // ���������� ��������� � �������� � ������������ div
                caseDiv.InnerHtml.AppendHtml(title);
                caseDiv.InnerHtml.AppendHtml(desc);
                caseDiv.InnerHtml.AppendHtml(tags);
                //
                CasesContainer.InnerHtml.AppendHtml(caseDiv);
                id++;
            }

            // ����������� TagBuilder � ������ HTML � ��������� ��� � ������
            using (var writer = new System.IO.StringWriter())
            {
                CasesContainer.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                CaseDivs.Add(writer.ToString());
            }
        }
        public IActionResult OnPostStatusClicked(int caseId)
        {
            CasesList.currentCase = caseId;

            return RedirectToPage("EditCase"); // �������������� �� ������� ��������
        }
    }
}
