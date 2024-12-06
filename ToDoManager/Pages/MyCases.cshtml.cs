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

        //перекодировка данных в html код

        public void OnPostAddDiv()
        {
            int id = 0;
            var CasesContainer = new TagBuilder("div");
            CasesContainer.AddCssClass("CasesContainer");

            // Основной скрытый input для caseId, который будет изменяться
            var hiddenInput = new TagBuilder("input");
            hiddenInput.Attributes["type"] = "hidden";
            hiddenInput.Attributes["name"] = "caseId";
            hiddenInput.Attributes["id"] = "selectedCaseId"; // ID, чтобы идентифицировать его

            // Добавляем токен и скрытый input в форму
            CasesContainer.InnerHtml.AppendHtml(hiddenInput);

            foreach (Case @case in CasesList.Cases)
            {
                var caseDiv = new TagBuilder("div");
                // Кликабельный div для каждого case
                caseDiv.AddCssClass("clickable-div");
                caseDiv.Attributes["onclick"] = $"document.getElementById('selectedCaseId').value='{id}'; this.closest('form').submit();"; // Устанавливаем caseId и отправляем форму

                // Заголовок и описание
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

                // Вкладываем заголовок и описание в кликабельный div
                caseDiv.InnerHtml.AppendHtml(title);
                caseDiv.InnerHtml.AppendHtml(desc);
                caseDiv.InnerHtml.AppendHtml(tags);
                //
                CasesContainer.InnerHtml.AppendHtml(caseDiv);
                id++;
            }

            // Преобразуем TagBuilder в строку HTML и добавляем его в список
            using (var writer = new System.IO.StringWriter())
            {
                CasesContainer.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                CaseDivs.Add(writer.ToString());
            }
        }
        public IActionResult OnPostStatusClicked(int caseId)
        {
            CasesList.currentCase = caseId;

            return RedirectToPage("EditCase"); // Перенаправляем на текущую страницу
        }
    }
}
