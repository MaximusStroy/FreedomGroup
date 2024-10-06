using Blazored.Toast.Services;
using Freedom.BusinessLogic;
using Freedom.Model.Entities;
using Freedom.Model.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Freedom.WebAdmin.Components.Pages.Question
{
    public partial class UpdateQuestion: ComponentBase
    {
        [Parameter]
        public Guid id { get; set; }
        public Questions Model { get; set; } = new();

        [Inject]
        private ApiClient ApiClient { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"/api/question/{id}");
            if (res != null &&  res.Success)
            {
                Model = JsonConvert.DeserializeObject<Questions>(res.Data.ToString());
            }
        }

        public async Task Submit()
        {
            var res = await ApiClient.PutAsync<BaseResponseModel, Questions>($"/api/question/{id}", Model);
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Вопрос успешно обновлен.");
                NavigationManager.NavigateTo("/question");
            }
        }
    }
}
