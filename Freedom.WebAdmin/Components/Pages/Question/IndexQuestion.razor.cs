using Freedom.Model.Entities;
using Freedom.Model.Models;
using Freedom.Web;
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

        protected override async Task OnInitializedAsync()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/question");
            if (res != null && res.Success)
            {
                this.Questions = JsonConvert.DeserializeObject<List<Questions>>(res.Data.ToString());
            }
            await base.OnInitializedAsync();
        }
    }
}
