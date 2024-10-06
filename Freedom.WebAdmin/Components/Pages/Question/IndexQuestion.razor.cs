using Blazored.Toast.Services;
using Freedom.BusinessLogic;
using Freedom.Model.Entities;
using Freedom.Model.Models;
using Freedom.WebAdmin.BaseComponents;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Freedom.WebAdmin.Components.Pages.Question
{
    public partial class IndexQuestion
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<Questions> Questions { get; set; } = null;
        public Guid DeleteID { get; set; }
        public AppModal Modal { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            
            await base.OnInitializedAsync();
            await LoadQuestions();
        }

        protected async Task LoadQuestions()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/question");
            if (res != null && res.Success)
            {
                this.Questions = JsonConvert.DeserializeObject<List<Questions>>(res.Data.ToString());
            }
        }

        protected async Task HandleDelete()
        {
            var res = await ApiClient.DeleteAsync<BaseResponseModel>($"/api/question/{DeleteID}");
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Продукт успешно удален");
                await LoadQuestions();
                Modal.Close();
            }
        }
    }
}
