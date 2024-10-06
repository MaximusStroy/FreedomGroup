using Blazored.Toast.Services;
using Freedom.BusinessLogic;
using Freedom.Model.Entities;
using Freedom.Model.Models;
using Microsoft.AspNetCore.Components;

namespace Freedom.Web.Components.Pages
{
    public partial class ContactUs
    {
        public Questions Model { get; set; } = new();

        [Inject]
        private ApiClient ApiClient { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        public async Task Submit()
        {
            var res = await ApiClient.PostAsync<BaseResponseModel, Questions>("/api/Question", Model);
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Вопрос успешно создан");
                NavigationManager.NavigateTo("/");
            }
            Model = new();
        }
    }
}
